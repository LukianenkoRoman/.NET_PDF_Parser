using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parser.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Parser.Infrastructure.Realization
{
    class log : ILog
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static void Debug(string message) => logger.Debug(message);
        public static void Info(string message) => logger.Info(message);
        public static void Warn(string message) => logger.Warn(message);
        public static void Error(string message) => logger.Error(message);
        public static void Fatal(string message) => logger.Fatal(message);
    }

    class check_logger_config
    {
        public static void check_logger_directory()
        {
            if (LogManager.Configuration == null)
            {
                Console.WriteLine("Error: NLog.config not loaded!");
                return;
            }

        }

    }
}
