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

namespace KmK_Business
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class AccountWindow : Window, IDisposable
    {
        string accountName = "";
        bool issDemo = true;
        
        public AccountWindow()
        {
            InitializeComponent();
        }
        public AccountWindow(string name, bool isD)
        {
            InitializeComponent();
            accName.Text = name;
            isDemo.IsChecked = isD;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.accountName = accName.Text;
            issDemo = isDemo.IsChecked != null ? (bool)isDemo.IsChecked : true;
            this.Close();
        }

        public string GetAccountName() { return accountName;}
        public bool GetIsDemo() { return issDemo;}


        public void Dispose()
        {
            this.Close();
        }
    }
}
