﻿#pragma checksum "..\..\TradingPlan.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "489D667CB7030D4205C1FA2EBEF0B996"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Adastra.RichEditorLibrary;
using KmK_Business.Convertor;
using KmK_Business.Model;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace KmK_Business {
    
    
    /// <summary>
    /// TradingPlan
    /// </summary>
    public partial class TradingPlan : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 105 "..\..\TradingPlan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl ContentNavigator;
        
        #line default
        #line hidden
        
        
        #line 259 "..\..\TradingPlan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Adastra.RichEditorLibrary.RichTextEditor m_richTextEditor;
        
        #line default
        #line hidden
        
        
        #line 307 "..\..\TradingPlan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbWantToBeATrader;
        
        #line default
        #line hidden
        
        
        #line 327 "..\..\TradingPlan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbICommitEnoughTime;
        
        #line default
        #line hidden
        
        
        #line 347 "..\..\TradingPlan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbIHaveFinancial;
        
        #line default
        #line hidden
        
        
        #line 367 "..\..\TradingPlan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbIhandlePressure;
        
        #line default
        #line hidden
        
        
        #line 387 "..\..\TradingPlan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbIGiveUpEasily;
        
        #line default
        #line hidden
        
        
        #line 407 "..\..\TradingPlan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbIHaveEnoughWillpower;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KmK Business;component/tradingplan.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TradingPlan.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 83 "..\..\TradingPlan.xaml"
            ((System.Windows.Controls.TreeView)(target)).SelectedItemChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.TreeView_SelectedItemChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ContentNavigator = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 3:
            this.m_richTextEditor = ((Adastra.RichEditorLibrary.RichTextEditor)(target));
            return;
            case 4:
            this.rbWantToBeATrader = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.rbICommitEnoughTime = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.rbIHaveFinancial = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.rbIhandlePressure = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.rbIGiveUpEasily = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.rbIHaveEnoughWillpower = ((System.Windows.Controls.RadioButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

