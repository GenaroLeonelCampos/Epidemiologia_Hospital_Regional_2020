using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Epidemiologia.Class;
using Epidemiologia.Data;

namespace Epidemiologia.Controllers
{
    public class PaisController : Controller
    {
        public IActionResult Index()
        {
            List<Paises> listaPais = new List<Paises>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listaPais = (from Paises in db.Paises                               
                                select new Paises
                                {
                                    IdPais = Paises.IdPais,
                                    Codigo = Paises.Codigo,
                                    Nombre = Paises.Nombre,
                                    CodigoPostal = Paises.CodigoPostal
                                }).ToList();
            }
            return View(listaPais);
        }
    }
}
