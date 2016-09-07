using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Custom
{
    public class MyHttpModule : IHttpModule
    {
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.EndRequest += WriteFFFF;
        }

        private void WriteFFFF(Object source,EventArgs e)
        {
            HttpApplication application = source as HttpApplication;

            HttpContext context = application.Context;

            //context.Response.Write("fffffffffffffffffffffffffffffffffffffffffffffffffff");
        }
    }
}