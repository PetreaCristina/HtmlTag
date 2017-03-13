using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HtmlRender
{
    class Element
    {
        protected Tag parinte;
        protected string internalInnerText;
        public string innerText
        {
            get
            {
                return internalInnerText;
            }
            set
            {
                //validare string
                Regex r = new Regex("^[a-zA-Z0-9 ]*$");
                if (r.IsMatch(value))
                {
                    internalInnerText = value;
                    //System.Console.WriteLine("-valid");
                }
                else
                    System.Console.WriteLine("-invalid");
            }
        }
    }
}
