using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using KmK_Business.Model;

namespace KmK_Business.ViewModel
{
    class TradingPlanViewModel : ObservableObject
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

        #region RTF editors
        private RichTextEditor goalRTFEditor;
        public RichTextEditor GoalRTFEditor
        {
            get { return goalRTFEditor; }
            set { goalRTFEditor = value;
            RaisePropertyChangedEvent("GoalRTFEditor");
            }
        }

        private RichTextEditor strategyRTFEditor;
        public RichTextEditor StrategyRTFEditor
        {
            get { return strategyRTFEditor; }
            set { strategyRTFEditor = value;
            RaisePropertyChangedEvent("StrategyRTFEditor");
            }
        }

        private RichTextEditor rulesRTFEditor;
        public RichTextEditor RulesRTFEditor
        {
            get { return rulesRTFEditor; }
            set { rulesRTFEditor = value;
            RaisePropertyChangedEvent("RulesRTFEditor");
            }
        }
        #endregion

        private string topStatusNavigator;
        public string TopStatusNavigator
        {
            get { return topStatusNavigator; }
            set 
            {                 
                topStatusNavigator = value;             
                RaisePropertyChangedEvent("TopStatusNavigator");
            }
        }

        private bool tradingPlanMainTestVisibility = false;
        public bool TradingPlanMainTestVisibility
        {
            get { return tradingPlanMainTestVisibility; }
            set
            {
                if (value)
                {
                    TradingPlanItemTestVisibility = false;
                }
                tradingPlanMainTestVisibility = value;
                RaisePropertyChangedEvent("TradingPlanMainTestVisibility");
            }
        }

        private bool tradingPlanItemTestVisibility = false;
        public bool TradingPlanItemTestVisibility
        {
            get { return tradingPlanItemTestVisibility; }
            set
            {
                if (value)
                {
                    TradingPlanMainTestVisibility = false;
                }
                tradingPlanItemTestVisibility = value;
                RaisePropertyChangedEvent("TradingPlanItemTestVisibility");
            }
        }

        private ObservableCollection<TradingPlansModel> treeSource = new ObservableCollection<TradingPlansModel>();
        public ObservableCollection<TradingPlansModel> TreeSource
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

        private List<bool> tradingTypes = new List<bool>();
        public List<bool> TradingTypes
        {
            get { return tradingTypes; }
            set { tradingTypes = value; }
        }

        private Plan selectedPlan;
        public Plan SelectedPlan 
        {
            get { return selectedPlan; }
            set 
            {                
                selectedPlan = value;
                                
                if (!string.IsNullOrWhiteSpace(selectedPlan?.GoalAdditionalNotesAndComments))
                {
                    try
                    {
                        GoalRTFEditor.HTML = selectedPlan.GoalAdditionalNotesAndComments;
                    }
                    catch
                    {
                        GoalRTFEditor.HTML = GoalRTFEditor.HTMLEmpty;
                    }
                }
                else
                {
                    GoalRTFEditor.HTML = GoalRTFEditor.HTMLEmpty;
                }

                if (!string.IsNullOrWhiteSpace(selectedPlan.StrategyAdditionalNotesAndComments))
                {
                    try
                    {
                        StrategyRTFEditor.HTML = selectedPlan.StrategyAdditionalNotesAndComments;
                    }
                    catch
                    {
                        StrategyRTFEditor.HTML = StrategyRTFEditor.HTMLEmpty;
                    }
                }
                else
                {
                    StrategyRTFEditor.HTML = StrategyRTFEditor.HTMLEmpty;
                }

                if (!string.IsNullOrWhiteSpace(selectedPlan.RulesAdditionalNotesAndComments))
                {
                    try
                    {
                        RulesRTFEditor.HTML = selectedPlan.RulesAdditionalNotesAndComments;
                    }
                    catch
                    {
                        RulesRTFEditor.HTML = RulesRTFEditor.HTMLEmpty;
                    }
                }
                else
                {
                    RulesRTFEditor.HTML = RulesRTFEditor.HTMLEmpty;
                }

                RaisePropertyChangedEvent("SelectedPlan");
            }
        }

        private TradingPlansModel selectedTradingPlan;
        public TradingPlansModel SelectedTradingPlan 
        {
            get { return selectedTradingPlan; }
            set 
            { 
                selectedTradingPlan = value;
                PlanControls.Clear();
                foreach (var plan in selectedTradingPlan.Plans)
                {
                    PlanControls.Add(new PlanGroupBoxControl(plan));
                }
                RaisePropertyChangedEvent("PlanControls");
                RaisePropertyChangedEvent("SelectedTradingPlan");                
            }
        }

        private string test = "Hello...";
        public string Test 
        {
            get { return test; }
            set { test = value; }
        }

        private ObservableCollection<PlanGroupBoxControl> planControls = new ObservableCollection<PlanGroupBoxControl>();
        public ObservableCollection<PlanGroupBoxControl> PlanControls
        {
            get { return planControls; }
            set { planControls = value; }
        }

        TradingPlansModel validTPM;
        TradingPlansModel testTPM;

        public TradingPlanViewModel()
        {
            MenuNavigator = new MenuNavigator();
            GoalRTFEditor = new RichTextEditor();
            StrategyRTFEditor = new RichTextEditor();
            RulesRTFEditor = new RichTextEditor();

            TradingTypes.Add(true);
            TradingTypes.Add(false);


            validTPM = new TradingPlansModel((string)App.Current.TryFindResource("validatedTradingPlan"));
            testTPM = new TradingPlansModel((string)App.Current.TryFindResource("testTradingPlans"));
            using (var context = new KmKContext(App.DBConnectionString))
            {
                foreach (var tpm in context.Plan)
                {
                    if (tpm.IsTest)
                    {
                        testTPM.Plans.Add(tpm);
                    }
                    else 
                    {
                        validTPM.Plans.Add(tpm);
                    }
                }
            }

            TreeSource.Add(validTPM);
            TreeSource.Add(testTPM);
        }

        private DelegateCommand addPlanCommand;
        private DelegateCommand editPlanCommand;
        private DelegateCommand deletePlanCommand;

        //private DelegateCommand addNewPlanCommand;
        //private DelegateCommand detelePlanCommand;
        private DelegateCommand savePlanCommand;
        private DelegateCommand cancelPlanCommand;
        private DelegateCommand printScreenCommand;

        public ICommand AddPlanCommand
        {
            get
            {
                if (addPlanCommand == null)
                {
                    addPlanCommand = new DelegateCommand(AddPlan);
                }
                return addPlanCommand;
            }
        }

        public ICommand EditPlanCommand
        {
            get
            {
                if (editPlanCommand == null)
                {
                    editPlanCommand = new DelegateCommand(EditPlan);
                }
                return editPlanCommand;
            }
        }

        public ICommand DeletePlanCommand
        {
            get
            {
                if (deletePlanCommand == null)
                {
                    deletePlanCommand = new DelegateCommand(DeletePlan);
                }
                return deletePlanCommand;
            }
        }

        void AddPlan()
        {
            using (var accWindow = new PlanWindow())
            {
                accWindow.ShowDialog();

                Plan acc = new Plan();

                acc.IsTest = accWindow.GetIsDemo();
                acc.Name = accWindow.GetAccountName();

                using (var context = new KmKContext(App.DBConnectionString))
                {
                    context.Plan.Add(acc);
                    context.SaveChanges();
                }

                if (acc.IsTest)
                {
                    testTPM.Plans.Add(acc);
                }
                else
                {
                    validTPM.Plans.Add(acc);
                }
            }
            RaisePropertyChangedEvent("TreeSource");

        }

        void EditPlan()
        {
            if (SelectedPlan != null)
            {
                using (var accWindow = new AccountWindow(SelectedPlan.Name, SelectedPlan.IsTest))
                {
                    accWindow.ShowDialog();

                    if (SelectedPlan.IsTest)
                    {
                        testTPM.Plans.Remove(SelectedPlan);
                    }
                    else
                    {
                        validTPM.Plans.Remove(SelectedPlan);
                    }

                    SelectedPlan.IsTest = accWindow.GetIsDemo();
                    SelectedPlan.Name = accWindow.GetAccountName();

                    using (var context = new KmKContext(App.DBConnectionString))
                    {
                        context.Plan.Attach(SelectedPlan);
                        context.Entry(SelectedPlan).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }


                    if (SelectedPlan.IsTest)
                    {
                        testTPM.Plans.Add(SelectedPlan);
                    }
                    else
                    {
                        validTPM.Plans.Add(SelectedPlan);
                    }
                }
                RaisePropertyChangedEvent("SelectedPlan");
                //RaisePropertyChangedEvent("SelectedAccounts");
                //RaisePropertyChangedEvent("AccountControls");
                RaisePropertyChangedEvent("TreeSource");
            }
            else
            {
                System.Windows.MessageBox.Show("Select an account!");
            }
        }

        void DeletePlan()
        {
            if (SelectedPlan != null)
            {
                using (var context = new KmKContext(App.DBConnectionString))
                {
                    var acc = context.Plan.First(item => item.Id == SelectedPlan.Id);
                    if (acc != null)
                    {
                        context.Plan.Remove(acc);

                        context.SaveChanges();
                    }
                    if (SelectedPlan.IsTest)
                    {
                        testTPM.Plans.Remove(SelectedPlan);
                    }
                    else
                    {
                        validTPM.Plans.Remove(SelectedPlan);
                    }
                    SelectedPlan = null;
                    RaisePropertyChangedEvent("AccountControls");
                    RaisePropertyChangedEvent("TreeSource");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Select an account!");
            }
        }


        //public ICommand AddNewPlanCommand
        //{
        //    get
        //    {
        //        if (addNewPlanCommand == null)
        //        {
        //            addNewPlanCommand = new DelegateCommand(AddNewTrade);
        //        }
        //        return addNewPlanCommand;
        //    }
        //}

        //public ICommand DeletePlanCommand
        //{
        //    get
        //    {
        //        if (detelePlanCommand == null)
        //        {
        //            detelePlanCommand = new DelegateCommand(DeletePlan);
        //        }
        //        return detelePlanCommand;
        //    }
        //}

        public ICommand SavePlanCommand
        {
            get
            {
                if (savePlanCommand == null)
                {
                    savePlanCommand = new DelegateCommand(SavePlan);
                }
                return savePlanCommand;
            }
        }

        public ICommand CancelPlanCommand
        {
            get
            {
                if (cancelPlanCommand == null)
                {
                    cancelPlanCommand = new DelegateCommand(CancelPlan);
                }
                return cancelPlanCommand;
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

        //void DeletePlan()
        //{ }

        void SavePlan()
        {
            if (SelectedPlan != null)
            {                
                SelectedPlan.GoalAdditionalNotesAndComments = GoalRTFEditor.HTML;
                SelectedPlan.StrategyAdditionalNotesAndComments = StrategyRTFEditor.HTML;
                SelectedPlan.RulesAdditionalNotesAndComments = RulesRTFEditor.HTML;

                using (var context = new KmKContext(App.DBConnectionString))
                {
                    context.Plan.Attach(SelectedPlan);
                    context.Entry(selectedPlan).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }

            testTPM.Plans.Remove(SelectedPlan);
            validTPM.Plans.Remove(SelectedPlan);

            if (SelectedPlan.IsTest)
            {
                testTPM.Plans.Add(SelectedPlan);
            }
            else
            {
                validTPM.Plans.Add(SelectedPlan);
            }

            RaisePropertyChangedEvent("TreeSource");
        }

        void CancelPlan()
        {
            testTPM.Plans.Clear();
            validTPM.Plans.Clear();
            using (var context = new KmKContext(App.DBConnectionString))
            {
                foreach (var tpm in context.Plan)
                {
                    if (tpm.IsTest)
                    {
                        testTPM.Plans.Add(tpm);
                    }
                    else
                    {
                        validTPM.Plans.Add(tpm);
                    }
                }
            }            
            RaisePropertyChangedEvent("TreeSource");
            RaisePropertyChangedEvent("SelectedPlan");
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
}
