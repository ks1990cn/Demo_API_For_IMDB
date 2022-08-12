using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
   public static class Logger
    {
        public static void LogInOutput(string message)
        {
            Debug.WriteLine("Log : " + message);
        }
    }
}
