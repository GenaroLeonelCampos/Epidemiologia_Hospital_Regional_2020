using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.ListaModelos
{
    public class IngresosL
    {
        [Key]
        public int? IngresosId { get; set; }
        [DisplayName("Medicamento")]
        [Required(ErrorMessage = "Debe ingresar un {0}")]
        public int? MedicamentoId { get; set; }
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [DisplayName("Cantidad")]
        public int? Cantidad { get; set; }
        [DisplayName("Fecha de Ingreso")]
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Fecha_Ingreso { get; set; }
        [MaxLength(150)]
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Observación")]
        public string Observacion { get; set; }
        public int Estado { get; set; }
        [Required(ErrorMessage = "Debe ingresar un {0}")]
        [DisplayName("Responsable")]
        public int? ResponsableId { get; set; }
        [DisplayName("Medicamento")]
        public string Medicamento { get; set; }
        [DisplayName("Responsable")]
        public string Responsable { get; set; }

    }
}
