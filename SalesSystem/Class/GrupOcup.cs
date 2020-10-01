using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class GrupOcup
    {
        public int GrupOcupId {get;set;}
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Este campo es requerido{0}")]
        public string Descripcion { get;set;}
        [DisplayName("Servicio")]
        public int? UnidLabId { get;set;}
        public UnidLab UnidLab { get; set; }
        //public virtual ICollection<Salidas> Salidas { get; set; }
    }
}
