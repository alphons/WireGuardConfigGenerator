namespace WireGuardConfigGenerator;

public partial class Form1 : Form
{
	private readonly FormPassword formPassword = new ();
	public Form1()
	{
		InitializeComponent();
	}

	public Panel GetPanel() => this.splitContainer1.Panel2;

	private void Exit_Click(object sender, EventArgs e)
	{
		this.Close();
	}

	private async void OpenFile_Click(object sender, EventArgs e)
	{
		if (formPassword.ShowDialog(this) == DialogResult.OK)
			await this.userControlTree1.LoadAsync(formPassword.Path, formPassword.Password);
	}

	private async void Form_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (!this.userControlTree1.IsDirty)
			return;

		if (formPassword.ShowDialog(this) == DialogResult.OK)
			await this.userControlTree1.SaveAsync(formPassword.Path, formPassword.Password);
	}

	private async void Save_Click(object sender, EventArgs e)
	{
		if (formPassword.ShowDialog(this) == DialogResult.OK)
			await this.userControlTree1.SaveAsync(formPassword.Path, formPassword.Password);

	}
}
