using RunAwayAppWPF.Properties;
using System;
using System.Diagnostics;

namespace RunAwayAppWPF
{
    public class WebKeysMethods
    {
        private string[] Refs;

        private string[] URLs;

        public void WwwKey(string[] args)
        {
            var wasPattern = false;
            for (int i = 0; i < Refs.Length; i++)
                if (args[1] == Refs[i])
                {
                    wasPattern = true;
                    Process.Start(Settings.Default.DefaultWebBrowser, URLs[i]);
                    break;
                }
            if (!wasPattern)
                Process.Start(Settings.Default.DefaultWebBrowser, args[1]);
        }

        public void AskKey(string[] args)
        {
            var url = "https://www.google.com/search?q=";
            for (int i = 1; i < args.Length; i++)
                url += "%20" + args[i];

            Process.Start(Settings.Default.DefaultWebBrowser, url);
        }

        public void TranslateKey(string[] args)
        {
            args[1] = args[1].Replace("Cmd", " ");
            var langKeys = args[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var text = "";
            for (int i = 2; i < args.Length; i++)
                text += args[i] + "%20";

            text = text.Replace("/", "%2F");
            text = text.Replace("\\", "%5C");
            text = text.Replace("+", "%2B");

            var url = $"https://translate.google.com/?hl=ru&sl={langKeys[0]}&tl={langKeys[1]}&text={text}&op=translate";
            Process.Start(Settings.Default.DefaultWebBrowser, url);
        }

        public WebKeysMethods()
        {
            Refs = Settings.Default.WebArgs.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            URLs = Settings.Default.WebURL.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
