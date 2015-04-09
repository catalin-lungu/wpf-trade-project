using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KmK_Business.ViewModel
{
    class RTFEditorViewModel : ObservableObject
    {
        
        private bool isSelectedAlignLeft;
        public bool IsSelectedAlignLeft
        {
            get 
            {
                return isSelectedAlignLeft; 
            }
            set 
            {
                if (value)
                {
                    IsSelectedAlignCenter = false;
                }
                isSelectedAlignLeft = value;
                RaisePropertyChangedEvent("IsSelectedAlignLeft");
            }
        }

        private bool isSelectedAlignCenter;
        public bool IsSelectedAlignCenter
        {
            get { return isSelectedAlignCenter; }
            set 
            {
                if (value)
                {
                    IsSelectedAlignLeft = false;
                }
                isSelectedAlignCenter = value;
                RaisePropertyChangedEvent("IsSelectedAlignCenter");
            }
        }

        public RTFEditorViewModel()
        {

        }


        private DelegateCommand boldCommand;
        public ICommand BoldCommand
        {
            get
            {
                if (boldCommand == null)
                {
                    boldCommand = new DelegateCommand(Bold);
                }
                return boldCommand;
            }
        }

        void Bold()
        { 

        
        }
    }
}
