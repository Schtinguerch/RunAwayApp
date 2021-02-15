using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using RunAwayAppWPF.Properties;
using System.Windows.Controls;
using FastSearchLibrary;
using System.Diagnostics;
using System.Collections.Specialized;
using ICSharpCode.AvalonEdit.CodeCompletion;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using FontFamily = System.Windows.Media.FontFamily;
using Image = System.Windows.Controls.Image;

namespace RunAwayAppWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            userActivity.KeyDown += UserActivity_KeyDown;
            userActivity.KeyUp += UserActivity_KeyUp;

            TextCorrecter.GetSource();
            using (var reader = new XmlTextReader("LML_Data\\Highlight.xshd"))
                CommandBox.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
            
            if (Settings.Default.IsFirstLaunch)
            {
                Settings.Default.IsFirstLaunch = false;
                Sourcer.CommandSourceUpdate();
            }

            IntelWords = IntelReader.GetArray("ShortCuts>Inputs").ToList();
            for (int i = 0; i < IntelWords.Count; i++)
            {
                IntelWords[i] = IntelWords[i].Replace("/", "");

                if (Regex.IsMatch(IntelWords[i], "[|]"))
                {
                    var words = IntelWords[i].Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
                    IntelWords[i] = words[0];
                    
                    for (int j = 1; j < words.Length; j++)
                        IntelWords.Add(words[j]);
                }
            }

            Files = FileSearcher.GetFilesFast(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs", "*.*");

            CommandBox.TextArea.TextEntering += IntellisenseTextEntering;
            CommandBox.TextArea.TextEntered += IntellisenseTextEntered;
        }

        private void IntellisenseTextEntering(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length > 0 && completionWindow != null)
                if (!char.IsLetterOrDigit(e.Text[0]))
                    completionWindow.CompletionList.RequestInsertion(e);
        }

        private void IntellisenseTextEntered(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == "/")
            {
                completionWindow = new CompletionWindow(CommandBox.TextArea)
                {
                    WindowStyle = WindowStyle.None
                };
                var data = completionWindow.CompletionList.CompletionData;
                
                for (int i = 0; i < IntelWords.Count; i++)
                    data.Add(new CompletionData(IntelWords[i], ""));

                completionWindow.Show();
                completionWindow.Closed += (o, i) => completionWindow = null;
            }
            else if (e.Text == "\\")
            {
                completionWindow = new CompletionWindow(CommandBox.TextArea)
                {
                    WindowStyle = WindowStyle.None,
                    Width = 200d
                };

                try
                {
                    var tokens = CommandBox.Text.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    var startIndex = -1;
                    for (int i = 0; i < tokens.Length; i++)
                        if (tokens[i] != tokens[i].Replace(":\\", ""))
                        {
                            startIndex = i;
                            break;
                        }

                    var directory = tokens[startIndex];
                    for (int i = startIndex + 1; i < tokens.Length; i++)
                        directory += " " + tokens[i];

                    var data = completionWindow.CompletionList.CompletionData;
                    
                    var paths = Directory.GetDirectories(directory, "*", SearchOption.TopDirectoryOnly);
                    foreach (var path in paths)
                        data.Add(new CompletionData(new FileInfo(path).Name, path));
                
                    paths = Directory.GetFiles(directory, "*", SearchOption.TopDirectoryOnly);
                    foreach (var path in paths)
                        data.Add(new CompletionData(new FileInfo(path).Name, path));
                }
                catch
                {
                    
                }

                completionWindow.Show();
                completionWindow.Closed += (o, i) => completionWindow = null;
            }
        }
        
        private void UserActivity_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyValue == 164)
                IsAltPressed = true;
            
            if (e.KeyCode == System.Windows.Forms.Keys.Space)
                IsSpacePressed = true;
        }

        private void UserActivity_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyValue == 164)
                IsAltPressed = false;

            if (e.KeyCode == System.Windows.Forms.Keys.Space)
                IsSpacePressed = false;
        }

        private void MainButton_Click(object sender, RoutedEventArgs e) =>
            ExecuteCommand();

        private void ExecuteCommand()
        {
            var schtinguerch = new Schtinguerch();
            var commands = CommandBox.Text.Split(new char[] { '`' }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var command in commands)
                schtinguerch.ExecuteCommand(command);

            if (Intermediary.MustBeHidden)
            {
                Hide();
                CommandBox.Text = "";
            }
            if (Intermediary.CommandTextChanged)
            {
                CommandBox.Text = Intermediary.CommandText;
                CommandBox.CaretOffset = CommandBox.Text.Length;
            }

            Intermediary.CommandTextChanged = false;
            Intermediary.MustBeHidden = true;
        }

        private void CmdWindow_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                Hide();
            else
                prevState = WindowState;
        }

        private void TaskbarIcon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
        {
            Show();
            WindowState = prevState;
        }

        private void CmdWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (Regex.IsMatch(CommandBox.Text, "^\\s*nn"))
            {
                new UserWindows.Notepad().Show();
                CommandBox.Text = "";
                Hide();
            }
            
            if (e.Key == Key.Space)
            {
                var corrected = TextCorrecter.CorrectLive(CommandBox.Text);
                if (CommandBox.Text != corrected)
                {
                    CommandBox.Text = corrected;
                    CommandBox.CaretOffset = CommandBox.Text.Length;
                }

                if (Regex.IsMatch(CommandBox.Text, "^\\s*:.+"))
                    CommandBox.Text = Regex.Replace(CommandBox.Text, "^\\s*:", "");
            }
            
            if (e.Key == Key.Enter)
            {
                CommandBox.Text = Regex.Replace(CommandBox.Text, @"
", " ",         RegexOptions.Multiline);
                CommandBox.CaretOffset = CommandBox.Text.Length;

                try
                {
                    if (CmdWindow.Height != 300d)
                    {
                        CommandBox.Text = CommandBox.Text.Replace("\n", "");
                        ExecuteCommand();
                    }
                }
                catch
                {
                    
                }
            }

            if (e.Key == Key.Escape)
            {
                if (CommandBox.IsFocused || EnterFirstTime)
                {
                    Hide();
                    CommandBox.Text = "";
                    EnterFirstTime = false;
                }

                EnterFirstTime = true;
            }
            else
                EnterFirstTime = false;

            bool
                isLifeSearch = Regex.IsMatch(CommandBox.Text, "(^|^\\s+)-\\s+"),
                isClassicSearch = Regex.IsMatch(CommandBox.Text, "(^|^\\s+)(find|search)\\s+");

            if (isLifeSearch || isClassicSearch)
            {
                if (CmdWindow.Height != 300d) CmdWindow.Height = 300d;
            }
            else if (CmdWindow.Height != 50d)
                CmdWindow.Height = 50d;

            if (isLifeSearch && e.Key != Key.Up && e.Key != Key.Down && e.Key != Key.Apps && e.Key != Key.Escape)
                StardLifeSearch();

            else if (isClassicSearch && (e.Key == Key.Right || e.Key == Key.RightCtrl))
                StartSearch();
        }

        private void StartSearch()
        {
            SuitFiles = new List<string>();
            
            ProgramsView.Items.Clear();

            try
            {
                int startIndex = 0, endIndex = 0;
                var expression = Regex.Replace(CommandBox.Text, "^\\s*(search|find)", "");
                var tokens = expression.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < tokens.Length; i++)
                {
                    if (tokens[i] != tokens[i].Replace(":\\", ""))
                        startIndex = i;
                    if (Regex.IsMatch(tokens[i], ":$"))
                        endIndex = i;
                }

                var folder = tokens[startIndex];
                for (int i = startIndex + 1; i <= endIndex; i++)
                    folder += " " + tokens[i];

                var pattern = tokens[endIndex + 1];
                for (int i = endIndex + 2; i < tokens.Length; i++)
                    pattern += " " + tokens[i];

                folder = Regex.Replace(folder, ":$", "");
                var files = FileSearcher.GetFilesFast(folder, pattern);
                
                for (int i = 0; i < files.Count; i++)
                {
                    var some = new FileToImageIconConverter(files[i].FullName);
                    var imgSource = some.Icon;

                    var stItem = new StackPanel()
                    {
                        Orientation = Orientation.Horizontal
                    };

                    stItem.Children.Add(new Image()
                    {
                        Source = imgSource,
                        Margin = new Thickness(20, 5, 20, 5),
                        Width = 20,
                        Height = 20
                    });

                    stItem.Children.Add(new TextBlock()
                    {
                        Text = files[i].Name,
                        FontFamily = new FontFamily("Bahnschrift"),
                        Margin = new Thickness(20, 5, 20, 5)
                    });

                    ProgramsView.Items.Add(stItem);
                    SuitFiles.Add(files[i].FullName);
                }
            }
            catch
            {
                
            }
        }

        private void StardLifeSearch()
        {
            SuitFiles = new List<string>();
            ProgramsView.Items.Clear();
            try
            {
                for (int i = 0; i < Files.Count; i++)
                {
                    if (Regex.IsMatch(Files[i].Name, Sourcer.ArrayToString(Regex.Replace(CommandBox.Text, "(^|^\\s+)-\\s+", "").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), ' '), RegexOptions.IgnoreCase))
                    {
                        var some = new FileToImageIconConverter(Files[i].FullName);
                        var imgSource = some.Icon;

                        var stItem = new StackPanel()
                        {
                            Orientation = Orientation.Horizontal
                        };

                        stItem.Children.Add(new Image()
                        {
                            Source = imgSource,
                            Margin = new Thickness(20, 5, 20, 5),
                            Width = 20,
                            Height = 20
                        });

                        stItem.Children.Add(new TextBlock()
                        {
                            Text = Files[i].Name,
                            FontFamily = new FontFamily("Bahnschrift"),
                            Margin = new Thickness(20, 5, 20, 5)
                        });

                        ProgramsView.Items.Add(stItem);
                        SuitFiles.Add(Files[i].FullName);
                    }
                }
            }
            catch { }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Show();
            WindowState = WindowState.Normal;
            CommandBox.Focus();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start("cmd.exe");
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            new UserWindows.ProgramCalculator().Show();
            Hide();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            new UserWindows.GraphDrawer().Show();
            Hide();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e) =>
            Application.Current.Shutdown();

        private void FileContextOpenFileClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(SuitFiles[ProgramsView.SelectedIndex]);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка:\n" + ex.Message);
            }
        }

        private void FileContextCopyFileClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var collection = new StringCollection();
                collection.Add(SuitFiles[ProgramsView.SelectedIndex]);
                Clipboard.SetFileDropList(collection);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка:\n" + ex.Message);
            }
        }

        private void FileContextShowFileClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var args = string.Format("/e, /select, \"{0}\"", SuitFiles[ProgramsView.SelectedIndex]);

                var info = new ProcessStartInfo();
                info.FileName = "explorer";
                info.Arguments = args;
                Process.Start(info);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка:\n" + ex.Message);
            }
        }

        private void FileContextCopyFileTextClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Clipboard.SetText(System.IO.File.ReadAllText(SuitFiles[ProgramsView.SelectedIndex]));
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка:\n" + ex.Message);
            }
        }
    }

    public class FileToImageIconConverter
    {
        private string filePath;
        private System.Windows.Media.ImageSource icon;

        public string FilePath { get { return filePath; } }

        public System.Windows.Media.ImageSource Icon
        {
            get
            {
                if (icon == null && System.IO.File.Exists(FilePath))
                    using (var sysicon = System.Drawing.Icon.ExtractAssociatedIcon(FilePath))
                        icon = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                            sysicon.Handle,
                            System.Windows.Int32Rect.Empty,
                            System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                
                return icon;
            }
        }

        public FileToImageIconConverter(string filePath) =>
            this.filePath = filePath;
    }
}
