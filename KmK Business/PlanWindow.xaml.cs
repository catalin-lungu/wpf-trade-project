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
    /// Interaction logic for PlanWindow.xaml
    /// </summary>
    public partial class PlanWindow : Window, IDisposable
    {
        string planName = "";
        bool issDemo = true;

        public PlanWindow()
        {
            InitializeComponent();
        }

        public PlanWindow(string name, bool isD)
        {
            InitializeComponent();
            plName.Text = name;
            isDemo.IsChecked = isD;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.planName = plName.Text;
            issDemo = isDemo.IsChecked != null ? (bool)isDemo.IsChecked : true;
            this.Close();
        }

        public string GetAccountName() { return planName; }
        public bool GetIsDemo() { return issDemo; }


        public void Dispose()
        {
            this.Close();
        }
    }
}
