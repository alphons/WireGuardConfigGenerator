namespace WireGuardConfigGenerator
{
	partial class UserControlServer
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			label1 = new Label();
			txtPrivateKey = new TextBox();
			txtPublicKey = new TextBox();
			label2 = new Label();
			txtListenPort = new TextBox();
			label3 = new Label();
			txtAddress = new TextBox();
			label4 = new Label();
			txtPostUp = new TextBox();
			label5 = new Label();
			tabControl1 = new TabControl();
			tabPage0 = new TabPage();
			button1 = new Button();
			txtConf = new TextBox();
			tabPage1 = new TabPage();
			groupBox1 = new GroupBox();
			button2 = new Button();
			comboBox1 = new ComboBox();
			txtEndpoint = new TextBox();
			label6 = new Label();
			buttonSave = new Button();
			buttonCancel = new Button();
			buttonEdit = new Button();
			lblName = new Label();
			label7 = new Label();
			tabControl1.SuspendLayout();
			tabPage0.SuspendLayout();
			tabPage1.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(8, 59);
			label1.Name = "label1";
			label1.Size = new Size(62, 15);
			label1.TabIndex = 0;
			label1.Text = "PrivateKey";
			// 
			// txtPrivateKey
			// 
			txtPrivateKey.Location = new Point(74, 56);
			txtPrivateKey.Name = "txtPrivateKey";
			txtPrivateKey.Size = new Size(318, 23);
			txtPrivateKey.TabIndex = 1;
			// 
			// txtPublicKey
			// 
			txtPublicKey.Location = new Point(74, 85);
			txtPublicKey.Name = "txtPublicKey";
			txtPublicKey.Size = new Size(318, 23);
			txtPublicKey.TabIndex = 3;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(8, 88);
			label2.Name = "label2";
			label2.Size = new Size(59, 15);
			label2.TabIndex = 2;
			label2.Text = "PublicKey";
			// 
			// txtListenPort
			// 
			txtListenPort.Location = new Point(316, 156);
			txtListenPort.Name = "txtListenPort";
			txtListenPort.Size = new Size(76, 23);
			txtListenPort.TabIndex = 5;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(250, 159);
			label3.Name = "label3";
			label3.Size = new Size(60, 15);
			label3.TabIndex = 4;
			label3.Text = "ListenPort";
			// 
			// txtAddress
			// 
			txtAddress.Location = new Point(74, 156);
			txtAddress.Name = "txtAddress";
			txtAddress.Size = new Size(108, 23);
			txtAddress.TabIndex = 7;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(18, 159);
			label4.Name = "label4";
			label4.Size = new Size(49, 15);
			label4.TabIndex = 6;
			label4.Text = "Address";
			// 
			// txtPostUp
			// 
			txtPostUp.AcceptsReturn = true;
			txtPostUp.Location = new Point(74, 185);
			txtPostUp.Multiline = true;
			txtPostUp.Name = "txtPostUp";
			txtPostUp.ScrollBars = ScrollBars.Both;
			txtPostUp.Size = new Size(318, 145);
			txtPostUp.TabIndex = 9;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(23, 188);
			label5.Name = "label5";
			label5.Size = new Size(45, 15);
			label5.TabIndex = 8;
			label5.Text = "PostUp";
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tabPage0);
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Dock = DockStyle.Fill;
			tabControl1.Location = new Point(0, 0);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(418, 453);
			tabControl1.TabIndex = 12;
			tabControl1.SelectedIndexChanged += TabControl_SelectedIndexChanged;
			// 
			// tabPage0
			// 
			tabPage0.Controls.Add(button1);
			tabPage0.Controls.Add(txtConf);
			tabPage0.Location = new Point(4, 24);
			tabPage0.Name = "tabPage0";
			tabPage0.Padding = new Padding(3);
			tabPage0.Size = new Size(410, 425);
			tabPage0.TabIndex = 1;
			tabPage0.Text = "server conf";
			tabPage0.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			button1.Location = new Point(329, 347);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 1;
			button1.Text = "Copy";
			button1.UseVisualStyleBackColor = true;
			button1.Click += Copy_Click;
			// 
			// txtConf
			// 
			txtConf.AcceptsReturn = true;
			txtConf.AcceptsTab = true;
			txtConf.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			txtConf.Location = new Point(3, 3);
			txtConf.Multiline = true;
			txtConf.Name = "txtConf";
			txtConf.ReadOnly = true;
			txtConf.ScrollBars = ScrollBars.Both;
			txtConf.Size = new Size(401, 338);
			txtConf.TabIndex = 0;
			// 
			// tabPage1
			// 
			tabPage1.Controls.Add(groupBox1);
			tabPage1.Controls.Add(buttonSave);
			tabPage1.Controls.Add(buttonCancel);
			tabPage1.Controls.Add(buttonEdit);
			tabPage1.Controls.Add(lblName);
			tabPage1.Controls.Add(label7);
			tabPage1.Location = new Point(4, 24);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(3);
			tabPage1.Size = new Size(410, 425);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "server settings";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			groupBox1.Controls.Add(button2);
			groupBox1.Controls.Add(comboBox1);
			groupBox1.Controls.Add(txtEndpoint);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(txtPrivateKey);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(txtListenPort);
			groupBox1.Controls.Add(txtAddress);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(txtPublicKey);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(txtPostUp);
			groupBox1.Enabled = false;
			groupBox1.Location = new Point(6, 48);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(398, 342);
			groupBox1.TabIndex = 13;
			groupBox1.TabStop = false;
			groupBox1.Text = "server";
			// 
			// button2
			// 
			button2.Location = new Point(74, 114);
			button2.Name = "button2";
			button2.Size = new Size(108, 23);
			button2.TabIndex = 19;
			button2.Text = "Renew keys";
			button2.UseVisualStyleBackColor = true;
			button2.Click += RenewKeys_Click;
			// 
			// comboBox1
			// 
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[] { "16", "24", "32" });
			comboBox1.Location = new Point(188, 156);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(46, 23);
			comboBox1.TabIndex = 13;
			// 
			// txtEndpoint
			// 
			txtEndpoint.Location = new Point(74, 22);
			txtEndpoint.Name = "txtEndpoint";
			txtEndpoint.Size = new Size(318, 23);
			txtEndpoint.TabIndex = 11;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(13, 25);
			label6.Name = "label6";
			label6.Size = new Size(55, 15);
			label6.TabIndex = 10;
			label6.Text = "Endpoint";
			// 
			// buttonSave
			// 
			buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonSave.Enabled = false;
			buttonSave.Location = new Point(322, 399);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(75, 23);
			buttonSave.TabIndex = 18;
			buttonSave.Text = "Save";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += Save_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonCancel.Enabled = false;
			buttonCancel.Location = new Point(202, 399);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(75, 23);
			buttonCancel.TabIndex = 17;
			buttonCancel.Text = "Cancel";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += Cancel_Click;
			// 
			// buttonEdit
			// 
			buttonEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonEdit.Location = new Point(121, 399);
			buttonEdit.Name = "buttonEdit";
			buttonEdit.Size = new Size(75, 23);
			buttonEdit.TabIndex = 16;
			buttonEdit.Text = "Edit";
			buttonEdit.UseVisualStyleBackColor = true;
			buttonEdit.Click += Edit_Click;
			// 
			// lblName
			// 
			lblName.AutoSize = true;
			lblName.Location = new Point(68, 21);
			lblName.Name = "lblName";
			lblName.Size = new Size(16, 15);
			lblName.TabIndex = 15;
			lblName.Text = "...";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(24, 21);
			label7.Name = "label7";
			label7.Size = new Size(39, 15);
			label7.TabIndex = 14;
			label7.Text = "Name";
			// 
			// UserControlServer
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(tabControl1);
			Name = "UserControlServer";
			Size = new Size(418, 453);
			tabControl1.ResumeLayout(false);
			tabPage0.ResumeLayout(false);
			tabPage0.PerformLayout();
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Label label1;
		private TextBox txtPrivateKey;
		private TextBox txtPublicKey;
		private Label label2;
		private TextBox txtListenPort;
		private Label label3;
		private TextBox txtAddress;
		private Label label4;
		private TextBox txtPostUp;
		private Label label5;
		private TabControl tabControl1;
		private TabPage tabPage1;
		private TabPage tabPage0;
		private TextBox txtConf;
		private Label lblName;
		private Label label7;
		private Button buttonSave;
		private Button buttonCancel;
		private Button buttonEdit;
		private GroupBox groupBox1;
		private Button button1;
		private TextBox txtEndpoint;
		private Label label6;
		private ComboBox comboBox1;
		private Button button2;
	}
}
