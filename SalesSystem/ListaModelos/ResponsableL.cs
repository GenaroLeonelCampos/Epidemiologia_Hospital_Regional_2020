using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Epidemiologia.ListaModelos
{
    public class ResponsableL
    {
        [DisplayName("Id")]
        public int ResponsableId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Personal de salud")]
        public int? PerSalId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Profesión")]
        public int? ProfesionId { get; set; }
        [DisplayName("Fecha de Ingreso")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Fecha_Ingreso { get; set; }
        public int Estado { get; set; }
        [DisplayName("Personal de salud")]
        public string Personal { get; set; }
        [DisplayName("Profesión")]
        public string Profesion { get; set; }
    }
}
