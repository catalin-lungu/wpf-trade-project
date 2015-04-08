using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KmK_Business
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string DBConnectionString { get; set; }

        public static string DBName
        {
            get 
            {
                return ((MainWindow)System.Windows.Application.Current.MainWindow).vm.DatabaseName;
            }
            set 
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).vm.DatabaseName = value ;
            }
        }

        public static string ContextToolTip
        {
            set 
            { 
                ((MainWindow)System.Windows.Application.Current.MainWindow).vm.ContextToolTips = value;
                ((MainWindow)System.Windows.Application.Current.MainWindow).contextToolTips.UpdateLayout();
            }
            
        }

        public static object CurrentWindow
        {
            set
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).ChangeWindow(value);
            }
        }

        public static void SetLanguageDictionary(string cult = "")
        {
            if (string.IsNullOrEmpty(cult))
            {
                cult = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();
            }

            ResourceDictionary dict = new ResourceDictionary();
            switch (cult)
            {                
                case "en-US":
                    dict.Source = new Uri("pack://application:,,,/KmK Business;component/languages/Dictionary.en-UK.xaml", UriKind.RelativeOrAbsolute);
                    break;
                default:
                    dict.Source = new Uri("pack://application:,,,/KmK Business;component/languages/Dictionary.en-UK.xaml", UriKind.RelativeOrAbsolute);
                    break;
            }
            App.Current.Resources.MergedDictionaries.Add(dict);
        }
    }
}
