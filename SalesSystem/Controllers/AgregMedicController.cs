using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epidemiologia.Class;
using Epidemiologia.Data;
using Epidemiologia.ListaModelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.Storage;

namespace Epidemiologia.Controllers
{
    public class AgregMedicController : Controller
    {
       
        public IActionResult Index()
        {
            List<AgregMedicL> listaAgregMedic = new List<AgregMedicL>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listaAgregMedic = (from AgrMedic in db.AgregMedic
                                   join medi in db.Medicamento
                                   on AgrMedic.MedicamentoId equals medi.MedicamentoId
                                   join salud in db.PerSal
                                 on AgrMedic.PerSalId equals salud.PerSalId
                                   select new AgregMedicL
                                   {
                                       //AgregMedicId = AgrMedic.AgregMedicId,
                                       Medicamento = medi.Cod_sismed + ' ' + medi.Denominacion + ' ' + medi.Concentracion + ' ' + medi.Presentacion,
                                       PersonalSalud = salud.Nombres + ' ' + salud.Apellidos,
                                       Fecha_Ingreso = AgrMedic.Fecha_Ingreso,
                                       //Fecha_Ingreso = ((DateTime)AgrMedic.Fecha_Ingreso).ToShortDateString(),
                                       Cantidad = AgrMedic.Cantidad,
                                       Observacion = AgrMedic.Observacion
                                   }).ToList();
            }
            return View(listaAgregMedic);
        }
        public IActionResult Agregar()
        {
            ViewBag.listaPersonal = listaPersonal();
            ViewBag.listaMedicamento = listaMedicamento();
            return View();
        }
        
        [HttpPost]
        public IActionResult Agregar(AgregMedicL oAgregMedicL)
        {
            using (ApplicationDbContext trans = new ApplicationDbContext())
            {
                trans.Database.ExecuteSqlCommand("usp_AgregMedic @p0,@p1,@p2,@p3,@p4"
                    , oAgregMedicL.MedicamentoId, oAgregMedicL.PerSalId,
                     oAgregMedicL.Fecha_Ingreso=DateTime.Now,oAgregMedicL.Cantidad, oAgregMedicL.Observacion);
            }
            return RedirectToAction("Index");
        }

        public List<SelectListItem> listaPersonal()
        {
            List<SelectListItem> listaPersonal = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listaPersonal = (from persa in db.PerSal
                                 select new SelectListItem
                                 {
                                     Text = persa.Nombres + ' ' + persa.Apellidos,
                                     Value = persa.PerSalId.ToString()
                                 }).ToList();
                listaPersonal.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return listaPersonal;
        }
        public List<SelectListItem> listaMedicamento()
        {
            List<SelectListItem> listaMedicamento = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listaMedicamento = (from medi in db.Medicamento
                                    select new SelectListItem
                                    {
                                        Text = medi.Cod_sismed + ' ' + medi.Denominacion + ' ' + medi.Concentracion + ' ' + medi.Presentacion,
                                        Value = medi.MedicamentoId.ToString()
                                    }).ToList();
                listaMedicamento.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return listaMedicamento;
        }


    }
}
