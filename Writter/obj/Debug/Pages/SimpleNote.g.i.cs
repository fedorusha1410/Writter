﻿#pragma checksum "..\..\..\Pages\SimpleNote.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2CB7CC9CDD9C7F3043F2DC48F5714B5BAB0E12F4A10F33DDF311D5FDB67CFE10"
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
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using Writter;


namespace Writter {
    
    
    /// <summary>
    /// SimpleNote
    /// </summary>
    public partial class SimpleNote : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Pages\SimpleNote.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid SimplNoteGrid;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Pages\SimpleNote.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel NOTEPanel;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Pages\SimpleNote.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StP;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Pages\SimpleNote.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PropertiesText;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Pages\SimpleNote.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Bold;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Pages\SimpleNote.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Italic;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Pages\SimpleNote.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ListFonts;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Pages\SimpleNote.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MainNote;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\Pages\SimpleNote.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderStackPanepFromNotes;
        
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
            System.Uri resourceLocater = new System.Uri("/Writter;component/pages/simplenote.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\SimpleNote.xaml"
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
            
            #line 8 "..\..\..\Pages\SimpleNote.xaml"
            ((Writter.SimpleNote)(target)).Loaded += new System.Windows.RoutedEventHandler(this.AllProp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SimplNoteGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.NOTEPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.StP = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.PropertiesText = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.Bold = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.Italic = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.ListFonts = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.MainNote = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.borderStackPanepFromNotes = ((System.Windows.Controls.Border)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
