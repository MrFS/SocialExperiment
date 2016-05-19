using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Core.DB
{
    public class DBConnect
    {
        public DBConnect()
        {
           
            try
            {
                MySqlConnection con = new MySqlConnection();

                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = "";

                    con.Open();
                }

            } catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                Debug.WriteLine(ex.Message);
            }
                


        }

    }
}
