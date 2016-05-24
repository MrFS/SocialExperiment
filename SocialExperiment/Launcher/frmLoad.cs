#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;
using Core.DB;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Launcher
{
    public partial class frmLoad : Syncfusion.Windows.Forms.MetroForm
    {

        DBConnect con = new DBConnect();
        vController v = new vController();
        About a = new About();

        public frmLoad()
        {
            InitializeComponent();
        }

        private void Olympus()
        {
            Application.Run(new Olympus.frmMain());
        }
       
        private void frmLoad_Load(object sender, EventArgs e)
        {
            if (Debugger.IsAttached)
            {
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(Olympus));
                t.Start();
            }

            pictureBox1.BackgroundImage = Core.Properties.Resources.logoSocialExperiment;
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipX);

            this.Text = a.titleLauncher();
            this.CenterToScreen();

            try
            {
                DataTable dt = new DataTable();

                dt = con.Select("SELECT * FROM test WHERE ID=1");

                autoLabel1.Text = dt.Rows[0].Field<string>(1);

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            autoLabel2.Text = "Major: " + v.Major +
                              " Minor: " + v.Minor +
                              " Build: " + v.Build +
                              " Revision: " + v.Revision;
            Core.XP.GetLVL xp = new Core.XP.GetLVL("test");

            autoLabel3.Text = xp.LVL.ToString();
        }
    } 
    
}
