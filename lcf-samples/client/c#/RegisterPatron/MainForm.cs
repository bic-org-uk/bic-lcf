using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace RegisterPatron
{
	public partial class MainForm : Form
	{
		enum entityOperation { GET, PUT, POST, DELETE };
		static string rootURI = @"http://integration.capita-libraries.co.uk/bic-lcf/TalisSOA/protocols/lcf/1.0/";
		static string lcfUser = "lcf@GA";
		static string lcfPassword = "bic-lcf-2015";
		static int pagesize = 20;
		static int startIndex = 0;

		BindingList<patronEntity> patronEntityList = new BindingList<patronEntity>();

		public MainForm()
		{
			InitializeComponent();
			CenterToScreen();
		}

		/// <summary>
		/// Make a webservice request to the host
		/// </summary>
		/// <param name="uri">The request URI</param>
		/// <param name="entityType">The expected type of entity for the response</param>
		/// <param name="op">The request operation, i.e. GET, PUT, POST or DELETE</param>
		/// <param name="payload">The optional payload required for some requests, e.g. Create Entity</param>
		/// <returns>success, entity, uri of created entity/message</returns>
		async Task<Tuple<bool, object, string>> lcfEntityRequestAsync(string uri, Type entityType, entityOperation op, object payload = null)
		{
			var handler = new HttpClientHandler();

			if (handler.SupportsAutomaticDecompression)
			{
				handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			}

			handler.Credentials = new NetworkCredential(lcfUser, lcfPassword);

			using (var hc = new HttpClient(handler))
			{
				hc.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
				hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

				HttpResponseMessage result = null;

				if (op == entityOperation.GET)
				{
					result = await hc.GetAsync(uri).ConfigureAwait(false);
				}
				else if (op == entityOperation.DELETE)
				{
					result = await hc.DeleteAsync(uri).ConfigureAwait(false);
				}
				else if (payload != null && (op == entityOperation.POST || op == entityOperation.PUT))
				{
					XmlSerializer ser = new XmlSerializer(payload.GetType());

					string xml;
					using (var sw = new StringWriterWithEncoding(Encoding.UTF8))
					{
						using (var xw = XmlWriter.Create(sw))
						{
							ser.Serialize(xw, payload);
							xml = sw.ToString();
						}
					}

					if (op == entityOperation.POST)
					{
						result = await hc.PostAsync(uri, new StringContent(xml, new UTF8Encoding(), "application/xml"));
					}
					else
					{
						result = await hc.PutAsync(uri, new StringContent(xml, new UTF8Encoding(), "application/xml"));
					}
				}
				else
				{
					throw new Exception("Missing payload");
				}

				// for CREATE (POST), StatusCode == 201 (Created) or 207 (MultiStatus) - content
				// will contain lcfexception 
				// for DELETE, 204 (No content)
				// for UPDATE (PUT), 200
				if (!result.IsSuccessStatusCode)
				{
					return new Tuple<bool, object, string>(false, null, result.StatusCode.ToString());
				}

				// for CREATE (POST), there may be content and header should contain Location field
				// for READ (GET), there should be content
				// for UPDATE (PUT), there may be content
				// for DELETE (DELETE), there should be no content

				if (result.StatusCode == HttpStatusCode.NoContent)
				{
					return new Tuple<bool, object, string>(true, null, result.ReasonPhrase);
				}
				else
				{
					var content = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

					try
					{
						object rsp = Activator.CreateInstance(entityType);
						XmlSerializer ser = new XmlSerializer(rsp.GetType());

						/*using (FileStream fs = new FileStream(@"response.xml", FileMode.Open))
						{
							rsp = ser.Deserialize(fs);
						}*/
						using (MemoryStream ms = new MemoryStream(UTF8Encoding.UTF8.GetBytes(content)))
						{
							rsp = ser.Deserialize(ms);
						}

						string location = result.Headers.Location == null ? String.Empty : result.Headers.Location.ToString();

						return new Tuple<bool, object, string>(true, rsp, location);
					}
					catch (XmlException xe)
					{
						return new Tuple<bool, object, string>(false, null, xe.Message);
					}
				}
			}
		}

		/// <summary>
		/// Display details of a patron and contacts for creation or updating purposes
		/// </summary>
		/// <param name="identifier">The identifier - may be blank when creating a new patron</param>
		/// <param name="create">Set to true when creating a patron</param>
		/// <returns>success, message</returns>
		private async Task<Tuple<bool, string>> displayPatronDetails(string identifier, bool create = false)
		{
			string uri = rootURI + "patrons/" + identifier;
			PatronDetailsForm patronDetailsForm = new PatronDetailsForm();
			patron existingPatron = null;
			List<contact> contacts = new List<contact>();
			Tuple<bool, object, string> ret;

			if (!create || !String.IsNullOrEmpty(identifier))
			{
				// look for existing patron
				ret = await lcfEntityRequestAsync(uri, typeof(patron), entityOperation.GET);

				if (!ret.Item1 && !create)
				{
					return new Tuple<bool, string>(false, String.Format("Problem finding patron '{0}' - {1}", identifier, ret.Item3));
				}

				existingPatron = ret.Item2 as patron;

				if (existingPatron != null)
				{
					if (create)
					{
						return new Tuple<bool, string>(false, String.Format("Patron '{0}' already exists", identifier));
					}

					patronDetailsForm.PatronIdentifier = existingPatron.identifier;
					patronDetailsForm.PatronName = existingPatron.name;

					if (existingPatron.contactref != null)
					{
						foreach (string contactRef in existingPatron.contactref)
						{
							ret = await lcfEntityRequestAsync(contactRef, typeof(contact), entityOperation.GET);

							if (ret.Item1)
							{
								var contactRsp = ret.Item2 as contact;
								contacts.Add(contactRsp);
							}
						}

						contact contactMethod;
						if (null != (contactMethod = contacts.FirstOrDefault(s => s.communicationtype == communicationType.Item05))) patronDetailsForm.PatronEmail = contactMethod.locator[0];
						if (null != (contactMethod = contacts.FirstOrDefault(s => s.communicationtype == communicationType.Item02))) patronDetailsForm.PatronHomePhone = contactMethod.locator[0];
						if (null != (contactMethod = contacts.FirstOrDefault(s => s.communicationtype == communicationType.Item03))) patronDetailsForm.PatronBusinessPhone = contactMethod.locator[0];
						if (null != (contactMethod = contacts.FirstOrDefault(s => s.communicationtype == communicationType.Item04))) patronDetailsForm.PatronMobilePhone = contactMethod.locator[0];
						if (null != (contactMethod = contacts.FirstOrDefault(s => s.communicationtype == communicationType.Item01))) patronDetailsForm.PatronOtherPhone = contactMethod.locator[0];
						if (null != (contactMethod = contacts.FirstOrDefault(s => s.communicationtype == communicationType.Item06))) patronDetailsForm.PatronAddress = contactMethod.locator;
					}
				}
				else
				{
					patronDetailsForm.PatronIdentifier = identifier;
				}
			}
			else
			{
				patronDetailsForm.PatronIdentifier = String.Empty;
			}

			if (existingPatron != null || create)
			{
				patronDetailsForm.ShowDialog(this);

				if (patronDetailsForm.DialogResult == DialogResult.OK)
				{
					// update details
					if (create)
					{
						// create patron
						Tuple<bool, string> createRet = await createPatron(patronDetailsForm);

						if (createRet.Item1)
						{
							return new Tuple<bool, string>(true, createRet.Item2);
						}
						else
						{
							return new Tuple<bool, string>(false, createRet.Item2);
						}
					}
					else
					{
						// update patron
						Tuple<bool, string> updateRet = await updatePatron(patronDetailsForm, existingPatron, contacts);

						if (updateRet.Item1)
						{
							return new Tuple<bool, string>(true, updateRet.Item2);
						}
						else
						{
							return new Tuple<bool, string>(false, updateRet.Item2);
						}
					}
				}
			}

			return new Tuple<bool, string>(true, null);
		}

		/// <summary>
		/// Create a new patron entity and associated contacts
		/// </summary>
		/// <param name="patronDetailsForm">The form containing the patron and contacts details</param>
		/// <returns>success, message</returns>
		private async Task<Tuple<bool, string>> createPatron(PatronDetailsForm patronDetailsForm)
		{
			bool success = true;

			patron p = new patron();
			p.identifier = patronDetailsForm.PatronIdentifier;
			p.name = patronDetailsForm.PatronName;
			p.language = languageCode.eng;
			p.associatedlocation = new associatedlocation[1];
			p.associatedlocation[0] = new associatedlocation();
			p.associatedlocation[0].associationtype = locationAssociationType.Item03;
			p.associatedlocation[0].locationref = new string[1];
			p.associatedlocation[0].locationref[0] = "http://localhost:8080/TalisSOA-2.1.0-SNAPSHOT/protocols/lcf/1.0/locations/GA";

			Tuple<bool, object, string> ret = await lcfEntityRequestAsync(rootURI + "patrons", typeof(patron), entityOperation.POST, p);

			if (!ret.Item1)
			{
				return new Tuple<bool, string>(false, String.Format("Problem creating patron '{0}' - {1}", p.identifier, ret.Item3));
			}

			var newPatron = ret.Item2 as patron;
			var newPatronLocationUri = ret.Item3;

			// create contacts
			if (newPatronLocationUri.Length != 0 &&
				(patronDetailsForm.PatronAddress.Length != 0 ||
				patronDetailsForm.PatronBusinessPhone.Length != 0 ||
				patronDetailsForm.PatronEmail.Length != 0 ||
				patronDetailsForm.PatronHomePhone.Length != 0 ||
				patronDetailsForm.PatronMobilePhone.Length != 0))
			{

				contact c;

				if (patronDetailsForm.PatronHomePhone.Length != 0)
				{
					c = new contact();
					c.patronref = newPatronLocationUri;
					c.locator = new string[1];
					c.locator[0] = patronDetailsForm.PatronHomePhone;
					c.communicationtype = communicationType.Item02;
					ret = await lcfEntityRequestAsync(rootURI + "contacts", typeof(contact), entityOperation.POST, c);
					success = ret.Item1;
				}

				if (success && patronDetailsForm.PatronBusinessPhone.Length != 0)
				{
					c = new contact();
					c.patronref = newPatronLocationUri;
					c.locator = new string[1];
					c.locator[0] = patronDetailsForm.PatronBusinessPhone;
					c.communicationtype = communicationType.Item03;
					ret = await lcfEntityRequestAsync(rootURI + "contacts", typeof(contact), entityOperation.POST, c);
					success = ret.Item1;
				}

				if (success && patronDetailsForm.PatronMobilePhone.Length != 0)
				{
					c = new contact();
					c.patronref = newPatronLocationUri;
					c.locator = new string[1];
					c.locator[0] = patronDetailsForm.PatronMobilePhone;
					c.communicationtype = communicationType.Item04;
					ret = await lcfEntityRequestAsync(rootURI + "contacts", typeof(contact), entityOperation.POST, c);
					success = ret.Item1;
				}

				if (success && patronDetailsForm.PatronOtherPhone.Length != 0)
				{
					c = new contact();
					c.patronref = newPatronLocationUri;
					c.locator = new string[1];
					c.locator[0] = patronDetailsForm.PatronOtherPhone;
					c.communicationtype = communicationType.Item01;
					ret = await lcfEntityRequestAsync(rootURI + "contacts", typeof(contact), entityOperation.POST, c);
					success = ret.Item1;
				}

				if (success && patronDetailsForm.PatronEmail.Length != 0)
				{
					c = new contact();
					c.patronref = newPatronLocationUri;
					c.locator = new string[1];
					c.locator[0] = patronDetailsForm.PatronEmail;
					c.communicationtype = communicationType.Item05;
					ret = await lcfEntityRequestAsync(rootURI + "contacts", typeof(contact), entityOperation.POST, c);
					success = ret.Item1;
				}

				if (success && patronDetailsForm.PatronAddress.Length != 0)
				{
					c = new contact();
					c.patronref = newPatronLocationUri;
					c.communicationtype = communicationType.Item06;
					c.locator = new string[patronDetailsForm.PatronAddress.Length];

					for (int i = 0; i < patronDetailsForm.PatronAddress.Length; i++)
					{
						c.locator[i] = patronDetailsForm.PatronAddress[i];
					}

					ret = await lcfEntityRequestAsync(rootURI + "contacts", typeof(contact), entityOperation.POST, c);
					success = ret.Item1;
				}

				if (!success)
				{
					return new Tuple<bool, string>(false, String.Format("Problem creating contact for patron '{0}' - {1}", p.identifier, ret.Item3));
				}
			}

			return new Tuple<bool, string>(true, String.Format("Patron '{0}' created", newPatron.identifier));
		}

		/// <summary>
		/// Update a patron entity and associated contacts
		/// </summary>
		/// <param name="patronDetailsForm">The form containing the updated patron and contacts details</param>
		/// <param name="existingPatron">The original patron entity</param>
		/// <param name="contacts">The original contact entities</param>
		/// <returns>success, message</returns>
		private async Task<Tuple<bool, string>> updatePatron(PatronDetailsForm patronDetailsForm, patron existingPatron, List<contact> contacts)
		{
			string patronUri = rootURI + "patrons/" + existingPatron.identifier;

			if (patronDetailsForm.PatronName.CompareTo(existingPatron.name) != 0)
			{
				existingPatron.name = patronDetailsForm.PatronName;
				Tuple<bool, object, string> ret = await lcfEntityRequestAsync(patronUri, typeof(patron), entityOperation.PUT, existingPatron);

				if (!ret.Item1)
				{
					return new Tuple<bool, string>(false, String.Format("Problem updating patron '{0}' - {1}", existingPatron.identifier, ret.Item3));
				}
			}

			string[] locator = new string[] { patronDetailsForm.PatronEmail };
			Tuple<bool, string> updateContactRet = await updateContact(communicationType.Item05, locator, contacts, patronUri);

			if (updateContactRet.Item1)
			{
				locator = new string[] { patronDetailsForm.PatronHomePhone };
				updateContactRet = await updateContact(communicationType.Item02, locator, contacts, patronUri);
			}

			if (updateContactRet.Item1)
			{
				locator = new string[] { patronDetailsForm.PatronBusinessPhone };
				updateContactRet = await updateContact(communicationType.Item03, locator, contacts, patronUri);
			}

			if (updateContactRet.Item1)
			{
				locator = new string[] { patronDetailsForm.PatronMobilePhone };
				updateContactRet = await updateContact(communicationType.Item04, locator, contacts, patronUri);
			}

			if (updateContactRet.Item1)
			{
				locator = new string[] { patronDetailsForm.PatronOtherPhone };
				updateContactRet = await updateContact(communicationType.Item01, locator, contacts, patronUri);
			}

			if (updateContactRet.Item1)
			{
				updateContactRet = await updateContact(communicationType.Item06, patronDetailsForm.PatronAddress, contacts, patronUri);
			}

			if (!updateContactRet.Item1)
			{
				return new Tuple<bool, string>(false, String.Format("Problem updating patron '{0}' - {1}", existingPatron.identifier, updateContactRet.Item2));
			}
			else
			{
				return new Tuple<bool, string>(true, String.Format("Patron '{0}' updated", existingPatron.identifier));
			}
		}

		/// <summary>
		/// Update a contact entity
		/// </summary>
		/// <param name="communicationType">The contact communication type</param>
		/// <param name="updatedText">The modified text for an entity with this communicationType</param>
		/// <param name="contacts">The original contact entities</param>
		/// <param name="patronUri">The URI of the patron entity that is associated with this contact</param>
		/// <returns>success, message</returns>
		private async Task<Tuple<bool, string>> updateContact(communicationType communicationType, string[] updatedText, List<contact> contacts, string patronUri)
		{
			contact contactMethod;
			Tuple<bool, object, string> ret = new Tuple<bool, object, string>(true, null, "");

			contactMethod = contacts.FirstOrDefault(s => s.communicationtype == communicationType);

			if (updatedText.Length == 0 || (updatedText.Length == 1 && updatedText[0].Length == 0))
			{
				// is there an existing contact entity to delete?
				if (contactMethod != null)
				{
					ret = await lcfEntityRequestAsync(rootURI + "contacts/" + contactMethod.identifier, typeof(contact), entityOperation.DELETE);
				}
			}
			else
			{
				// do we need to add a new contact entity?
				if (contactMethod == null)
				{
					contact c = new contact();
					c.patronref = patronUri;
					c.locator = new string[1];

					for (int i = 0; i < updatedText.Length; i++)
					{
						c.locator[i] = updatedText[i];
					}

					c.communicationtype = communicationType;
					ret = await lcfEntityRequestAsync(rootURI + "contacts", typeof(contact), entityOperation.POST, c);
				}
				else
				{
					// do we need to modify an existing contact entity?
					bool updateRequired = updatedText.Length != contactMethod.locator.Length;

					for (int i = 0; i < updatedText.Length && !updateRequired; i++)
					{
						if (updatedText[i].CompareTo(contactMethod.locator[i]) != 0)
						{
							updateRequired = true;
						}
					}

					if (updateRequired)
					{
						contactMethod.locator = updatedText;
						ret = await lcfEntityRequestAsync(rootURI + "contacts/" + contactMethod.identifier, typeof(contact), entityOperation.PUT, contactMethod);
					}
				}
			}

			return new Tuple<bool, string>(ret.Item1, ret.Item3);
		}

		/// <summary>
		/// Delete a patron entity
		/// </summary>
		/// <param name="identifier">The patron identifier</param>
		/// <returns>success, message</returns>
		private async Task<Tuple<bool, string>> deletePatron(string identifier)
		{
			string uri = rootURI + "patrons/" + identifier;
			Tuple<bool, object, string> ret = await lcfEntityRequestAsync(uri, typeof(patron), entityOperation.GET);

			if (!ret.Item1 || ret.Item2 == null)
			{
				return new Tuple<bool, string>(false, String.Format("Patron '{0}' not found", identifier));
			}

			// For Capita LMS, it is not necessary to delete contact entities before deleting patron
			/*var existingPatron = ret.Item2 as patron;
			List<contact> contacts = new List<contact>();

			if (existingPatron.contactref != null)
			{
				foreach (string contactRef in existingPatron.contactref)
				{
					ret = await lcfEntityRequestAsync(contactRef, typeof(contact), entityOperation.DELETE);

					if (!ret.Item1)
					{
						break;
					}
				}
			}*/

			ret = await lcfEntityRequestAsync(uri, typeof(patron), entityOperation.DELETE);

			if (!ret.Item1)
			{
				return new Tuple<bool, string>(false, ret.Item3);
			}
			else
			{
				return new Tuple<bool, string>(true, String.Format("Patron '{0}' deleted", identifier));
			}
		}

		#region Form event handlers

		private async void buttonCreatePatron_Click(object sender, EventArgs e)
		{
			Tuple<bool, string> ret = await displayPatronDetails(textBoxBarcode.Text, true);

			if (!ret.Item1)
			{
				using (new CentreWinDialog(this))
				{
					MessageBox.Show(ret.Item2, "Error");
				}
			}
			else
			{
				if (!String.IsNullOrWhiteSpace(ret.Item2))
				{
					using (new CentreWinDialog(this))
					{
						MessageBox.Show(ret.Item2, "Success");
					}
				}
			}
		}

		private async void buttonEditPatron_Click(object sender, EventArgs e)
		{
			if (textBoxBarcode.Text.Length > 0)
			{
				Tuple<bool, string> ret = await displayPatronDetails(textBoxBarcode.Text);

				if (!ret.Item1)
				{
					using (new CentreWinDialog(this))
					{
						MessageBox.Show(ret.Item2, "Error");
					}
				}
			}
		}

		private async void buttonDeletePatron_Click(object sender, EventArgs e)
		{
			if (textBoxBarcode.Text.Length > 0)
			{
				using (new CentreWinDialog(this))
				{
					if (MessageBox.Show("Are you sure that you want to delete the patron record associated with the barcode " + textBoxBarcode.Text + "?", "Delete patron?", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						Tuple<bool, string> ret = await deletePatron(textBoxBarcode.Text);

						if (!ret.Item1)
						{
							using (new CentreWinDialog(this))
							{
								MessageBox.Show(String.Format("Failed to delete patron '{0}' - {1}", textBoxBarcode.Text, ret.Item2), "Error");
							}
						}
						else
						{
							using (new CentreWinDialog(this))
							{
								MessageBox.Show(ret.Item2, "Success");
							}
						}
					}
				}
			}
		}

		private void buttonPatronListStart_Click(object sender, EventArgs e)
		{
			startIndex = 0;
			patronEntityList.Clear();
			buttonPatronListContinue_Click(sender, e);
		}

		private async void buttonPatronListContinue_Click(object sender, EventArgs e)
		{
			Tuple<bool, object, string> ret = await lcfEntityRequestAsync(rootURI + "patrons" + "?" + "os:count=" + pagesize + "&" + "os:startIndex=" + startIndex, typeof(lcfentitylistresponse), entityOperation.GET);
			startIndex += pagesize;

			if (ret.Item1)
			{
				var rsp = ret.Item2 as lcfentitylistresponse;

				foreach (var ent in rsp.entity)
				{
					patronEntityList.Add(new patronEntity { URI = ent.href, Identifier = ent.href.Split('/').Last() });
				}

				this.patronListBox.DisplayMember = "Identifier";
				this.patronListBox.ValueMember = "URI";
				this.patronListBox.DataSource = patronEntityList;
				this.patronListBox.SelectedIndex = patronEntityList.Count - 1;
			}
			else
			{
				MessageBox.Show(ret.Item3, "Error");
			}
		}

		private async void patronListBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int index = this.patronListBox.IndexFromPoint(e.Location);

			if (index != ListBox.NoMatches)
			{
				string identifier = (this.patronListBox.Items[index] as patronEntity).Identifier;
				await displayPatronDetails(identifier);
			}
		}

		#endregion
	}

	public class patronEntity
	{
		public string URI { get; set; }
		public string Identifier { get; set; }
	}
}
