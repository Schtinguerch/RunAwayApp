using System;
using System.Linq;
using System.Reflection;
using RunAwayAppWPF.Properties;

namespace RunAwayAppWPF
{
    class ToolTable : ICommand
    {
        public bool HideAfterExecuting { get; set; }

        private string[] Refs;

        private string[] Windows;

        public void Execute(string[] args)
        {
            HideAfterExecuting = true;

            var argument = args[0];
            for (int i = 0; i < Refs.Length; i++)
                if (argument == Refs[i])
                {
                    var aWindow = ClassByName(Windows[i]);
                    var method = aWindow.GetType().GetMethod("Show");
                    method.Invoke(aWindow, null);
                }

            Intermediary.MustBeHidden = HideAfterExecuting;
        }

        public ToolTable()
        {
            Refs = Settings.Default.PadInputArgs.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            Windows = Settings.Default.PadWindows.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private object ClassByName(string className)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes().First(t => t.Name == className);

            return Activator.CreateInstance(type);
        }
    }
}
