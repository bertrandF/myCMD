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
        public Prompt prompt = new Prompt();
        public bool CursorIsAtStartOfLine 
        { 
            get 
            {
                if (SelectionStart == Text.Length - Lines[Lines.Length - 1].Length)
                    return true;
                return false;
            } 
        }
        public bool CursorIsAtEndOfLine
        {
            get
            {
                if (SelectionStart == Text.Length)
                    return true;
                return false;
            }
        }

        public Cmd() : base() {
            this.BackColor = Color.Black;
            this.ForeColor = Color.DarkGray;
            this.Font = new Font("windows_command_prompt.ttf", 10);
            this.Dock = DockStyle.Fill;
        }

        protected override void OnKeyDown(KeyEventArgs e) 
        {
            switch(e.KeyCode) 
            {
                case Keys.Down:
                case Keys.Up:
                    // TODO: Historique !
                    e.Handled = true;
                    break;
                case Keys.Left:
                    if (CursorIsAtStartOfLine)
                        e.Handled = true;
                    break;
                case Keys.Right:
                    if (CursorIsAtEndOfLine)
                        e.Handled = true;
                    break;
                case Keys.Enter:
                    MessageBox.Show("Executing cmd : " + this.Lines[this.Lines.Length - 1]);
                    Text += "\r\n" + prompt.Text;
                    this.SelectionStart = Text.Length;
                    e.Handled = true;
                    break;
                default:
                    break;
            }

            base.OnKeyDown(e);
        }


    }
}
