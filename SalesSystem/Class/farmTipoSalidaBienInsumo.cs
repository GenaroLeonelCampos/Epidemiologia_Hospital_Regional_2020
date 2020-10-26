using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class farmTipoSalidaBienInsumo
    {
        [Key]
        public int idTipoSalidaBienInsumo { get; set; }
        public string tipo { get; set; }       

    }
}
