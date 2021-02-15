using System;
using System.Net;
using System.Text.RegularExpressions;

namespace RunAwayAppWPF
{
    class CurrencyConverter : ICommand
    {
        public bool HideAfterExecuting { get; set; } = false;

        public void Execute(string[] args)
        {
            var convertCurSysDirective = args[0];
            convertCurSysDirective = convertCurSysDirective.Replace("Cmd", " ");
            var curCodes = convertCurSysDirective.Split(new char[] { ' ' });

            Intermediary.CommandText = (RublesInValute(curCodes[0].ToUpper()) / RublesInValute(curCodes[1].ToUpper()) * Convert.ToSingle(args[1].Replace(".", ","))).ToString();
            Intermediary.MustBeHidden = HideAfterExecuting;
            Intermediary.CommandTextChanged = true;
        }

        private double RublesInValute(string valCode)
        {
            if (valCode == "RUB") return 1;

            var webClient = new WebClient();
            var allXmlData = webClient.DownloadString("https://www.cbr-xml-daily.ru/daily_eng_utf8.xml");
            var match = Regex.Match(allXmlData, "<CharCode>" + valCode + "</CharCode><Nominal>(.*?)</Nominal><Name>(.*?)</Name><Value>(.*?)</Value>");

            var val = Convert.ToDouble(match.Groups[3].Value) + 0d;
            var nominal = Convert.ToDouble(match.Groups[1].Value) + 0d;

            return val / nominal;
        }
    }
}
