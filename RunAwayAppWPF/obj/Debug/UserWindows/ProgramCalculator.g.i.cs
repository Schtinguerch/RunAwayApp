﻿#pragma checksum "..\..\..\UserWindows\ProgramCalculator.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "88B38A7E3B9EC20A896679E67B0FD2A7B8A59B2238193F6934F289DE2490F831"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.AvalonEdit.Search;
using RunAwayAppWPF.UserWindows;
using System;
using System.Collections;
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


namespace RunAwayAppWPF.UserWindows {
    
    
    /// <summary>
    /// ProgramCalculator
    /// </summary>
    public partial class ProgramCalculator : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\UserWindows\ProgramCalculator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal RunAwayAppWPF.UserWindows.ProgramCalculator CalcWindow;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\UserWindows\ProgramCalculator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ToolBar;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\UserWindows\ProgramCalculator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Polygon Hat;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\UserWindows\ProgramCalculator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image LowButton;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\UserWindows\ProgramCalculator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image UpButton;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\UserWindows\ProgramCalculator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image CloseButton;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\UserWindows\ProgramCalculator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition settingswid;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\UserWindows\ProgramCalculator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ICSharpCode.AvalonEdit.TextEditor CodeTextBox;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\UserWindows\ProgramCalculator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ICSharpCode.AvalonEdit.TextEditor OutputTextBox;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\UserWindows\ProgramCalculator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Vars;
        
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
            System.Uri resourceLocater = new System.Uri("/RunAwayAppWPF;component/userwindows/programcalculator.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserWindows\ProgramCalculator.xaml"
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
            this.CalcWindow = ((RunAwayAppWPF.UserWindows.ProgramCalculator)(target));
            
            #line 11 "..\..\..\UserWindows\ProgramCalculator.xaml"
            this.CalcWindow.SizeChanged += new System.Windows.SizeChangedEventHandler(this.Window_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ToolBar = ((System.Windows.Controls.Grid)(target));
            
            #line 18 "..\..\..\UserWindows\ProgramCalculator.xaml"
            this.ToolBar.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ToolBar_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Hat = ((System.Windows.Shapes.Polygon)(target));
            return;
            case 4:
            
            #line 29 "..\..\..\UserWindows\ProgramCalculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LowButton = ((System.Windows.Controls.Image)(target));
            
            #line 32 "..\..\..\UserWindows\ProgramCalculator.xaml"
            this.LowButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.LowButton_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.UpButton = ((System.Windows.Controls.Image)(target));
            
            #line 44 "..\..\..\UserWindows\ProgramCalculator.xaml"
            this.UpButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.UpButton_MouseDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CloseButton = ((System.Windows.Controls.Image)(target));
            
            #line 56 "..\..\..\UserWindows\ProgramCalculator.xaml"
            this.CloseButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.CloseButton_MouseDown);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 72 "..\..\..\UserWindows\ProgramCalculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 81 "..\..\..\UserWindows\ProgramCalculator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.settingswid = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 11:
            this.CodeTextBox = ((ICSharpCode.AvalonEdit.TextEditor)(target));
            
            #line 117 "..\..\..\UserWindows\ProgramCalculator.xaml"
            this.CodeTextBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.CodeTextBox_KeyUp);
            
            #line default
            #line hidden
            return;
            case 12:
            this.OutputTextBox = ((ICSharpCode.AvalonEdit.TextEditor)(target));
            return;
            case 13:
            this.Vars = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
