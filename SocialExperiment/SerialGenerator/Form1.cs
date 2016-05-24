using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.DB;

namespace SerialGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;

            int value = 100 / int.Parse(textBox1.Text);

            int length = int.Parse(textBox1.Text) + 1;

            for (int j = 1; j < length; j++)
            {

                progressBar1.Value += value;

                label5.Text = j + "/" + textBox1.Text;
                
                string s = "0123456789";
                Random r = new Random();
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i <= 16; i++)
                {
                    int idx = r.Next(0, 10);
                    sb.Append(s.Substring(idx, 1));
                }

                label1.Text = sb.ToString();

                listBox1.Items.Add(sb.ToString());

                DBConnect DB = new DBConnect();
                
                DB.Insert("INSERT IGNORE INTO `serialnumbers`(`serial`, `registered`, `user`) VALUES ('" + sb.ToString() + "','0','0')");
                //DB.Insert("INSERT IGNORE INTO `serialnumbers`(`serial`, `registered`, `user`) VALUES ('9862872455565860','0','0')");

                progressBar1.Refresh();
                Refresh();

                sb.Clear();
            }
        }
    }
}
