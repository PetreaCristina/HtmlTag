using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlRender
{
    class PvTag : Tag
    {
        public PvTag() : base(TagName.p)
        {

        }
        public new void AddChild(Element tag)
        {
            if(((Tag)tag).TagName.Equals(TagName.div)==false)
            {
                children.Add(tag);
            }
            
        }
    }
}
