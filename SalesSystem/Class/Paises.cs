using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Epidemiologia.Class
{
    public partial class Paises
    {      
        [Key]
        public int IdPais { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string CodigoPostal { get; set; }
        public bool? IndFlag { get; set; }

      
    }
}
