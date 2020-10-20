using Epidemiologia.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.ListaModelos
{
    public class SalidaEppDetalleL
    {

        public int ResponsableId { get; set; }
        public int CartservId { get; set; }
        public int PerSalId { get; set; }
        public int PertenenciaId { get; set; }
        public int MedicamentoId { get; set; }
        public DateTime Fecha_salida { get; set; }
        public int Cantidad { get; set; }
        public string Observacion { get; set; }
        public bool Estado { get; set; }

    //    public List<SalidaEPP> SalidaEPPs { get; set; }
    //}
    //public class SalidaEPP
    //{
    //    public int MedicamentoId { get; set; }
    //    public DateTime Fecha_salida { get; set; }
    //    public int Cantidad { get; set; }
    //    public string Observacion { get; set; }
    }
}
