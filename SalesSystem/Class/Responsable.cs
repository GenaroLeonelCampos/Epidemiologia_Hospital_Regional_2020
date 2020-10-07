using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class Responsable
    {
        public int ResponsableId { get; set; }
        public int PerSalId { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public int Estado { get; set; }
    }
}
