using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myCMD
{
    class TabConsole : TabPage
    {
        public TabConsole() : base() 
        {
            this.Controls.Add(new Cmd());
        }
        public TabConsole(string name) : base(name) 
        {
            this.Controls.Add(new Cmd());
        }
    }
}
