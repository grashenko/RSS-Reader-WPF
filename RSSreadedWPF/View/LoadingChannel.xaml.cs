using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net;
namespace RSSreaderWPF
{
    /// <summary>
    /// Логика взаимодействия для LoadingChannel.xaml
    /// </summary>
    public partial class LoadingChannel : Window
    {
        WebClient webClient = new WebClient();
        public string xml;
        public string LoadUri;
        public LoadingChannel(string uri)
        {

            webClient.Encoding = Encoding.UTF8;
            LoadUri = uri;
            Load();
            InitializeComponent();
        }
        public async void Load()
        {
            xml = await LoadString();
            this.Close();
        }
        public Task<string> LoadString()
        {


            return Task.Run(() =>
            {
                string xml = "";
                try
                {
                    xml = webClient.DownloadString(new Uri(LoadUri));
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка соединения с сервером!");
                    xml = "<?xml version='1.0'?>" + "<rss></rss>";
                }
                return xml;
            });
        }
    }


}
