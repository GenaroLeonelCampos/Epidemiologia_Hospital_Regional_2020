using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class Medicamento
    {
        public int MedicamentoId { get; set; }
        [MaxLength(150)]
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Código SISMED")]
        public string? Cod_sismed { get; set; }
        [DisplayName("Denominación")]
        public string? Denominacion { get; set; }
        [DisplayName("COncentración")]
        public string? Concentracion { get; set; }
        [DisplayName("Presentación")]
        public string? Presentacion { get; set; }
        [DisplayName("N° Ingresos")]
        //public int? Ingresos { get; set; }
        //[DisplayName("Salso")]
        public int? Saldo { get; set; }
        [DisplayName("Fecha de Ingreso")]
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Fecha_Ingreso { get; set; }
        [DisplayName("Observación")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string? Observacion { get; set; }    
        [DisplayName("Estado")]
        public int? Estado { get; set; }

        //public virtual ICollection<Salidas> Salidas { get; set; }
    }
}
