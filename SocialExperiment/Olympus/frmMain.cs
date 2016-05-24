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

namespace Olympus
{
    public partial class frmMain : Syncfusion.Windows.Forms.MetroForm
    {
        Core.DB.DBConnect DB = new Core.DB.DBConnect();

        public frmMain()
        {
            InitializeComponent();
        }

        private void CoreUI()
        {
            Application.Run(new Core.UI());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Text = Core.Administration.Olympus.About.olympusTitle();

            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(CoreUI));
            t.Start();
        }

        private void tmrOnline_Tick(object sender, EventArgs e)
        {

            listBox1.Items.Clear();

            DataTable dt = new DataTable();

            dt = DB.Select("SELECT username FROM users WHERE online = 1");

            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    if (!listBox1.Items.Contains(item))
                    {
                        listBox1.Items.Add(item.ToString());
                    }
                }

            }

        }

        private void tmrUpdateChat_Tick(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = DB.Select("SELECT transcript, user FROM publicchat");

            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    string sb = row.Field<string>(1) + ": " + row.Field<string>(0);
                    if (!textBox1.Text.Contains(sb.ToString()))
                    {
                        textBox1.Text += sb.ToString() + Environment.NewLine;
                    }
                    
                }
            }
        }

        private void btnSendPublic_Click(object sender, EventArgs e)
        {
            string text = textBox2.Text;
            DB.Insert("INSERT INTO publicchat(transcript, user) VALUES ('" + text + "','test')");
            textBox2.Clear();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                string text = textBox2.Text;
                DB.Insert("INSERT INTO publicchat(transcript, user) VALUES ('" + text + "','ADMIN')");
                textBox2.Clear();
            }
        }
    }
}
