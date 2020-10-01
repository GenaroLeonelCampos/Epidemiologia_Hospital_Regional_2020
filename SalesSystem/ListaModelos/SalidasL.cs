using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.ListaModelos
{
    public class SalidasL
    {
        [Key]
        public int? SalidasId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Medicamento")]
        public int? MedicamentoId { get; set; }
        [DisplayName("Responsable")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int? ResponsableId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Servicio")]
        public int? CartservId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Personal Recepciona")]
        public int? PerSalId { get; set; }
        [DisplayName("Pertenencia")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int? PertenenciaId { get; set; }
        [DisplayName("Fecha de Salida")]
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? FechaDistrib { get; set; }
        [DisplayName("Descripción")]
        public string? Descripcion { get; set; }
        [DisplayName("Cantidad")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int? Cantidad { get; set; }
        public int? Estado { get; set; }

        public string? Medicamento { get; set; }
        public string? Responsable { get; set; }
        public string? Servicio { get; set; }
        public string? Recepcionante { get; set; }
        public string? Pertenencia { get; set; }
    }
}
