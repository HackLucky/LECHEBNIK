﻿#pragma checksum "..\..\..\Windows\Main.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B126264E084063DF5938920B055BDCDAB11EB70E8149E05ECA6F3EC76688A22F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SokolovLechebnik.Windows;
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


namespace SokolovLechebnik.Windows {
    
    
    /// <summary>
    /// Main
    /// </summary>
    public partial class Main : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridMain;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonMenu;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup MenuPopup;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelMainReg;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border BorderLabelMainReg;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonOnOff;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxForAvatar;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonExit;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\..\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockExit;
        
        #line default
        #line hidden
        
        
        #line 206 "..\..\..\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockMain;
        
        #line default
        #line hidden
        
        
        #line 220 "..\..\..\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockAvatar;
        
        #line default
        #line hidden
        
        
        #line 232 "..\..\..\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonImageAvatar;
        
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
            System.Uri resourceLocater = new System.Uri("/SokolovLechebnik;component/windows/main.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\Main.xaml"
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
            this.GridMain = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.ButtonMenu = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Windows\Main.xaml"
            this.ButtonMenu.Click += new System.Windows.RoutedEventHandler(this.MainButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MenuPopup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 4:
            
            #line 30 "..\..\..\Windows\Main.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonProfile_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 31 "..\..\..\Windows\Main.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonCatalog_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 32 "..\..\..\Windows\Main.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonBasket_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 33 "..\..\..\Windows\Main.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonOrders_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 34 "..\..\..\Windows\Main.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonDisease_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 35 "..\..\..\Windows\Main.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAbout_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.LabelMainReg = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.BorderLabelMainReg = ((System.Windows.Controls.Border)(target));
            return;
            case 12:
            this.ButtonOnOff = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\Windows\Main.xaml"
            this.ButtonOnOff.Click += new System.Windows.RoutedEventHandler(this.ButtonOnOff_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.TextBoxForAvatar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.ButtonExit = ((System.Windows.Controls.Button)(target));
            
            #line 144 "..\..\..\Windows\Main.xaml"
            this.ButtonExit.Click += new System.Windows.RoutedEventHandler(this.ButtonExit_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.TextBlockExit = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 16:
            this.TextBlockMain = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 17:
            this.TextBlockAvatar = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 18:
            this.ButtonImageAvatar = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

