using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myCMD
{
    class Prompt
    {
        private string text;
        public string Text 
        {
            get
            {
                StringBuilder result = new StringBuilder();
                foreach(char c in text) {
                    switch(c) 
                    {
                        case 'h':
                            result.Append(DateTime.Now.ToString("HH"));
                            break;
                        case 'm':
                            result.Append(DateTime.Now.ToString("mm"));
                            break;
                        case 's':
                            result.Append(DateTime.Now.ToString("ss"));
                            break;
                        case 'D':
                            result.Append(DateTime.Now.ToString("dd"));
                            break;
                        case 'M':
                            result.Append(DateTime.Now.ToString("MM"));
                            break;
                        case 'A':
                            result.Append(DateTime.Now.ToString("yyyy"));
                            break;
                        case 'u':
                            result.Append(System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1]);
                            break;
                        case 'c':
                            result.Append(System.Environment.MachineName);
                            break;
                        default:
                            result.Append(c);
                            break;
                    }
                }
                return result.ToString();
            } 
            private set
            {
                text = value;
            }
        }

        public Prompt() 
        {
            this.Text = "[D/M/Y h:m:s]\nu@c >> ";
        }

        public Prompt(string text) 
        {
            this.Text = text;
        }

    }
}
