using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork13_7.Bank.Logger
{
    public class Logger
    {
        public delegate void AddLogEvent(string message);
        private static AddLogEvent _logEvent;

        static Logger() 
        { 
        }

        public static void AddEventLogHandler(AddLogEvent handler)
        {
            _logEvent = handler;
        }

        public static void AddEvent(string message)
        {
            _logEvent?.Invoke(message);
        }
    }
}
