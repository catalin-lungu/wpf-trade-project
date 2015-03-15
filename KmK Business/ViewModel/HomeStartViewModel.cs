using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KmK_Business.Model;


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

        public HomeStartViewModel()
        {
            DBSignInVisibility = false;
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
            catch
            {
                System.Windows.MessageBox.Show("An error has accured!");
            }
        }

        private void Login()
        {
            try
            {
                using (var context = new KmKContext(App.DBConnectionString))
                {
                    var user = context.AdminDB.FirstOrDefault(a => a.UserName.Equals(UserName) && a.Password.Equals(Password));
                    if (user != null)
                    {
                        App.CurrentWindow = new Home();
                        App.DBName = DatabaseName;   
                    }
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("An error has accured!");
            }
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
                    SQLiteConnection.CreateFile(dbFile);

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
                    System.Windows.MessageBox.Show("DB created successfully ");
                }

                
            }
            catch
            {
                System.Windows.MessageBox.Show("An error has accured!");
            }
        }
    }
}
