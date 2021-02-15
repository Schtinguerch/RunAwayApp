using System;
using static System.Math;

namespace RunAwayAppWPF
{
    class NumeralConverter : ICommand
    {
        public bool HideAfterExecuting { get; set; }

        private char[] Letters = new char[]
           {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z', 'α', 'β', 'γ', 'δ',
                'ε', 'ζ', 'η', 'θ', 'ι', 'κ', 'λ', 'μ', 'ν', 'ξ',
                'ο', 'π', 'ρ', 'ς', 'σ', 'τ', 'υ', 'φ', 'χ', 'ψ',
                'ω', 'ϊ', 'ϋ', 'ό', 'ύ', 'ώ', 'À', 'Á', 'Â', 'Ã',
                'Ä', 'Å', 'Æ', 'Ç', 'È', 'É', 'Ê', 'Ë', 'Ì', 'Í',
                'Î', 'Ï', 'Ð', 'Ñ', 'Ò', 'Ó', 'Ô', 'Õ', 'Ö', 'Ø',
                'Ù', 'Ú', 'Û', 'Ü', 'Ý', 'Ā', 'Ă', 'Ą', 'Ć', 'Ĉ',
                'Ċ', 'Č', 'Ď', 'Đ', 'Ē', 'Ĕ', 'Ė', 'Ę', 'Ě', 'Ĝ',
                'Ğ', 'Ġ', 'Ģ', 'Ĥ', 'Ħ', 'Ĩ', 'Ī', 'Ĭ', 'Į', 'İ',
                'Ĳ', 'Ĵ', 'Ķ', 'Ĺ', 'Ļ', 'Ľ', 'Ŀ', 'Ł', 'Ń', 'Ņ',
                'Ň', 'Ŋ', 'Ō', 'Ŏ', 'Ő', 'Œ', 'Ŕ', 'Ŗ', 'Ř', 'Ś',
                'Ŝ', 'Ş', 'Š', 'Ţ', 'Ť', 'Ŧ', 'Ũ', 'Ū', 'Ŭ', 'Ů',
                'Ű', 'Ų', 'Ŵ', 'Ŷ', 'Ÿ', 'Ź', 'Ż', 'Ž', 'Ǎ', 'Ǐ',
                'Ǒ', 'Ǔ', 'Ǖ', 'Ǘ', 'Ǚ', 'Ǜ', 'Ǟ', 'Ǡ', 'Ǣ', 'Ǥ',
                'Ǧ', 'Ǩ', 'Ǫ', 'Ǭ', 'Ȁ', 'Ȅ', 'Ȉ', 'Ȍ', 'Ȑ', 'Ȕ'
           };

        public void Execute(string[] args)
        {
            HideAfterExecuting = false;
            Intermediary.MustBeHidden = HideAfterExecuting;
            Intermediary.CommandTextChanged = true;

            var convertNumSysDirective = args[0];
            convertNumSysDirective = convertNumSysDirective.Replace("Cmd", " ");
            var numSysRadixes = convertNumSysDirective.Split(new char[] { ' ' });

            int inputRadix = Convert.ToInt32(numSysRadixes[0]), outputRadix = Convert.ToInt32(numSysRadixes[1]);
            if (outputRadix == 10)
                Intermediary.CommandText = $"= {ConvertToDecimalNumSys(args[1], inputRadix)}";
            else if (inputRadix == 10)
                Intermediary.CommandText = $"= {ConvertFromDecimalSys(Convert.ToDouble(args[1]), outputRadix)}";
            else
            {
                var decimalNum = ConvertToDecimalNumSys(args[1], inputRadix);
                Intermediary.CommandText = $"= {ConvertFromDecimalSys(decimalNum, outputRadix)}";
            }
        }

        private double ConvertToDecimalNumSys(string num, int numSysFrom)
        {
            string expression;

            int multipler = 1;
            if (num != num.Replace("-", ""))
            {
                multipler = -1;
                expression = num.Replace("-", "");
            }

            int powerValue = -1;
            if (num != num.Replace(".", ""))
            {
                for (int i = 0; i < num.Length; i++)
                    if (num[i] == '.')
                        powerValue = i - 1;
            }
            else
                powerValue = num.Length - 1;


            expression = num.Replace(".", "");

            var value = 0d;

            for (int i = 0; i < expression.Length; i++)
                value += DecimalValFromChar(expression[i]) * Pow(numSysFrom, powerValue - i);

            return value * multipler;
        }

        private string ConvertFromDecimalSys(double num, int numSysTo)
        {
            var fracNumPart = num % 1;
            int intNumPart = (int)(num - fracNumPart);

            var value = "";
            while (intNumPart > 0)
            {
                value = CharFromDecimalVal(intNumPart % numSysTo) + value;
                intNumPart /= numSysTo;
            }
            if (fracNumPart > 0)
            {
                value += '.'; int x = 0;
                while ((fracNumPart > 0) && (x < 12))
                {
                    fracNumPart *= numSysTo;
                    value += CharFromDecimalVal((int)(fracNumPart - (fracNumPart % 1)));
                    fracNumPart %= 1; x++;
                }
            }

            return value;
        }

        private int DecimalValFromChar(char x)
        {
            int value = -1;
            for (int i = 0; i < Letters.Length; i++)
                if (Letters[i] == x)
                {
                    value = i;
                    break;
                }

            return value;
        }

        private char CharFromDecimalVal(int x)
        {
            return Letters[x];
        }
    }
}
