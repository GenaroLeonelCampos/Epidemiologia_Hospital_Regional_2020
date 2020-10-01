using Epidemiologia.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Areas.Tipdoc.Models
{
    public class Tipdoc
    {
        [Key]
        public int TipdocId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Responsable> Responsable { get; set; }
    }
}
