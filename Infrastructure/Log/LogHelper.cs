using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;
//using log4net.Core;
//using log4net.Util;
using log4net;

namespace Infrastructure.Log
{
    public static class LogHelper
    {
            static readonly ILog Loginfo = LogManager.GetLogger("loginfo");
            static readonly ILog Logerror = LogManager.GetLogger("logerror");
            static readonly ILog Logmonitor = LogManager.GetLogger("logmonitor");

            public static void Error(string errorMsg, Exception ex = null)
            {
                if (ex != null)
                {
                    Logerror.Error(errorMsg, ex);
                }
                else
                {
                    Logerror.Error(errorMsg);
                }
            }

            public static void Info(string msg)
            {
                Loginfo.Info(msg);
            }

            public static void Monitor(string msg)
            {
                Logmonitor.Info(msg);
            }
     }

}
