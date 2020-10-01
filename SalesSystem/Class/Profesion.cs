using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class Profesion
    {
        public int ProfesionId { get; set; }        
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 5)]
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        public string Descripcion { get; set; }
        public virtual ICollection<Responsable> Responsable { get; set; }
        public virtual ICollection<PerSal> PerSal { get; set; }
    }
}
