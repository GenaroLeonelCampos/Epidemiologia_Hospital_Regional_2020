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
        [Required(ErrorMessage = "Este campo es requerido{0}")]
        [DisplayName("Nombres")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Este campo es requerido{0}")]
        [DisplayName("Apellidos")]
        public string Apellidos { get; set; }
        public int TipdocId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido{0}")]
        [DisplayName("DNI")]
        public int NdocIden { get; set; }
        public int CartservId { get; set; }
        public int ProfesionId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido{0}")]
        [DisplayName("Colegiatura")]
        public string NColegio { get; set; }
        public string Celular { get; set; }
        public int DepartamentoId { get; set; }
        public int ProvinciaId { get; set; }
        public int DistritoId { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public bool Condicion { get; set; }














        //public int PerSalId { get; set; }
        //[StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        //[Required(ErrorMessage = "Este campo es requerido{0}")]
        //[DisplayName("Nombres")]
        //public string Nombres { get; set; }
        //[StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        //[Required(ErrorMessage = "Este campo es requerido")]
        //[DisplayName("Apellidos")]
        //public string Apellidos { get; set; }
        //[DisplayName("Tipo de Documento")]
        //public int TipdocId { get; set; }
        //[StringLength(8, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        //[Required(ErrorMessage = "Este campo es requerido")]
        //[DisplayName("N° de Documento")]
        //public Int32 NdocIden { get; set; }
        //[DisplayName("Servicio")]
        //public int CartservId { get; set; }
        //[DisplayName("Profesión")]
        //public int ProfesionId { get; set; }
        //[DisplayName("N° Colegiatura")]
        //public int NColegio { get; set; }
        //[DisplayName("Celular")]
        //public string Celular { get; set; }
        //[DisplayName("Departamento")]
        //public int DepartamentoId { get; set; }
        //[DisplayName("Provincia")]
        //public int ProvinciaId { get; set; }
        //[DisplayName("Distrito")]
        //public int DistritoId { get; set; }
        //[DisplayName("Dirección")]
        //public string Direccion { get; set; }
        //[EmailAddress(ErrorMessage = "NO es un {0} valido")]
        //[DisplayName("E-mail")]
        //public string Correo { get; set; }
        //[DisplayName("Estado")]
        //public bool Condicion { get; set; }

        //[DisplayName("Tipo de Documento")]
        //public string TipoDocumento { get; set; }
        //[DisplayName("Servicio")]
        //public string Servicio { get; set; }
        //[DisplayName("Profesión")]
        //public string Profesion { get; set; }
        //[DisplayName("Departamento")]
        //public string Departamento { get; set; }
        //[DisplayName("Provincia")]
        //public string Provincia { get; set; }
        //[DisplayName("Distrito")]
        //public string Distrito { get; set; }
    }
}
