using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunAwayAppWPF
{
    class RunAway : ICommand
    {
        public bool HideAfterExecuting { get; set; }

        public void Execute(string[] args) =>
            Sourcer.CommandSourceUpdate();
    }
}
