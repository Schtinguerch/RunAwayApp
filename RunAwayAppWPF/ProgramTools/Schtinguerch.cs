using System;
using System.Linq;
using System.Reflection;

namespace RunAwayAppWPF
{
    class Schtinguerch
    {
        public string Command { get; private set; }

        private string[] Tokens { get; set; }

        public Schtinguerch() { }

        public Schtinguerch(string command)
        {
            SetCommand(command);
        }

        public void SetCommand(string command)
        {
            Command = TextCorrecter.CorrectToProgramCommand(command);
            Tokens = GetTokens(Command);
        }

        public void ExecuteCommand()
        {
            CallCommand(Tokens[0]);
        }
        
        public void ExecuteCommand(string command)
        {
            SetCommand(command);
            CallCommand(Tokens[0]);
        }

        private void CallCommand(string className)
        {
            var aClass = ClassByName(className);
            var method = aClass.GetType().GetMethod("Execute");
            method.Invoke(aClass, new object[] { Arguments(Tokens) });
        }

        private string[] GetTokens(string command) => 
            command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        private static object ClassByName(string className)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes().First(t => t.Name == className);

            return Activator.CreateInstance(type);
        }

        private string[] Arguments(string[] command)
        {
            var args = new string[command.Length - 1];

            for (int i = 1; i < command.Length; i++)
                args[i - 1] = command[i];

            return args;
        }
    }
}