using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPS.GESTIONCITAS.RECETASLogic.Services.Base
{
    /// <summary>
    /// Resultado al eejecutar un servicio
    /// </summary>
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public T Extras { get; set; }

        /// <summary>
        /// Marca como exitoso en casio que haya errores
        /// </summary>
        public void MarkAsSuccessIfNoErrors()
        {
            Success = Errors.Count == 0;
        }
    }
}
