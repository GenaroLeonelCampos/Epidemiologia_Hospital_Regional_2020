using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.ListaModelos
{
    public class DetalleMedicamentoL
    {
        public int ResponsableId { get; set; }
        public int CartservId { get; set; }
        public int PerSalId { get; set; }
        public int PertenenciaId { get; set; }
        public DateTime Fecha_salida { get; set; }
        public int Estado { get; set; }        
        public List<DetalleSalidas> Detalles { get; set; }
    }
    public class DetalleSalidas
    {
        //public int CabeceraSalidaId { get; set; }
        public int MedicamentoId { get; set; }
        //public DateTime Fecha_salida { get; set; }
        public int Cantidad { get; set; }
        public string Observacion { get; set; }
    }
}

