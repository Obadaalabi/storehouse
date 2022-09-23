using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp
{
   public interface Ilogger
    {
        void log(string message);
        void log(string message, String messagetype);
    }
}
