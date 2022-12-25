using System;
using System.Data;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LT.NET_project_cuoiki
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConnectionMysql c = new ConnectionMysql();
            var d = c.SQL_query_to_DataTable("select * from product");
            
            foreach (DataRow r in d.Rows)
            {
                string s = r[columnName: "title"].ToString();
                Console.WriteLine(s);
               
            }

        }
       
    }
}
