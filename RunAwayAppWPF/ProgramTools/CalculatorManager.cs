using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using RunAwayAppWPF.Properties;
using RunAwayAppWPF.UserWindows;

namespace RunAwayAppWPF
{
    public class CalculatorManager : MarshalByRefObject
    {
        private string[] InputArgs;

        private string[] Functions;

        public List<Variable> Variables = new List<Variable>();

        public List<string> Values = new List<string>();

        public double Value { get; set; }

        public string StringValue { get; set; }

        public CalculatorManager()
        {
            StringValue = "";

            InputArgs = Settings.Default.CalcInputArgs.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            Functions = Settings.Default.CalcFunctions.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public string CorrectedExpression(string expression)
        {
            var value = expression;

            for (int i = 0; i < InputArgs.Length; i++)
                value = Regex.Replace(value, InputArgs[i], Functions[i]);

            return value;
        }

        public string FinalCorrection(string result)
        {
            var value = result;

            result = result.Replace(",", ".");
            result = result.Replace("E+", "*ten(");
            result = result.Replace("E-", "*ten(-");

            if (Regex.IsMatch(result, "ten"))
                result += ")";

            value = result;
            return value;
        }

        
        public double Ctg(double x) => Math.Pow(Math.Tan(x), -1);

        public double Ln(double x) => Math.Log(x);

        public double Lg(double x) => Math.Log10(x);

        public int Factorial(int x)
        {
            int value = 1;

            for (int i = 2; i <= x; i++)
                value *= i;

            return value;
        }

        public double Ten(double x) => Math.Pow(10, x);

        public double Snum(double x) => Math.Round(x);

        public double Trunc(double x) => Math.Ceiling(x);

        public int Rnd(int x, int y) => new Random().Next(x, y);

        public double Sqrn(double n, double x) => Math.Pow(x, 1d / n);
        

        public int Hex(string n)
        {
            int value = 0, p = 16;
            foreach (var d in n)
            {
                var i = d < '0' || d > '9' ? char.ToUpper(d) - 'A' + 10 : d - '0';
                value = value * p + i;
            }
            return value;
        }

        public void StringAdd(params object[] x)
        {
            StringValue += Regex.Replace(x[0].ToString(), ",", ".");
            for (int i = 1; i < x.Length; i++)
                StringValue += ", " + Regex.Replace(x[i].ToString(), ",", ".");
        }

        public void AddVariable(string name, string val) =>
            Variables.Add(new Variable()
            {
                Var = name,
                Val = val
            });
        

        public void AddNewValue(object x)
        {
            var type = x.GetType();
            if (type.Equals(typeof(double[])))
            {
                var array = (double[])x;
                var value = $"<{array[0]}";

                for (int i = 1; i < array.Length; i++)
                    value += $" {array[i]}";

                value += ">";

                Values.Add(value);
            }
            else
                Values.Add(x.ToString());
        }
    }
}
