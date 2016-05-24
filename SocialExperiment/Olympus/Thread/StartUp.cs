using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olympus.Thread
{
    public class StartUp
    {
        public StartUp()
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(CoreUI));

            t.Start();
        }

        private void CoreUI()
        {
            Application.Run(new UI());
        }
    }
}
