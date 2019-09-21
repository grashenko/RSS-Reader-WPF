using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace RSSreaderWPF
{
    public static class ThemeChange
    {
        public static void Change(string theme)
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri("Theme/Theme."+theme, UriKind.Relative);
            ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
                                          where d.Source != null && d.Source.OriginalString.StartsWith("Theme/Theme.")
                                          select d).First();
            if (oldDict != null)
            {
                int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(dict);
            }
        }
    }
}
