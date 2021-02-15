using RunAwayAppWPF.Properties;
using LmlLibrary;
using Microsoft.Win32;
using System;
using System.Windows;

namespace RunAwayAppWPF
{
    public static class Sourcer
    {
        public static void CommandSourceUpdate()
        {
            var mailLml = new Lml("LML_Data\\CalculatorReferences.lml", Lml.Open.FromFile);
            Settings.Default.CalcInputArgs = ArrayToString(mailLml.GetArray("CalculatorReferences>Arguments"), '|');
            Settings.Default.CalcFunctions = ArrayToString(mailLml.GetArray("CalculatorReferences>Functions"), '|');
            Settings.Default.CalcDescriptions = ArrayToString(mailLml.GetArray("CalculatorReferences>Descriptions"), '|');

            mailLml = new Lml("LML_Data\\ControlPanelReferences.lml", Lml.Open.FromFile);
            Settings.Default.CtrlRefs = ArrayToString(mailLml.GetArray("ControlPanelReferences>Arguments"), '|');
            Settings.Default.CtrlStarts = ArrayToString(mailLml.GetArray("ControlPanelReferences>References"), '|');

            mailLml = new Lml("LML_Data\\SystemReferences.lml", Lml.Open.FromFile);
            Settings.Default.SysRefs = ArrayToString(mailLml.GetArray("SystemReferences>Arguments"), '|');
            Settings.Default.SysStarts = ArrayToString(mailLml.GetArray("SystemReferences>References"), '|');

            int spCount = mailLml.GetInt("SystemReferences>SpecCommandsCount");
            Settings.Default.SysSpNames = mailLml.GetString($"SystemReferences>Name0");
            Settings.Default.SysSpCmds = mailLml.GetString($"SystemReferences>Spec0");
            for (int i = 1; i < spCount; i++)
            {
                Settings.Default.SysSpNames += "|" + mailLml.GetString($"SystemReferences>Name{i}");
                Settings.Default.SysSpCmds += "|" + mailLml.GetString($"SystemReferences>Spec{i}");
            }

            mailLml = new Lml("LML_Data\\WebReferences.lml", Lml.Open.FromFile);
            Settings.Default.WebArgs = ArrayToString(mailLml.GetArray($"WebReferences>Arguments"), '|');
            Settings.Default.WebURL = ArrayToString(mailLml.GetArray($"WebReferences>References"), '|');

            mailLml = new Lml("LML_Data\\WebKeysReferences.lml", Lml.Open.FromFile);
            Settings.Default.KeyInputArgs = ArrayToString(mailLml.GetArray("WebKeysReferences>Inputs"), '|');
            Settings.Default.KeyFunctions = ArrayToString(mailLml.GetArray("WebKeysReferences>Outputs"), '|');

            mailLml = new Lml("LML_Data\\PadReferences.lml", Lml.Open.FromFile);
            Settings.Default.PadInputArgs = ArrayToString(mailLml.GetArray("PadReferences>Inputs"), '|');
            Settings.Default.PadWindows = ArrayToString(mailLml.GetArray("PadReferences>Outputs"), '|');

            mailLml = new Lml("LML_Data\\!CodeWords.lml", Lml.Open.FromFile);
            Settings.Default.DefaultWebBrowser = mailLml.GetArray("CodeWords>Outputs")[0];

            Settings.Default.Save();
        }


        public static string ArrayToString(string[] objs, char separator)
        {
            var value = "";

            value += objs[0];
            for (int i = 1; i < objs.Length; i++)
                value += separator + objs[i];

            return value;
        }
    }
}
