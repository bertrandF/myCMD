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
        private List<string> cmdHisto = new List<string>();
        private int historyPointer = -1;
        public Prompt prompt = new Prompt();
        private int promptLastCharAt;
        public bool CursorIsAtStartOfLine 
        { 
            get 
            {
                if (SelectionStart == promptLastCharAt)
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

            Text = prompt.Text;
            this.promptLastCharAt = Text.Length;
            this.SelectionStart = Text.Length;

        }

        protected override void OnKeyDown(KeyEventArgs e) 
        {
            switch(e.KeyCode) 
            {
                case Keys.Down:
                    Text.Remove(promptLastCharAt-1);
                    Text += HistoryDown();
                    e.Handled = true;
                    break;
                case Keys.Up:
                    Text.Remove(promptLastCharAt-1);
                    Text += HistoryUp();
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
                    string cmd = Text.Substring(promptLastCharAt);
                    cmdHisto.Add(cmd);
                    MessageBox.Show("Executing cmd : " + cmd);
                    Text += "\r\n" + prompt.Text;
                    this.promptLastCharAt = Text.Length;
                    e.Handled = true;
                    ResetHistoryPointer();
                    break;
                default:
                    break;
            }
            this.SelectionStart = Text.Length;
            base.OnKeyDown(e);
        }

        private void ResetHistoryPointer() {
                historyPointer = cmdHisto.Count - 1;
        }

        private string HistoryUp() 
        {
            if (historyPointer < 0)
                return "";
            return cmdHisto[historyPointer--];
        }

        private string HistoryDown() 
        {
            if (historyPointer >= cmdHisto.Count)
                return "";
            return cmdHisto[historyPointer++];
        }
    }
}
