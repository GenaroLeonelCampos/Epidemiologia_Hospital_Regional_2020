using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class Provincia
    {
        public int ProvinciaId { get; set; }
        [StringLength(8, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Este campo es requerido{0}")]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Departamento")]
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public virtual ICollection<Distrito> Distrito { get; set; }
        //public virtual ICollection<Responsable> Responsable { get; set; }
        public virtual ICollection<PerSal> PerSal { get; set; }
    }
}
