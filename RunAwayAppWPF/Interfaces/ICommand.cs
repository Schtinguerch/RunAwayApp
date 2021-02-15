namespace RunAwayAppWPF
{
    interface ICommand
    { 
        bool HideAfterExecuting { get; set; }
        void Execute(string[] args);
    }
}
