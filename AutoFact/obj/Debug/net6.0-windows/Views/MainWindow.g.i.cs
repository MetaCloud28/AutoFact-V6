﻿#pragma checksum "..\..\..\..\Views\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0A4E659046C05A1A3906FEE7D14B805C1AA6F0AB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace AutoFact {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image img_logo;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button home_button;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button fav_button;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button para_button;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button menu_button;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button stats_button;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button close_button;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button reduc_button;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame contentFrame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AutoFact;V1.0.0.0;component/views/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 7 "..\..\..\..\Views\MainWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.img_logo = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.home_button = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\Views\MainWindow.xaml"
            this.home_button.Click += new System.Windows.RoutedEventHandler(this.home_button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.fav_button = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\..\Views\MainWindow.xaml"
            this.fav_button.Click += new System.Windows.RoutedEventHandler(this.fav_button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.para_button = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\..\Views\MainWindow.xaml"
            this.para_button.Click += new System.Windows.RoutedEventHandler(this.para_button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.menu_button = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\..\Views\MainWindow.xaml"
            this.menu_button.Click += new System.Windows.RoutedEventHandler(this.etats_button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.stats_button = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\..\Views\MainWindow.xaml"
            this.stats_button.Click += new System.Windows.RoutedEventHandler(this.close_button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.close_button = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\..\Views\MainWindow.xaml"
            this.close_button.Click += new System.Windows.RoutedEventHandler(this.close_button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.reduc_button = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\..\Views\MainWindow.xaml"
            this.reduc_button.Click += new System.Windows.RoutedEventHandler(this.reduc_button_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.contentFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
