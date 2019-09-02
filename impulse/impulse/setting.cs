using Newtonsoft.Json;
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
    public partial class setting : Form
    {
        public setting()
        {
            InitializeComponent();
        }
        public class Setting
        {
            public int round
            {
                get;
                set;
            }
        }

        private void setting_Load(object sender, EventArgs e)
        {
            Setting s = new Setting();
            StreamReader reader = new StreamReader(Application.StartupPath + @"\setting.json");
            string jsonValue = reader.ReadToEnd();
            reader.Close();
            Setting items = JsonConvert.DeserializeObject<Setting>(jsonValue);
            numericUpDown1.Value = items.round;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Setting s = new Setting();
            s.round = Convert.ToInt32(numericUpDown1.Value);
            string json = JsonConvert.SerializeObject(s);

            File.WriteAllText(Application.StartupPath+ @"\setting.json", json);
            
        }
        public int round

        {
            get {
                Setting s = new Setting();
                StreamReader reader = new StreamReader(Application.StartupPath + @"\setting.json");
                string jsonValue = reader.ReadToEnd();
                reader.Close();
                Setting items = JsonConvert.DeserializeObject<Setting>(jsonValue);
                return items.round;
            }
        }
        
    }
}


















 
