using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace RunAwayAppWPF
{
    public class ProrgamKeysMethods
    {
        public string GotValue { get; private set; } = "";

        public void VersionKey()
        {
            GotValue = "version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public void UpdateKey()
        {

        }

        public void BackupKey()
        {

        }

        public void RecoveryKey()
        {

        }

        public void CheckVersionKey()
        {

        }
    }
}
