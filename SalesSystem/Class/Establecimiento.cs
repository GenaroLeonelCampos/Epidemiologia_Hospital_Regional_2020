using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class Establecimiento
    {     
       
        public int EstablecimientoId { get; set;}
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [StringLength(8, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 5)]
        [Required(ErrorMessage = "Este campo es requerido")]        
        [DisplayName("N° Renaes")]
        public string Renaes { get; set; }
        [StringLength(150, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Este campo es requerido")]        
        [DisplayName("Nombre del Establecimiento")]
        public string Descripcion { get; set; }
        [DisplayName("Distrito de Ubicación")]
        public int DistritoId { get; set; }
        public Distrito Distrito { get; set; }
        public virtual ICollection<Depmedico> Depmedico { get; set; }
        //public virtual ICollection<Servicio> Servicio { get; set; }
        //public virtual ICollection<UnidLab> UnidLab { get; set; }
        //public virtual ICollection<Cartserv> Cartserv { get; set; }
    }
}
