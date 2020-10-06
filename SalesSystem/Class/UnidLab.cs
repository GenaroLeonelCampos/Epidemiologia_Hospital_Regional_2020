using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class UnidLab
    {
        public int UnidLabId { get; set; }
        [StringLength(250, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 5)]
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        public string Descripcion { get; set; }
        [DisplayName("Servicio")]
        public int? CartservId { get; set; }
        public Cartserv Cartserv { get; set; }       
        public virtual ICollection<GrupOcup> GrupOcup { get; set; }
        //public virtual ICollection<Responsable> Responsable { get; set; }
    }
}
