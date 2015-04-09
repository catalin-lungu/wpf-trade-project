using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using KmK_Business.Model;
using ServiceStack.OrmLite;
//using SqliteORM;

namespace KmK_Business.ViewModel
{
    class TradingJournalViewModel : ObservableObject
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

        private string topStatusNavigator = "TRADING JOURNAL";
            
        public string TopStatusNavigator
        {
            get { return topStatusNavigator; }
            set
            {
                topStatusNavigator = value;
                RaisePropertyChangedEvent("TopStatusNavigator");
            }
        }

        private bool accountMainTestVisibility = false;
        public bool AccountMainTestVisibility
        {
            get { return accountMainTestVisibility; }
            set
            {
                if (value)
                {
                    AccountsItemTestVisibility = false;
                }
                accountMainTestVisibility = value;
                RaisePropertyChangedEvent("AccountMainTestVisibility");
            }
        }

        private bool accountsItemTestVisibility = false;
        public bool AccountsItemTestVisibility
        {
            get { return accountsItemTestVisibility; }
            set
            {
                if (value)
                {
                    AccountMainTestVisibility = false;
                }
                accountsItemTestVisibility = value;
                RaisePropertyChangedEvent("AccountsItemTestVisibility");
            }
        }

        private bool journalVisibility = true;
        public bool JournalVisibility
        {
            get { return journalVisibility; }
            set 
            {
                if (value)
                {
                    SummaryVisibility = false;
                }
                journalVisibility = value;
                RaisePropertyChangedEvent("JournalVisibility");
            }
        }

        private bool summaryVisibility = false;
        public bool SummaryVisibility
        {
            get { return summaryVisibility; }
            set 
            {
                if (value)
                {
                    JournalVisibility = false;
                }
                summaryVisibility = value;
                RaisePropertyChangedEvent("SummaryVisibility");
            }
        }


        private ObservableCollection<Accounts> treeSource = new ObservableCollection<Accounts>();
        public ObservableCollection<Accounts> TreeSource
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

        private Account selectedAccount;
        public Account SelectedAccount
        {
            get { return selectedAccount; }
            set
            {
                selectedAccount = value;
                UpdateGrid();
                RaisePropertyChangedEvent("SelectedAccount");
            }
        }

        private Accounts selectedAccounts;
        public Accounts SelectedAccounts
        {
            get { return selectedAccounts; }
            set
            {
                selectedAccounts = value;
                AccountControls.Clear();
                foreach (var account in selectedAccounts.AccountsList)
                {
                    AccountControls.Add(new AccountGroupBoxControl(account));
                }
                RaisePropertyChangedEvent("AccountControls");
                RaisePropertyChangedEvent("SelectedAccounts");
            }
        }

        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set 
            { 
                selectedDate = value;
                UpdateGrid();
                RaisePropertyChangedEvent("SelectedDate");
            }
        }

        private ObservableCollection<AccountGroupBoxControl> accountControls = new ObservableCollection<AccountGroupBoxControl>();
        public ObservableCollection<AccountGroupBoxControl> AccountControls
        {
            get { return accountControls; }
            set { accountControls = value; }
        }

        private ObservableCollection<TradingJournalModel> tradingJournal;
        public ObservableCollection<TradingJournalModel> TradingJournal
        {
            get { return tradingJournal; }
            set 
            {
                tradingJournal = value;
                UpdateTotals();
                RaisePropertyChangedEvent("TradingJournal");
            }
        }

        private TradingJournalModel rowTradingJournal;
        public TradingJournalModel RowTradingJournal
        {
            get { return rowTradingJournal; }
            set 
            { 
                rowTradingJournal = value;            
                RaisePropertyChangedEvent("SelectedDate");
            }
        }

        private Summary summaryObject;
        public Summary SummaryObject
        {
            get { return summaryObject; }
            set { summaryObject = value;
            RaisePropertyChangedEvent("SummaryObject");
            }
        }
        
        Accounts accLive;
        Accounts accDemo;
        public TradingJournalViewModel()
        {
            MenuNavigator = new MenuNavigator();
            
            //List<Account> accs = new List<Account>();
            //accs.Add(new Account() { Name = "live1", IsDemo = false });
            //accs.Add(new Account() { Name = "demo1", IsDemo = true });
            //accs.Add(new Account() { Name = "demo2", IsDemo = true });

            //accs.ElementAt(0).TradingJournal.Add(new TradingJournalModel() { EntryDate = new DateTime(2015, 3, 21) });
            //accs.ElementAt(0).TradingJournal.Add(new TradingJournalModel() { EntryDate = new DateTime(2015, 3, 21,22,12,24) });
            //accs.ElementAt(0).TradingJournal.Add(new TradingJournalModel() { EntryDate = new DateTime(2015, 3, 22) });


            accLive = new Accounts((string)App.Current.TryFindResource("liveAccounts"));
            //foreach (var p in accs)
            //{
            //    if (!p.IsDemo)
            //    {
            //        accLive.AccountsList.Add(p);
            //    }
            //}
            //TreeSource.Add(accLive);

            accDemo = new Accounts((string)App.Current.TryFindResource("demoAccounts"));
            //foreach (var tp in accs)
            //{
            //    if (tp.IsDemo)
            //    {
            //        accDemo.AccountsList.Add(tp);
            //    }
            //}
            //TreeSource.Add(accDemo);

            using (var context = new KmKContext(App.DBConnectionString))
            {
                foreach (var acc in context.Account.ToList())
                {
                    if(acc.IsDemo)
                    {
                        accDemo.AccountsList.Add(acc);
                    }
                    else
                    {
                        accLive.AccountsList.Add(acc);
                    }                    
                }
                TreeSource.Add(accLive);
                TreeSource.Add(accDemo);
            }

        }

        void UpdateGrid()
        {

            //string cs = "Data Source=" + App.DBConnectionString;

            //using (SQLiteConnection conn = new SQLiteConnection(App.DBConnectionString))
            //{
            //    using (SQLiteCommand cmd = new SQLiteCommand())
            //    {
            //        cmd.Connection = conn;
            //        conn.Open();

            //        SQLiteHelper sh = new SQLiteHelper(cmd);

            //        DataTable dt = sh.Select("select * from TradingJournalModel ");
            //        //where entryDate = @aaa ;",
            //        //new SQLiteParameter[] { 
            //        //    new SQLiteParameter("@aaa", SelectedDate.Date)
            //        //});

            //        //var myEnumerable = myDataTable.AsEnumerable();

            //        //List<MyClass> myClassList =
            //        //    (from item in myEnumerable
            //        //     select new MyClass
            //        //     {
            //        //         MyClassProperty1 = item.Field<string>("DataTableColumnName1"),
            //        //         MyClassProperty2 = item.Field<string>("DataTableColumnName2")
            //        //     }).ToList();

            //        //List<TradingJournalModel> rows = dt.Rows.Cast<TradingJournalModel>().ToList();
            //        //TradingJournal = new ObservableCollection<TradingJournalModel>(rows);
            //        conn.Close();
            //    }
            //}

            //cnn.Close();
            using (var context = new KmKContext(App.DBConnectionString))
            {
                //var collection1 = context.AdminDB.Where(item => item.Id == 1);
                //var collection = context.TradingJournalModel.ToList();//.Where(item => item.EntryDate.Date.Year == SelectedDate.Date.Year);

                var collection = new List<TradingJournalModel>();
                if (SelectedAccount != null)
                {
                    var account = context.Account.First(acc => acc.Id == SelectedAccount.Id);
                    if (account != null)
                    {
                        foreach (var c in account.TradingJournal)
                        {
                            if (c.EntryDate.Date == SelectedDate.Date)
                            {
                                collection.Add(c);
                            }
                        }
                    }
                        
                    TradingJournal = new ObservableCollection<TradingJournalModel>(collection);
                }
            }

        }

        #region Totals
        private int totalTrades;

        public int TotalTrades
        {
            get { return totalTrades; }
            set { totalTrades = value;
            RaisePropertyChangedEvent("TotalTrades");
            }
        }

        private int netPL;

        public int NetPL
        {
            get { return netPL; }
            set { netPL = value;
            RaisePropertyChangedEvent("NetPL");
            }
        }

        private int charges;

        public int Charges
        {
            get { return charges; }
            set { charges = value;
            RaisePropertyChangedEvent("Charges");
            }
        }

        private int grossPL;

        public int GrossPL
        {
            get { return grossPL; }
            set { grossPL = value;
            RaisePropertyChangedEvent("GrossPL");
            }
        }


        private int wonPips;
        public int WonPips
        {
            get { return wonPips; }
            set { wonPips = value;
            RaisePropertyChangedEvent("WonPips");
            }
        }

        private int lostPips;

        public int LostPips
        {
            get { return lostPips; }
            set { lostPips = value;
            RaisePropertyChangedEvent("LostPips");
            }
        }


        void UpdateTotals()
        {
            NetPL = 0;
            Charges = 0;
            GrossPL = 0;
            WonPips = 0;
            LostPips = 0;

            TotalTrades = TradingJournal.Count;
            foreach (var item in TradingJournal)
            {
                NetPL += Convert.ToInt32(item.NetPL);
                Charges += item.Commission;
                GrossPL += item.GrossPL;
                WonPips += item.WonPips;
                LostPips += item.LostPips;
            }
        }
        #endregion

        private DelegateCommand journalCommand;
        private DelegateCommand summaryCommand;
        private DelegateCommand addNewTradeCommand;
        private DelegateCommand deteleTradeCommand;
        private DelegateCommand saveTradeCommand;
        private DelegateCommand cancelTradeCommand;
        
        private DelegateCommand addAccountCommand;
        private DelegateCommand editAccountCommand;
        private DelegateCommand deleteAccountCommand;
        private DelegateCommand printScreenCommand;

        public ICommand JournalCommand
        {
            get
            {
                if (journalCommand == null)
                {
                    journalCommand = new DelegateCommand(Journal);
                }
                return journalCommand;
            }
        }

        public ICommand SummaryCommand
        {
            get
            {
                if (summaryCommand == null)
                {
                    summaryCommand = new DelegateCommand(Summary);
                }
                return summaryCommand;
            }
        }

        public ICommand AddNewTradeCommand
        {
            get
            {
                if (addNewTradeCommand == null)
                {
                    addNewTradeCommand = new DelegateCommand(AddNewTrade);
                }
                return addNewTradeCommand;
            }
        }

        public ICommand DeleteTradeCommand
        {
            get
            {
                if (deteleTradeCommand == null)
                {
                    deteleTradeCommand = new DelegateCommand(DeleteTrade);
                }
                return deteleTradeCommand;
            }
        }

        public ICommand SaveTradeCommand
        {
            get
            {
                if (saveTradeCommand == null)
                {
                    saveTradeCommand = new DelegateCommand(SaveTrade);
                }
                return saveTradeCommand;
            }
        }

        public ICommand CancelTradeCommand
        {
            get
            {
                if (cancelTradeCommand == null)
                {
                    cancelTradeCommand = new DelegateCommand(CancelTrade);
                }
                return cancelTradeCommand;
            }
        }

        public ICommand AddAccountCommand
        {
            get
            {
                if (addAccountCommand == null)
                {
                    addAccountCommand = new DelegateCommand(AddAccount);
                }
                return addAccountCommand;
            }
        }

        public ICommand EditAccountCommand
        {
            get
            {
                if (editAccountCommand == null)
                {
                    editAccountCommand = new DelegateCommand(EditAccount);
                }
                return editAccountCommand;
            }
        }

        public ICommand DeleteAccountCommand
        {
            get
            {
                if (deleteAccountCommand == null)
                {
                    deleteAccountCommand = new DelegateCommand(DeleteAccount);
                }
                return deleteAccountCommand;
            }
        }

        public ICommand PrintScreenCommand
        {
            get
            {
                if (printScreenCommand == null)
                {
                    printScreenCommand = new DelegateCommand(PrintSreen);
                }
                return printScreenCommand;
            }
        }
              

        void Journal()
        {
            JournalVisibility = true;
        }

        void Summary()
        {
            SummaryVisibility = true;
            SummaryObject = new Summary(TradingJournal);
        }

        void AddNewTrade()
        {
            if (SelectedAccount != null)
            {
                DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                dateTime = dateTime.AddMilliseconds(-dateTime.Millisecond);
                TradingJournalModel tjm = new TradingJournalModel() { EntryDate = dateTime };
                if (SelectedAccount != null)
                {
                    tjm.AccountId = SelectedAccount.Id;
                }
                using (var context = new KmKContext(App.DBConnectionString))
                {
                    context.TradingJournalModel.Add(tjm);
                    context.SaveChanges();
                   
                }
                //UpdateGrid();
                SelectedDate = dateTime;
            }
        }

        void DeleteTrade()
        {
            if (SelectedAccount != null && RowTradingJournal != null)
            {
                //SelectedAccount.TradingJournal.Remove(RowTradingJournal);
                using (var context = new KmKContext(App.DBConnectionString))
                {
                    context.TradingJournalModel.Remove(RowTradingJournal);
                    context.SaveChanges();

                }
                UpdateGrid();
            }
        }

        void SaveTrade()
        {
            using (var context = new KmKContext(App.DBConnectionString))
            {
                foreach (var tjm in TradingJournal)
                {
                    context.TradingJournalModel.Attach(tjm);
                    context.Entry(tjm).State = System.Data.Entity.EntityState.Modified;
                }               

                context.SaveChanges();
            }
            UpdateTotals();
            //db.Users.Attach(updatedUser);
            //var entry = db.Entry(updatedUser);
            //entry.Property(e => e.Email).IsModified = true;
            //// other changed properties
            //db.SaveChanges();
        }

        void CancelTrade()
        {
            UpdateGrid();
        }

        void AddAccount()
        {            
                using (var accWindow = new AccountWindow())
                {
                    accWindow.ShowDialog();

                    Account acc = new Account();
                                       
                    acc.IsDemo = accWindow.GetIsDemo();
                    acc.Name = accWindow.GetAccountName();

                    using (var context = new KmKContext(App.DBConnectionString))
                    {                        
                        context.Account.Add(acc);
                        context.SaveChanges();
                    }

                    if (acc.IsDemo)
                    {
                        accDemo.AccountsList.Add(acc);
                    }
                    else
                    {
                        accLive.AccountsList.Add(acc);
                    }                    
                }
                RaisePropertyChangedEvent("AccountControls");
                RaisePropertyChangedEvent("SelectedAccounts");
                RaisePropertyChangedEvent("TreeSource");
           
        }

        void EditAccount()
        {
            if (SelectedAccount != null)
            {
                using (var accWindow = new AccountWindow(SelectedAccount.Name, SelectedAccount.IsDemo))
                {
                    accWindow.ShowDialog();

                    if (SelectedAccount.IsDemo)
                    {
                        accDemo.AccountsList.Remove(SelectedAccount);
                    }
                    else
                    {
                        accLive.AccountsList.Remove(SelectedAccount);
                    }

                    SelectedAccount.IsDemo = accWindow.GetIsDemo();
                    SelectedAccount.Name = accWindow.GetAccountName();

                    using (var context = new KmKContext(App.DBConnectionString))
                    {
                        context.Account.Attach(SelectedAccount);
                        context.Entry(SelectedAccount).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }


                    if (SelectedAccount.IsDemo)
                    {
                        accDemo.AccountsList.Add(SelectedAccount);
                    }
                    else
                    {
                        accLive.AccountsList.Add(SelectedAccount);
                    }
                }
                RaisePropertyChangedEvent("SelectedAccount");
                RaisePropertyChangedEvent("SelectedAccounts");
                RaisePropertyChangedEvent("AccountControls");
                RaisePropertyChangedEvent("TreeSource");
            }
            else
            {
                System.Windows.MessageBox.Show("Select an account!");
            }
        }

        void DeleteAccount()
        {
            if (SelectedAccount != null)
            {
                using (var context = new KmKContext(App.DBConnectionString))
                {
                    var acc = context.Account.First(item => item.Id == SelectedAccount.Id);
                    if (acc != null)
                    {
                        context.Account.Remove(acc);

                        context.SaveChanges();
                    }
                    if (SelectedAccount.IsDemo)
                    {
                        accDemo.AccountsList.Remove(SelectedAccount);
                    }
                    else
                    {
                        accLive.AccountsList.Remove(SelectedAccount);
                    }
                    SelectedAccount = null;
                    RaisePropertyChangedEvent("AccountControls");
                    RaisePropertyChangedEvent("TreeSource");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Select an account!");
            }
        }

        private void PrintSreen()
        {
            try
            {
                WindowPrintScreen win = new WindowPrintScreen();
                win.WindowState = System.Windows.WindowState.Maximized;
                win.ShowDialog();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Some error has occured!");
            }
        }
    }

    public class Summary
    {
        public Summary(ObservableCollection<TradingJournalModel> items)
        {
            foreach (var item in items)
            {
                Buys += 0;
                BuysWon += 0;
                BuysLost += 0;

                Sells += 0;
                SellsWon += 0;
                SellsLost += 0;

                Scalps += 0;
                ScalpsWon += 0;
                ScalpsLost += 0;

                MasDrawDown += 0;
                MasDrawDownPercent += 0;

                StartingBalance += 0;
                CurrentBalance += 0;
                PlusMinus += 0;

                LeverageUsed += 0;
                AverageRiskPercentUsed += 0;
                AllocatedRisk += 0;

                TotalTradesCount += 0;
                WinCount += 0;
                LossCount += 0;
                WinPercent += 0;
                LostPercent += 0;
                WinLossRatio += 0;

                WonPips += item.WonPips;
                LostPips += item.LostPips;
                WLPipsBalance += item.WonPips - item.LostPips;
                WonDolar += 0;
                LostDolar += 0;
                TradingCostDolar += 0;
                WLBalance = WonDolar - (LostDolar + TradingCostDolar);
            }
        }

        #region col 1
        private int buys;
        public int Buys
        {
            get { return buys; }
            set { buys = value; }
        }
        private int buysWon;
        public int BuysWon
        {
            get { return buysWon; }
            set { buysWon = value; }
        }
        private int buysLost;
        public int BuysLost
        {
            get { return buysLost; }
            set { buysLost = value; }
        }
        #endregion

        #region col 2
        private int sells;
        public int Sells
        {
            get { return sells; }
            set { sells = value; }
        }
        private int sellsWon;
        public int SellsWon
        {
            get { return sellsWon; }
            set { sellsWon = value; }
        }
        private int sellsLost;
        public int SellsLost
        {
            get { return sellsLost; }
            set { sellsLost = value; }
        }
        #endregion

        #region col 3
        private int scalps;
        public int Scalps
        {
            get { return scalps; }
            set { scalps = value; }
        }
        private int scalpsWon;
        public int ScalpsWon
        {
            get { return scalpsWon; }
            set { scalpsWon = value; }
        }
        private int scalpsLost;
        public int ScalpsLost
        {
            get { return scalpsLost; }
            set { scalpsLost = value; }
        }
        #endregion

        #region col 1
        private int swings;
        public int Swings
        {
            get { return swings; }
            set { swings = value; }
        }
        private int swingsWon;
        public int SwingsWon
        {
            get { return swingsWon; }
            set { swingsWon = value; }
        }
        private int swingsLost;
        public int SwingsLost
        {
            get { return swingsLost; }
            set { swingsLost = value; }
        }
        #endregion

        #region col 1
        private int maxDrawDown;
        public int MasDrawDown
        {
            get { return maxDrawDown; }
            set { maxDrawDown = value; }
        }
        private int maxDrawDownPercent;
        public int MasDrawDownPercent
        {
            get { return maxDrawDownPercent; }
            set { maxDrawDownPercent = value; }
        }
        #endregion

        #region col 1
        private int startingBalance;
        public int StartingBalance
        {
            get { return startingBalance; }
            set { startingBalance = value; }
        }
        private int currentBalance;
        public int CurrentBalance
        {
            get { return currentBalance; }
            set { currentBalance = value; }
        }
        private int plusMinus;
        public int PlusMinus
        {
            get { return plusMinus; }
            set { plusMinus = value; }
        }
        #endregion

        #region col 1
        private int leverageUsed;
        public int LeverageUsed
        {
            get { return leverageUsed; }
            set { leverageUsed = value; }
        }
        private int averageRiskPercentUsed;
        public int AverageRiskPercentUsed
        {
            get { return averageRiskPercentUsed; }
            set { averageRiskPercentUsed = value; }
        }
        private int allocatedRisk;
        public int AllocatedRisk
        {
            get { return allocatedRisk; }
            set { allocatedRisk = value; }
        }
        #endregion

        #region col 1
        private int totalTradesCount;
        public int TotalTradesCount
        {
            get { return totalTradesCount; }
            set { totalTradesCount = value; }
        }
        private int winCount;
        public int WinCount
        {
            get { return winCount; }
            set { winCount = value; }
        }
        private int lossCount;
        public int LossCount
        {
            get { return lossCount; }
            set { lossCount = value; }
        }
        private int winPercent;        
        public int WinPercent
        {
            get { return winPercent; }
            set { winPercent = value; }
        }
        private int lostPercent;
        public int LostPercent
        {
            get { return lostPercent; }
            set { lostPercent = value; }
        }
        private int winLossRatio;
        public int WinLossRatio
        {
            get { return winLossRatio; }
            set { winLossRatio = value; }
        }
        #endregion

        private int wonPips;
        public int WonPips
        {
            get { return wonPips; }
            set { wonPips = value; }
        }
        private int lostPips;
        public int LostPips
        {
            get { return lostPips; }
            set { lostPips = value; }
        }
        private int wlPispBalance;
        public int WLPipsBalance
        {
            get { return wlPispBalance; }
            set { wlPispBalance = value; }
        }
        private double wonDolar;
        public double WonDolar
        {
            get { return wonDolar; }
            set { wonDolar = value; }
        }
        private double lostDolar;
        public double LostDolar
        {
            get { return lostDolar; }
            set { lostDolar = value; }
        }
        private double tradingCostDolar;
        public double TradingCostDolar
        {
            get { return tradingCostDolar; }
            set { tradingCostDolar = value; }
        }
        private double wlBalance;
        public double WLBalance
        {
            get { return wlBalance; }
            set { wlBalance = value; }
        }



    }

   
}
