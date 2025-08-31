namespace WireGuardConfigGenerator
{
	partial class UserControlPeer
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
			tabControl1 = new TabControl();
			tabPage0 = new TabPage();
			button2 = new Button();
			txtConf = new TextBox();
			tabPage1 = new TabPage();
			groupBox1 = new GroupBox();
			chkUseKeepAlive = new CheckBox();
			chkUseDns = new CheckBox();
			chkUseAllowedIPs = new CheckBox();
			txtAllowedIPs = new TextBox();
			label5 = new Label();
			txtDnsServers = new TextBox();
			label7 = new Label();
			button3 = new Button();
			button1 = new Button();
			comboBox1 = new ComboBox();
			txtPersistenKeepAlive = new TextBox();
			label8 = new Label();
			txtPrivateKey = new TextBox();
			label1 = new Label();
			txtListenPort = new TextBox();
			txtAddress = new TextBox();
			label3 = new Label();
			label2 = new Label();
			txtPublicKey = new TextBox();
			label6 = new Label();
			buttonSave = new Button();
			buttonCancel = new Button();
			buttonEdit = new Button();
			lblName = new Label();
			label4 = new Label();
			tabControl1.SuspendLayout();
			tabPage0.SuspendLayout();
			tabPage1.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tabPage0);
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Dock = DockStyle.Fill;
			tabControl1.Location = new Point(0, 0);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(467, 364);
			tabControl1.TabIndex = 12;
			tabControl1.SelectedIndexChanged += TabControl_SelectedIndexChanged;
			// 
			// tabPage0
			// 
			tabPage0.Controls.Add(button2);
			tabPage0.Controls.Add(txtConf);
			tabPage0.Location = new Point(4, 24);
			tabPage0.Name = "tabPage0";
			tabPage0.Padding = new Padding(3);
			tabPage0.Size = new Size(459, 336);
			tabPage0.TabIndex = 1;
			tabPage0.Text = "peer conf";
			tabPage0.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			button2.Location = new Point(378, 307);
			button2.Name = "button2";
			button2.Size = new Size(75, 23);
			button2.TabIndex = 5;
			button2.Text = "Copy";
			button2.UseVisualStyleBackColor = true;
			button2.Click += Copy_Click;
			// 
			// txtConf
			// 
			txtConf.AcceptsReturn = true;
			txtConf.AcceptsTab = true;
			txtConf.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			txtConf.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtConf.Location = new Point(6, 6);
			txtConf.Multiline = true;
			txtConf.Name = "txtConf";
			txtConf.ReadOnly = true;
			txtConf.ScrollBars = ScrollBars.Both;
			txtConf.Size = new Size(447, 295);
			txtConf.TabIndex = 4;
			// 
			// tabPage1
			// 
			tabPage1.Controls.Add(groupBox1);
			tabPage1.Controls.Add(buttonSave);
			tabPage1.Controls.Add(buttonCancel);
			tabPage1.Controls.Add(buttonEdit);
			tabPage1.Controls.Add(lblName);
			tabPage1.Controls.Add(label4);
			tabPage1.Location = new Point(4, 24);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(3);
			tabPage1.Size = new Size(459, 336);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "peer settings";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			groupBox1.Controls.Add(chkUseKeepAlive);
			groupBox1.Controls.Add(chkUseDns);
			groupBox1.Controls.Add(chkUseAllowedIPs);
			groupBox1.Controls.Add(txtAllowedIPs);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(txtDnsServers);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(button3);
			groupBox1.Controls.Add(button1);
			groupBox1.Controls.Add(comboBox1);
			groupBox1.Controls.Add(txtPersistenKeepAlive);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(txtPrivateKey);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(txtListenPort);
			groupBox1.Controls.Add(txtAddress);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(txtPublicKey);
			groupBox1.Controls.Add(label6);
			groupBox1.Enabled = false;
			groupBox1.Location = new Point(7, 31);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(446, 270);
			groupBox1.TabIndex = 19;
			groupBox1.TabStop = false;
			groupBox1.Text = "peer";
			// 
			// chkUseKeepAlive
			// 
			chkUseKeepAlive.AutoSize = true;
			chkUseKeepAlive.Location = new Point(94, 211);
			chkUseKeepAlive.Name = "chkUseKeepAlive";
			chkUseKeepAlive.Size = new Size(69, 19);
			chkUseKeepAlive.TabIndex = 30;
			chkUseKeepAlive.Text = "override";
			chkUseKeepAlive.UseVisualStyleBackColor = true;
			chkUseKeepAlive.CheckedChanged += UseKeepAlive_CheckedChanged;
			// 
			// chkUseDns
			// 
			chkUseDns.AutoSize = true;
			chkUseDns.Location = new Point(94, 185);
			chkUseDns.Name = "chkUseDns";
			chkUseDns.Size = new Size(69, 19);
			chkUseDns.TabIndex = 29;
			chkUseDns.Text = "override";
			chkUseDns.UseVisualStyleBackColor = true;
			chkUseDns.CheckedChanged += Dns_CheckedChanged;
			// 
			// chkUseAllowedIPs
			// 
			chkUseAllowedIPs.AutoSize = true;
			chkUseAllowedIPs.Location = new Point(94, 158);
			chkUseAllowedIPs.Name = "chkUseAllowedIPs";
			chkUseAllowedIPs.Size = new Size(69, 19);
			chkUseAllowedIPs.TabIndex = 26;
			chkUseAllowedIPs.Text = "override";
			chkUseAllowedIPs.UseVisualStyleBackColor = true;
			chkUseAllowedIPs.CheckedChanged += AllowedIP_CheckedChanged;
			// 
			// txtAllowedIPs
			// 
			txtAllowedIPs.Enabled = false;
			txtAllowedIPs.Font = new Font("Consolas", 8.25F);
			txtAllowedIPs.Location = new Point(169, 158);
			txtAllowedIPs.Name = "txtAllowedIPs";
			txtAllowedIPs.Size = new Size(230, 20);
			txtAllowedIPs.TabIndex = 25;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(10, 162);
			label5.Name = "label5";
			label5.Size = new Size(65, 15);
			label5.TabIndex = 24;
			label5.Text = "AllowedIPs";
			// 
			// txtDnsServers
			// 
			txtDnsServers.Enabled = false;
			txtDnsServers.Font = new Font("Consolas", 8.25F);
			txtDnsServers.Location = new Point(169, 184);
			txtDnsServers.Name = "txtDnsServers";
			txtDnsServers.Size = new Size(159, 20);
			txtDnsServers.TabIndex = 23;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(6, 186);
			label7.Name = "label7";
			label7.Size = new Size(69, 15);
			label7.TabIndex = 22;
			label7.Text = "DNS servers";
			// 
			// button3
			// 
			button3.Location = new Point(264, 45);
			button3.Name = "button3";
			button3.Size = new Size(135, 23);
			button3.TabIndex = 21;
			button3.Text = "Generate PublicKey";
			button3.UseVisualStyleBackColor = true;
			button3.Click += GeneratePublicKey_Click;
			// 
			// button1
			// 
			button1.Location = new Point(81, 45);
			button1.Name = "button1";
			button1.Size = new Size(108, 23);
			button1.TabIndex = 20;
			button1.Text = "Renew keys";
			button1.UseVisualStyleBackColor = true;
			button1.Click += RenewKeys_Click;
			// 
			// comboBox1
			// 
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[] { "16", "24", "32" });
			comboBox1.Location = new Point(199, 131);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(46, 23);
			comboBox1.TabIndex = 14;
			// 
			// txtPersistenKeepAlive
			// 
			txtPersistenKeepAlive.Enabled = false;
			txtPersistenKeepAlive.Font = new Font("Consolas", 8.25F);
			txtPersistenKeepAlive.Location = new Point(169, 210);
			txtPersistenKeepAlive.Name = "txtPersistenKeepAlive";
			txtPersistenKeepAlive.Size = new Size(40, 20);
			txtPersistenKeepAlive.TabIndex = 12;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(13, 211);
			label8.Name = "label8";
			label8.Size = new Size(59, 15);
			label8.TabIndex = 11;
			label8.Text = "KeepAlive";
			// 
			// txtPrivateKey
			// 
			txtPrivateKey.Font = new Font("Consolas", 8.25F);
			txtPrivateKey.Location = new Point(81, 74);
			txtPrivateKey.Name = "txtPrivateKey";
			txtPrivateKey.Size = new Size(318, 20);
			txtPrivateKey.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(25, 134);
			label1.Name = "label1";
			label1.Size = new Size(49, 15);
			label1.TabIndex = 6;
			label1.Text = "Address";
			// 
			// txtListenPort
			// 
			txtListenPort.Font = new Font("Consolas", 8.25F);
			txtListenPort.Location = new Point(323, 131);
			txtListenPort.Name = "txtListenPort";
			txtListenPort.Size = new Size(76, 20);
			txtListenPort.TabIndex = 5;
			// 
			// txtAddress
			// 
			txtAddress.Font = new Font("Consolas", 8.25F);
			txtAddress.Location = new Point(81, 131);
			txtAddress.Name = "txtAddress";
			txtAddress.Size = new Size(112, 20);
			txtAddress.TabIndex = 7;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(257, 134);
			label3.Name = "label3";
			label3.Size = new Size(60, 15);
			label3.TabIndex = 4;
			label3.Text = "ListenPort";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(13, 75);
			label2.Name = "label2";
			label2.Size = new Size(62, 15);
			label2.TabIndex = 0;
			label2.Text = "PrivateKey";
			// 
			// txtPublicKey
			// 
			txtPublicKey.Font = new Font("Consolas", 8.25F);
			txtPublicKey.Location = new Point(81, 103);
			txtPublicKey.Name = "txtPublicKey";
			txtPublicKey.Size = new Size(318, 20);
			txtPublicKey.TabIndex = 3;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(16, 104);
			label6.Name = "label6";
			label6.Size = new Size(59, 15);
			label6.TabIndex = 2;
			label6.Text = "PublicKey";
			// 
			// buttonSave
			// 
			buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonSave.Enabled = false;
			buttonSave.Location = new Point(247, 307);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(75, 23);
			buttonSave.TabIndex = 22;
			buttonSave.Text = "Save";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += Save_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonCancel.Enabled = false;
			buttonCancel.Location = new Point(378, 307);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(75, 23);
			buttonCancel.TabIndex = 21;
			buttonCancel.Text = "Cancel";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += Cancel_Click;
			// 
			// buttonEdit
			// 
			buttonEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonEdit.Location = new Point(167, 307);
			buttonEdit.Name = "buttonEdit";
			buttonEdit.Size = new Size(75, 23);
			buttonEdit.TabIndex = 20;
			buttonEdit.Text = "Edit";
			buttonEdit.UseVisualStyleBackColor = true;
			buttonEdit.Click += Edit_Click;
			// 
			// lblName
			// 
			lblName.AutoSize = true;
			lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblName.Location = new Point(88, 13);
			lblName.Name = "lblName";
			lblName.Size = new Size(16, 15);
			lblName.TabIndex = 13;
			lblName.Text = "...";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(32, 13);
			label4.Name = "label4";
			label4.Size = new Size(42, 15);
			label4.TabIndex = 12;
			label4.Text = "Name:";
			// 
			// UserControlPeer
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(tabControl1);
			Name = "UserControlPeer";
			Size = new Size(467, 364);
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
		private TabControl tabControl1;
		private TabPage tabPage1;
		private TabPage tabPage0;
		private Label lblName;
		private Label label4;
		private GroupBox groupBox1;
		private TextBox txtPrivateKey;
		private Label label1;
		private TextBox txtListenPort;
		private TextBox txtAddress;
		private Label label3;
		private Label label2;
		private TextBox txtPublicKey;
		private Label label6;
		private Button buttonSave;
		private Button buttonCancel;
		private Button buttonEdit;
		private Button button2;
		private TextBox txtConf;
		private TextBox txtPersistenKeepAlive;
		private Label label8;
		private ComboBox comboBox1;
		private Button button1;
		private Button button3;
		private TextBox txtDnsServers;
		private Label label7;
		private CheckBox chkUseAllowedIPs;
		private TextBox txtAllowedIPs;
		private Label label5;
		private CheckBox chkUseDns;
		private CheckBox chkUseKeepAlive;
	}
}
