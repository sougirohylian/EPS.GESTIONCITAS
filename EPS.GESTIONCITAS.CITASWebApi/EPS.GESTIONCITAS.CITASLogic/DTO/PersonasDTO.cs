using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPS.GESTIONCITAS.CITASLogic.DTO
{
    public class PersonasDTO
    {
        [Key]
        public decimal ID_PERSONA { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public Nullable<System.DateTime> FECHA_NACIMIENTO { get; set; }
        public Nullable<decimal> ID_TIPO_PERSONA { get; set; }
        public Nullable<decimal> CEDULA { get; set; }
    }
}
