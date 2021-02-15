using gma.System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using ICSharpCode.AvalonEdit.CodeCompletion;
using LmlLibrary;

namespace RunAwayAppWPF
{
    public partial class MainWindow : Window
    {
        private bool open = false;

        WindowState prevState;

        UserActivityHook userActivity = new UserActivityHook();

        private List<FileInfo> Files;

        private List<string> SuitFiles;

        private CompletionWindow completionWindow;
        
        private Lml IntelReader = new Lml("LML_Data\\CorrectingSource.lml", Lml.Open.FromFile);
        
        private List<string> IntelWords = new List<string>();
        
        private bool IsAltPressed = false;

        private bool IsSpacePressed
        {
            set
            {
                if (value && IsAltPressed)
                {
                    Show();
                    WindowState = WindowState.Normal;
                    CommandBox.Focus();
                    SendKeys.SendWait("%");
                }
            }
        }

        private bool CanStartSearch = false;

        private bool EnterFirstTime = false;
    }
}
