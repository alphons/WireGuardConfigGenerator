namespace WireGuardConfigGenerator;

public partial class FormPassword : Form
{
	public FormPassword()
	{
		InitializeComponent();
	}

	public string Password => this.txtPassword.Text.Trim();
	public string Path => this.txtPath.Text.Trim();

	private void Ok_Click(object sender, EventArgs e)
	{
		if (this.txtPassword.Text.Length < 8)
		{
			this.lblError.Text = "Min. password length 8 chars";
		}
		else
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}

	private void Cancel_Click(object sender, EventArgs e)
	{
		this.DialogResult = DialogResult.Cancel;
		this.Close();
	}

	private void SelectFile_Click(object sender, EventArgs e)
	{
		this.openFileDialog1.CheckPathExists = true;
		this.openFileDialog1.InitialDirectory = AppContext.BaseDirectory;
		this.openFileDialog1.Filter = "Wireguard db files|*.db|All Files|*.*";
		this.openFileDialog1.FileName = this.txtPath.Text;
		this.openFileDialog1.RestoreDirectory = true;

		if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
		{
			this.txtPath.Text = this.openFileDialog1.FileName.Replace(AppContext.BaseDirectory, string.Empty);
		}
	}

	private void Password_TextChanged(object sender, EventArgs e)
	{
		this.lblError.Text = string.Empty;
	}

	private void txtPassword_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Enter)
		{
			e.Handled = true;
			Ok_Click(sender, e);
		}
	}
}
