using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace impulse
{
    public partial class pdfview : Form
    {
        public pdfview()
        {
            InitializeComponent();
        }

        private void pdfview_Load(object sender, EventArgs e)
        {
            try
            {
                axAcroPDF1.src = Application.StartupPath + @"\Impulse.pdf";
                //MessageBox.Show(Application.StartupPath + @"\Impulse.pdf");
                //AxAcroPDFLib.AxAcroPDF a = new AxAcroPDFLib.AxAcroPDF();
              
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }
            //catch(exe)
                 
        }
    }
}
