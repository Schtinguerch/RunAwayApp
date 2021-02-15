using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunAwayAppWPF
{
    public interface IRule
    {
        string InputString { get; set; }

        string GetValue(string input);
    }
}
