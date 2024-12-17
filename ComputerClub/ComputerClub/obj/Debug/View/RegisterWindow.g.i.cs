﻿#pragma checksum "..\..\..\View\RegisterWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FCA11E66786343F41ADB680E998BEF115BDCD2CD64B8AED7B034E3890AD243D6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ComputerClub.Helper;
using ComputerClub.ViewModel;
using ComputerClub.Wind;
using MaterialDesignThemes.Wpf;
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


namespace ComputerClub.Wind {
    
    
    /// <summary>
    /// RegisterWindow
    /// </summary>
    public partial class RegisterWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 67 "..\..\..\View\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_name;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\View\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_lastname;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\View\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_patronymic;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\View\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker txt_birth;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\View\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_mobile;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\View\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_email;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\View\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_login;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\View\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txt_pass;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\View\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost hecho2;
        
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
            System.Uri resourceLocater = new System.Uri("/ComputerClub;component/view/registerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\RegisterWindow.xaml"
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
            
            #line 35 "..\..\..\View\RegisterWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.BorderDrag_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 39 "..\..\..\View\RegisterWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseLog_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txt_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txt_lastname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txt_patronymic = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txt_birth = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.txt_mobile = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txt_email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.txt_login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.txt_pass = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 92 "..\..\..\View\RegisterWindow.xaml"
            this.txt_pass.PasswordChanged += new System.Windows.RoutedEventHandler(this.txt_pass_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.hecho2 = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

