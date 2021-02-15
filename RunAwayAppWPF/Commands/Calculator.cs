using Tech.CodeGeneration;
using Tech.CodeGeneration.Compilers;

namespace RunAwayAppWPF
{
    class Calculator : ICommand
    {
        public bool HideAfterExecuting { get; set; }

        public void Execute(string[] args)
        {
            HideAfterExecuting = false;

            var Calc = new CalculatorManager();
            var command = $"Calc.Value = {Calc.CorrectedExpression(GetStringByTokens(args))};"; 

            using (var sandBox = new Sandbox())
            {
                var d = CodeGenerator.CreateCode<double>
                (   sandBox,
                    CS.Compiler,
                    command, null, null,
                    CodeParameter.Create("Calc", Calc
                ));

                d.Execute(Calc);
            }

            var result = $" = {Calc.FinalCorrection(Calc.Value.ToString())}";

            Intermediary.MustBeHidden = HideAfterExecuting;
            Intermediary.CommandTextChanged = true;

            Intermediary.CommandText = result;
            Intermediary.CaretOffset = result.Length;
        }

        private string GetStringByTokens(string[] tokens)
        {
            var value = "";

            foreach (var token in tokens)
                value += token;

            return value;
        }
    }
}
