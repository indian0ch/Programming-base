﻿#pragma checksum "..\..\ZvitAdmin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C6EDE5A99C6237C944003B00D1B5F1E1DBF76A9BA8CBE60DB39FBA609460E3B8"
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
    /// ZvitAdmin
    /// </summary>
    public partial class ZvitAdmin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 123 "..\..\ZvitAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar Calendar1;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\ZvitAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar Calendar2;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\ZvitAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreateZvitBtn;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\ZvitAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ReturnBtn;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\ZvitAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CountClientLbl;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\ZvitAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label GeneralSumLbl;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\ZvitAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox NumberRoomCb;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\ZvitAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CountFreeDayLbl;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\ZvitAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CountNonFreeDayLbl;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\ZvitAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ZvitRoomBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/HotelProgramTest;component/zvitadmin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ZvitAdmin.xaml"
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
            this.Calendar1 = ((System.Windows.Controls.Calendar)(target));
            return;
            case 2:
            this.Calendar2 = ((System.Windows.Controls.Calendar)(target));
            return;
            case 3:
            this.CreateZvitBtn = ((System.Windows.Controls.Button)(target));
            
            #line 125 "..\..\ZvitAdmin.xaml"
            this.CreateZvitBtn.Click += new System.Windows.RoutedEventHandler(this.CreateZvitBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ReturnBtn = ((System.Windows.Controls.Button)(target));
            
            #line 126 "..\..\ZvitAdmin.xaml"
            this.ReturnBtn.Click += new System.Windows.RoutedEventHandler(this.ReturnBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CountClientLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.GeneralSumLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.NumberRoomCb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.CountFreeDayLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.CountNonFreeDayLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.ZvitRoomBtn = ((System.Windows.Controls.Button)(target));
            
            #line 134 "..\..\ZvitAdmin.xaml"
            this.ZvitRoomBtn.Click += new System.Windows.RoutedEventHandler(this.ZvitRoomBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

