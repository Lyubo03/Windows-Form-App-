using System;
using System.Windows.Forms;

namespace HomeWork
{
    public partial class MainForm : Form
    {
        public TitleForm previous;//тук съхраняваме от коя форма е извикана текущата
        public MainForm ()
        {
            InitializeComponent ();
        }
        double price = 0;
        private void brnPay_Click ( object sender , EventArgs e )
        {
            PayForm pf = new PayForm ();
            pf.finalPrice = price;
          if(  pf.ShowDialog ()==DialogResult.OK)
            {
                MessageBox.Show ("Благодарим Ви за поръчката!...");
                previous.Show ();
                this.Close ();
            }
         

        }

        private void MainForm_Load ( object sender , EventArgs e )
        {
            
        }

        private void btnBack_Click ( object sender , EventArgs e )
        {
            previous.Show ();// отваряне на заглавната форма
            this.Close ();//затваряне на текущата форма 
        }
    }
}
