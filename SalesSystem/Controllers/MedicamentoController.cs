using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epidemiologia.Data;
using Epidemiologia.ListaModelos;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using OfficeOpenXml;
using Epidemiologia.Class;

namespace Epidemiologia.Controllers
{
    public class MedicamentoController : Controller
    {
        public static List<MedicamentoL> lista;
        //Metdo para descargar archivo
        public FileResult exportarExcel()
        {
            string[] cabeceras = { "MedicamentoId", "Cod_sismed", "Denominacion", "Concentracion", "Presentacion", "Saldo", "Fecha_Ingreso", "Observacion" };
            string[] nombrepropiedades = { "MedicamentoId", "Cod_sismed", "Denominacion", "Concentracion", "Presentacion", "Saldo", "Fecha_Ingreso", "Observacion" };
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
       
        public IActionResult Index()
        {
            List<MedicamentoL> listamedicamento = new List<MedicamentoL>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {              
                    listamedicamento = (from medicamento in db.Medicamento
                                        select new MedicamentoL
                                        {
                                            MedicamentoId = medicamento.MedicamentoId,
                                            Cod_sismed=medicamento.Cod_sismed,
                                            Denominacion = medicamento.Denominacion,
                                            Concentracion = medicamento.Concentracion,
                                            Presentacion=medicamento.Presentacion,
                                            Saldo=medicamento.Saldo,
                                            Fecha_Ingreso = medicamento.Fecha_Ingreso,
                                            Observacion = medicamento.Observacion
                                        }).ToList();
            }
            return View(listamedicamento);
        }
        public IActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Agregar(MedicamentoL oMedicamentoL)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(oMedicamentoL);
                }
                else
                {
                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        Medicamento oMedicamento = new Medicamento();
                        oMedicamento.Cod_sismed = oMedicamentoL.Cod_sismed;
                        oMedicamento.Denominacion = oMedicamentoL.Denominacion;
                        oMedicamento.Concentracion = oMedicamentoL.Concentracion;
                        oMedicamento.Presentacion = oMedicamentoL.Presentacion;
                        oMedicamento.Saldo = oMedicamentoL.Saldo;
                        oMedicamento.Fecha_Ingreso = DateTime.Now;
                        oMedicamento.Observacion = oMedicamentoL.Observacion;
                        oMedicamento.Estado = 1;
                        db.Medicamento.Add(oMedicamento);
                        db.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                return View(oMedicamentoL);
            }
            return RedirectToAction("Index");
        }
    }
}

