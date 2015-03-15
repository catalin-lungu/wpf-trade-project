using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KmK_Business.ViewModel
{
    class HomeViewModel : ObservableObject
    {
        private UserControl menuNavigator;

        public UserControl MenuNavigator
        {
            get { return menuNavigator; }
            set
            {
                menuNavigator = value;
                RaisePropertyChangedEvent("MenuNavigator");
            }
        }


        public HomeViewModel()
        {
            MenuNavigator = new MenuNavigator();
        }
    }
}
