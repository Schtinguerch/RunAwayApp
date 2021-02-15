using System.Collections.Generic;
using System.Text.RegularExpressions;
using LmlLibrary;

namespace RunAwayAppWPF
{
    public static class TextCorrecter
    {
        private static List<string> CorrectPatterts = new List<string>();

        private static List<string> CorrectingNames = new List<string>();

        private static List<string> Replacement = new List<string>();

        private static List<string> ShortCuts = new List<string>();

        private static List<string> RepShCuts = new List<string>();

        private static List<string> CodeWordsInputs = new List<string>();

        private static List<string> CodeWordsOutputs = new List<string>();

        public static void GetSource()
        {
            CorrectPatterts.Clear();
            CorrectingNames.Clear();
            Replacement.Clear();

            Add();
        }

        public static void ClearAll()
        {
            CorrectPatterts.Clear();
            CorrectingNames.Clear();
            Replacement.Clear();
        }

        public static string CorrectLive(string text)
        {
            var value = text;

            for (int i = 0; i < CorrectingNames.Count; i++)
                value = Regex.Replace(value, CorrectingNames[i], CorrectPatterts[i]);

            for (int i = 0; i < ShortCuts.Count; i++)
                value = Regex.Replace(value, ShortCuts[i], RepShCuts[i]);

            return value;
        }

        public static string CorrectShortCuts(string text)
        {
            var value = text;

            for (int i = 0; i < ShortCuts.Count; i++)
                value = Regex.Replace(value, ShortCuts[i], RepShCuts[i]);

            return value;
        }

        public static string CorrectToProgramCommand(string text) //------------------------------------------------------------
        {
            var value = text;

            for (int i = 0; i < CorrectPatterts.Count; i++)
                value = Regex.Replace(value, CorrectPatterts[i], Replacement[i]);

            for (int i = 0; i < CodeWordsInputs.Count; i++)
                value = Regex.Replace(value, CodeWordsInputs[i], CodeWordsOutputs[i]);

            return value;
        }

        private static void Add()
        {
            var reader = new Lml("LML_Data\\CorrectingSource.lml", Lml.Open.FromFile);

            var liveinputs = reader.GetArray("CorrectSourse>LiveInputs");
            var inputs = reader.GetArray("CorrectSourse>Inputs");
            var outputs = reader.GetArray("CorrectSourse>Outputs");

            var shortCuts = reader.GetArray("ShortCuts>Inputs");
            var repShCuts = reader.GetArray("ShortCuts>Outputs");

            reader = new Lml("LML_Data\\!CodeWords.lml", Lml.Open.FromFile);
            var codeWordsIn = reader.GetArray("CodeWords>Inputs");
            var codeWordsOut = reader.GetArray("CodeWords>Outputs");

            if (inputs.Length == outputs.Length && inputs.Length == liveinputs.Length)
                for (int i = 0; i < inputs.Length; i++)
                {
                    CorrectingNames.Add(liveinputs[i]);
                    CorrectPatterts.Add(inputs[i]);
                    Replacement.Add(outputs[i]);
                }

            if (shortCuts.Length == repShCuts.Length)
                for (int i = 0; i < shortCuts.Length; i++)
                {
                    ShortCuts.Add(shortCuts[i]);
                    RepShCuts.Add(repShCuts[i]);
                }

            if (codeWordsIn.Length == codeWordsOut.Length)
                for (int i = 0; i < codeWordsIn.Length; i++)
                {
                    CodeWordsInputs.Add(codeWordsIn[i]);
                    CodeWordsOutputs.Add(codeWordsOut[i]);
                }
        }
    }
}
