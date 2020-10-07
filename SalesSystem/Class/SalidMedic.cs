using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class SalidMedic
    {
        public int SalidMedicId { get; set; }
        public int MedicamentoId { get; set; }
        public int ResponsableId { get; set; }
        public int CartservId { get; set; }
        public int PerSalId { get; set; }
        public int PertenenciaId { get; set; }
        public DateTime Fecha_salida { get; set; }
        public int Cantidad { get; set; }
        public string Observacion { get; set; }
        public int Estado { get; set; }
    }
}
