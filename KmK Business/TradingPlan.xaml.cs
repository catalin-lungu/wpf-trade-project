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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KmK_Business.ViewModel;
using mshtml;

namespace KmK_Business
{
    /// <summary>
    /// Interaction logic for TradingPlan.xaml
    /// </summary>
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class TradingPlan : UserControl
    {
        TradingPlanViewModel vm;
        public TradingPlan()
        {
            InitializeComponent();
            vm = new TradingPlanViewModel();
            this.DataContext = vm;

           

            //rtfGrid.Navigate("https://www.google.ro/?gws_rd=ssl");
            //rtfGrid.Navigate(new Uri("pack://siteoforigin:,,,/HTMLPage1.html", UriKind.RelativeOrAbsolute));
            Uri uri = new Uri(@"pack://application:,,,/HTMLPage1.html");
            System.IO.Stream source = Application.GetContentStream(uri).Stream;

            //ObjectForScriptingHelper helper = new ObjectForScriptingHelper(this);
            //rtfGrid.ObjectForScripting = helper;
            //rtfGrid.LoadCompleted += BrowserOnLoadCompleted;
            //rtfGrid.NavigateToStream(source);
            
        }

        private void BrowserOnLoadCompleted(object sender, NavigationEventArgs navigationEventArgs)
        {
            //rtfGrid.Source = new Uri(string.Format("javascript: {0}({1});", "CKEDITOR.replace", "editor1"));
            //if (rtfGrid.IsLoaded)
            //{
            //    rtfGrid.InvokeScript("CKEDITOR.replace", "editor1");
            //}

            //var doc = (System.Xml.HtmlDocument)rtfGrid.Document;
            //var head = doc.getElementsByTagName("head").Cast<HTMLHeadElement>().First();
            //var script = (IHTMLScriptElement)doc.createElement("script");
            //script.text = "alert('hi');";
            //head.appendChild((IHTMLDOMNode)script);
            //script.text = "alert('bye');";
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //if (rtfGrid.IsLoaded)
            //{
            //    rtfGrid.InvokeScript("CKEDITOR.replace", "editor1");
            //}
            string x = m_richTextEditor.HTML;
            if (e.NewValue is Model.Plan)
            {
                vm.SelectedPlan = e.NewValue as Model.Plan;
                vm.TradingPlanItemTestVisibility = true;
            }
            else if (e.NewValue is Model.TradingPlansModel)
            {
                vm.SelectedTradingPlan = e.NewValue as Model.TradingPlansModel;
                vm.TradingPlanMainTestVisibility = true;
            }
        }
    }
}
