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
    public class ResponsableController : Controller
    {
        public IActionResult Index()
        {
            List<ResponsableL> listaResponsable = new List<ResponsableL>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //if (oResponsableL.Estado == 1)
                //{
                listaResponsable = (from respons in db.Responsable
                                    join persal in db.PerSal
                                    on respons.PerSalId equals persal.PerSalId
                                    join prof in db.Profesion
                                    on respons.ProfesionId equals prof.ProfesionId
                                    select new ResponsableL
                                    {
                                        ResponsableId = respons.ResponsableId,
                                        Personal = persal.Nombres + ' ' + persal.Apellidos,
                                        Profesion = prof.Descripcion,
                                        Fecha_Ingreso = (DateTime)respons.Fecha_Ingreso
                                    }).ToList();
            }
            return View(listaResponsable);
        }
        public IActionResult Agregar()
        {
            ViewBag.listaPersonal = listaPersonal();
            ViewBag.listaProfesion = listaProfesion();
            return View();
        }
        [HttpPost]
        public IActionResult Agregar(ResponsableL oResponsableL)
        {
            ViewBag.listaPersonal = listaPersonal();
            ViewBag.listaProfesion = listaProfesion();
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(oResponsableL);
                }
                else
                {
                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        Responsable oResponsable = new Responsable();
                        oResponsable.PerSalId = oResponsableL.PerSalId;
                        oResponsable.ProfesionId = oResponsableL.ProfesionId;
                        oResponsable.Fecha_Ingreso = DateTime.Now;
                        oResponsable.Estado = 1;
                        db.Responsable.Add(oResponsable);
                        db.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                return View(oResponsableL);
            }
            return RedirectToAction("Index");
        }
        public List<SelectListItem> listaPersonal()
        {
            List<SelectListItem> listaPersonal = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listaPersonal = (from salud in db.PerSal
                                 select new SelectListItem
                                 {
                                     Text = salud.Nombres + ' ' + salud.Apellidos,
                                     Value = salud.PerSalId.ToString()
                                 }).ToList();
                listaPersonal.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return listaPersonal;
        }
        public List<SelectListItem> listaProfesion()
        {
            List<SelectListItem> listaProfesion = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listaProfesion = (from prof in db.Profesion
                                  where prof.Descripcion == "Químico Farmacéutico" || prof.Descripcion == "Técnico en Farmacia" || prof.Descripcion == "Técnico/a en Farmacia" || prof.Descripcion == "Técnico/a en Farmacia I"
                                || prof.Descripcion == "Técnico/a en Farmacia II"
                                  select new SelectListItem
                                  {
                                      Text = prof.Descripcion,
                                      Value = prof.ProfesionId.ToString()
                                  }).ToList();
                listaProfesion.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return listaProfesion;
        }
    }
}
