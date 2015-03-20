using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KmK_Business.ViewModel
{
    class MenuNavigatorViewModel : ObservableObject
    {


        private DelegateCommand homeCommand;
        private DelegateCommand tradingPlanCommand;
        private DelegateCommand tradingJournalCommand;
        private DelegateCommand tradingToolsCommand;
        private DelegateCommand reportsCommand;
        private DelegateCommand tasksCommand;
        private DelegateCommand contactsCommand;
        private DelegateCommand knowledgebaseCommand;
        

        public ICommand HomeCommand
        {
            get
            {
                if (homeCommand == null)
                {
                    homeCommand = new DelegateCommand(Home);
                }
                return homeCommand;
            }
        }

        public ICommand TradingPlanCommand
        {
            get
            {
                if (tradingPlanCommand == null)
                {
                    tradingPlanCommand = new DelegateCommand(TradingPlan);
                }
                return tradingPlanCommand;
            }
        }

        public ICommand TradingJournalCommand
        {
            get
            {
                if (tradingJournalCommand == null)
                {
                    tradingJournalCommand = new DelegateCommand(TradingJournal);
                }
                return tradingJournalCommand;
            }
        }

        public ICommand TradingToolsCommand
        {
            get
            {
                if (tradingToolsCommand == null)
                {
                    tradingToolsCommand = new DelegateCommand(TradingTools);
                }
                return tradingToolsCommand;
            }
        }

        public ICommand ReportsCommand
        {
            get
            {
                if (reportsCommand == null)
                {
                    reportsCommand = new DelegateCommand(Reports);
                }
                return reportsCommand;
            }
        }

        public ICommand TasksCommand
        {
            get
            {
                if (tasksCommand == null)
                {
                    tasksCommand = new DelegateCommand(Tasks);
                }
                return tasksCommand;
            }
        }

        public ICommand ContactsCommand
        {
            get
            {
                if (contactsCommand == null)
                {
                    contactsCommand = new DelegateCommand(Contacts);
                }
                return contactsCommand;
            }
        }

        public ICommand KnowledgebaseCommand
        {
            get
            {
                if (knowledgebaseCommand == null)
                {
                    knowledgebaseCommand = new DelegateCommand(Knowledgebase);
                }
                return knowledgebaseCommand;
            }
        }


        private void Home()
        {
            App.CurrentWindow = new Home();
        }

        private void TradingPlan()
        {
            App.CurrentWindow = new TradingPlan();
        }

        private void TradingJournal()
        {
            App.CurrentWindow = new TradingJournal();
        }

        private void TradingTools()
        {
        }

        private void Reports()
        {
        }

        private void Tasks()
        {
        }

        private void Contacts()
        {
        }

        private void Knowledgebase()
        {
        }

    }
}
