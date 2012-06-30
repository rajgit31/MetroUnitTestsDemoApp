using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAccessDemo
{
    public interface ILoggerService
    {
        void Log(string message);
    }


    public class LoggerService : ILoggerService
    {
        public void Log(string message)
        {
            //Log the message to a db
        }
    }
}
