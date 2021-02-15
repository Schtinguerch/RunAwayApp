namespace RunAwayAppWPF
{
    class Hide : ICommand
    {
        public bool HideAfterExecuting { get; set; }

        public void Execute(string[] args) =>
            Intermediary.MustBeHidden = true;
    }
}
