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
using System.Threading;
namespace RSSreaderWPF
{
    /// <summary>
    /// Логика взаимодействия для Loading.xaml
    /// </summary>
    public partial class Loading : Window
    {
        public ReaderContext context = new ReaderContext();
        public Loading()
        {
            Load();
            InitializeComponent();
        }
        public async void Load()
        {
            var result = await EntryDatabase();
            this.Close();
        }
        public Task<List<UserModel>> EntryDatabase()
        {
            return Task.Run(() =>
            {
                return context.Users.ToList();
            });
        }
    }
}
