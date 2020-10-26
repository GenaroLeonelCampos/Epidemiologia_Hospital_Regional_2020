using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epidemiologia.Class
{
    public class FactCatalogoBienesInsumos
    {
        [Key]
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string NombreComercial { get; set; }
        public int IdGrupoFarmacologico { get; set; }
        public int IdSubGrupoFarmacologico { get; set; }
        public int IdPartida { get; set; }
        public int IdCentroCosto { get; set; }
        public int PrecioCompra { get; set; }
        public int PrecioDistribucion { get; set; }
        public int PrecioDonacion { get; set; }
        public int PrecioUltCompra { get; set; }
        public int idTipoSalidaBienInsumo { get; set; }
        public int StockMinimo { get; set; }
        public int TipoProducto { get; set; }
        public string Denominacion { get; set; }
        public string Concentracion { get; set; }
        public string Presentacion { get; set; }
        public string FormaFarmaceutica { get; set; }
        public string MaterialEnvase { get; set; }
        public string PresentacionEnvase { get; set; }
        public string Fabricante { get; set; }
        public int IdPaisOrigen { get; set; }
        public int Petitorio { get; set; }
        public string TipoProductoSismed { get; set; }
        public int esPaquete { get; set; }
        public string codigoSUNAT { get; set; }
    }
}
