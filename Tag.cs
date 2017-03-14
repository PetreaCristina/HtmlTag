using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HtmlRender
{


    class Tag : Element
    {

        protected TagName internalTagName;
        protected Dictionary<string, string> attributes = new Dictionary<string, string>();
        protected List<Element> children;
        protected bool isSelfClosing;

        public bool isSelfClosingg
        {
            get
            {
                return isSelfClosing;
            }
            set
            {
                isSelfClosing = value;
            }
        }
        public TagName TagName
        {
            get
            {
                return internalTagName;
            }
        }
        public new string innerText
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
        public Tag(TagName t)
        {
            //parinte = new Tag(TagName.html);
            internalTagName = t;
            attributes = new Dictionary<string, string>();
            children = new List<Element>();
            isSelfClosing = false;
            internalInnerText = "";

        }

        public void SetAttribute(string key, string value)
        {
            if (!String.IsNullOrEmpty(key) && !String.IsNullOrEmpty(value))
            {
                if (attributes.ContainsKey(key))
                {
                    attributes[key] = value;
                }
                else
                    attributes.Add(key, value);
            }
        }

        public bool HasAttribute(string key)
        {
            if (attributes.ContainsKey(key))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void RemoveAttribute(string key)
        {
            if (HasAttribute(key))
                attributes.Remove(key);

        }
        public void RemoveAllAtributes()
        {
            foreach (var key in attributes.Keys)
            {
                attributes.Remove(key);
            }

        }
        public int AttributeCount()
        {
            return attributes.Count();
        }



        public void printTagName()
        {
            Console.WriteLine(internalTagName);
        }
        public string GetAttributeValue(string key)
        {
            return attributes[key];//valoarea asociata
        }
        public Dictionary<string, string> GetAllAttributeValue()
        {
            return attributes;
        }


        public void AddChild(Element child)
        {
            child.parent = this;
            children.Add(child);
            /*
            if (isSelfClosing == false)
            {
                parent = this;
                children.Add(child);

            }*/
        }
        public bool AddChild(Element child, int poz)
        {

            if (CountChildren() <= poz)
            {
                children.Insert(poz, child);
                return true;
            }
            return false;

        }
        public void AddChildren(List<Element> newChildrens)
        {
            if (isSelfClosing == false)
                children.AddRange(newChildrens);
        }

        public bool RemoveChild(Element child)
        {
            return children.Remove(child);
        }
        public List<Element> RemoveAllChildren()
        {
            List<Element> AllChildrenRemoved = new List<Element>(children);
            children.Clear();
            return AllChildrenRemoved;

        }
        public List<Element> RemoveAllChildren(TagName child)
        {
            List<Element> AllChildrenRemoved = new List<Element>();
            foreach (var childTag in children)
            {
                if (((Tag)childTag).TagName.Equals(child))
                {
                    AllChildrenRemoved.Add(childTag);
                    children.Remove(childTag);
                }
            }
            return AllChildrenRemoved;
        }
        public int CountChildren()
        {
            return children.Count();
        }
        public StringBuilder Render()
        {
            int countTabs = 0;
            return Render(countTabs);
        }

        public StringBuilder Render(int levelCount = 0)
        {
            StringBuilder text = new StringBuilder("");
            for (int i = 0; i < levelCount; ++i)
                text.Append("\t");

            text.Append("<");
            text.Append(internalTagName.ToString());

            foreach (var item in attributes)
            {
                text.Append(" " + item.Key.ToString() + "='" + item.Value.ToString() + "'");

            }
            if (this.isSelfClosing == true)
                text.Append("/");
            text.Append(">");


            //if (attributes.Count() != 0 || innerText != null)
            //{
            //    text.Append("\n");
            //}
            text.Append('\n');
            if (innerText != "")
            {
                for (int i = 0; i < levelCount + 1; i++)
                {
                    text.Append("\t");

                }

                text.Append(innerText + "\n");

            }


            foreach (var item in children)
            {
                if (item is Tag)
                {

                    text.Append(((Tag)item).Render(levelCount + 1));
                }
                else
                {

                    for (int i = 0; i < levelCount + 1; i++)
                    {
                        text.Append("\t");
                    }
                    text.Append(item.innerText.ToString() + '\n');
                }

            }


            if (this.isSelfClosing == false)
            {
                for (int i = 0; i < levelCount; i++)
                {
                    text.Append("\t");

                }

                text.Append("</" + internalTagName.ToString() + ">\n");
            }

            return text;
        }


        public bool Contains(TagName tg)
        {
            foreach (var item in children)
            {
                if (((Tag)item).TagName == tg)
                    return true;
            }
            return false;
        }

    }

}



