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
			btnCancel = new Button();
			txtPath = new TextBox();
			label2 = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(16, 47);
			label1.Name = "label1";
			label1.Size = new Size(57, 15);
			label1.TabIndex = 0;
			label1.Text = "password";
			// 
			// txtPassword
			// 
			txtPassword.Location = new Point(16, 65);
			txtPassword.Name = "txtPassword";
			txtPassword.PasswordChar = '*';
			txtPassword.Size = new Size(167, 23);
			txtPassword.TabIndex = 1;
			// 
			// btnOk
			// 
			btnOk.Location = new Point(135, 94);
			btnOk.Name = "btnOk";
			btnOk.Size = new Size(48, 23);
			btnOk.TabIndex = 2;
			btnOk.Text = "Ok";
			btnOk.UseVisualStyleBackColor = true;
			btnOk.Click += Ok_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(54, 94);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 3;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += Cancel_Click;
			// 
			// txtPath
			// 
			txtPath.Location = new Point(16, 21);
			txtPath.Name = "txtPath";
			txtPath.Size = new Size(167, 23);
			txtPath.TabIndex = 5;
			txtPath.Text = "wireguard.db";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(16, 3);
			label2.Name = "label2";
			label2.Size = new Size(23, 15);
			label2.TabIndex = 4;
			label2.Text = "file";
			// 
			// FormPassword
			// 
			AcceptButton = btnOk;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(193, 126);
			Controls.Add(txtPath);
			Controls.Add(label2);
			Controls.Add(btnCancel);
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
		private Button btnCancel;
		private TextBox txtPath;
		private Label label2;
	}
}