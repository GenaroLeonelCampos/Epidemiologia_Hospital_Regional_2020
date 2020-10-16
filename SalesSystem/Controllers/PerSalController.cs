using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epidemiologia.Class;
using Epidemiologia.Data;
using Epidemiologia.ListaModelos;
using Microsoft.AspNetCore.Mvc;

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
    }
}
