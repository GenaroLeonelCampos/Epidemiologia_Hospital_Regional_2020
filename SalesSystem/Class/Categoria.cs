using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Este campo es requerido{0}")]
        public string Descripcion { get; set; }
        //public virtual ICollection<Medicamento> MedicamentosCat { get; set; }
    }
}
