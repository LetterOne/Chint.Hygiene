using System.Web;
using System.Web.Mvc;

namespace _12.Chint.Hygiene
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
