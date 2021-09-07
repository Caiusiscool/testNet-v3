using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testNet_v3.Commands
{
    class Module
    {
        public string ModuleName;
        public string ModuleDescription;
        public string ModuleCMD;

        public Module(string name, string desc, string cmd)
        {
            ModuleName = name;
            ModuleDescription = desc;
            ModuleCMD = cmd;
            ModuleManager.RegisterModule(this);
        }

        public void onCall()
        {

        }
    }
}
