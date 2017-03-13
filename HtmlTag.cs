using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlRender
{
    class HtmlTag:Tag
    {
        bool isInstantieted = false;
        public HtmlTag():base(TagName.html)
        {
            isInstantieted = true;
        }
        public new void AddChild(Element child)
        {
                if (!this.Contains(TagName.head) && (child is HeadTag))
                        children.Insert(0,child);
                if (!this.Contains(TagName.body) && (child is BodyTag))
                    children.Add(child);
       
        }
        public List<string> Parse(string path)
        {
            
            List<string> htmlTags = new List<string>();
            TagName tName;
            TagName tNAme;
            Tag tag;
            if (File.Exists(path))
            {
                string readText = File.ReadAllText(path);
                string word;
                while(readText!=null)
                {
                    int startIndex = readText.IndexOf('<');
                    int endIndex = readText.IndexOf('>');
                    try
                    {
                        word = readText.Substring(startIndex + 1, endIndex - startIndex - 1);
                        
                        int count = 0;
                        TagName.TryParse(word,out tName);
                        if (Enum.IsDefined(typeof(TagName), tName))
                        {
                            tag = new Tag(tName);
                            count++;
                            Console.WriteLine(count);
                            if (!word.Contains('/'))
                            {

                            }
                        }
                        if (word.Contains('/'))
                        {
                             htmlTags.Add(word.TrimStart(' ','/'));
                            TagName.TryParse(word,out tNAme);
                            if(tName.Equals(tNAme))
                            {
                                count--;
                                Console.WriteLine(count);
                            }

                        }

                        else
                        {
                            htmlTags.Add(word);
                        }

                    }
                    catch
                    {
                        path = null;
                        break;
                    }
                readText = readText.Remove(0,endIndex+1);
                   // Console.WriteLine(readText);
                }
            }
            return htmlTags;

        }
        public Tag Parse2(string path)
        {
           // List<string> htmlTags = new List<string>();
            //HtmlTag rootTag = new HtmlTag();
            Tag child;
            Tag tag;
            Tag rootTag;

            if (File.Exists(path))
            {
                string readText = File.ReadAllText(path);
                string word;
                TagName tName;
                // readText.Replace('\n','');
                // readText.Replace('\t', '');
                int startIndex = readText.IndexOf('<');
                int endIndex = readText.IndexOf('>');
                word = readText.Substring(startIndex + 1, endIndex - startIndex - 1);
                TagName.TryParse(word, out tName);
                if (Enum.IsDefined(typeof(TagName), tName))
                {
                    rootTag= new Tag(tName);
                }
                while (readText != null)
                {
                   startIndex = readText.IndexOf('<');
                   endIndex = readText.IndexOf('>');
                   word = readText.Substring(startIndex + 1, endIndex - startIndex - 1);
                   TagName.TryParse(word, out tName);
                    tag = new Tag(tName);
                    AddChild(tag);
                    
                    try
                    {
     
                   }
                    catch
                    {
                        path = null;
                        break;
                    }
                    
                }


            }



            return htmlTags;
        }
    }
}
