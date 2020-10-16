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
