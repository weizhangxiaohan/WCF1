using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Log;

namespace Web.Exception
{
    public class MyHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            LogHelper.Error("ErrorMessage:" + filterContext.Exception.Message + ";Stack:" + filterContext.Exception.StackTrace);
        }
    }
}