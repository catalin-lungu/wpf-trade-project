using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KmK_Business.Model;

namespace KmK_Business.ViewModel
{
    public class AccountGroupBoxControlViewModel : ObservableObject
    {
        private string accNameNumber;
        public string AccNameNumber
        {
            get { return accNameNumber; }
            set 
            { 
                accNameNumber = value;
                RaisePropertyChangedEvent("AccNameNumber");
            }
        }

        private string brokerName;
        public string BrokerName
        {
            get { return brokerName; }
            set 
            { 
                brokerName = value;
                RaisePropertyChangedEvent("BrokerName");
            }
        }

        private AccountOverview accountOverview;

        public AccountOverview AccountOverviewObject
        {
            get { return accountOverview; }
            set { accountOverview = value;
            RaisePropertyChangedEvent("AccountOverviewObject");
            }
        }

        public AccountGroupBoxControlViewModel(Account account)
        {
            AccNameNumber = account.Name;
            BrokerName = "broker name";
            AccountOverviewObject = new AccountOverview();

            using (var context = new KmKContext(App.DBConnectionString))
            {
                HashSet<DateTime> days = new HashSet<DateTime>();
                var acc = context.Account.First(item => item.Id == account.Id);
                if (acc != null)
                {
                    foreach (var item in acc.TradingJournal)
                    {
                        days.Add(item.EntryDate.Date);
                    }
                    AccountOverviewObject.History = days.Count;
                }
            }

        }

    }

    public class AccountOverview
    {
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
        private double winsAmounts;
        public double WinsAmounts
        {
            get { return winsAmounts; }
            set { winsAmounts = value; }
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
        private double lossesAmouts;
        public double LossesAmounts
        {
            get { return lossesAmouts; }
            set { lossesAmouts = value; }
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
        private double balanceAmounts;
        public double BalanceAmounts
        {
            get { return balanceAmounts; }
            set { balanceAmounts = value; }
        }

        private double deposits;
        public double Deposits
        {
            get { return deposits; }
            set { deposits = value; }
        }
        private double withdrawals;
        public double Withdrawals
        {
            get { return withdrawals; }
            set { withdrawals = value; }
        }
        private double net;
        public double Net
        {
            get { return net; }
            set { net = value; }
        }
        private double accBalance;
        public double AccBalance
        {
            get { return accBalance; }
            set { accBalance = value; }
        }

        private int days;
        public int Daily
        {
            get { return days; }
            set { days = value; }
        }
        private int weekly;
        public int Weekly
        {
            get { return weekly; }
            set { weekly = value; }
        }
        private int monthly;
        public int Monthly
        {
            get { return monthly; }
            set { monthly = value; }
        }
        private int yearly;
        public int Yearly
        {
            get { return yearly; }
            set { yearly = value; }
        }

        private int history;
        public int History
        {
            get { return history; }
            set { history = value; }
        }
        private double profitFactor;
        public double ProfitFactor
        {
            get { return profitFactor; }
            set { profitFactor = value; }
        }

    }
}
