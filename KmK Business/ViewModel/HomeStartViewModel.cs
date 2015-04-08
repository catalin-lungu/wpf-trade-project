using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KmK_Business.Model;
//using SqliteORM;


namespace KmK_Business.ViewModel
{
    class HomeStartViewModel : ObservableObject
    {

        private string databaseName;
        public string DatabaseName
        {
            get { return databaseName; }
            set
            {
                databaseName = value;
                RaisePropertyChangedEvent("DatabaseName");
            }
        }

        private bool dbSignInVisibility;
        public bool DBSignInVisibility
        {
            get { return dbSignInVisibility; }
            set 
            { 
                dbSignInVisibility = value;
                RaisePropertyChangedEvent("DBSignInVisibility");
            }
        }
        

        public string UserName { get; set; }
        public string Password { get; set; }

        private bool rememberUserName;
        public bool RememberUserName
        {
            get { return rememberUserName; }
            set { rememberUserName = value;
            RaisePropertyChangedEvent("RememberUserName");
            }
        }
        private bool rememberPassword;
        public bool RememberPassword
        {
            get { return rememberPassword; }
            set { rememberPassword = value;
            RaisePropertyChangedEvent("RememberPassword");
            }
        }



        public HomeStartViewModel()
        {
            DBSignInVisibility = false;

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.Username) && Properties.Settings.Default.Username.Length > 0)
            {
                RememberUserName = true;
                UserName = Properties.Settings.Default.Username;
            }
            else
            {
                RememberUserName = false;
            }
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.Password) && Properties.Settings.Default.Password.Length > 0)
            {
                RememberPassword = true;
                Password = Properties.Settings.Default.Password;
            }
            else
            {
                RememberPassword = false;
            }
        }

        private DelegateCommand openDBCommand;
        private DelegateCommand loginCommand;
        private DelegateCommand recoverPasswordCommand;
        private DelegateCommand createDBCommand;

        public ICommand OpenDBCommand
        {
            get
            {
                if (openDBCommand == null)
                {
                    openDBCommand = new DelegateCommand(OpenDB);
                }
                return openDBCommand;
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new DelegateCommand(Login);
                }
                return loginCommand;
            }
        }

        public ICommand RecoverPasswordCommand
        {
            get
            {
                if (recoverPasswordCommand == null)
                {
                    recoverPasswordCommand = new DelegateCommand(RecoverPassword);
                }
                return recoverPasswordCommand;
            }
        }

        public ICommand CreateDBCommand
        {
            get
            {
                if (createDBCommand == null)
                {
                    createDBCommand = new DelegateCommand(CreateDB);
                }
                return createDBCommand;
            }
        }

        private void OpenDB()
        {
            try
            {
                // OpenDB 
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                               
                // Set filter for file extension and default file extension 
                dlg.DefaultExt = ".sqlite";
                dlg.Filter = "Database Files (*.sqlite)|*.sqlite";

                Nullable<bool> result = dlg.ShowDialog();

                // Get the selected file name and display in a TextBox 
                if (result == true)
                {
                    using (var context = new KmKContext("Data Source=" + dlg.FileName))
                    {
                        if (context.AdminDB.Count() > 0)// login required
                        {
                            var user = context.AdminDB.First();
                            if (!string.IsNullOrEmpty(user.Password) || !string.IsNullOrEmpty(user.UserName))
                            {
                                DatabaseName = dlg.SafeFileName;
                                DBSignInVisibility = true;
                            }
                            else // no login
                            {
                                App.CurrentWindow = new Home();
                                App.DBName = dlg.SafeFileName;                                
                            }
                        }
                        else // no login
                        {
                            App.CurrentWindow = new Home();
                            App.DBName = dlg.SafeFileName;
                        }
                        App.DBConnectionString = "Data Source=" + dlg.FileName;
                    }                    
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void Login()
        {
            App.ContextToolTip = "Checking credentials...";
            try
            {
                using (var context = new KmKContext(App.DBConnectionString))
                {
                    var user = context.AdminDB.FirstOrDefault(a => a.UserName.Equals(UserName) && a.Password.Equals(Password));
                    if (user != null)
                    {
                        App.CurrentWindow = new Home();
                        App.DBName = DatabaseName;

                        if (RememberUserName)
                        {
                            Properties.Settings.Default.Username = user.UserName;
                        }
                        else
                        {
                            Properties.Settings.Default.Username = "";
                        }
                        if (RememberPassword)
                        {
                            Properties.Settings.Default.Password = user.UserName;
                        }
                        else
                        {
                            Properties.Settings.Default.Password = "";
                        }
                    }
                    else
                    {
                        App.ContextToolTip = "Wrong credentials...";
                        return;
                    }
                }
            }
            catch
            {                
                System.Windows.MessageBox.Show("An error has accured!");
            }
            App.ContextToolTip = "";
        }

        private void RecoverPassword()
        { }

        private void CreateDB()
        {
            
            try
            {
                string dbFile;
                string pass;
                string username;

                using (var createDB = new CreateDB())
                {
                    createDB.ShowDialog();

                    dbFile = createDB.GetDBFile();
                    username = createDB.GetUsername();
                    pass = createDB.GetPassword();
                }

                if (!string.IsNullOrEmpty(dbFile))
                {
                    App.ContextToolTip = "Creating DB...";
                    SQLiteConnection.CreateFile(dbFile);

                    //create database
                    using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + dbFile))
                    {
                        using (SQLiteCommand cmd = new SQLiteCommand())
                        {
                            cmd.Connection = conn;
                            conn.Open();

                            SQLiteHelper sh = new SQLiteHelper(cmd);

                            SQLiteTable tb = new SQLiteTable("AdminDB");

                            tb.Columns.Add(new SQLiteColumn("id", true));
                            tb.Columns.Add(new SQLiteColumn("username"));
                            tb.Columns.Add(new SQLiteColumn("password"));

                            sh.CreateTable(tb);

                            SQLiteTable tbAccount = new SQLiteTable("Account");
                            tbAccount.Columns.Add(new SQLiteColumn("Id", true));
                            tbAccount.Columns.Add(new SQLiteColumn("Name"));
                            tbAccount.Columns.Add(new SQLiteColumn("IsDemo", ColType.Integer));
                            sh.CreateTable(tbAccount);

                            SQLiteTable tjm = new SQLiteTable("TradingJournalModel");

                            tjm.Columns.Add(new SQLiteColumn("Id", true));
                            tjm.Columns.Add(new SQLiteColumn("AccountId", ColType.Integer));
                            tjm.Columns.Add(new SQLiteColumn("OrderNum"));
                            tjm.Columns.Add(new SQLiteColumn("Instrument"));
                            tjm.Columns.Add(new SQLiteColumn("Type"));
                            tjm.Columns.Add(new SQLiteColumn("Category"));
                            tjm.Columns.Add(new SQLiteColumn("LotSize"));
                            tjm.Columns.Add(new SQLiteColumn("EntryPrice", ColType.Integer));
                            tjm.Columns.Add(new SQLiteColumn("EntryDate", ColType.DateTime));

                            tjm.Columns.Add(new SQLiteColumn("TPPrice", ColType.Integer));
                            tjm.Columns.Add(new SQLiteColumn("TargetPips"));
                            tjm.Columns.Add(new SQLiteColumn("Target", ColType.Integer));
                            tjm.Columns.Add(new SQLiteColumn("SLPips", ColType.Integer));
                            tjm.Columns.Add(new SQLiteColumn("SL", ColType.Integer));
                            tjm.Columns.Add(new SQLiteColumn("RR"));

                            tjm.Columns.Add(new SQLiteColumn("ExitPrice", ColType.Integer));
                            tjm.Columns.Add(new SQLiteColumn("RealizedRR"));
                            tjm.Columns.Add(new SQLiteColumn("ExitDate", ColType.DateTime));

                            tjm.Columns.Add(new SQLiteColumn("NetPL", ColType.Integer));
                            tjm.Columns.Add(new SQLiteColumn("Commission", ColType.Integer));
                            tjm.Columns.Add(new SQLiteColumn("Swap"));
                            tjm.Columns.Add(new SQLiteColumn("GrossPL", ColType.Integer));
                            tjm.Columns.Add(new SQLiteColumn("WonPips", ColType.Integer));
                            tjm.Columns.Add(new SQLiteColumn("LostPips", ColType.Integer));
                            tjm.Columns.Add(new SQLiteColumn("RunBalance"));

                            tjm.Columns.Add(new SQLiteColumn("TradingTF"));
                            tjm.Columns.Add(new SQLiteColumn("EntryTF"));
                            tjm.Columns.Add(new SQLiteColumn("DurationHours"));
                            tjm.Columns.Add(new SQLiteColumn("DurationMinutes"));

                            tjm.Columns.Add(new SQLiteColumn("EntryReason"));
                            tjm.Columns.Add(new SQLiteColumn("EntryReasonLong"));
                            tjm.Columns.Add(new SQLiteColumn("ExitReason"));
                            tjm.Columns.Add(new SQLiteColumn("ExitReasonLong"));
                            tjm.Columns.Add(new SQLiteColumn("StrategyUsed"));
                            tjm.Columns.Add(new SQLiteColumn("StrategyUsedLong"));

                            tjm.Columns.Add(new SQLiteColumn("Notes"));

                            sh.CreateTable(tjm);

                            SQLiteTable tbPlan = new SQLiteTable("Plan");
                            tbPlan.Columns.Add(new SQLiteColumn("Id", true));
                            tbPlan.Columns.Add(new SQLiteColumn("IsTest", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("Name"));
                            tbPlan.Columns.Add(new SQLiteColumn("FirstName"));
                            tbPlan.Columns.Add(new SQLiteColumn("LastName"));
                            tbPlan.Columns.Add(new SQLiteColumn("TradingPlanName"));
                            tbPlan.Columns.Add(new SQLiteColumn("TradingPlanNameLongDesc"));

                            tbPlan.Columns.Add(new SQLiteColumn("WhatKingOfPerson"));
                            tbPlan.Columns.Add(new SQLiteColumn("MyStrength"));
                            tbPlan.Columns.Add(new SQLiteColumn("MyWeaknesses"));
                            tbPlan.Columns.Add(new SQLiteColumn("DoIWantToBeATrader"));
                            tbPlan.Columns.Add(new SQLiteColumn("CanICommitEnoughTime"));
                            tbPlan.Columns.Add(new SQLiteColumn("DoIHaveFinancial"));
                            tbPlan.Columns.Add(new SQLiteColumn("CanIhandlePressure"));
                            tbPlan.Columns.Add(new SQLiteColumn("DoIGiveUpEasily"));
                            tbPlan.Columns.Add(new SQLiteColumn("DoIHaveEnoughWillpower"));

                            tbPlan.Columns.Add(new SQLiteColumn("DoIWantToBeATraderYesNo", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("CanICommitEnoughTimeYesNo", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("DoIHaveFinancialYesNo", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("CanIhandlePressureYesNo", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("DoIGiveUpEasilyYesNo", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("DoIHaveEnoughWillpowerYesNo", ColType.Integer));

                            tbPlan.Columns.Add(new SQLiteColumn("WhatIsMyTradingGoal"));
                            tbPlan.Columns.Add(new SQLiteColumn("GoalAdditionalNotesAndComments"));

                            tbPlan.Columns.Add(new SQLiteColumn("MaxRiskAccount"));
                            tbPlan.Columns.Add(new SQLiteColumn("MinRiskRewardRatio"));
                            tbPlan.Columns.Add(new SQLiteColumn("MaxStopLoss"));
                            tbPlan.Columns.Add(new SQLiteColumn("LongTerm", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("Swing", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("IntraDay", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("Scalp", ColType.Integer));

                            tbPlan.Columns.Add(new SQLiteColumn("SupplyDemand", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("PriceAnalysis", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("Breakouts", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("Momentum", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("Divergence", ColType.Integer));

                            tbPlan.Columns.Add(new SQLiteColumn("Trend", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("OscillatorsOverbought", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("Retracements", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("CandlePatterns", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("HistoricalSupRes", ColType.Integer));

                            tbPlan.Columns.Add(new SQLiteColumn("MALines", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("DailyOpenLine", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("Reversals", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("ChartPatterns", ColType.Integer));
                            tbPlan.Columns.Add(new SQLiteColumn("RoundNumbers", ColType.Integer));

                            tbPlan.Columns.Add(new SQLiteColumn("StrategyAdditionalNotesAndComments"));

                            tbPlan.Columns.Add(new SQLiteColumn("EntryRule"));
                            tbPlan.Columns.Add(new SQLiteColumn("TradeManagementRule"));
                            tbPlan.Columns.Add(new SQLiteColumn("ExitRule"));
                            tbPlan.Columns.Add(new SQLiteColumn("AdditionalRules"));
                            tbPlan.Columns.Add(new SQLiteColumn("RulesAdditionalNotesAndComments"));

                            sh.CreateTable(tbPlan);


                            conn.Close();
                        }
                    }

                    


                    SQLiteConnection cnn = new SQLiteConnection("Data Source=" + dbFile); //;Password=mypassword");

                    cnn.Open();

                    cnn.Close();

                    //System.Data.Common.DbProviderFactory factory = new System.Data.Common.DbProviderFactory();
                    //SQLiteConnectionStringBuilder builder = factory.CreateConnectionStringBuilder() as SQLiteConnectionStringBuilder;
                    //builder.DataSource = dbFile; // Path to file name of the user

                    using (var context = new KmKContext("Data Source=" + dbFile))
                    {
                        context.AdminDB.Add(
                         new AdminDB
                         {
                             UserName = username,
                             Password = pass
                         });

                        context.SaveChanges();
                    }
                    App.ContextToolTip = "DB created successfully";
                    System.Windows.MessageBox.Show("DB created successfully ");
                }

                
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }
    }
}
