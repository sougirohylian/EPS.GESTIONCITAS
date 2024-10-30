using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPS.GESTIONCITAS.CITASLogic.Settings
{
    public interface IGlobalSettings
    {
        /// <summary>
        /// Url de consumo al servicio Personas
        /// </summary>
        string PersonasUrl { get; set; }
        /// <summary>
        /// Url de consumo al servicio Recetas
        /// </summary>
        string RecetasUrl { get; set; }
    }
    public class GlobalSettings : IGlobalSettings
    {
        public string PersonasUrl { get; set; }
        public string RecetasUrl { get; set; }
    }
}
