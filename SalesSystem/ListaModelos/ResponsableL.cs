using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.ListaModelos
{
    public class ResponsableL
    {
        [DisplayName("Id")]
        public int ResponsableId { get; set; }
        [DisplayName("Personal de Salud")]
        public int PerSalId { get; set; }
        [DisplayName("Profesión")]
        public int ProfesionId { get; set; }
        [DisplayName("Fecha de Ingreso")]
        public DateTime Fecha_Ingreso { get; set; }
        [DisplayName("Estado")]
        public int Estado { get; set; }
        [DisplayName("Personal de Salud")]
        public string PersonalSalud { get; set; }
        [DisplayName("Profesión")]
        public string Profesion { get; set; }
    }
}
