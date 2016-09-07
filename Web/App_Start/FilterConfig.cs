using System.Web;
using System.Web.Mvc;
using Web.Custom;
using Web.Exception;

namespace Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new MyAuthorizeAttribute());
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new MyHandleErrorAttribute());
        }
    }
}
