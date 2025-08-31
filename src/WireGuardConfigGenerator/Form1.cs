namespace WireGuardConfigGenerator;

public partial class Form1 : Form
{
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
		var f = new FormPassword();

		if (f.ShowDialog(this) == DialogResult.OK)
			await this.userControlTree1.LoadAsync(f.Path, f.Password);
	}

	private async void Form_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (!this.userControlTree1.IsDirty)
			return;

		var f = new FormPassword();

		if (f.ShowDialog(this) == DialogResult.OK)
			await this.userControlTree1.SaveAsync(f.Path, f.Password);
	}

	private async void Save_Click(object sender, EventArgs e)
	{
		var f = new FormPassword();

		if (f.ShowDialog(this) == DialogResult.OK)
			await this.userControlTree1.SaveAsync(f.Path, f.Password);
	}
}
