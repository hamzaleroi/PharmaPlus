﻿#pragma checksum "..\..\..\Les_interfaces\Saisir_commande.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07F21F4457D42E1040E26E666DE9D36E3B9AA7EF"
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
using facture;


namespace facture {
    
    
    /// <summary>
    /// Saisir_commande
    /// </summary>
    public partial class Saisir_commande : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 53 "..\..\..\Les_interfaces\Saisir_commande.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox fournisseur;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Les_interfaces\Saisir_commande.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Les_interfaces\Saisir_commande.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox code;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Les_interfaces\Saisir_commande.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView viewMed;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\Les_interfaces\Saisir_commande.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ajouter;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\Les_interfaces\Saisir_commande.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button update_listview;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\Les_interfaces\Saisir_commande.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button valider;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\Les_interfaces\Saisir_commande.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Reinitialiser;
        
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
            System.Uri resourceLocater = new System.Uri("/Menu;component/les_interfaces/saisir_commande.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Les_interfaces\Saisir_commande.xaml"
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
            this.fournisseur = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.date = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.code = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.viewMed = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.Ajouter = ((System.Windows.Controls.Button)(target));
            
            #line 108 "..\..\..\Les_interfaces\Saisir_commande.xaml"
            this.Ajouter.Click += new System.Windows.RoutedEventHandler(this.Ajouter_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 112 "..\..\..\Les_interfaces\Saisir_commande.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.modifier_med);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 116 "..\..\..\Les_interfaces\Saisir_commande.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Supprimer_med);
            
            #line default
            #line hidden
            return;
            case 8:
            this.update_listview = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\..\Les_interfaces\Saisir_commande.xaml"
            this.update_listview.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.valider = ((System.Windows.Controls.Button)(target));
            
            #line 125 "..\..\..\Les_interfaces\Saisir_commande.xaml"
            this.valider.Click += new System.Windows.RoutedEventHandler(this.valider_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Reinitialiser = ((System.Windows.Controls.Button)(target));
            
            #line 130 "..\..\..\Les_interfaces\Saisir_commande.xaml"
            this.Reinitialiser.Click += new System.Windows.RoutedEventHandler(this.Reinitialiser_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 137 "..\..\..\Les_interfaces\Saisir_commande.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.imprim_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

