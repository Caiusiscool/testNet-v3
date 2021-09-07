using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace testNet_v3.Util
{
    class Logger
    {
        public enum LogType
        {
            WARNING,
            ERROR,
            INFO,
        };
        private static StreamWriter sw;

        public static void Log(LogType type, string content)
        {
            File.AppendAllText(netCfg.logPath, DateTime.Now.ToString() + " | [" + type.ToString() + "] " + content + Environment.NewLine);
        }
    }
}
