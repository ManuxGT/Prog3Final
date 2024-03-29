//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prog3Final
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class SalidaEmpleado
    {

        public int Id { get; set; }
    
        [Required(ErrorMessage ="Se necesita el Codigo del empleado")]
        public int IdEmpleado { get; set; }

        [Required(ErrorMessage = "Se necesita el tipo de salida")]
        public string TipoSalida { get; set; }

        public string Motivo { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Se necesita la fecha de salida")]
        public  DateTime FechaSalida { get; set; }
    
        public virtual Empleado Empleado { get; set; }
    }
}
