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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel vm;
        private MainWindow mw;
        public MainWindow()
        {
            InitializeComponent();

            if (DateTime.Now.Date > new DateTime(2015, 6 , 1))
            {
                MessageBox.Show("This alpha version has expired!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
            else
            {
                mw = this;
                vm = new MainWindowViewModel();
                this.DataContext = vm;
                App.CurrentWindow = new HomeStart();
            }
        }

        public void ChangeWindow(object newControl=null)
        {
            if (newControl != null)
            {
                mw.ContentHolder.Content = newControl;

                if (newControl is Home)
                {
                    vm.VisibilityEdit = true;
                    vm.VisibilityMenuItem = false;
                    vm.WindowTitle = App.DBName;
                }
                else if (newControl is TradingPlan ||
                        newControl is TradingJournal)
                {
                    vm.VisibilityEdit = true;
                    vm.VisibilityMenuItem = true;
                    vm.WindowTitle = App.DBName;
                }
                else
                {
                    vm.VisibilityEdit = false;
                    vm.VisibilityMenuItem = false;
                }
                

            }
            else 
            {
                mw.ContentHolder.Content = new HomeStart();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ChangeWindow(new HomeStart());
        }
        

    }
}
