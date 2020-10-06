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
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Medicamento")]
        public int? MedicamentoId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Farmacéutico")]
        public int? ResponsableId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Servicio")]
        public int? CartservId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Personal de salud")]
        public int? PerSalId { get; set; }
        [DisplayName("Pertenece")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int? PertenenciaId { get; set; }
        //[DisplayName("Fecha de Ingreso")]
        //[Required(ErrorMessage = "Debe ingresar una {0}")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Fecha_salida { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Cantidad")]
        public int? Cantidad { get; set; }
        [DisplayName("Observación")]
        public string Observacion { get; set; }
        [DisplayName("Estado")]
        public int Estado { get; set; }
        [DisplayName("Medicamento")]
        public string Medicamento { get; set; }
        [DisplayName("Resp. Farmacia")]
        public string Responsable { get; set; }
        [DisplayName("Servicio")]
        public string Cartera { get; set; }
        [DisplayName("Personal de salud")]
        public string Salud { get; set; }
        [DisplayName("Pertenece")]
        public string Pertenencia { get; set; }
    }
}
