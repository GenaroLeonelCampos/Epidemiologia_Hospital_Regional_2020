using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class AgregMedic
    {
        [DisplayName("Id")]
        public int AgregMedicId { get; set; }
        [DisplayName("Medicamento")]
        public int MedicamentoId { get; set; }
        [DisplayName("Personal de Salud")]
        public int PerSalId { get; set; }
        [DisplayName("Fecha de Ingreso")]
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Fecha_Ingreso { get; set; }
        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }
        [DisplayName("Obsercación")]
        public string Observacion { get; set; }
    }
}
