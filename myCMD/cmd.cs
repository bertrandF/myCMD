using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myCMD
{
    class Cmd : RichTextBox
    {
        public Cmd() : base() {
            this.BackColor = Color.Black;
            this.ForeColor = Color.DarkGray;
            this.Font = new Font("windows_command_prompt.ttf", 10);
            this.Dock = DockStyle.Fill;
        }
    }
}
