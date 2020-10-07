using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epidemiologia.Class;
using Epidemiologia.Data;
using Epidemiologia.ListaModelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Epidemiologia.Controllers
{
    public class SalidMedicController : Controller
    {
        public IActionResult Index()
        {
            List<SalidMedicL> listaSalidMedicL = new List<SalidMedicL>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listaSalidMedicL = (from sali in db.SalidMedic
                                    join med in db.Medicamento
                                    on sali.MedicamentoId equals med.MedicamentoId
                                    join resp in db.Responsable
                                    on sali.ResponsableId equals resp.ResponsableId
                                    join salud in db.PerSal
                                    on resp.PerSalId equals salud.PerSalId
                                    join cart in db.Cartserv
                                    on sali.CartservId equals cart.CartservId
                                    join pers in db.PerSal
                                    on sali.PerSalId equals pers.PerSalId
                                    join pert in db.Pertenencia
                                    on sali.PertenenciaId equals pert.PertenenciaId
                                    select new SalidMedicL
                                    {
                                        SalidMedicId = sali.SalidMedicId,
                                        Medicamento = med.Cod_sismed + ' ' + med.Denominacion + ' ' + med.Concentracion + ' ' + med.Presentacion,
                                        Responsable = salud.Apellidos + ' ' + salud.Nombres,
                                        Cartserv = cart.Descripcion,
                                        PerSal = pers.Nombres + ' ' + pers.Apellidos,
                                        Pertenencia = pert.Descripcion,
                                        Fecha_salida = DateTime.Now,
                                        Cantidad = sali.Cantidad,
                                        Observacion = sali.Observacion
                                    }).ToList();
            }
            return View(listaSalidMedicL);
        }
        public IActionResult Agregar()
        {
            ViewBag.ListaMedicamento = ListaMedicamento();
            ViewBag.ListaResponsable = ListaResponsable();
            ViewBag.ListaCartserv = ListaCartserv();
            ViewBag.ListaPerSal = ListaPerSal();
            ViewBag.ListaPertenencia = ListaPertenencia();
            return View();
        }
        [HttpPost]
        public IActionResult Agregar(SalidMedicL oSalidMedicL)
        {
            ViewBag.ListaMedicamento = ListaMedicamento();
            ViewBag.ListaResponsable = ListaResponsable();
            ViewBag.ListaCartserv = ListaCartserv();
            ViewBag.ListaPerSal = ListaPerSal();
            ViewBag.ListaPertenencia = ListaPertenencia();

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(oSalidMedicL);
                }
                else
                {
                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        SalidMedic oSalidMedic = new SalidMedic();
                        oSalidMedic.MedicamentoId = (int)oSalidMedicL.MedicamentoId;
                        oSalidMedic.ResponsableId = (int)oSalidMedicL.ResponsableId;
                        oSalidMedic.CartservId = (int)oSalidMedicL.CartservId;
                        oSalidMedic.PerSalId = (int)oSalidMedicL.PerSalId;
                        oSalidMedic.PertenenciaId = (int)oSalidMedicL.PertenenciaId;
                        oSalidMedic.Fecha_salida = DateTime.Now;
                        oSalidMedic.Cantidad = (int)oSalidMedicL.Cantidad;
                        oSalidMedic.Observacion = oSalidMedicL.Observacion;
                        oSalidMedic.Estado = 1;
                        db.SalidMedic.Add(oSalidMedic);
                        db.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                return View(oSalidMedicL);
            }
            return RedirectToAction("Index");
        }

        public List<SelectListItem> ListaMedicamento()
        {
            List<SelectListItem> ListaMedicamento = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ListaMedicamento = (from med in db.Medicamento
                                 select new SelectListItem
                                 {
                                     Text = med.Cod_sismed + ' ' + med.Denominacion + ' ' + med.Concentracion + ' ' + med.Presentacion,
                                     Value = med.MedicamentoId.ToString()
                                 }).ToList();
                ListaMedicamento.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return ListaMedicamento;
        }
        public List<SelectListItem> ListaResponsable()
        {
            List<SelectListItem> ListaResponsable = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ListaResponsable = (from resp in db.Responsable
                                    join salud in db.PerSal
                                    on resp.PerSalId equals salud.PerSalId
                                    select new SelectListItem
                                    {
                                        Text = salud.Nombres + ' ' + salud.Apellidos,
                                        Value = resp.ResponsableId.ToString()
                                    }).ToList();
                ListaResponsable.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return ListaResponsable;
        }
        public List<SelectListItem> ListaCartserv()
        {
            List<SelectListItem> ListaCartserv = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ListaCartserv = (from cartse in db.Cartserv                                   
                                    select new SelectListItem
                                    {
                                        Text = cartse.Descripcion,
                                        Value = cartse.CartservId.ToString()
                                    }).ToList();
                ListaCartserv.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return ListaCartserv;
        }
        public List<SelectListItem> ListaPerSal()
        {
            List<SelectListItem> ListaPerSal = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ListaPerSal = (from pers in db.PerSal
                                 select new SelectListItem
                                 {
                                     Text = pers.Nombres+' '+pers.Apellidos,
                                     Value = pers.PerSalId.ToString()
                                 }).ToList();
                ListaPerSal.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return ListaPerSal;
        }
        public List<SelectListItem> ListaPertenencia()
        {
            List<SelectListItem> ListaPertenencia = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ListaPertenencia = (from pert in db.Pertenencia
                               select new SelectListItem
                               {
                                   Text = pert.Descripcion,
                                   Value = pert.PertenenciaId.ToString()
                               }).ToList();
                ListaPertenencia.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return ListaPertenencia;
        }
    }
}