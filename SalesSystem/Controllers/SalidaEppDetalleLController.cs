using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epidemiologia.ListaModelos;
using Microsoft.AspNetCore.Mvc;
using Epidemiologia.Class;
using Microsoft.AspNetCore.Mvc.Rendering;
using Epidemiologia.Data;

namespace Epidemiologia.Controllers
{
    public class SalidaEppDetalleLController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
        public ActionResult Agregar(DetalleMedicamentoL model)
        {
            ViewBag.ListaMedicamento = ListaMedicamento();
            ViewBag.ListaResponsable = ListaResponsable();
            ViewBag.ListaCartserv = ListaCartserv();
            ViewBag.ListaPerSal = ListaPerSal();
            ViewBag.ListaPertenencia = ListaPertenencia();
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    CabeceraSalida oCabeceraSalida = new CabeceraSalida();
                    oCabeceraSalida.ResponsableId = model.ResponsableId;
                    oCabeceraSalida.CartservId = model.CartservId;
                    oCabeceraSalida.PerSalId = model.PerSalId;
                    oCabeceraSalida.PertenenciaId = model.PertenenciaId;
                    oCabeceraSalida.Fecha_salida = DateTime.Now;
                    oCabeceraSalida.Estado = 1;
                    db.CabeceraSalida.Add(oCabeceraSalida);
                    db.SaveChanges();

                    foreach (var oDS in model.Detalles)
                    {
                        DetalleSalida oDetalleSalida = new DetalleSalida();
                        oDetalleSalida.CabeceraSalidaId = oCabeceraSalida.CabeceraSalidaId;
                        oDetalleSalida.MedicamentoId = oDS.MedicamentoId;
                        //oDetalleSalida.Fecha_salida = DateTime.Now;
                        oDetalleSalida.Cantidad = oDS.Cantidad;
                        oDetalleSalida.Observacion = oDS.Observacion;
                        //oDetalleSalida.Estado = 1;
                        db.DetalleSalida.Add(oDetalleSalida);
                    }
                    db.SaveChanges();
                }
                ViewBag.Message = "Registro se agrego correctamente";
                return View();
            }
            catch (Exception ex)
            {
                return View(model);
            }
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
                                   Text = pers.Nombres + ' ' + pers.Apellidos,
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
