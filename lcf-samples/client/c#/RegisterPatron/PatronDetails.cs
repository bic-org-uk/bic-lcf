using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterPatron
{
	public partial class PatronDetailsForm : Form
	{
		public PatronDetailsForm()
		{
			InitializeComponent();
			CenterToScreen();
		}

		public string PatronName
		{
			get
			{
				return textBoxName.Text;
			}
			set
			{
				textBoxName.Text = value;
			}
		}

		public string PatronEmail
		{
			get
			{
				return textBoxEmail.Text;
			}
			set
			{
				textBoxEmail.Text = value;
			}
		}

		public string[] PatronAddress
		{
			get
			{
				return textBoxAddress.Lines;
			}
			set
			{
				textBoxAddress.Lines = value;
			}
		}

		public string PatronHomePhone
		{
			get
			{
				return textBoxHomePhone.Text;
			}
			set
			{
				textBoxHomePhone.Text = value;
			}
		}

		public string PatronBusinessPhone
		{
			get
			{
				return textBoxBusinessPhone.Text;
			}
			set
			{
				textBoxBusinessPhone.Text = value;
			}
		}

		public string PatronMobilePhone
		{
			get
			{
				return textBoxMobilePhone.Text;
			}
			set
			{
				textBoxMobilePhone.Text = value;
			}
		}

		public string PatronOtherPhone
		{
			get
			{
				return textBoxOtherPhone.Text;
			}
			set
			{
				textBoxOtherPhone.Text = value;
			}
		}

		public string PatronIdentifier
		{
			get
			{
				return textBoxIdentifier.Text;
			}
			set
			{
				textBoxIdentifier.Text = value;
			}
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
