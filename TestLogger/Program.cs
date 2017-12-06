using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DumbLogger;
//using DumbLogger.Configuration;


namespace TestDumbLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            LogWriter firstLogger = LogManager.GetLogger("First");

            firstLogger.Debug("First message", new Exception("exception_message"));
            
            firstLogger.Error("First message", new Exception("exception_message"));

            Console.ReadLine();
        }

    }


}
