using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using OxyPlot;
using Tech.CodeGeneration;
using Tech.CodeGeneration.Compilers;
using CodeGenerator = Tech.CodeGeneration.CodeGenerator;

namespace RunAwayAppWPF.UserWindows
{
    /// <summary>
    /// Логика взаимодействия для GraphDrawer.xaml
    /// </summary>
    public partial class GraphDrawer : Window
    {
        private OxyPlot.Series.LineSeries LS;

        public GraphDrawer()
        {
            InitializeComponent();
            
            LS = new OxyPlot.Series.LineSeries();
            Grapher.Model = PlotModelDefine.ZeroCrossing();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var points = new PointCollection();
            points.Add(new Point(150, 0));
            points.Add(new Point(160, 10));
            points.Add(new Point(GraphDrawerr.Width - 160, 10));
            points.Add(new Point(GraphDrawerr.Width - 150, 0));
            Hat.Points = points;
        }

        private void ToolBar_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) => 
            new GraphDrawer().Show();

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e) => Close();

        private void UpButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void LowButton_MouseDown(object sender, MouseButtonEventArgs e) =>
            GraphDrawerr.WindowState = WindowState.Minimized;
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LS = new OxyPlot.Series.LineSeries();
            double Xmin = Convert.ToDouble(rangeA.Text), Xmax = Convert.ToDouble(rangeB.Text);

            var Calc = new CalculatorManager();
            var InputExpression = Calc.CorrectedExpression(formulaTextBox.Text);

            InputExpression = $"Calc.Value = {InputExpression};";
            using (var sndBox = new Sandbox())
            {
                var d = CodeGenerator.CreateCode<double>(sndBox,
                CS.Compiler,
                InputExpression, null, null,
                CodeParameter.Create("Calc", Calc),
                new CodeParameter("x", typeof(double)));

                const double delta = 0.01d;
                for (double i = Xmin; i < Xmax; i += delta)
                {
                    d.Execute(Calc, i);
                    LS.Points.Add(new DataPoint(i, Calc.Value));
                }
            }

            Grapher.Model.Series.Clear();
            Grapher.Model.Series.Add(LS);
        }
    }
}
