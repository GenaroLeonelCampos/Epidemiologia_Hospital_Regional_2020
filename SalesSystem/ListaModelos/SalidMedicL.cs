using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.ListaModelos
{
    public class SalidMedicL
    {
        [DisplayName("Id")]
        public int SalidMedicId { get; set; }
        [DisplayName("Medicamento")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int? MedicamentoId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Responsable")]
        public int? ResponsableId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Servicio")]
        public int? CartservId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Personal Salud")]
        public int? PerSalId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Pertenencia")]
        public int? PertenenciaId { get; set; }
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Fecha_salida { get; set; }
        [DisplayName("Cantidad")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int? Cantidad { get; set; }
        public string Observacion { get; set; }
        public int Estado { get; set; }

        [DisplayName("Medicamento")]
        public string Medicamento { get; set; }
        [DisplayName("Responsable")]
        public string Responsable { get; set; }
        [DisplayName("Servicio")]
        public string Cartserv { get; set; }
        [DisplayName("Personal Salud")]
        public string PerSal { get; set; }
        [DisplayName("Pertenencia")]
        public string Pertenencia { get; set; }
    }
}
