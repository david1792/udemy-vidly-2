using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());// if we used this line of code, everyone who visit our web page, must be login, is very restrictive
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
