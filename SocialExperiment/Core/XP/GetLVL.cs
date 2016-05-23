using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.XP
{
    public class GetLVL : GetEXP
    {
        private int _EXP;
        private int _lvl;
        private string _user;

        Dictionary<int, int> levels = new Dictionary<int, int>();

        public GetLVL(string user)
        {
            //Legg til levels basert på XP
            //Tall 1 = level | Tall 2 = EXP Required
            for (int i = 1; i < 31; i++)
            {
                levels.Add(i, (10*(i * i)));
            }

            _user = user;

            _EXP = EXP(_user);

            try
            {
                foreach (KeyValuePair<int, int> pair in levels)
                {
                    if (pair.Value < _EXP)
                    {
                        _lvl = pair.Key;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public int LVL
        {
            get
            {
                return _lvl;
            }
        }
    }
}
