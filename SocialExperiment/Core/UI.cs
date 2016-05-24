using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core
{
    public partial class UI : Form
    {
        int test = 320;
        public UI()
        {
            InitializeComponent();
        }

        private void UI_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            

        }

        private void coreTick_Tick(object sender, EventArgs e)
        {
            test++;
            toolStripLabel2.Text = test.ToString();

            DB.DBConnect db = new DB.DBConnect();

            if (db.State())
            {
                serverConnection.BackColor = Color.Green;
                Refresh();
            }else
            {
                serverConnection.BackColor = Color.Red;
                Refresh();
            }


        }
    }
}
