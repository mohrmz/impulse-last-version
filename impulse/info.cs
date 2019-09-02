using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace impulse
{
    public partial class info : Form
    {
        int b;
        public info(int a)
        {
            b = a;
            InitializeComponent();
        }

        private void info_Load(object sender, EventArgs e)
        {
            if (b==1)
            {
                label1.Text =  File.ReadAllText(Application.StartupPath + @"\doctor.txt", System.Text.Encoding.Default);

            }
            if (b == 2)
            {
                label1.Text = File.ReadAllText(Application.StartupPath + @"\programmer.txt", System.Text.Encoding.Default);

            }
        }
    }
}
