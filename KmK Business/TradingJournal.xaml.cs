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
using KmK_Business.ViewModel;

namespace KmK_Business
{
    /// <summary>
    /// Interaction logic for TradingJournal.xaml
    /// </summary>
    public partial class TradingJournal : UserControl
    {
        TradingJournalViewModel vm;
        public TradingJournal()
        {
            InitializeComponent();
            vm = new TradingJournalViewModel();
            this.DataContext = vm;
        }
        

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is Model.Account)
            {
                vm.SelectedAccount = e.NewValue as Model.Account;
                vm.AccountsItemTestVisibility = true;
            }
            else if (e.NewValue is Model.Accounts)
            {
                vm.SelectedAccounts = e.NewValue as Model.Accounts;
                vm.AccountMainTestVisibility = true;
            }
        }
    }


}
