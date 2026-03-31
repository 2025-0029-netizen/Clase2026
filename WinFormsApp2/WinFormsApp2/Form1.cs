namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnGrupo1_Click(object sender, EventArgs e)
        {
            FormGrupo1 form = new FormGrupo1();
            form.Show();
        }

        private void BtnGrupo2_Click(object sender, EventArgs e)
        {
            FormGrupo2 form = new FormGrupo2();
            form.Show();
        }

        private void BtnGrupo3_Click(object sender, EventArgs e)
        {
            FormGrupo3 form = new FormGrupo3();
            form.Show();
        }

        private void BtnOpcionales_Click(object sender, EventArgs e)
        {
            FormOpcionales form = new FormOpcionales();
            form.Show();
        }
    }
}
