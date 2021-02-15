using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Tech.CodeGeneration;
using Tech.CodeGeneration.Compilers;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using ICSharpCode.AvalonEdit.Folding;

namespace RunAwayAppWPF.UserWindows
{
    /// <summary>
    /// Логика взаимодействия для ProgramCalculator.xaml
    /// </summary>
    public partial class ProgramCalculator : Window
    {
        private string[] InputArgs;

        private string[] Outputs;

        public ProgramCalculator()
        {
            InitializeComponent();
            settingswid.Width = new GridLength(0d);

            var foldingManager = FoldingManager.Install(CodeTextBox.TextArea);
            var foldingStrategy = new XmlFoldingStrategy();
            foldingStrategy.UpdateFoldings(foldingManager, CodeTextBox.Document);

            var foldingManager2 = FoldingManager.Install(OutputTextBox.TextArea);
            var foldingStrategy2 = new XmlFoldingStrategy();
            foldingStrategy2.UpdateFoldings(foldingManager2, OutputTextBox.Document);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var points = new PointCollection();
            points.Add(new Point(150, 0));
            points.Add(new Point(160, 10));
            points.Add(new Point(CalcWindow.Width - 160, 10));
            points.Add(new Point(CalcWindow.Width - 150, 0));
            Hat.Points = points;
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e) => Close();
        

        private void UpButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void LowButton_MouseDown(object sender, MouseButtonEventArgs e) =>
            CalcWindow.WindowState = WindowState.Minimized;
         

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Calc = new CalculatorManager();

            var inputCode = CodeTextBox.Text;
            var lines = inputCode.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var names = new List<string>();
            var additionCode = "";
            int idx = -1;

            for (int i = 0; i < lines.Length; i++)
            {
                var regex = Regex.Match(lines[i], "^\\s*>\\s*(.*?)\\s*=");
                if (regex.Success)
                {
                    names.Add($"{Regex.Replace(regex.Groups[1].Value, "[[][]]\\s+", "")}"); idx++;
                    additionCode += "\n" + $"Calc.AddNewValue({names[idx]});";
                }
            }

            inputCode = Regex.Replace(inputCode, "out:", "Calc.StringAdd:");
            var worker = new CodeWorker(inputCode + "\n");

            worker.AddNewRule("^\\s*>", "double");
            worker.AddNewRule("//.*?$", "");
            worker.AddNewRule("while ", "while (");
            worker.AddNewRule("for ", "for (");
            worker.AddNewRule("if ", "if (");
            worker.AddNewRule(":\\s*$", ") {");
            worker.AddNewRule(";\\s*$", "}");
            worker.AddNewRule("exit|quit|stop", "goto end");
            worker.AddNewRule("for [(]\\s*", "for (int ");

            foreach (Match m in Regex.Matches(inputCode, "^.*?([<].*?[>]).*?$", RegexOptions.Multiline))
            {
                var arrayItems = m.Groups[1].Value;
                worker.AddNewRule(new ArrayQuotesWorker() { InputString = arrayItems });
            }

            foreach (Match m in Regex.Matches(inputCode, "^\\s*(Calc.StringAdd:.*?)\\s*.\\s*$", RegexOptions.Multiline))
            {
                var outItems = m.Groups[1].Value;
                worker.AddNewRule(new OutFunctionWorker() { InputString = outItems });
            }

            worker.AddNewRule("\n+", ";\n");
            worker.AddNewRule("{;", "{");
            worker.AddNewRule("};", ";}");

            worker.ProcessString();
            inputCode = worker.WorkingString;
            inputCode = Regex.Replace(inputCode, "[)][.]|[.][)]", ")");
            inputCode = Regex.Replace(inputCode, "[)]\\s*}", ");}");
            inputCode = Regex.Replace(inputCode, "\\s*}", ";}");

            inputCode = $"Calc.Value = 1; {Calc.CorrectedExpression(inputCode)}" + additionCode;

            try
            {
                using (var sandBox = new Sandbox())
                {
                    var d = CodeGenerator.CreateCode<double>
                    (sandBox,
                        CS.Compiler,
                        inputCode, null, null,
                        CodeParameter.Create("Calc", Calc
                        ));

                    d.Execute(Calc);
                }
                OutputTextBox.Text = Calc.StringValue;

                var values = Calc.Values;
                for (int i = 0; i < names.Count; i++)
                    Calc.AddVariable(names[i], values[i]);

                Vars.ItemsSource = Calc.Variables;
            }
            catch
            {
                MessageBox.Show(inputCode);
            }
        }

        bool OpenSettings = false;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenSettings = !OpenSettings;
            if (OpenSettings)
                settingswid.Width = new GridLength(200d);
            else
                settingswid.Width = new GridLength(0d);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) =>
            new ProgramCalculator().Show();

        private void CodeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                int crt = CodeTextBox.CaretOffset;
                CodeTextBox.Text = TextCorrecter.CorrectShortCuts(CodeTextBox.Text);
                CodeTextBox.CaretOffset = crt;
            }
        }
    }
}
