using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Custom
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    base.OnAuthorization(filterContext);
        //}

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User.Identity.Name == "laowang")
                return true;
            else
                return false;
        }       
    }
}