using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp
{
    public class Logger : Ilogger
    {
        public void log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter("log.txt",true))
            {
              
                streamWriter.WriteLine(message);
            }
            Console.WriteLine(message);
        }

        public void log(string message, String messagetype)
        {
            log($"{messagetype} : {message}");
        }
    }
}
