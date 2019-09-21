using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для Entry.xaml
    /// </summary>
    public partial class Entry : Window
    {
        DispatcherTimer timer;
        private ReaderContext reader = new ReaderContext();
        public Entry()
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

        private void Entry_Click(object sender, RoutedEventArgs e)
        {

            if (!Validation())
            {
                MessageBox.Show("Неверный логин или пароль");
            }
            
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }
        public bool Validation()
        {
            if (login.Text.Length != 0 && password.Password.Length != 0)
            {
                foreach (var user in reader.Users.ToList())
                {
                    if (user.Login == login.Text && user.Password == Hash.Generate(password.Password))
                    {
                        MessageBox.Show("Вход выполнен!");
                        UserWindow userWindow = new UserWindow(user);
                        userWindow.Show();
                        this.Close();
                        return true;
                    }
                }
                return false;
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
                return false;
            }
        }

        private void Empty_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
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
