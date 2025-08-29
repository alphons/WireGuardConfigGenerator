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
		this.DialogResult = DialogResult.OK;
		this.Close();
	}

	private void Cancel_Click(object sender, EventArgs e)
	{
		this.Close();
	}
}
