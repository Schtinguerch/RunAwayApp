using System.Windows;

namespace RunAwayAppWPF
{
    class Exit : ICommand
    {
        public bool HideAfterExecuting { get; set; }

        public void Execute(string[] args) =>
            Application.Current.Shutdown();
    }
}
