using System;
using System.Windows;
using System.Windows.Media;

namespace RunAwayAppWPF.UserWindows
{
    //Window's form data (properties)
    public partial class ProgramCalculator : Window
    {
        public double TextFontSize 
        {
            get => _txtFontSize;

            set
            {
                _txtFontSize = value;
                CodeTextBox.FontSize = value;
                OutputTextBox.FontSize = value;
            }
        }
        
        private double _txtFontSize;

        public FontFamily TextFontFamily
        {
            get => _txtFontFamily;

            set
            {
                _txtFontFamily = value;
                CodeTextBox.FontFamily = value;
                OutputTextBox.FontFamily = value;
            }
        }
        
        private FontFamily _txtFontFamily; 
    }
}
