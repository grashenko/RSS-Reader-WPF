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
using System.Windows.Threading;

namespace RSSreaderWPF
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        DispatcherTimer timer;
        private ReaderContext reader = new ReaderContext();
        public RegistrationWindow()
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

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                UserModel user = new UserModel();
                user.Login = login.Text;
                user.Password = Hash.Generate(password.Password);
                reader.Users.Add(user);
                reader.SaveChanges();
                MessageBox.Show("Пользователь успешно зарегистрирован!");
                Entry entry = new Entry();
                entry.Show();
                this.Close();
                
            }
        }
        public bool Validation()
        {
            if (login.Text.Length != 0 && password.Password.Length != 0)
            {

                foreach (var user in reader.Users.ToList())
                {
                    if (user.Login == login.Text)
                    {
                        MessageBox.Show("Пользователь с таким именем уже есть!");
                        return false;
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
                return false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Entry ent = new Entry();
            ent.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Entry entry = new Entry();
            entry.Show();
        }
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            ThemeChange.Change("Pesimistic.xaml");
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ThemeChange.Change("Optimistic.xaml");
        } 
    }
}
