#pragma checksum "..\..\..\Pages\SportTraker.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6281162998CAAC028897FAB17D8B825E744C5E8276ECB30F2E89180E8B79B885"
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
    /// SportTraker
    /// </summary>
    public partial class SportTraker : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Pages\SportTraker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Code_Note;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Pages\SportTraker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Days;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Pages\SportTraker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DaysListBox;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\Pages\SportTraker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel TrackerSportDate;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\Pages\SportTraker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer ScrollWork;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\Pages\SportTraker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel TrackerSportWork;
        
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
            System.Uri resourceLocater = new System.Uri("/Writter;component/pages/sporttraker.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\SportTraker.xaml"
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
            this.Code_Note = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Days = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.DaysListBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.TrackerSportDate = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.ScrollWork = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 6:
            this.TrackerSportWork = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            
            #line 120 "..\..\..\Pages\SportTraker.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddNewDay);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

