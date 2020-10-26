using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class farmAlmacen
    {
        [Key]
        public int idAlmacen { get; set; }
        public string descripcion { get; set; }
        public int idTipoLocales { get; set; }
        public int idTipoSuministro { get; set; }
        public int idEstado { get; set; }
        public string codigoSISMED { get; set; }
        public string regenerarDias { get; set; }
        public string regenerarHora { get; set; }
        public string regenerarEstado { get; set; }
        public int ArmaPaquetes { get; set; }
        public int esUnidosis { get; set; }
    }
}
