using System;
using System.Diagnostics;
using RunAwayAppWPF.Properties;

namespace RunAwayAppWPF
{
    class SystemManager : ICommand
    {
        public bool HideAfterExecuting { get; set; }

        private string[] Refs;

        private string[] StartupURIs;

        private string[] SpecURIs;

        private string[] SpecRefs;

        public void Execute(string[] args)
        {
            HideAfterExecuting = true;
            var WasPattern = false;

            for (int i = 0; i < Refs.Length; i++)
                if (args[0] == Refs[i])
                {
                    WasPattern = true;
                    Process.Start(StartupURIs[i]);
                    break;
                }

            if (!WasPattern)
            {
                for (int i = 0; i < SpecRefs.Length; i++)
                {
                    if (args[0] == SpecRefs[i])
                    {
                        WasPattern = true;
                        var spTokens = SpecURIs[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        var run = new Run();
                        run.Execute(spTokens);
                        break;
                    }
                }
            }
            if (!WasPattern)
                throw new NotImplementedException($"Аргумент \"{args[1]}\" не существует в данном контексте!");

            Intermediary.MustBeHidden = HideAfterExecuting;
        }

        public SystemManager()
        {
            Refs = Settings.Default.SysRefs.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            StartupURIs = Settings.Default.SysStarts.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            if (Refs.Length != StartupURIs.Length)
                throw new NotImplementedException("Ошибка: количество входных и выходных ссылок не совпадает!\nПроверьте содержимое .lml-файлов.");

            SpecRefs = Settings.Default.SysSpNames.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            SpecURIs = Settings.Default.SysSpCmds.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
