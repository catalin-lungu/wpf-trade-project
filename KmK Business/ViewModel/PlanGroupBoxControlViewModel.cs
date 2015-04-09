using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KmK_Business.Model;

namespace KmK_Business.ViewModel
{
    class PlanGroupBoxControlViewModel : ObservableObject
    {
        private string testPlanName;

        public string TestPlanName
        {
            get { return testPlanName; }
            set 
            { 
                testPlanName = value;
                RaisePropertyChangedEvent("TestPlanName");
            }
        }

        private int winsCount;

        public int WinsCount
        {
            get { return winsCount; }
            set { winsCount = value; }
        }
        private int winsPips;

        public int WinsPips
        {
            get { return winsPips; }
            set { winsPips = value; }
        }
        private int lossesCount;

        public int LossesCount
        {
            get { return lossesCount; }
            set { lossesCount = value; }
        }
        private int lossesPips;

        public int LossesPips
        {
            get { return lossesPips; }
            set { lossesPips = value; }
        }
        private int balanceCount;

        public int BalanceCount
        {
            get { return balanceCount; }
            set { balanceCount = value; }
        }
        private int balancePips;

        public int BalancePips
        {
            get { return balancePips; }
            set { balancePips = value; }
        }


        public PlanGroupBoxControlViewModel(Plan plan)
        {
            TestPlanName = plan.Name + " " + App.Current.TryFindResource("performanceToDate");
        }
    }
}
