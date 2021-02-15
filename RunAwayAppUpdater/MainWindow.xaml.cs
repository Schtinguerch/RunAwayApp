using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ionic.Zip;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace RunAwayAppUpdater
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string DownloadedFile;

        private string UpdateFolder;

        private string ProrgamPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

        public MainWindow()
        {
            InitializeComponent();

            //Form shown -> start update
            UpdateAsync();
        }

        private async void UpdateAsync() => await Task.Run(() => Update());

        private void Update()
        {
            DownloadUpdate();
            DeployUpdateZipFiles(DownloadedFile);

            Process.Start(ProrgamPath + "RunAwayAppWPF.exe");
        }

        private void DownloadUpdate()
        {
            DownloadStatusHeader.Text = "Downloading update";

            WebClient webClient = new WebClient();
            string 
                url = "http://runawayapplication.000webhostapp.com/sourse/RunAwayAppUpdate.zip",
                updadeFolder = ProrgamPath + "\\TempUpdateData";

            DownloadedFile = updadeFolder + "RunAwayAppUpdate.zip";
            UpdateFolder = updadeFolder;

            webClient.DownloadProgressChanged += DownloadUpdateProgressChanged;
            webClient.DownloadFile(url, DownloadedFile);
        }

        private void DeployUpdateZipFiles(string zipFile) 
        {
            string lmlData = File.ReadAllText(ProrgamPath + "\\LML_Data\\CorrectingSource.lml");
            lmlData = Regex.Match(lmlData, "<<ShortCuts:(.*?):ShortCuts>>", RegexOptions.Multiline).Groups[1].Value;

            DownloadStatusHeader.Text = "Extracting files";

            ZipFile zippedFiles = ZipFile.Read(zipFile);
            foreach (ZipEntry zipEntry in zippedFiles)
            {
                zipEntry.Extract(ProrgamPath, ExtractExistingFileAction.OverwriteSilently);
            }

            File.Delete(UpdateFolder + "\\RunAwayAppUpdate.zip");

            string newLmlData = File.ReadAllText(ProrgamPath + "\\LML_Data\\CorrectingSource.lml");
            newLmlData = Regex.Replace(newLmlData, "<<ShortCuts:(.*?):ShortCuts>>", "<<ShortCuts:" + lmlData + ":ShortCuts>>", RegexOptions.Multiline);

            File.WriteAllText(ProrgamPath + "\\LML_Data\\CorrectingSource.lml", newLmlData);
        }

        private void DownloadUpdateProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadStatusProgress.Text = $"{e.BytesReceived} of {e.TotalBytesToReceive} bytes; {e.ProgressPercentage}%";
        }
    }
}
