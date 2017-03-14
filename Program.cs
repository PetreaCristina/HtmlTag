using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlRender
{
    class Program
    {
      
        static void Main(string[] args)
             {
            /*var myFirstTag = new Tag(TagName.input);
            Console.WriteLine(myFirstTag.getTag());
            */

            HtmlTag html = new HtmlTag();
            HeadTag head1 = new HeadTag();
            HeadTag head2 = new HeadTag();
            BodyTag body = new BodyTag();

            Element div3 = new Tag(TagName.div);

            InputTag input = new InputTag();
            Tag div = new Tag(TagName.div);
            Tag div2 = new Tag(TagName.div);
            Tag h1 = new Tag(TagName.h1);
            Tag font = new Tag(TagName.font);
            Element e1 = new Element();
            PvTag p1 = new PvTag();
            p1.innerText = "Paragraful nr 1";
            PvTag p2 = new PvTag();
            p2.innerText = "Paragraful nr 2";
            e1.innerText = "Element1";
            //body.AddChild(div3);
            

           
           
            /*
            ATag link = new ATag("http://www.expertnetwork.eu/");
            link.innerText = "Link catre Expert Network";*/
            html.AddChild(body);
            html.AddChild(head1);
            html.AddChild(head2);
            


            //div.innerText = "div";
            // font.innerText = "h1";
            // font.SetAttribute("color","red");

            body.AddChild(div);
            body.AddChild(e1);
            div.AddChild(h1);
            div.AddChild(p1);
            p1.AddChild(div2);//ok
            //div.AddChild(link);
            h1.AddChild(font);
           // body.AddChild(input);
           // input.SetAttribute("type","text");
            //input.SetAttribute("placeholder","Your text here");
           // input.innerText = "Scrie un numar";//nu va fi afisat

            // Console.WriteLine(obiectInput.Render());

            StringBuilder textRender = html.Render();
            using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(@"C:\Users\EXNintern4\Documents\Visual Studio 2015\Projects\HtmlRender\output.html"))
            {
                outputFile.WriteLine(textRender);
            }
            Console.WriteLine("---Render---\n");
            Console.WriteLine(textRender);





            Console.WriteLine("---Parse---");

            string path = @"C:\Users\EXNintern4\Documents\Visual Studio 2015\Projects\HtmlRender\output.html";

            // html.Parse(path);
          
           Tag parseTag=html.Parse2(path);
            if (parseTag != null)
            {
                Console.WriteLine(parseTag.Render());
            }
        }
    }
}
