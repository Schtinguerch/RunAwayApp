using System.Diagnostics;

namespace RunAwayAppWPF
{
    class Cmd : ICommand
    {

        public bool HideAfterExecuting { get; set; } = true;

        public void Execute(string[] args)
        {
            var command = args[0];
            for (int i = 1; i < args.Length; i++)
                command += " " + args[i];

            var info = new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c {command}"
            };

            Process.Start(info);
            Intermediary.MustBeHidden = HideAfterExecuting;
        }
    }
}
