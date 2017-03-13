using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlRender
{
    class InputTag:Tag
    {
        public InputTag():base(TagName.input)
        {
            isSelfClosing = true;
            this.SetAttribute("type","");
            this.SetAttribute("value", "");
        }
        public new string innerText
        {
            get
            {
                return null;
            }
            set
            {
                    
            }
        }
        
    }
}
