using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.XP
{
    class XP : DB.DBConnect
    {
        public void Add(string user, int xp)
        {
            DataTable dt = new DataTable();

            dt = Select("SELECT exp FROM users WHERE username='" + user + "'");

            int exp = dt.Rows[0].Field<int>(0);
            exp += xp;

            Update("UPDATE users SET exp=" + exp + "WHERE username='" + user + "'");
        }
    }
}
