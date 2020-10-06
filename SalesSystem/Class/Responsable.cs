﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class Responsable
    {
        [DisplayName("Id")]
        public int ResponsableId { get; set; }
        [DisplayName("Personal de salud")]
        public int? PerSalId { get; set; }
        [DisplayName("Profesión")]
        public int? ProfesionId { get; set; }
        [DisplayName("Fecha de Ingreso")]
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Fecha_Ingreso { get; set; }
        public int Estado { get; set; }
}
}
