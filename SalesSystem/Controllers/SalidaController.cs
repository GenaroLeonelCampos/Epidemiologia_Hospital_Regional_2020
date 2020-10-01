using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Epidemiologia.Class;
using Epidemiologia.Data;
using Epidemiologia.ListaModelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;

namespace Epidemiologia.Controllers
{
    public class SalidaController : Controller
    {
        public static List<SalidasL> lista;
        //Metdo para descargar archivo
        public FileResult exportarExcel()
        {
            string[] cabeceras = { "SalidasId", "Medicamento", "Responsable", "Servicio", "Recepcionante", "Pertenencia", "FechaDistrib", /*"Descripcion",*/ "Cantidad" };
            string[] nombrepropiedades = { "SalidasId", "Medicamento", "Responsable", "Servicio", "Recepcionante", "Pertenencia", "FechaDistrib", /*"Descripcion",*/ "Cantidad" };
            byte[] buffer = exportarExcelDatos(cabeceras, nombrepropiedades, lista);
            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
        //Genera el array
        public byte[] exportarExcelDatos<T>(string[] cabeceras, string[] nombrepropiedades, List<T> listaReporte)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage ep = new ExcelPackage())
                {
                    ep.Workbook.Worksheets.Add("Hoja");
                    ExcelWorksheet ew = ep.Workbook.Worksheets[0];
                    for (int i = 0; i < cabeceras.Length; i++)
                    {
                        ew.Cells[1, i + 1].Value = cabeceras[i];
                        ew.Column(i + 1).Width = 50;
                    }
                    int fila = 2;
                    int col = 1;

                    foreach (object item in listaReporte)
                    {
                        col = 1;
                        foreach (string propiedad in nombrepropiedades)
                        {
                            ew.Cells[fila, col].Value = item.GetType().GetProperty(propiedad).GetValue(item).ToString();
                            col++;
                        }
                        fila++;
                    }

                    ep.SaveAs(ms);
                    byte[] buffer = ms.ToArray();
                    return buffer;
                }
            }
        }
        public List<SelectListItem> listaMedicamentos()
        {
            List<SelectListItem> listaMedicamentos = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listaMedicamentos = (from medicamento in db.Medicamento
                                     where medicamento.Estado == 1
                                     select new SelectListItem
                                     {
                                         Text = medicamento.Denominacion + ' ' + medicamento.Concentracion + ' '+medicamento.Presentacion,
                                         Value = medicamento.MedicamentoId.ToString()
                                     }).ToList();
                listaMedicamentos.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return listaMedicamentos;
        }
        public List<SelectListItem> listaResponsable()
        {
            List<SelectListItem> listaResponsable = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listaResponsable = (from respon in db.Responsable
                                    select new SelectListItem
                                    {
                                        Text = respon.Apellidos + ' ' + respon.Nombres,
                                        Value = respon.ResponsableId.ToString()
                                    }).ToList();
                listaResponsable.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return listaResponsable;
        }
        public List<SelectListItem> listaServicio()
        {
            List<SelectListItem> listaServicio = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listaServicio = (from servicio in db.Cartserv
                                     select new SelectListItem
                                     {
                                         Text = servicio.Descripcion,
                                         Value = servicio.CartservId.ToString()
                                     }).ToList();
                listaServicio.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return listaServicio;
        }
        public List<SelectListItem> listaRecepcionante()
        {
            List<SelectListItem> listaRecepcionante = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listaRecepcionante = (from persa in db.PerSal
                                    select new SelectListItem
                                    {
                                        Text = persa.Apellidos + ' ' + persa.Nombres,
                                        Value = persa.PerSalId.ToString()
                                    }).ToList();
                listaRecepcionante.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return listaRecepcionante;
        }
        public List<SelectListItem> listapertenecia()
        {
            List<SelectListItem> listapertenecia = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listapertenecia = (from per in db.Pertenencia
                                      select new SelectListItem
                                      {
                                          Text = per.Descripcion,
                                          Value = per.PertenenciaId.ToString()
                                      }).ToList();
                listapertenecia.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return listapertenecia;
        }
        public IActionResult Index(SalidasL oSalidaL)
        {
            ViewBag.listaMedicamentos = listaMedicamentos();
            ViewBag.listaResponsable = listaResponsable();
            ViewBag.listaServicio = listaServicio();
            ViewBag.listaRecepcionante = listaRecepcionante();
            ViewBag.listapertenecia = listapertenecia();
            List<SalidasL> listaSalida = new List<SalidasL>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (oSalidaL.Descripcion == null || oSalidaL.Descripcion == "")
                {
                    listaSalida = (from salida in db.Salidas
                                   join medicamento in db.Medicamento
                                  on salida.MedicamentoId equals medicamento.MedicamentoId
                                   join responsable in db.Responsable
                                   on salida.ResponsableId equals responsable.ResponsableId
                                   join servicio in db.Cartserv
                                  on salida.CartservId equals servicio.CartservId
                                   join recoge in db.PerSal
                                   on salida.PerSalId equals recoge.PerSalId
                                   join pertenece in db.Pertenencia
                                   on salida.PertenenciaId equals pertenece.PertenenciaId
                                   where salida.Estado == 1
                                   select new SalidasL
                                   {
                                       SalidasId = salida.SalidasId,
                                       Medicamento = medicamento.Denominacion + ' ' + medicamento.Concentracion + ' ' + medicamento.Presentacion,
                                       Responsable = responsable.Apellidos + ' ' + responsable.Nombres,
                                       Servicio = servicio.Descripcion,
                                       Recepcionante = recoge.Apellidos+' '+recoge.Nombres,
                                       Pertenencia = pertenece.Descripcion,
                                       FechaDistrib=salida.FechaDistrib,
                                       Descripcion=salida.Descripcion,
                                       Cantidad=salida.Cantidad

                                   }).ToList();
                    ViewBag.Observacion = "";
                }
                else
                {
                    listaSalida = (from salida in db.Salidas
                                   join medicamento in db.Medicamento
                                  on salida.MedicamentoId equals medicamento.MedicamentoId
                                   join responsable in db.Responsable
                                   on salida.ResponsableId equals responsable.ResponsableId
                                   join servicio in db.Cartserv
                                  on salida.CartservId equals servicio.CartservId
                                   join recoge in db.PerSal
                                   on salida.PerSalId equals recoge.PerSalId
                                   join pertenece in db.Pertenencia
                                   on salida.PertenenciaId equals pertenece.PertenenciaId
                                   where salida.Descripcion.Contains(oSalidaL.Descripcion)
                                     select new SalidasL
                                     {
                                         SalidasId = salida.SalidasId,
                                         Medicamento = medicamento.Denominacion + ' ' + medicamento.Concentracion + ' ' + medicamento.Presentacion,
                                         Responsable = responsable.Apellidos + ' ' + responsable.Nombres,
                                         Servicio = servicio.Descripcion,
                                         Recepcionante = recoge.Apellidos + ' ' + recoge.Nombres,
                                         Pertenencia = pertenece.Descripcion,
                                         FechaDistrib = salida.FechaDistrib,
                                         Descripcion = salida.Descripcion,
                                         Cantidad = salida.Cantidad
                                     }).ToList();
                    ViewBag.Observacion = (oSalidaL.Descripcion);
                }
                lista = listaSalida;
                return View(listaSalida);
            }           
        }
        public IActionResult Agregar()
        {
            ViewBag.listaMedicamentos = listaMedicamentos();
            ViewBag.listaResponsable = listaResponsable();
            ViewBag.listaServicio = listaServicio();
            ViewBag.listaRecepcionante = listaRecepcionante();
            ViewBag.listapertenecia = listapertenecia();
            return View();
        }
        [HttpPost]
        public IActionResult Agregar(SalidasL oSalidasL/*, MedicamentoL oMedicamentoL*/)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(oSalidasL);
                }
                else
                {
                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        Salidas oSalidas = new Salidas();
                        oSalidas.MedicamentoId = oSalidasL.MedicamentoId;
                        oSalidas.ResponsableId = oSalidasL.Cantidad;
                        oSalidas.CartservId = oSalidasL.CartservId;
                        oSalidas.PerSalId = oSalidasL.PerSalId;
                        oSalidas.PertenenciaId = oSalidasL.PertenenciaId;
                        oSalidas.FechaDistrib = oSalidasL.FechaDistrib;
                        oSalidas.Descripcion = oSalidasL.Descripcion;
                        oSalidas.Cantidad = oSalidasL.Cantidad;
                        oSalidas.Estado = 1;
                        //int id = oMedicamentoL.MedicamentoId;
                        //int cantidad = (int)oIngresos.Cantidad;
                        //oMedicamentoL.Saldo = oMedicamentoL.Saldo + cantidad;

                        db.Salidas.Add(oSalidas);
                        db.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                return View(oSalidasL);
            }
            return RedirectToAction("Index");
        }
    }
}
