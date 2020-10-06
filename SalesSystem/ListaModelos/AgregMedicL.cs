using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.ListaModelos
{
    public class AgregMedicL
    {
        [DisplayName("Id")]
        public int AgregMedicId { get; set; }
        [DisplayName("Medicamento")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int? MedicamentoId { get; set; }
        [DisplayName("Personal de Salud")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int? PerSalId { get; set; }
        [DisplayName("Fecha de Ingreso")]
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Fecha_Ingreso { get; set; }
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [DisplayName("Cantidad")]
        public int? Cantidad { get; set; }
        [DisplayName("Observación")]
        public string Observacion { get; set; }
        [DisplayName("Personal de Salud")]
        public string PersonalSalud { get; set; }
        [DisplayName("Medicamento")]
        public string Medicamento { get; set; }
    }
}
