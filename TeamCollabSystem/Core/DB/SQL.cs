using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace Core.DB
{
    public class SQL
    {
        public DataTable query(string sql, string success = "")
        {
            MySqlConnection con = new MySqlConnection();

            DataTable dt = new DataTable();

            if (con.State == ConnectionState.Closed)
            {
                try
                {
                    con.Open();
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Debug.WriteLine(ex.Message);
                }
            }




            return dt;
        }
    }
}