using OxyPlot;
using OxyPlot.Axes;

namespace RunAwayAppWPF
{
    class PlotModelDefine : PlotModel
    {
        public static PlotModel ZeroCrossing()
        {
            var plotModel1 = new PlotModel();
            plotModel1.TextColor = OxyColor.FromRgb(255, 255, 255);
            plotModel1.PlotAreaBorderThickness = new OxyThickness(0d);
            plotModel1.PlotMargins = new OxyThickness(10, 10, 10, 10);
            
            var linearAxis1 = new LinearAxis();
            linearAxis1.TicklineColor = OxyColor.FromRgb(255, 255, 255);
            linearAxis1.Maximum = 50;
            linearAxis1.Minimum = -30;
            linearAxis1.PositionAtZeroCrossing = true;
            linearAxis1.TickStyle = TickStyle.Inside;
            plotModel1.Axes.Add(linearAxis1);
            
            var linearAxis2 = new LinearAxis();
            linearAxis2.TicklineColor = OxyColor.FromRgb(255, 255, 255);
            linearAxis2.Maximum = 70;
            linearAxis2.Minimum = -50;
            linearAxis2.Position = AxisPosition.Bottom;
            linearAxis2.PositionAtZeroCrossing = true;
            linearAxis2.TickStyle = TickStyle.Inside;
            plotModel1.Axes.Add(linearAxis2);
            
            return plotModel1;
        }
    }
}
