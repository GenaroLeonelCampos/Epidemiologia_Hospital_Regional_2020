using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class Cartserv
    {
        public int CartservId { get; set; }
        [DisplayName("Servicioo")]
        [StringLength(180, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Este campo es requerido{0}")]
        public string? Descripcion { get; set; }
        [DisplayName("Departamento Medico")]
        public int? DepmedicoId { get; set; }
        public Depmedico Depmedico { get; set; }
        public virtual ICollection<UnidLab> UnidLab { get; set; }
        public virtual ICollection<PerSal> PerSal { get; set; }
    }
}
