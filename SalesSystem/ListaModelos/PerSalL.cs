using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.ListaModelos
{
    public class PerSalL
    {
        [DisplayName("Identificación")]
        public int? PerSalId { get; set; }
        [Required(ErrorMessage = "Este campo {0} es requerido")]
        [DisplayName("Nombres")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Este campo {0} es requerido")]
        [DisplayName("Apellidos")]
        public string Apellidos { get; set; }
        [DisplayName("Tipo Documento")]
        public int? TipdocId { get; set; }
        [Required(ErrorMessage = "Este campo {0} es requerido")]
        [DisplayName("DNI")]
        public int? NdocIden { get; set; }
        [DisplayName("Servicio")]
        public int? CartservId { get; set; }
        [DisplayName("Profesión")]
        public int? ProfesionId { get; set; }        
        [DisplayName("Colegiatura")]
        public string NColegio { get; set; }
        [DisplayName("Celular")]
        public string Celular { get; set; }
        [DisplayName("Departamento")]
        public int? DepartamentoId { get; set; }
        [DisplayName("Provincia")]
        public int? ProvinciaId { get; set; }
        [DisplayName("Distrito")]
        public int? DistritoId { get; set; }
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        [DisplayName("Correo")]
        public string Correo { get; set; }
        public bool Condicion { get; set; }


        [DisplayName("Tipo de Documento")]
        public string TipoDocumento { get; set; }
        [DisplayName("Servicio")]
        public string Servicio { get; set; }
        [DisplayName("Profesión")]
        public string Profesion { get; set; }
        [DisplayName("Departamento")]
        public string Departamento { get; set; }
        [DisplayName("Provincia")]
        public string Provincia { get; set; }
        [DisplayName("Distrito")]
        public string Distrito { get; set; }
        [DisplayName("Apellidos y Nombres")]
        public string ApNom { get; set; }
    }
}
