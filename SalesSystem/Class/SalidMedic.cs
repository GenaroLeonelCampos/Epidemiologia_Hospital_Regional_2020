using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class SalidMedic
    {
        [DisplayName("Id")]
        public int SalidMedicId { get; set; }
        [DisplayName("Medicamento")]
        public int MedicamentoId { get; set; }
        [DisplayName("Farmacéutico")]
        public int ResponsableId { get; set; }
        [DisplayName("Servicio")]
        public int CartservId { get; set; }
        [DisplayName("Personal de salud")]
        public int PerSalId { get; set; }
        [DisplayName("Pertenece")]
        public int PertenenciaId { get; set; }
        [DisplayName("Fecha de Ingreso")]
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Fecha_salida { get; set; }
        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }
        [DisplayName("Observación")]
        public string Observacion { get; set; }
        [DisplayName("Estado")]
        public int Estado { get; set; }
    }
}
