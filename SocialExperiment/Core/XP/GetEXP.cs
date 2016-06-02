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
            
            return dt.Rows[0].Field<int>(0);
        }

        public int incEXP(int addEXP, string user)
        {
            int newEXP = EXP(user) + addEXP;

            Insert("");

            return 0;
        }
        
    }
}
