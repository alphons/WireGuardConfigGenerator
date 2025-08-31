namespace WireGuardConfigGenerator
{
	partial class FormPassword
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
			label1 = new Label();
			txtPassword = new TextBox();
			btnOk = new Button();
			txtPath = new TextBox();
			label2 = new Label();
			button1 = new Button();
			openFileDialog1 = new OpenFileDialog();
			btnCancel = new Button();
			lblError = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 64);
			label1.Name = "label1";
			label1.Size = new Size(57, 15);
			label1.TabIndex = 0;
			label1.Text = "Password";
			// 
			// txtPassword
			// 
			txtPassword.Location = new Point(12, 82);
			txtPassword.Name = "txtPassword";
			txtPassword.PasswordChar = '*';
			txtPassword.Size = new Size(142, 23);
			txtPassword.TabIndex = 1;
			txtPassword.TextChanged += Password_TextChanged;
			txtPassword.KeyDown += txtPassword_KeyDown;
			// 
			// btnOk
			// 
			btnOk.Location = new Point(320, 118);
			btnOk.Name = "btnOk";
			btnOk.Size = new Size(75, 23);
			btnOk.TabIndex = 2;
			btnOk.Text = "Ok";
			btnOk.UseVisualStyleBackColor = true;
			btnOk.Click += Ok_Click;
			// 
			// txtPath
			// 
			txtPath.Location = new Point(12, 27);
			txtPath.Name = "txtPath";
			txtPath.Size = new Size(464, 23);
			txtPath.TabIndex = 5;
			txtPath.Text = "wireguard.db";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 9);
			label2.Name = "label2";
			label2.Size = new Size(22, 15);
			label2.TabIndex = 4;
			label2.Text = "Db";
			// 
			// button1
			// 
			button1.Location = new Point(401, 56);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 6;
			button1.Text = "File...";
			button1.UseVisualStyleBackColor = true;
			button1.Click += SelectFile_Click;
			// 
			// openFileDialog1
			// 
			openFileDialog1.FileName = "openFileDialog1";
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(401, 118);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 7;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += Cancel_Click;
			// 
			// lblError
			// 
			lblError.AutoSize = true;
			lblError.ForeColor = Color.Red;
			lblError.Location = new Point(174, 87);
			lblError.Name = "lblError";
			lblError.Size = new Size(0, 15);
			lblError.TabIndex = 8;
			// 
			// FormPassword
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(488, 152);
			Controls.Add(lblError);
			Controls.Add(btnCancel);
			Controls.Add(button1);
			Controls.Add(txtPath);
			Controls.Add(label2);
			Controls.Add(btnOk);
			Controls.Add(txtPassword);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "FormPassword";
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "FormPassword";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox txtPassword;
		private Button btnOk;
		private TextBox txtPath;
		private Label label2;
		private Button button1;
		private OpenFileDialog openFileDialog1;
		private Button btnCancel;
		private Label lblError;
	}
}