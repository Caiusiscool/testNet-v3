using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testNet_v3.Util;
namespace testNet_v3.Commands
{
    class ModuleManager
    {

        private static List<Module> modules = new List<Module>();

        public ModuleManager()
        {
            Logger.Log(Logger.LogType.INFO, "Module manager succesfully initialized");
        }

        public static void RegisterModule(Module m)
        {
            modules.Add(m);
            Logger.Log(Logger.LogType.INFO, "Registered module: " + m.ModuleName);
        }

        public Module GetModuleByName(string name)
        {
            foreach(Module m in modules)
            {
                if(m.ModuleName == name)
                {
                    return m;
                }
            }
            return null;
        }
    }
}
