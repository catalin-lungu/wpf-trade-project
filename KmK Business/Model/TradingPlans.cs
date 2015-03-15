using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmK_Business.Model
{
    public class TradingPlans
    {
        private string name ;
        public string Name
        { 
            get { return this.name; }  
        }

        private ObservableCollection<Plan> plans = new ObservableCollection<Plan>();

        public ObservableCollection<Plan> Plans
        {
            get { return plans; }
            set { plans = value; }
        }

        public TradingPlans(string name)
        {
            this.name = name;
        }

    }
}
