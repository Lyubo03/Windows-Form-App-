using System;
using System.Windows.Forms;

namespace HomeWork
{
    public partial class PayForm : Form
    {
        public PayForm ()
        {
            InitializeComponent ();
        }
        public decimal FinalPrice { get; set; }

        private void PayForm_Load ( object sender , EventArgs e )
        {
            lblInfo.Text += FinalPrice.ToString ("0.00") + "лв.";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}