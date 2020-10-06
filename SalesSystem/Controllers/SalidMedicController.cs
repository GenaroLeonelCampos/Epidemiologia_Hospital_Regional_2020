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
            List<SalidMedicL> listasalidas = new List<SalidMedicL>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listasalidas = (from sali in db.SalidMedic
                                join medi in db.Medicamento
                                on sali.MedicamentoId equals medi.MedicamentoId
                                join resp in db.Responsable
                                on sali.ResponsableId equals resp.ResponsableId
                                join saludos in db.PerSal
                              on resp.PerSalId equals saludos.PerSalId
                                join cart in db.Cartserv
                                on sali.CartservId equals cart.CartservId
                                join persa in db.PerSal
                                on sali.PerSalId equals persa.PerSalId
                                join perte in db.Pertenencia
                               on sali.PertenenciaId equals perte.PertenenciaId
                                select new SalidMedicL
                                {
                                    SalidMedicId = sali.SalidMedicId,
                                    Medicamento = medi.Denominacion,
                                    Responsable = saludos.Nombres + ' ' + saludos.Apellidos,
                                    Cartera = cart.Descripcion,
                                    Salud = persa.Nombres + ' ' + persa.Apellidos,
                                    Pertenencia = perte.Descripcion,
                                    Fecha_salida = sali.Fecha_salida,
                                    Cantidad = sali.Cantidad,
                                    Observacion = sali.Observacion
                                }).ToList();
            }
            return View(listasalidas);
        }

        public IActionResult Agregar()
        {
            ViewBag.listaResponsable = listaResponsable();
            ViewBag.listaMedicamento = listaMedicamento();
            ViewBag.listaPersonal = listaPersonal();
            ViewBag.listaPertenencia = listaPertenencia();
            ViewBag.listaServicio = listaServicio();
            return View();
        }
        [HttpPost]
        public IActionResult Agregar(SalidMedicL oSalidMedicL)
        {
            ViewBag.listaResponsable = listaResponsable();
            ViewBag.listaMedicamento = listaMedicamento();
            ViewBag.listaPersonal = listaPersonal();
            ViewBag.listaPertenencia = listaPertenencia();
            ViewBag.listaServicio = listaServicio();
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
                        oSalidMedic.PerSalId = (int)oSalidMedicL.PerSalId;
                        oSalidMedic.CartservId = (int)oSalidMedicL.CartservId;
                        oSalidMedic.PertenenciaId = (int)oSalidMedicL.PertenenciaId;
                        oSalidMedic.Fecha_salida = DateTime.Now;
                        oSalidMedic.Cantidad = (int)oSalidMedicL.Cantidad;
                        oSalidMedic.Observacion = oSalidMedicL.Observacion;
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
        public List<SelectListItem> listaResponsable()
        {
            List<SelectListItem> listaResponsable = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listaResponsable = (from resp in db.Responsable
                                    join salud in db.PerSal
                                    on resp.PerSalId equals salud.PerSalId
                                    where resp.ProfesionId== 41|| resp.ProfesionId == 48|| resp.ProfesionId == 61|| resp.ProfesionId == 62|| resp.ProfesionId == 63
                                 select new SelectListItem
                                 {
                                     Text = salud.Nombres + ' ' + salud.Apellidos,
                                     Value = resp.PerSalId.ToString()
                                 }).ToList();
                listaResponsable.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return listaResponsable;
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
        public List<SelectListItem> listaPertenencia()
        {
            List<SelectListItem> listaPertenencia = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listaPertenencia = (from pert in db.Pertenencia
                                 select new SelectListItem
                                 {
                                     Text = pert.Descripcion,
                                     Value = pert.PertenenciaId.ToString()
                                 }).ToList();
                listaPertenencia.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return listaPertenencia;
        }
        public List<SelectListItem> listaServicio()
        {
            List<SelectListItem> listaServicio = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listaServicio = (from serv in db.Cartserv
                                    select new SelectListItem
                                    {
                                        Text = serv.Descripcion,
                                        Value = serv.CartservId.ToString()
                                    }).ToList();
                listaServicio.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return listaServicio;
        }
    }
}
