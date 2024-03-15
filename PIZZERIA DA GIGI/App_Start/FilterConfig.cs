using System.Web;
using System.Web.Mvc;

namespace PIZZERIA_DA_GIGI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
