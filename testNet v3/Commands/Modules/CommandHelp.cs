using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testNet_v3.Commands.Modules
{
    class CommandHelp
    {
        private static Module help_cmd = new Module("help", "Help", "Command used to display useful information about testNet");

        public static void Init()
        {

        }

    }
}
