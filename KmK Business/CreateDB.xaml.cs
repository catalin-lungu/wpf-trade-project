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
using System.Windows.Shapes;

namespace KmK_Business
{
    /// <summary>
    /// Interaction logic for CreateDB.xaml
    /// </summary>
    public partial class CreateDB : Window , IDisposable
    {
        string dbFile = "";
        string username = "";
        string password = "";
        public CreateDB()
        {
            InitializeComponent();
        }

        public string GetDBFile()
        {
            return this.dbFile;
        }

        public string GetPassword()
        {
            return this.password;
        }

        public string GetUsername()
        {
            return this.username;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.password = txtPassword.Password;
            this.username = txtUsername.Text;
            //this.dbFile = txtDB.Text;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create OpenFileDialog 
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

                dlg.Title = (string)App.Current.TryFindResource("createDB");
                
                // Set filter for file extension and default file extension 
                dlg.DefaultExt = ".sqlite";
                dlg.Filter = "Database Files (*.sqlite)|*.sqlite";


                // Display OpenFileDialog by calling ShowDialog method 
                Nullable<bool> result = dlg.ShowDialog();

                // Get the selected file name and display in a TextBox 
                if (result == true)
                {
                    // Open document 
                    dbFile = dlg.FileName;
                    txtDB.Text = dlg.SafeFileName;
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("An error has accured!");
            }
        }



        public void Dispose()
        {
            this.Close();
        }
    }
}
