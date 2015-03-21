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
using KmK_Business.Model;
using KmK_Business.ViewModel;

namespace KmK_Business
{
    /// <summary>
    /// Interaction logic for AccountGroupBoxControl.xaml
    /// </summary>
    public partial class AccountGroupBoxControl : UserControl
    {
        AccountGroupBoxControlViewModel vm;
        public AccountGroupBoxControl(Account account)
        {
            InitializeComponent();
            vm = new AccountGroupBoxControlViewModel(account);
            this.DataContext = vm;
        }
    }
}
