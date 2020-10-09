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
            List<ResponsableL> listamedicamento = new List<ResponsableL>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listamedicamento = (from resp in db.Responsable
                                    join salu in db.PerSal
                                    on resp.PerSalId equals salu.PerSalId                                   
                                    select new ResponsableL
                                    {
                                        ResponsableId = resp.ResponsableId,
                                        Personal = salu.Nombres + ' ' + salu.Apellidos,
                                        Fecha_Ingreso = DateTime.Now
                                    }).ToList();
            }
            return View(listamedicamento);
        }
        public IActionResult Agregar()
        {
            ViewBag.listaPersonalSalud = listaPersonalSalud();
            return View();
        }
        [HttpPost]
        public IActionResult Agregar(ResponsableL oResponsableL)
        {
            ViewBag.listaPersonalSalud = listaPersonalSalud();
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
        public List<SelectListItem> listaPersonalSalud()
        {
            List<SelectListItem> listaPersonalSalud = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listaPersonalSalud = (from persa in db.PerSal
                                      join prof in db.Profesion
                                      on persa.ProfesionId equals prof.ProfesionId
                                      where prof.Descripcion == "Químico Farmacéutico" || prof.Descripcion == "Técnico en Farmacia" || prof.Descripcion == "Técnico/a en Farmacia" || prof.Descripcion == "Técnico/a en Farmacia I"
                               || prof.Descripcion == "Técnico/a en Farmacia II"
                                      select new SelectListItem
                                      {
                                          Text = persa.Apellidos + ' ' + persa.Nombres,
                                          Value = persa.PerSalId.ToString()
                                      }).ToList();
                listaPersonalSalud.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return listaPersonalSalud;
        }       
    }
}
