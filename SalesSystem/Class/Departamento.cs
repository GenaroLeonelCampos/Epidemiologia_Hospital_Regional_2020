using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class Departamento
    {        
        public int DepartamentoId { get; set; }
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 5)]
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [DisplayName("Nombre del Departamento")]
        public string Descripcion { get; set; }
        [DisplayName("Pais")]
        public int PaisId { get; set; }
        public Pais Pais { get; set; }
        public virtual ICollection<Provincia> Provincia { get; set; }
        public virtual ICollection<Responsable> Responsable { get; set; }
        public virtual ICollection<PerSal> PerSal { get; set; }
        //public virtual ICollection<SalidasMedicAlmac> SalidasMedicAlmac { get; set; }
        //public virtual ICollection<Distribucion> Distribucion { get; set; }
    }
}
