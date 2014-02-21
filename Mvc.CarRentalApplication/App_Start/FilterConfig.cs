using System.Web;
using System.Web.Mvc;

namespace Mvc.CarRentalApplication
{
    /// <summary>
    /// This is the place to add filters to the application Globally
    /// </summary>
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new ValidateJsonAntiForgeryTokenAttribute());
        }
    }
}