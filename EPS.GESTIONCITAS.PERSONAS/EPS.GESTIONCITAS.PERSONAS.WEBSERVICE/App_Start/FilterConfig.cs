using System.Web;
using System.Web.Mvc;

namespace EPS.GESTIONCITAS.PERSONAS.WEBSERVICE
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
