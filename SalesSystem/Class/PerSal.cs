using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class PerSal
    {
        public int PerSalId { get; set; }
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Este campo es requerido{0}")]
        [DisplayName("Nombres")]        public string Nombres { get; set; }
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Apellidos")]
        public string Apellidos { get; set; }

        [DisplayName("Tipo de Documento")]
        public int TipdocId { get; set; }
        [StringLength(8, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("N° de Documento")]
        public Int32? NdocIden { get; set; }
        [DisplayName("Servicio")]
        public int CartservId { get; set; }
        [DisplayName("Profesión")]
        public int ProfesionId { get; set; }
        [DisplayName("N° Colegiatura")]
        public string NColegio { get; set; }
        [DisplayName("Celular")]
        public string Celular { get; set; }
        [DisplayName("Departamento")]
        public int DepartamentoId { get; set; }
        [DisplayName("Provincia")]
        public int ProvinciaId { get; set; }
        [DisplayName("Distrito")]
        public int DistritoId { get; set; }
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        [EmailAddress(ErrorMessage = "NO es un {0} valido")]
        [DisplayName("E-mail")]
        public string Correo { get; set; }
        [DisplayName("Estado")]
        public bool Condicion { get; set; }

        public Tipdoc Tipdoc { get; set; }
        public Cartserv Cartserv { get; set; }
        public Profesion Profesion { get; set; }
        public Departamento Departamento { get; set; }
        public Provincia Provincia { get; set; }
        public Distrito Distrito { get; set; }
        //public virtual ICollection<Salidas> Salidas { get; set; }
    }
}
