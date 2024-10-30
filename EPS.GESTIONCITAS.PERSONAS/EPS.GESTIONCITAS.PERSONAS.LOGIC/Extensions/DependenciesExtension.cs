using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPS.GESTIONCITAS.PERSONAS.DATAACCESS;
using EPS.GESTIONCITAS.PERSONAS.DATAACCESS.Repositories;
using EPS.GESTIONCITAS.PERSONAS.LOGIC.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EPS.GESTIONCITAS.PERSONAS.LOGIC.Extensions
{
    public static class DependenciesExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            #region Servicios
            services.AddHttpClient<IConsumerService, ConsumerService>();
            services.AddScoped<IConsumerService, ConsumerService>();
            services.AddScoped<IPersonasServices, PersonasServices>();
            #endregion
            #region Repositorios
            services.AddScoped<IPersonasRepository, PersonasRepository>();
            #endregion
        }
    }
}
