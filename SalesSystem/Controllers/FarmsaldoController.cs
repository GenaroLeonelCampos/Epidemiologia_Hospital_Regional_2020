using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epidemiologia.Class;
using Epidemiologia.Data;
using Microsoft.AspNetCore.Mvc;

namespace Epidemiologia.Controllers
{
    public class FarmsaldoController : Controller
    {
        public IActionResult Index()
        {
            List<Farmsaldo> listaFarmsaldo = new List<Farmsaldo>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listaFarmsaldo = (from saldo in db.Farmsaldo
                                  join almacen in db.farmAlmacen
                                  on saldo.idAlmacen equals almacen.idAlmacen
                                  join medic in db.FactCatalogoBienesInsumos
                                  on saldo.IdTipoSalidaBienInsumo equals medic.idTipoSalidaBienInsumo
                                  join insumo in db.farmTipoSalidaBienInsumo
                                  on saldo.IdTipoSalidaBienInsumo equals insumo.idTipoSalidaBienInsumo
                                  where saldo.idProducto == 7751 || saldo.idProducto == 944 || saldo.idProducto == 13442 || saldo.idProducto == 14083 ||
saldo.idProducto == 14210 || saldo.idProducto == 14211 || saldo.idProducto == 17801 || saldo.idProducto == 17834 ||
saldo.idProducto == 20874 || saldo.idProducto == 23589 || saldo.idProducto == 24769 || saldo.idProducto == 24772 ||
saldo.idProducto == 24534 || saldo.idProducto == 24476 || saldo.idProducto == 24627 || saldo.idProducto == 27251 ||
saldo.idProducto == 27250 || saldo.idProducto == 27249 || saldo.idProducto == 25481 || saldo.idProducto == 25479 ||
saldo.idProducto == 39740 || saldo.idProducto == 39699 || saldo.idProducto == 39536 || saldo.idProducto == 37122 ||
saldo.idProducto == 30566
                                  //where medic.Codigo == "23127" || medic.Codigo == "23127" || medic.Codigo == "29849" || medic.Codigo == "28687" ||
                                  //       medic.Codigo == "19362" || medic.Codigo == "30129" || medic.Codigo == "19492" || medic.Codigo == "19491" ||
                                  //       medic.Codigo == "26631" || medic.Codigo == "41488" || medic.Codigo == "44065" || medic.Codigo == "18726" ||
                                  //       medic.Codigo == "32269" || medic.Codigo == "32270" || medic.Codigo == "43902" || medic.Codigo == "30498" ||
                                  //       medic.Codigo == "10221" || medic.Codigo == "10230" || medic.Codigo == "23112" || medic.Codigo == "30142" ||
                                  //       medic.Codigo == "32268" || medic.Codigo == "30500" || medic.Codigo == "44106" || medic.Codigo == "35583" ||
                                  //       medic.Codigo == "29689" || medic.Codigo == "29692"
                                  select new Farmsaldo
                                  {
                                      Almacen = almacen.descripcion,
                                      Producto = medic.Nombre + ' ' + medic.FormaFarmaceutica,
                                      TipoSalida = insumo.tipo,
                                      cantidad = saldo.cantidad,
                                      Precio = saldo.Precio
                                  }).ToList();
            }
            return View(listaFarmsaldo);
        }
    }
}
