namespace RunAwayAppWPF
{
    class KillProcess : ICommand
    {
        public bool HideAfterExecuting { get; set; }

        public void Execute(string[] args)
        {
            var argument = "taskkill /F /IM " + args[0];
            for (int i = 1; i < args.Length; i++)
                argument += ' ' + args[i];

            argument += '*';

            var killCommand = new Cmd();
            killCommand.Execute(new string[] { argument });
        }
    }
}
