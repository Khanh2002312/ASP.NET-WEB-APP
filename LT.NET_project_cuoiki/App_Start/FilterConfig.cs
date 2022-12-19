using System.Web;
using System.Web.Mvc;

namespace LT.NET_project_cuoiki
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
