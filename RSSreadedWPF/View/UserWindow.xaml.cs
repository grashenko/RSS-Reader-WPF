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
using System.Text.RegularExpressions;
using System.Windows.Threading;
using System.Reflection;
using System.IO;
namespace RSSreaderWPF
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        DispatcherTimer timer= new DispatcherTimer();
        UserModel user;
    
        private ReaderContext reader = new ReaderContext();
        public UserWindow(UserModel userInit)
        {
            InitializeComponent();
            user = userInit;
            webBrowser1.Navigated += (sender, args) => { HideScriptErrors((WebBrowser)sender, true); };
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1.0);
            timer.Start();
            timer.Tick += new EventHandler(delegate (object s, EventArgs a)
            {

                DateTime datetime = DateTime.Now;
                tb.Text = datetime.ToString("HH:mm:ss");


            });
        }
        RSSChannel example = new RSSChannel();
        public string html;
        private void Uri_Click(object sender, EventArgs e)
        {
            if (Uri.Text.Length != 0)
            {
                CreateNewChanel(Uri.Text);
            }
            else
            {
                MessageBox.Show("Строка не заполнена!");
            }
        }

        bool generateHtml(RSSChannel channel)
        {
            try
            {
                html = "<html>" + "<head>" + "<meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>" + "<style type='text/css'>" + "A{color:#483D8B; text-decoration:none; font:Verdana;}" + 
                    "pre{font-family:courier;color:#000000;" +
                "background-color:#dfe2e5;padding-top:5pt;padding-left:5pt;" +
                "padding-bottom:5pt;border-top:1pt solid #87A5C3;" +
                "border-bottom:1pt solid #87A5C3;border-left:1pt solid #87A5C3;" +
                "border-right : 1pt solid #87A5C3;	text-align : left;}" +
                 " img{width:150; height:100;}" +
                "</style>" +
                "</head>" +
                "<body>" +
                 @"<font size=""2"" face=""Verdana"">" +
                "<a href=" + example.imageOfChannel.imgLink + ">" +
                "<img src=" + example.imageOfChannel.imgURL + " border=0></a>  " +
                "<h3>" + example.title + "</h3></a>" +
                 @"<table width=""80%"" align=""center"" border=1>";
                foreach (RSSItem article in channel.Items)
                {
                    html += "<tr>" +
                     "<td>" +
                    @"<br>  <a href=" + article.link + "><b>" + article.title + "</b></a>" +
                     "(" + article.pubDate + ")<br><br>" +
                     @"<table width=""95 % "" align=""center"" border=0>" +
                    "<tr><td>" +
                    article.description +
                    "</td></tr></table>" +
                    "<br>  <a href=" + article.link + ">" +
                    @"<font size=""1"">читать дальше</font></a><br><br>" +
                     "</td>" +
                     "</tr>";
                }
                html += "</table><br>" +
                @"<p align=""center"">" + "</font>" + "</body>" + "</html>";
                webBrowser1.NavigateToString(html);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                RSSItem article = example.Items[listBox1.SelectedIndex];
                PrintArticle(article);
            }

        }

        private void Home_Click(object sender, EventArgs e)
        {
            if (html != null)
            {
                webBrowser1.NavigateToString(html);
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"(\w*)" + Search.Text + @"(\w*)");
            int i = 0;
            List<RSSItem> articles = new List<RSSItem>();
            foreach (var a in listBox1.Items)
            {
                if (regex.IsMatch(a.ToString()))
                {
                    RSSItem article = example.Items[i];
                    articles.Add(article);
                }
                i++;
            }
            PrintArticle(articles);
        }

        void PrintArticle(RSSItem article)//Для одной записи
        {
            webBrowser1.NavigateToString("<html>" + "<head>" + "<meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>" + "<style type='text/css'>" + "A{color:#483D8B; text-decoration:none; font:Verdana;}" + "pre{font-family:courier;color:#000000;" +
                "background-color:#dfe2e5;padding-top:5pt;padding-left:5pt;" +
                "padding-bottom:5pt;border-top:1pt solid #87A5C3;" +
                "border-bottom:1pt solid #87A5C3;border-left:1pt solid #87A5C3;" +
                "border-right : 1pt solid #87A5C3;	text-align : left;}" +
                 " img{width:100; height:50;}" +
                "</style>" +
                "</head>" +
                "<body>" +
                @"<font size=""2"" face=""Verdana"">" +
                "<a href=" + example.imageOfChannel.imgLink + ">" +
                "<img src=" + example.imageOfChannel.imgURL + " border=0></a>  " +
                "<h3>" + example.title + "</h3></a>" +
                @"<table width=""80%"" align=""center"" border=1>" +
                "<tr>" +
                "<td>" +
                @"<br>  <a href=" + article.link + "><b>" + article.title + "</b></a>" +
                "(" + article.pubDate + ")<br><br>" +
                @"<table width=""95 % "" align=""center"" border=0>" +
                "<tr><td>" +
                article.description +
                "</td></tr></table>" +
                "<br>  <a href=" + article.link + ">" +
                @"<font size=""1"">читать дальше</font></a><br><br>" +
                "</td>" +
                "</tr>" +
                "</table><br>" +
                @"<p align=""center"">" + "</font>" + "</body>" + "</html>");
        }
        void PrintArticle(List<RSSItem> articles)//Переопределил для нескольких записей
        {
            string html = "<html>" + "<head>" + "<meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>" + "<style type='text/css'>" + "A{color:#483D8B; text-decoration:none; font:Verdana;}" + "pre{font-family:courier;color:#000000;" +
                "background-color:#dfe2e5;padding-top:5pt;padding-left:5pt;" +
                "padding-bottom:5pt;border-top:1pt solid #87A5C3;" +
                "border-bottom:1pt solid #87A5C3;border-left:1pt solid #87A5C3;" +
                "border-right : 1pt solid #87A5C3;	text-align : left;}" +
                 " img{width:100; height:50;}" +
                "</style>" +
                "</head>" +
                "<body>" +
                 @"<font size=""2"" face=""Verdana"">" +
                "<a href=" + example.imageOfChannel.imgLink + ">" +
                "<img src=" + example.imageOfChannel.imgURL + " border=0></a>  " +
                "<h3>" + example.title + "</h3></a>" +
                 @"<table width=""80%"" align=""center"" border=1>";
            foreach (RSSItem article in articles)
            {
                html += "<tr>" +
                 "<td>" +
                @"<br>  <a href=" + article.link + "><b>" + article.title + "</b></a>" +
                 "(" + article.pubDate + ")<br><br>" +
                 @"<table width=""95 % "" align=""center"" border=0>" +
                "<tr><td>" +
                article.description +
                "</td></tr></table>" +
                "<br>  <a href=" + article.link + ">" +
                @"<font size=""1"">читать дальше</font></a><br><br>" +
                 "</td>" +
                 "</tr>";
            }
            html += "</table><br>" +
            @"<p align=""center"">" + "</font>" + "</body>" + "</html>";
            webBrowser1.NavigateToString(html);
        }

        private void favotitesBox_Loaded(object sender, RoutedEventArgs e)
        {
            updateFavorites();
        }

        private void favotitesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (favotitesBox.SelectedItem != null)
            {
                string Uri = ((ComboBoxItem)favotitesBox.SelectedItem).Content.ToString();
                CreateNewChanel(Uri);
            }
            else
            {
                MessageBox.Show("Пожалуйста выберите канал!");
            }
        }
        
        public void updateFavorites()
        {
            favotitesBox.Items.Clear();
            foreach (var site in user.FavoriteSites.ToList())
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = site.Url;
                favotitesBox.Items.Add(comboBoxItem);
            }

        }
        public void CreateNewChanel(string url)
        {
            example = new RSSChannel(url);
            listBox1.Items.Clear();
            int count = 0;
            foreach (RSSItem a in example.Items)
            {

                listBox1.Items.Insert(count, count + 1 + ". " + a.title + Environment.NewLine);
                count++;
            }
            generateHtml(example);
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            ThemeChange.Change("Pesimistic.xaml");
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ThemeChange.Change("Optimistic.xaml");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Entry entry = new Entry();
            entry.Show();
            
        }
        public void HideScriptErrors(WebBrowser wb, bool Hide)
        {
            FieldInfo fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiComWebBrowser == null) return;
            object objComWebBrowser = fiComWebBrowser.GetValue(wb);
            if (objComWebBrowser == null) return;
            objComWebBrowser.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] { Hide });
        }
        public bool isFavorite(string uri)
        {
            foreach (var site in user.FavoriteSites.ToList())
            {
                if (site.Url == uri)
                {
                    return true;
                }
            }
            return false;
        }

        private void Add_Favorite(object sender, RoutedEventArgs e)
        {
            FavoriteSite favoriteSite = new FavoriteSite();
            if (example.UrlOfChannel != null && isFavorite(example.UrlOfChannel) == false)
            {
                favoriteSite.Url = example.UrlOfChannel;
                foreach (var User in reader.Users.ToList())
                {
                    if (User.Id == user.Id)
                    {
                        user.FavoriteSites.Add(favoriteSite);
                        User.FavoriteSites.Add(favoriteSite);
                        reader.SaveChanges();
                    }
                }
               
                updateFavorites();
            }
            else
            {
                MessageBox.Show("Канала не выбран или уже в закладках");
            }

        }

        private void Remove_Favorite(object sender, RoutedEventArgs e)
        {
           
            if (example.UrlOfChannel != null && isFavorite(example.UrlOfChannel) == true)
            {
                foreach (var site in reader.Favorites.ToList())
                {
                    if (site.Url == example.UrlOfChannel)
                    {
                        reader.Favorites.Remove(site);
                        foreach (var a in user.FavoriteSites.ToList())
                        {
                            if (site.Id == a.Id)
                            {
                                user.FavoriteSites.Remove(a);
                                updateFavorites();
                            }
                        }
                        reader.SaveChanges();
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Канала не выбран или его нет в закладках");
            }
        }

        private void Save_Channel(object sender, RoutedEventArgs e)
        {
            if (html.Length != 0)
                using (StreamWriter sw = new StreamWriter("Channel.html", false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(html);
                    MessageBox.Show("Канал сохранен!");
                }
            else
            {
                MessageBox.Show("Канал не выбран!");
            }

        }
    }
}
