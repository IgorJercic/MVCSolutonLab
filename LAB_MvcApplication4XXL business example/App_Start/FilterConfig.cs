using System.Web;
using System.Web.Mvc;

namespace LAB_MvcApplication4XXL_business_example
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}