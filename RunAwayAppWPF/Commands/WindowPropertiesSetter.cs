using System;
using System.Windows;
using System.Windows.Forms;
using static RunAwayAppWPF.Properties.Settings;

namespace RunAwayAppWPF.Commands
{
    class WindowPropertiesSetter : ICommand
    {
        public bool HideAfterExecuting { get; set; } = false;

        public void Execute(string[] args)
        {
            Intermediary.MustBeHidden = false;

            int value = Convert.ToInt32(args[1]);
            switch (args[0])
            {
                case "width:":
                    foreach (Window window in System.Windows.Application.Current.Windows)
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).Width = value;
                            (window as MainWindow).Left = (SystemParameters.PrimaryScreenWidth - (window as MainWindow).Width) / 2;

                            Default.WindowWidth = value;
                            Default.Save();
                        }
                    break;

                case "monitor:":
                    var workingArea = Screen.AllScreens[value - 1].WorkingArea;

                    foreach (Window window in System.Windows.Application.Current.Windows)
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).Left = workingArea.Left + (SystemParameters.PrimaryScreenWidth - (window as MainWindow).Width) / 2;

                            Default.ChosenMonitor = value - 1;
                            Default.Save();
                        }
                    break;
            }

        }
    }
}
