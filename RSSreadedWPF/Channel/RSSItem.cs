using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RSSreaderWPF
{
    class RSSItem
    {
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public DateTime pubDate { get; set; }
        public RSSItem(XmlNode Item)
        {
            foreach (XmlNode node in Item.ChildNodes)
            {
                switch (node.Name)
                {
                    case "title":
                        {
                            title = node.InnerText;
                            break;
                        }
                    case "link":
                        {
                            link = node.InnerText;
                            break;
                        }
                    case "description":
                        {
                            description = node.InnerText;
                            break;
                        }
                    case "pubDate":
                        {
                            DateTime time = new DateTime();
                            DateTime.TryParse(node.InnerText, out time);
                            pubDate = time;
                            break;
                        }
                }
            }
        }
    }
}
