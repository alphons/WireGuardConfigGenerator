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

}
