using Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
//using System.Web.Http.Filters;


namespace Web.Custom
{
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            LogHelper.Info("MyActionFilter -- OnActionExecuted");
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LogHelper.Info("MyActionFilter -- OnActionExecuting");
        }


        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            LogHelper.Info("MyActionFilter -- OnResultExecuted");
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            LogHelper.Info("MyActionFilter -- OnResultExecuting");
        }
    }
}