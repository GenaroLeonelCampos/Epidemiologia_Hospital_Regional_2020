using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class Ingresos
    {
        [DisplayName("Id Ingreso")]
        public int? IngresosId { get; set; }
        [DisplayName("Código Medicamento")]
        public int? MedicamentoId { get; set; }
        [DisplayName("Código Cantidad")]
        public int? Cantidad { get; set; }
        [DisplayName("Fecha de Ingreso")]
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Fecha_Ingreso  { get; set; } = DateTime.Now;
        [MaxLength(150)]
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Observación")]
        public string? Observacion { get; set; }
        public int? Estado { get; set; }
        [DisplayName("Responsable Ingreso")]
        public int? ResponsableId { get; set; }
        public Medicamento Medicamento { get; set; }
        public Responsable Responsable { get; set; }
    }
}
