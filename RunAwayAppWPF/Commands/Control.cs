using System;
using System.Diagnostics;
using RunAwayAppWPF.Properties;

namespace RunAwayAppWPF
{
    class Control : ICommand
    {
        public bool HideAfterExecuting { get; set; } = true;

        private string[] Refs;

        private string[] StartupURIs;

        public void Execute(string[] args)
        {
            var WasPattern = false;

            for (int i = 0; i < Refs.Length; i++)  
                if (args[0] == Refs[i])
                {
                    WasPattern = true;
                    Process.Start(StartupURIs[i]);
                    break;
                }

            if (!WasPattern)
                Process.Start("control " + args[1]);

            Intermediary.MustBeHidden = HideAfterExecuting;
        }

        public Control()
        {
            Refs = Settings.Default.CtrlRefs.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            StartupURIs = Settings.Default.CtrlStarts.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            if (Refs.Length != StartupURIs.Length)
                throw new NotImplementedException("Ошибка: количество входных и выходных ссылок не совпадает!\nПроверьте содержимое .lml-файлов.");
        }
    }
}
