using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class Distrito
    {
        public int DistritoId { get; set; }
        [StringLength(153, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "Este campo es requerido{0}")]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Provincia")]
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
        public virtual ICollection<Establecimiento> Establecimiento { get; set; }
        //public virtual ICollection<Responsable> Responsable { get; set; }
        public virtual ICollection<PerSal> PerSal { get; set; }
    }
}
