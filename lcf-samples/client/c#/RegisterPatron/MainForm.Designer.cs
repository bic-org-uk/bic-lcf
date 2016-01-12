namespace RegisterPatron
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.patronListBox = new System.Windows.Forms.ListBox();
			this.buttonPatronListStart = new System.Windows.Forms.Button();
			this.buttonPatronListContinue = new System.Windows.Forms.Button();
			this.buttonCreatePatron = new System.Windows.Forms.Button();
			this.textBoxBarcode = new System.Windows.Forms.TextBox();
			this.labelBarcode = new System.Windows.Forms.Label();
			this.buttonEditPatron = new System.Windows.Forms.Button();
			this.buttonDeletePatron = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// patronListBox
			// 
			this.patronListBox.FormattingEnabled = true;
			this.patronListBox.Location = new System.Drawing.Point(405, 27);
			this.patronListBox.Name = "patronListBox";
			this.patronListBox.Size = new System.Drawing.Size(187, 355);
			this.patronListBox.TabIndex = 0;
			this.patronListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.patronListBox_MouseDoubleClick);
			// 
			// buttonPatronListStart
			// 
			this.buttonPatronListStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonPatronListStart.Location = new System.Drawing.Point(249, 192);
			this.buttonPatronListStart.Name = "buttonPatronListStart";
			this.buttonPatronListStart.Size = new System.Drawing.Size(116, 32);
			this.buttonPatronListStart.TabIndex = 1;
			this.buttonPatronListStart.Text = "Start patron list";
			this.buttonPatronListStart.UseVisualStyleBackColor = true;
			this.buttonPatronListStart.Click += new System.EventHandler(this.buttonPatronListStart_Click);
			// 
			// buttonPatronListContinue
			// 
			this.buttonPatronListContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonPatronListContinue.Location = new System.Drawing.Point(249, 247);
			this.buttonPatronListContinue.Name = "buttonPatronListContinue";
			this.buttonPatronListContinue.Size = new System.Drawing.Size(116, 32);
			this.buttonPatronListContinue.TabIndex = 7;
			this.buttonPatronListContinue.Text = "Continue patron list";
			this.buttonPatronListContinue.UseVisualStyleBackColor = true;
			this.buttonPatronListContinue.Click += new System.EventHandler(this.buttonPatronListContinue_Click);
			// 
			// buttonCreatePatron
			// 
			this.buttonCreatePatron.Location = new System.Drawing.Point(249, 27);
			this.buttonCreatePatron.Name = "buttonCreatePatron";
			this.buttonCreatePatron.Size = new System.Drawing.Size(116, 33);
			this.buttonCreatePatron.TabIndex = 2;
			this.buttonCreatePatron.Text = "Register new patron";
			this.buttonCreatePatron.UseVisualStyleBackColor = true;
			this.buttonCreatePatron.Click += new System.EventHandler(this.buttonCreatePatron_Click);
			// 
			// textBoxBarcode
			// 
			this.textBoxBarcode.Location = new System.Drawing.Point(74, 33);
			this.textBoxBarcode.Name = "textBoxBarcode";
			this.textBoxBarcode.Size = new System.Drawing.Size(138, 20);
			this.textBoxBarcode.TabIndex = 3;
			// 
			// labelBarcode
			// 
			this.labelBarcode.AutoSize = true;
			this.labelBarcode.Location = new System.Drawing.Point(15, 37);
			this.labelBarcode.Name = "labelBarcode";
			this.labelBarcode.Size = new System.Drawing.Size(47, 13);
			this.labelBarcode.TabIndex = 4;
			this.labelBarcode.Text = "Barcode";
			// 
			// buttonEditPatron
			// 
			this.buttonEditPatron.Location = new System.Drawing.Point(249, 82);
			this.buttonEditPatron.Name = "buttonEditPatron";
			this.buttonEditPatron.Size = new System.Drawing.Size(116, 33);
			this.buttonEditPatron.TabIndex = 5;
			this.buttonEditPatron.Text = "Edit patron details";
			this.buttonEditPatron.UseVisualStyleBackColor = true;
			this.buttonEditPatron.Click += new System.EventHandler(this.buttonEditPatron_Click);
			// 
			// buttonDeletePatron
			// 
			this.buttonDeletePatron.Location = new System.Drawing.Point(249, 137);
			this.buttonDeletePatron.Name = "buttonDeletePatron";
			this.buttonDeletePatron.Size = new System.Drawing.Size(116, 33);
			this.buttonDeletePatron.TabIndex = 6;
			this.buttonDeletePatron.Text = "Delete patron";
			this.buttonDeletePatron.UseVisualStyleBackColor = true;
			this.buttonDeletePatron.Click += new System.EventHandler(this.buttonDeletePatron_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(604, 399);
			this.Controls.Add(this.buttonPatronListContinue);
			this.Controls.Add(this.buttonDeletePatron);
			this.Controls.Add(this.buttonEditPatron);
			this.Controls.Add(this.labelBarcode);
			this.Controls.Add(this.textBoxBarcode);
			this.Controls.Add(this.buttonCreatePatron);
			this.Controls.Add(this.buttonPatronListStart);
			this.Controls.Add(this.patronListBox);
			this.Name = "MainForm";
			this.Text = "Register Patron";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox patronListBox;
		private System.Windows.Forms.Button buttonPatronListStart;
		private System.Windows.Forms.Button buttonPatronListContinue;
		private System.Windows.Forms.Button buttonCreatePatron;
		private System.Windows.Forms.TextBox textBoxBarcode;
		private System.Windows.Forms.Label labelBarcode;
		private System.Windows.Forms.Button buttonEditPatron;
		private System.Windows.Forms.Button buttonDeletePatron;
	}
}

