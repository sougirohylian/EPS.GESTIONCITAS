//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EPS.GESTIONCITAS.CITASDataAccess.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CITAS
    {
        [Key]
        public decimal ID_CITAS { get; set; }
        public Nullable<System.DateTime> FECHA_CITA { get; set; }
        public Nullable<decimal> ID_PERSONA { get; set; }
        public Nullable<decimal> ID_MEDICO { get; set; }
        public Nullable<decimal> ID_RECETA { get; set; }
        public Nullable<decimal> ID_ESTADO { get; set; }
    }
}
