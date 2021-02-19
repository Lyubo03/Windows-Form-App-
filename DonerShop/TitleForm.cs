using System;
using System.Windows.Forms;

namespace HomeWork
{
    public partial class TitleForm : Form
    {
        public TitleForm()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Previous = this;
            mf.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
