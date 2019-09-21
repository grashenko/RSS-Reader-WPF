﻿#pragma checksum "..\..\UserWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0B4448CB0A7A27D6B537C4C36BBF60E235D82BAF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using RSSreadedWPF;
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


namespace RSSreaderWPF {
    
    
    /// <summary>
    /// UserWindow
    /// </summary>
    public partial class UserWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBox1;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WebBrowser webBrowser1;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Uri;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Search;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox favotitesBox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb;
        
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
            System.Uri resourceLocater = new System.Uri("/RSSreadedWPF;component/userwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserWindow.xaml"
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
            
            #line 9 "..\..\UserWindow.xaml"
            ((RSSreaderWPF.UserWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.listBox1 = ((System.Windows.Controls.ListBox)(target));
            
            #line 24 "..\..\UserWindow.xaml"
            this.listBox1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listBox1_SelectedIndexChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.webBrowser1 = ((System.Windows.Controls.WebBrowser)(target));
            return;
            case 4:
            
            #line 27 "..\..\UserWindow.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.ToggleButton_Checked);
            
            #line default
            #line hidden
            
            #line 27 "..\..\UserWindow.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.ToggleButton_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Uri = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Search = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 33 "..\..\UserWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Uri_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 34 "..\..\UserWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Search_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 35 "..\..\UserWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Home_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.favotitesBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 36 "..\..\UserWindow.xaml"
            this.favotitesBox.Loaded += new System.Windows.RoutedEventHandler(this.favotitesBox_Loaded);
            
            #line default
            #line hidden
            
            #line 36 "..\..\UserWindow.xaml"
            this.favotitesBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.favotitesBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.tb = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            
            #line 39 "..\..\UserWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add_Favorite);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 40 "..\..\UserWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Remove_Favorite);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 41 "..\..\UserWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Save_Channel);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

