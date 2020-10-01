using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class Responsable
    {
        public int ResponsableId { get; set; }
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [DisplayName("Unidad que labora")]
        public int? UnidLabId { get; set; }
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [DisplayName("Nombres")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [DisplayName("Apellidos")]
        public string Apellidos { get; set; }
        [DisplayName("Profesión")]
        public int ProfesionId { get; set; }
        [DisplayName("Tipo Documento")]
        public int TipdocId { get; set; }
        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [DisplayName("N° Documento")]
        public int NdocIden { get; set; }
        [DisplayName("Celular")]
        public string Celular { get; set; }
        [DisplayName("Email")]
        public string Correo { get; set; }
        [DisplayName("Departamento")]
        public int DepartamentoId { get; set; }
        [DisplayName("Provincia")]
        public int ProvinciaId { get; set; }
        [DisplayName("Distrito")]
        public int DistritoId { get; set; }
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        [DisplayName("Estado")]
        public bool Condicion { get; set; }

        public UnidLab UnidLab { get; set; }
        public Profesion Profesion { get; set; }
        public Tipdoc Tipdoc { get; set; }
        public Departamento Departamento { get; set; }
        public Provincia Provincia { get; set; }
        public Distrito Distrito { get; set; }
        //public virtual ICollection<Salidas> Salidas { get; set; }
    }
}
