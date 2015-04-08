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
    /// Interaction logic for HomeStart.xaml
    /// </summary>
    public partial class HomeStart : UserControl
    {
        HomeStartViewModel vm;
        public HomeStart()
        {
            InitializeComponent();
            vm = new HomeStartViewModel();
            this.DataContext = vm;
        }               

        private void inPassword_KeyUp(object sender, KeyEventArgs e)
        {
            vm.Password = inPassword.Password;
        }
    }
}
