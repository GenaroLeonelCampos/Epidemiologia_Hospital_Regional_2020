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
    public class IngresosController : Controller
    {
        public static List<IngresosL> lista;
        //Metdo para descargar archivo
        public FileResult exportarExcel()
        {
            string[] cabeceras = { "IngresosId", "Medicamento", "Cantidad", "Fecha_Ingreso", "Observacion", "Responsable" };
            string[] nombrepropiedades = { "IngresosId", "Medicamento", "Cantidad", "Fecha_Ingreso", "Observacion", "Responsable" };
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
                                         Text = medicamento.Denominacion + ' ' + medicamento.Concentracion + ' ' + medicamento.Presentacion,
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
        public IActionResult Index(IngresosL oIngresosL)
        {
            ViewBag.listaMedicamentos = listaMedicamentos();
            List<IngresosL> listaIngresos = new List<IngresosL>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (oIngresosL.Observacion == null || oIngresosL.Observacion == "")
                {
                    listaIngresos = (from ingresos in db.Ingresos
                                     join medicamento in db.Medicamento
                                    on ingresos.MedicamentoId equals medicamento.MedicamentoId
                                     join responsable in db.Responsable
                                     on ingresos.ResponsableId equals responsable.ResponsableId
                                     where ingresos.Estado == 1
                                     select new IngresosL
                                     {
                                         IngresosId = ingresos.IngresosId,
                                         Medicamento = medicamento.Denominacion + ' ' + medicamento.Concentracion + ' ' + medicamento.Presentacion,
                                         Cantidad = ingresos.Cantidad,
                                         Fecha_Ingreso = ingresos.Fecha_Ingreso,
                                         Observacion = ingresos.Observacion,
                                         Responsable = responsable.Apellidos + ' ' + responsable.Nombres
                                     }).ToList();
                    ViewBag.Observacion = "";
                }
                else
                {
                    listaIngresos = (from ingresos in db.Ingresos
                                     join medicamento in db.Medicamento
                                    on ingresos.MedicamentoId equals medicamento.MedicamentoId
                                     join responsable in db.Responsable
                                     on ingresos.ResponsableId equals responsable.ResponsableId
                                     where ingresos.Observacion.Contains(oIngresosL.Observacion)
                                     select new IngresosL
                                     {
                                         IngresosId = ingresos.MedicamentoId,
                                         Medicamento = medicamento.Denominacion,
                                         Cantidad = ingresos.Cantidad,
                                         Fecha_Ingreso = ingresos.Fecha_Ingreso,
                                         Observacion = ingresos.Observacion,
                                         Responsable = responsable.Apellidos + ' ' + responsable.Nombres
                                     }).ToList();
                    ViewBag.Observacion = (oIngresosL.Observacion);
                }
                lista = listaIngresos;
                return View(listaIngresos);
            }
        }
        public IActionResult Agregar()
        {
            ViewBag.listaResponsable = listaResponsable();
            ViewBag.listaMedicamentos = listaMedicamentos();
            return View();
        }
        [HttpPost]
        public IActionResult Agregar(IngresosL oIngresosL/*, MedicamentoL oMedicamentoL*/)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(oIngresosL);
                }
                else
                {
                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        Ingresos oIngresos = new Ingresos();
                        oIngresos.MedicamentoId = oIngresosL.MedicamentoId;
                        oIngresos.Cantidad = oIngresosL.Cantidad;
                        oIngresos.Fecha_Ingreso = oIngresosL.Fecha_Ingreso;
                        oIngresos.Observacion = oIngresosL.Observacion;
                        oIngresos.Estado = 1;
                        oIngresos.ResponsableId = oIngresosL.ResponsableId;

                        //int id = oMedicamentoL.MedicamentoId;
                        //int cantidad = (int)oIngresos.Cantidad;
                        //oMedicamentoL.Saldo = oMedicamentoL.Saldo + cantidad;

                        db.Ingresos.Add(oIngresos);
                        db.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                return View(oIngresosL);
            }
            return RedirectToAction("Index");
        }
    }
}
