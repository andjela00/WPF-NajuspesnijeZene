﻿#pragma checksum "..\..\DodavanjeSlike.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CD7442A52AF7E0BFF90BCD7B360FF6101735A1C572CAF85228244FDD5AFB938E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HCI_projekat;
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


namespace HCI_projekat {
    
    
    /// <summary>
    /// DodavanjeSlike
    /// </summary>
    public partial class DodavanjeSlike : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\DodavanjeSlike.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lista;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\DodavanjeSlike.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas KanvasSlika;
        
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
            System.Uri resourceLocater = new System.Uri("/HCI_projekat;component/dodavanjeslike.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DodavanjeSlike.xaml"
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
            
            #line 8 "..\..\DodavanjeSlike.xaml"
            ((HCI_projekat.DodavanjeSlike)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lista = ((System.Windows.Controls.ListView)(target));
            
            #line 12 "..\..\DodavanjeSlike.xaml"
            this.lista.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lista_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 12 "..\..\DodavanjeSlike.xaml"
            this.lista.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.lista_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.KanvasSlika = ((System.Windows.Controls.Canvas)(target));
            
            #line 97 "..\..\DodavanjeSlike.xaml"
            this.KanvasSlika.Drop += new System.Windows.DragEventHandler(this.KanvasSlika_Drop);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
