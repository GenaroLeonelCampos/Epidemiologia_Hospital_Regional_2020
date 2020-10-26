using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Epidemiologia.Class
{
    public partial class Empleados
    {       
        [Key]
        public int IdEmpleado { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public int IdCondicionTrabajo { get; set; }
        public int IdTipoEmpleado { get; set; }
        public string Dni { get; set; }
        public string CodigoPlanilla { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? FechaIngreso { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? FechaAlta { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public int? LoginEstado { get; set; }
        public string LoginPc { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? IdTipoDestacado { get; set; }
        public int? IdEstablecimientoExterno { get; set; }
        public string HisCodigoDigitador { get; set; }
        public bool? ReniecAutorizado { get; set; }
        public int? IdTipoDocumento { get; set; }
        public int? IdSupervisor { get; set; }
        public bool? EsActivo { get; set; }
        public int? IdTipoSexo { get; set; }
        public int? IdPais { get; set; }
    
       
    }
}
