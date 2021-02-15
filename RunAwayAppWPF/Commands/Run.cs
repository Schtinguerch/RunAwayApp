using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace RunAwayAppWPF
{
    class Run : ICommand
    {
        public bool HideAfterExecuting { get; set; } = true;

        public void Execute(string[] args)
        {
            var command = args[0];
            for (int i = 1; i < args.Length; i++)
                command += " " + args[i];

            var tokens = command.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 2)
            {
                if (Regex.IsMatch(args[0], "cmd", RegexOptions.IgnoreCase))
                {
                    var cmd = new Cmd();
                    cmd.Execute(new string[] { tokens[1] });
                }
                else
                    Process.Start(tokens[0], tokens[1]);
            }
            else
                Process.Start(command);

            Intermediary.MustBeHidden = HideAfterExecuting;
        }
    }
}
