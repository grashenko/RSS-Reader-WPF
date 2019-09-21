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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Windows.Threading;

namespace RSSreaderWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();

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
        private void button1_Click(object sender, EventArgs e)
        {
            example = new RSSChannel(textBox1.Text);
            listBox1.Items.Clear();
            
            int count = 0;
            foreach (RSSItem a in example.Items)
            {

                listBox1.Items.Insert(count, count + 1 + ". " + a.title + Environment.NewLine);
                count++;
            }
            generateHtml(example);
        }

        bool generateHtml(RSSChannel channel)
        {
            try
            {
                html = "<html>" + "<head>" + "<meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>" + "<style type='text/css'>" + "A{color:#483D8B; text-decoration:none; font:Verdana;}" + "pre{font-family:courier;color:#000000;" +
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

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.NavigateToString(html);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"(\w*)" + textBox2.Text + @"(\w*)");
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
            webBrowser1.NavigateToString( "<html>" + "<head>" + "<meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>" + "<style type='text/css'>" + "A{color:#483D8B; text-decoration:none; font:Verdana;}" + "pre{font-family:courier;color:#000000;" +
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

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (html != null)
            {
                webBrowser1.NavigateToString(html);
            }
        }

       
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Entry entry = new Entry();
            entry.Show();
        }
        private void ChangeTheme_Checked(object sender, RoutedEventArgs e)
        {

            ThemeChange.Change("Pesimistic.xaml");
        }

        private void ChangeTheme_Unchecked(object sender, RoutedEventArgs e)
        {
            ThemeChange.Change("Optimistic.xaml");
        }

    }
}
