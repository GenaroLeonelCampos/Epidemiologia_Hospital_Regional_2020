﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.ListaModelos
{
    public class MedicamentoL
    {
        [Key]
        public int MedicamentoId { get; set; }
        [MaxLength(150)]
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Código SISMED")]
        public string? Cod_sismed { get; set; }
        [DisplayName("Denominación")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string? Denominacion { get; set; }
        [DisplayName("Concentración")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string? Concentracion { get; set; }
        [DisplayName("Presentación")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string? Presentacion { get; set; }
        //[DisplayName("N° Ingresos")]
        //[Required(ErrorMessage = "Este campo es requerido")]
        //public int? Ingresos { get; set; }
        [DisplayName("Saldo")]
        public int? Saldo { get; set; }
        [DisplayName("Fecha de Ingreso")]
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Fecha_Ingreso { get; set; }
        [DisplayName("Observación")]    
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        public string? Observacion { get; set; }
    }
}
