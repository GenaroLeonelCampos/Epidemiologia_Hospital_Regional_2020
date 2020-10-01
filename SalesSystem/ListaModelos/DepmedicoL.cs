using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.ListaModelos
{
    public class DepmedicoL
    {
        public int DepmedicoId { get; set; }
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 5)]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Descripcion { get; set; }
        [DisplayName("Establecimiento")]
        public int? EstablecimientoNOmbre { get; set; }
    }
}
