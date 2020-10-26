using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Epidemiologia.Class
{
    public partial class TiposSexo
    {
        public TiposSexo()
        {
            
        }
        [Key]
        public int IdTipoSexo { get; set; }
        public string Descripcion { get; set; }

      
    }
}
