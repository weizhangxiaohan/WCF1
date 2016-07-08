using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AService.Logs
{
    public class Log4NetLogger : ILogger
    {
        private readonly log4net.ILog _log;

        public Log4NetLogger()
        {
            _log = log4net.LogManager.GetLogger("loginfo");
        }

        public void Log(string msg)
        {
            _log.Info(msg);
        }
    }
}
