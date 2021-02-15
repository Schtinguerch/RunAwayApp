namespace RunAwayAppWPF
{
    class Update : ICommand
    {
        public bool HideAfterExecuting { get; set; } = false;

        public void Execute(string[] args)
        {
            Sourcer.CommandSourceUpdate();
            TextCorrecter.GetSource();

            Intermediary.MustBeHidden = HideAfterExecuting;
        }
    }
}
