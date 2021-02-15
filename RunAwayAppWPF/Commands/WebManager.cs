using System;
using RunAwayAppWPF.Properties;
using System.Reflection;

namespace RunAwayAppWPF
{
    public partial class WebManager : ICommand
    {
        public bool HideAfterExecuting { get; set; }

        private string[] WebKeyArgs;

        private string[] WebKeyMethods;

        public void Execute(string[] args)
        {
            HideAfterExecuting = true;

            var cls = new WebKeysMethods();
            for (int i = 0; i < WebKeyArgs.Length; i++)
                if (args[0] == WebKeyArgs[i])
                {
                    MethodInfo method = cls.GetType().GetMethod(WebKeyMethods[i]);
                    method.Invoke(cls, new object[] { args });
                }
        }

        public WebManager()
        {
            WebKeyArgs = Settings.Default.KeyInputArgs.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            WebKeyMethods = Settings.Default.KeyFunctions.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
