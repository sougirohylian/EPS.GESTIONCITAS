using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPS.GESTIONCITAS.CITASLogic.DTO
{
    public class RecetasDTO
    {
        [Key]
        public decimal ID_RECETA { get; set; }
        public decimal ID_MEDICO { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal ID_ESTADO { get; set; }
    }
}
