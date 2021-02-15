using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using static RunAwayAppWPF.Properties.Settings;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace RunAwayAppWPF.UserWindows
{
    public partial class Notepad : Window
    {
        public Notepad()
        {
            InitializeComponent();
        }

        private void Notepad_OnLoaded(object sender, RoutedEventArgs e)
        {
            notepadTextBox.Focus();
            notepadTextBox.Text = Default.NotepadText;
        }


        private void Notepad_OnClosing(object sender, CancelEventArgs e)
        {
            Default.NotepadText = notepadTextBox.Text;
            Default.Save();
        }

        private void Notepad_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }
    }
}