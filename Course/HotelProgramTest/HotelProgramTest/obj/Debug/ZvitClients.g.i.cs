﻿#pragma checksum "..\..\ZvitClients.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "45DBBB380A6B7C96319B05AD6C3F6C4BC130354E6D5F400EAE91D624067A611D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HotelProgramTest;
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


namespace HotelProgramTest {
    
    
    /// <summary>
    /// ZvitClients
    /// </summary>
    public partial class ZvitClients : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 122 "..\..\ZvitClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SurnameCb;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\ZvitClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MakeZvitBtn;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\ZvitClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ReturnBtn;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\ZvitClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TestLabel;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\ZvitClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PswTb;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\ZvitClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CheckBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/HotelProgramTest;component/zvitclients.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ZvitClients.xaml"
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
            this.SurnameCb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.MakeZvitBtn = ((System.Windows.Controls.Button)(target));
            
            #line 123 "..\..\ZvitClients.xaml"
            this.MakeZvitBtn.Click += new System.Windows.RoutedEventHandler(this.MakeZvitBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ReturnBtn = ((System.Windows.Controls.Button)(target));
            
            #line 124 "..\..\ZvitClients.xaml"
            this.ReturnBtn.Click += new System.Windows.RoutedEventHandler(this.ReturnBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TestLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.PswTb = ((System.Windows.Controls.TextBox)(target));
            
            #line 127 "..\..\ZvitClients.xaml"
            this.PswTb.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.PswTb_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CheckBtn = ((System.Windows.Controls.Button)(target));
            
            #line 128 "..\..\ZvitClients.xaml"
            this.CheckBtn.Click += new System.Windows.RoutedEventHandler(this.CheckBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

