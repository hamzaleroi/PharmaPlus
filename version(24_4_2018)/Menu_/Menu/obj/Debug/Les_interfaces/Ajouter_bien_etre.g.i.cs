﻿#pragma checksum "..\..\..\Les_interfaces\Ajouter_bien_etre.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B78B883345247B07F61C6A7899A80924E366FB36"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using Menu.Les_interfaces;
using RootLibrary.WPF.Localization;
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


namespace Menu.Les_interfaces {
    
    
    /// <summary>
    /// Ajouter_b1_etre
    /// </summary>
    public partial class Ajouter_b1_etre : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 84 "..\..\..\Les_interfaces\Ajouter_bien_etre.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Marque;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\Les_interfaces\Ajouter_bien_etre.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Type;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\Les_interfaces\Ajouter_bien_etre.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox main_ingred;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\Les_interfaces\Ajouter_bien_etre.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Quantite;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\Les_interfaces\Ajouter_bien_etre.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox prix;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\Les_interfaces\Ajouter_bien_etre.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date_prod;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\Les_interfaces\Ajouter_bien_etre.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date_peromp;
        
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
            System.Uri resourceLocater = new System.Uri("/Menu;component/les_interfaces/ajouter_bien_etre.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Les_interfaces\Ajouter_bien_etre.xaml"
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
            this.Marque = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Type = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.main_ingred = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Quantite = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.prix = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.date_prod = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.date_peromp = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            
            #line 131 "..\..\..\Les_interfaces\Ajouter_bien_etre.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 137 "..\..\..\Les_interfaces\Ajouter_bien_etre.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

