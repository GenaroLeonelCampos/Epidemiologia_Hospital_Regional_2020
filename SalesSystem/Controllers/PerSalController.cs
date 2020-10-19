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
    public class PerSalController : Controller
    {
        public IActionResult Index()
        {
            List<PerSalL> listaPerSalL = new List<PerSalL>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listaPerSalL = (from salud in db.PerSal
                                    join tipo in db.Tipdoc
                                    on salud.TipdocId equals tipo.TipdocId
                                    join servicio in db.Cartserv
                                    on salud.CartservId equals servicio.CartservId
                                    join profesion in db.Profesion
                                    on salud.ProfesionId equals profesion.ProfesionId
                                    join depart in db.Departamento
                                    on salud.DepartamentoId equals depart.DepartamentoId
                                    join provincia in db.Provincia
                                    on salud.ProvinciaId equals provincia.ProvinciaId
                                    join distrito in db.Distrito
                                    on salud.DistritoId equals distrito.DistritoId
                                    select new PerSalL
                                    {
                                        PerSalId = salud.PerSalId,
                                        ApNom=salud.Apellidos + ' ' + salud.Nombres,
                                        NdocIden = salud.NdocIden,
                                        Servicio = servicio.Descripcion,
                                        Profesion =profesion.Descripcion,
                                        NColegio=salud.NColegio,
                                        Celular=salud.Celular,
                                        Departamento = profesion.Descripcion,
                                        Provincia = profesion.Descripcion,
                                        Distrito = distrito.Descripcion,
                                        Direccion=salud.Direccion,
                                        Correo=salud.Correo
                                    }).ToList();
            }
            return View(listaPerSalL);
        }
        public IActionResult Agregar()
        {
            ViewBag.ListaTipdoc = ListaTipdoc(); 
            ViewBag.ListaCartserv = ListaCartserv(); 
            ViewBag.ListaProfesion = ListaProfesion(); 
            ViewBag.ListaDepartamento = ListaDepartamento(); 
            ViewBag.ListaProvincia = ListaProvincia(); 
            ViewBag.ListaDistrito = ListaDistrito(); 
            return View();
        }
        [HttpPost]
        public IActionResult Agregar(PerSalL oPerSalL)
        {
            ViewBag.ListaTipdoc = ListaTipdoc();
            ViewBag.ListaCartserv = ListaCartserv();
            ViewBag.ListaProfesion = ListaProfesion();
            ViewBag.ListaDepartamento = ListaDepartamento();
            ViewBag.ListaProvincia = ListaProvincia();
            ViewBag.ListaDistrito = ListaDistrito();
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(oPerSalL);
                }
                else
                {
                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        PerSal oPerSal = new PerSal();
                        oPerSal.Nombres = oPerSalL.Nombres;
                        oPerSal.Apellidos = oPerSalL.Apellidos;
                        oPerSal.TipdocId = (int)oPerSalL.TipdocId;
                        oPerSal.NdocIden = (int)oPerSalL.NdocIden;
                        oPerSal.CartservId = (int)oPerSalL.CartservId;
                        oPerSal.ProfesionId = (int)oPerSalL.ProfesionId;
                        oPerSal.NColegio = oPerSalL.NColegio;
                        oPerSal.Celular = oPerSalL.Celular;
                        oPerSal.DepartamentoId = (int)oPerSalL.DepartamentoId;
                        oPerSal.ProvinciaId = (int)oPerSalL.ProvinciaId;
                        oPerSal.DistritoId = (int)oPerSalL.DistritoId;
                        oPerSal.Direccion = oPerSalL.Direccion;
                        oPerSal.Correo = oPerSalL.Correo;
                        db.PerSal.Add(oPerSal);
                        db.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                return View(oPerSalL);
            }
            return RedirectToAction("Index");
        
    }
        public List<SelectListItem> ListaTipdoc()
        {
            List<SelectListItem> ListaTipdoc = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ListaTipdoc = (from med in db.Tipdoc
                                    select new SelectListItem
                                    {
                                        Text = med.Descripcion,
                                        Value = med.TipdocId.ToString()
                                    }).ToList();
                ListaTipdoc.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return ListaTipdoc;
        }
        public List<SelectListItem> ListaCartserv()
        {
            List<SelectListItem> ListaCartserv = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ListaCartserv = (from med in db.Cartserv
                               select new SelectListItem
                               {
                                   Text = med.Descripcion,
                                   Value = med.CartservId.ToString()
                               }).ToList();
                ListaCartserv.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return ListaCartserv;
        }
        public List<SelectListItem> ListaProfesion()
        {
            List<SelectListItem> ListaProfesion = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ListaProfesion = (from med in db.Profesion
                                 select new SelectListItem
                                 {
                                     Text = med.Descripcion,
                                     Value = med.ProfesionId.ToString()
                                 }).ToList();
                ListaProfesion.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return ListaProfesion;
        }
        public List<SelectListItem> ListaDepartamento()
        {
            List<SelectListItem> ListaDepartamento = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ListaDepartamento = (from med in db.Departamento
                                  select new SelectListItem
                                  {
                                      Text = med.Descripcion,
                                      Value = med.DepartamentoId.ToString()
                                  }).ToList();
                ListaDepartamento.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return ListaDepartamento;
        }
        public List<SelectListItem> ListaProvincia()
        {
            List<SelectListItem> ListaProvincia = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ListaProvincia = (from med in db.Provincia
                                     select new SelectListItem
                                     {
                                         Text = med.Descripcion,
                                         Value = med.ProvinciaId.ToString()
                                     }).ToList();
                ListaProvincia.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return ListaProvincia;
        }
        public List<SelectListItem> ListaDistrito()
        {
            List<SelectListItem> ListaDistrito = new List<SelectListItem>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ListaDistrito = (from med in db.Distrito
                                  select new SelectListItem
                                  {
                                      Text = med.Descripcion,
                                      Value = med.DistritoId.ToString()
                                  }).ToList();
                ListaDistrito.Insert(0, new SelectListItem
                {
                    Text = "--Selecciona--",
                    Value = ""
                });

            }
            return ListaDistrito;
        }
    }
}
