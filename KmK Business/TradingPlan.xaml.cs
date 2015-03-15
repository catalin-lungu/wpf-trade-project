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
    /// Interaction logic for TradingPlan.xaml
    /// </summary>
    public partial class TradingPlan : UserControl
    {
        TradingPlanViewModel vm;
        public TradingPlan()
        {
            InitializeComponent();
            vm = new TradingPlanViewModel();
            this.DataContext = vm;
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is Model.Plan)
            {
                vm.SelectedPlan = e.NewValue as Model.Plan;
                vm.TradingPlanItemTestVisibility = true;
            }
            else if (e.NewValue is Model.TradingPlans)
            {
                vm.SelectedTradingPlan = e.NewValue as Model.TradingPlans;
                vm.TradingPlanMainTestVisibility = true;
            }
        }
    }
}
