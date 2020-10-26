using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class Farmsaldo
    {
        [Key]
        public int idAlmacen { get; set; }
        public int idProducto { get; set; }
        public int IdTipoSalidaBienInsumo { get; set; }
        public decimal cantidad { get; set; }
        public decimal Precio { get; set; }

        [DisplayName("Almacen")]
        public string Almacen { get; set; }
        [DisplayName("Medicamento")]
        public string Producto { get; set; }
        [DisplayName("Bien Insumo")]
        public string TipoSalida { get; set; }
    }
}
