using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.XP
{
    public class GetEXP : DB.DBConnect
    {
        public int EXP(string user)
        {
            DataTable dt = new DataTable();

            dt = Select("SELECT exp FROM users WHERE username='" + user + "'");

            int EXP = dt.Rows[0].Field<int>(0);

            return EXP;
        }
        
    }
}
