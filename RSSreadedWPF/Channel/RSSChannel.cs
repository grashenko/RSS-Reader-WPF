using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows;
using System.IO;
using System.Threading;
using System.Net;

namespace RSSreaderWPF
{
    class RSSChannel
    {
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public List<RSSItem> Items = new List<RSSItem>();
        public ImageOfChannel imageOfChannel = new ImageOfChannel();
        public string UrlOfChannel { get; set; }
        public RSSChannel(string uri)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                UrlOfChannel = uri;
                LoadingChannel loading = new LoadingChannel(uri);
                loading.ShowDialog();
                string xml = loading.xml;
                xDoc.LoadXml(xml);
                XmlNode channelXmlNode = xDoc.GetElementsByTagName("channel")[0];
                if (channelXmlNode != null)
                {
                    foreach (XmlNode xnode in channelXmlNode.ChildNodes)
                    {
                        switch (xnode.Name)
                        {
                            case "title":
                                {
                                    title = xnode.InnerText;
                                    break;
                                }
                            case "link":
                                {
                                    link = xnode.InnerText;
                                    break;
                                }
                            case "description":
                                {
                                    description = xnode.InnerText;
                                    break;
                                }
                            case "image":
                                {
                                    foreach (XmlNode image in xnode.ChildNodes)
                                    {
                                        if (image.Name == "url")
                                        {
                                            imageOfChannel.imgURL = image.InnerText;
                                        }
                                        if (image.Name == "title")
                                        {
                                            imageOfChannel.imgTitle = image.InnerText;
                                        }
                                        if (image.Name == "link")
                                        {
                                            imageOfChannel.imgLink = image.InnerText;
                                        }
                                    }
                                    break;
                                }

                            case "item":
                                {
                                    RSSItem item = new RSSItem(xnode);
                                    Items.Add(item);
                                    break;
                                }
                        }
                    }
                }

                else
                {
                    throw new Exception("Ошибка в XML.Описание канала не найдено!");
                }

            }

            catch (System.Net.WebException ex)
            {

                if (ex.Status == System.Net.WebExceptionStatus.NameResolutionFailure)
                {

                    throw new Exception("Невозможно соединиться с указаным источником.\r\n" + uri);
                }

                else throw new Exception();

            }
            catch (System.IO.FileNotFoundException)
            {
                throw new Exception("Файл " + uri + "не найден!");
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
          
        }
       

        public RSSChannel()
        {

        }

        internal RSSItem RSSItem
        {
            get => default(RSSItem);
            set
            {
            }
        }

        internal ImageOfChannel ImageOfChannel
        {
            get => default(ImageOfChannel);
            set
            {
            }
        }
    }
}
