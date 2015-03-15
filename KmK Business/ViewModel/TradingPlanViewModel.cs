using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using KmK_Business.Model;

namespace KmK_Business.ViewModel
{
    class TradingPlanViewModel : ObservableObject
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

        private string topStatusNavigator;

        public string TopStatusNavigator
        {
            get { return topStatusNavigator; }
            set 
            {                 
                topStatusNavigator = value;             
                RaisePropertyChangedEvent("TopStatusNavigator");
            }
        }

        private bool tradingPlanMainTestVisibility = false;
        public bool TradingPlanMainTestVisibility
        {
            get { return tradingPlanMainTestVisibility; }
            set
            {
                if (value)
                {
                    TradingPlanItemTestVisibility = false;
                }
                tradingPlanMainTestVisibility = value;
                RaisePropertyChangedEvent("TradingPlanMainTestVisibility");
            }
        }

        private bool tradingPlanItemTestVisibility = false;
        public bool TradingPlanItemTestVisibility
        {
            get { return tradingPlanItemTestVisibility; }
            set
            {
                if (value)
                {
                    TradingPlanMainTestVisibility = true;
                }
                tradingPlanItemTestVisibility = value;
                RaisePropertyChangedEvent("TradingPlanItemTestVisibility");
            }
        }

        private ObservableCollection<TradingPlans> treeSource = new ObservableCollection<TradingPlans>();
        public ObservableCollection<TradingPlans> TreeSource
        {
            get 
            {
                return treeSource;
            }
            set
            {
                treeSource = value;
                RaisePropertyChangedEvent("TreeSource");
            }
        }

        private Plan selectedPlan;
        public Plan SelectedPlan 
        {
            get { return selectedPlan; }
            set 
            { 
                selectedPlan = value;
                RaisePropertyChangedEvent("SelectedPlan");
            }
        }

        private TradingPlans selectedTradingPlan;
        public TradingPlans SelectedTradingPlan 
        {
            get { return selectedTradingPlan; }
            set 
            { 
                selectedTradingPlan = value;
                RaisePropertyChangedEvent("SelectedTradingPlan");
            }
        }

        public TradingPlanViewModel()
        {
            MenuNavigator = new MenuNavigator();
            List<Plan> plans = new List<Plan>();
            plans.Add(new Plan() { Name = "plan1", IsTest = false });
            plans.Add(new Plan() { Name = "test1", IsTest = true });
            plans.Add(new Plan() { Name = "test2", IsTest = true });


            TradingPlans vtp = new TradingPlans((string)App.Current.TryFindResource("validatedTradingPlan"));
            foreach (var p in plans)
            {
                if (!p.IsTest)
                {
                    vtp.Plans.Add(p);
                }
            }
            TreeSource.Add(vtp);

            TradingPlans ttp = new TradingPlans((string)App.Current.TryFindResource("testTradingPlans"));
            foreach (var tp in plans)
            {
                if (tp.IsTest)
                {
                    ttp.Plans.Add(tp);
                }
            }
            TreeSource.Add(ttp);

        }


    }
}
