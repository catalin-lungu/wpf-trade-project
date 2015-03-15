using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KmK_Business.ViewModel
{
    public class MainWindowViewModel : ObservableObject
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

        private string contextToolTips;
        public string ContextToolTips
        {
            get { return contextToolTips; }
            set 
            {
                contextToolTips = value;
                RaisePropertyChangedEvent("ContextToolTips");
            }
        }

        private string windowTitle;
        public string WindowTitle
        {
            get { return windowTitle; }
            set 
            {
                if (value.Length > 0)
                {
                    windowTitle = (string)App.Current.FindResource("windowTitle") + " - " + value;
                }
                else
                {
                    windowTitle = (string)App.Current.FindResource("windowTitle");
                }
                RaisePropertyChangedEvent("WindowTitle");
            }
        }

        private bool visibilityEdit;
        public bool VisibilityEdit
        {
            get { return visibilityEdit; }
            set
            {
                visibilityEdit = value;
                RaisePropertyChangedEvent("VisibilityEdit");
            }
        }

        private bool visibilityMenuItem;
        public bool VisibilityMenuItem
        {
            get { return visibilityMenuItem; }
            set
            {
                visibilityMenuItem = value;
                RaisePropertyChangedEvent("VisibilityMenuItem");
            }
        }


        public MainWindowViewModel()
        {
            DatabaseName = "C\\..";
            ContextToolTips = "ContextToolTips...";
            WindowTitle = "";
        }


        private DelegateCommand exampleCommand;

        public ICommand GenAllCertCommand
        {
            get
            {
                if (exampleCommand == null)
                {
                    exampleCommand = new DelegateCommand(GenAllCert);
                }
                return exampleCommand;
            }
        }

        private void GenAllCert()
        {
            throw new NotImplementedException();
        }

    }
}
