using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmK_Business.Model
{
    public class Accounts
    {
        private string name;
        public string Name
        {
            get { return this.name; }
        }

        private ObservableCollection<Account> accounts = new ObservableCollection<Account>();

        public ObservableCollection<Account> AccountsList
        {
            get { return accounts; }
            set { accounts = value;
            //RaisePropertyChangedEvent("AccountsList");
            }
        }

        public Accounts(string name)
        {
            this.name = name;
        }
    }
}
