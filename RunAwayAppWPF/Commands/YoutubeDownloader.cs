namespace RunAwayAppWPF
{
    class YoutubeDownloader : ICommand
    {
        public bool HideAfterExecuting { get; set; } = true;

        public void Execute(string[] args)
        {
            Intermediary.MustBeHidden = HideAfterExecuting;
            var url = args[0];

            System.IO.File.WriteAllText("DownloadVideoScript.bat", $"youtube-dl.exe {url}");
            System.Diagnostics.Process.Start("DownloadVideoScript.bat");
        }
    }
}
