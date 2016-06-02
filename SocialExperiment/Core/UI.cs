using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Core
{
    public partial class UI : Form
    {

        public UI()
        {
            InitializeComponent();
                
            CenterToScreen();    
        }

        DB.DBConnect db = new DB.DBConnect();


        vController v = new vController();

        Process current = Process.GetCurrentProcess();

        getCPU CPU = new getCPU();

        private void UI_Load(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "Main: " + v.Version;
            toolStripLabel2.Text = "Core: 0.0.0.29a56";
            toolStripLabel3.Text = "Olympus: 0.0.0.4a89";

            dataGridView1.DataSource = db.Select("SHOW GLOBAL STATUS");

        }

        private void coreTick_Tick(object sender, EventArgs e)
        {
            
            double mm = GC.GetTotalMemory(false) / 1024 / 1024;
            
            label1.Text = Convert.ToString(mm) + "MB Allocated GC";
            
            double nn = current.PrivateMemorySize64 / 1024 / 1024;

            label2.Text = Convert.ToString(nn) + "MB In Use";

            label3.Text = "Total CPU Time: " + Convert.ToString(current.TotalProcessorTime);

            label4.Text = "CPU Usage: " + Convert.ToString(CPU.GetUsage()) + "%";

            label5.Text = "Ping: " + Convert.ToString(db.DBPing()) + "ms";
            
            label6.Text = "Server Version: " + db.DBv();

            label7.Text = "Server State: " + db.States();
            
            if (db.States() == ConnectionState.Open)
            {
                toolStripStatusLabel2.BackColor = Color.Green;
                Refresh();
            }else if(db.States() == ConnectionState.Broken)
            {
                toolStripStatusLabel2.BackColor = Color.Red;
            }
        }

        private void dbStatus_Tick(object sender, EventArgs e)
        {
          dataGridView1.DataSource = db.Select("SHOW GLOBAL STATUS");
        }
    }

}
