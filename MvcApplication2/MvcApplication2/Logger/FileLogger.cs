using System;
using System.IO;

namespace MvcApplication2.Logger
{
    public class FileLogger
    {
        public void LogException(Exception e)
        {
            File.WriteAllLines("C://Error//" + DateTime.Now.ToString("dd-MM-yyyy mm hh ss") + ".txt",
                new[]
                {
                    "Message:" + e.Message,
                    "Stacktrace:" + e.StackTrace
                });
        }
    }
}