using EPS.GESTIONCITAS.PERSONAS.App_Start;
using EPS.GESTIONCITAS.PERSONAS.LOGIC.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EPS.GESTIONCITAS.PERSONAS
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //NinjectWebCommon.Start();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Otras configuraciones...
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            //Generamos la coleccion de servicios
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPersonasServices, PersonasServices>();

        }
    }
}
