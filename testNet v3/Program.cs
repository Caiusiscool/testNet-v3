using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using testNet_v3.Util;

namespace testNet_v3
{

    class Program
    {
        
        //private static Thread threadInputListener = new Thread(Commands.InputListener);
        //private static Thread threadNetworkListener = new Thread(Networking.Listener.StartListening);
        //private static Thread threadCommandHandler = new Thread(Commands.CommandHandler);
        static void Main(string[] args)
        {
            Logger.Log(Logger.LogType.INFO, "Program started");
            Commands.ModuleManager module_manager = new Commands.ModuleManager();
            //threadCommandHandler.Start();
            //threadInputListener.Start();
            //threadNetworkListener.Start();
            //Commands.DisplayLogo();
        }


        


    }
}
