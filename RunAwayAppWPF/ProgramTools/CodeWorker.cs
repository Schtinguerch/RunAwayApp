using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RunAwayAppWPF
{
    public enum WorkingPriority
    {
        CustomRulesPriority,
        StandardRulesPriority
    }

    public class CodeWorker
    {
        public struct Pattern
        {
            public string Input;
            public string Replacement;
        }

        public List<Pattern> Rules { get; } = new List<Pattern>();

        public List<IRule> CustomRules { get; } = new List<IRule>();

        public string WorkingString { get; set; }

        public void AddNewRule(string inputString, string replacement) =>
            Rules.Add(new Pattern()
            {
                Input = inputString,
                Replacement = replacement
            });
        

        public void AddNewRule(IRule rule) => CustomRules.Add(rule);

        public void ClearRules()
        {
            Rules.Clear();
            CustomRules.Clear();
        }

        public CodeWorker(string workingString) => WorkingString = workingString;

        public void ProcessString()
        {
            ProcessStandardRules();
            ProcessCustomRules();
        }

        public void ProcessString(WorkingPriority priority)
        {
            if (priority == WorkingPriority.CustomRulesPriority)
            {
                ProcessCustomRules();
                ProcessStandardRules();
            }
            else
            {
                ProcessStandardRules();
                ProcessCustomRules();
            }
        }

        private void ProcessStandardRules()
        {
            foreach (var rule in Rules)
                WorkingString = Regex.Replace(WorkingString, rule.Input, rule.Replacement, RegexOptions.Multiline);
        }

        private void ProcessCustomRules()
        {
            foreach (var rule in CustomRules)
                WorkingString = Regex.Replace(WorkingString, rule.InputString, rule.GetValue(rule.InputString), RegexOptions.Multiline);
        }
    }

    public class OutFunctionWorker : IRule
    {
        public string InputString { get; set; }

        public string GetValue(string input)
        {
            var value = input;

            value = Regex.Replace(value, "Calc.StringAdd:\\s+", "Calc.StringAdd(");
            value += ")";
            value = Regex.Replace(value, "\\s+", ",");
            value = Regex.Replace(value, ",[)]", ")");

            return value;
        }
    }

    public class ArrayQuotesWorker : IRule
    {
        public string InputString { get; set; }

        public string GetValue(string input)
        {
            var value = input;

            value = Regex.Replace(value, "[<]\\s*", "{");
            value = Regex.Replace(value, "\\s*[>]", "}");
            value = Regex.Replace(value, "\\s+", ",");
            value = Regex.Replace(value, ",[}]", "}");

            return value;
        }
    }
}