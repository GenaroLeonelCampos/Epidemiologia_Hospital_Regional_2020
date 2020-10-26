using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epidemiologia.ListaModelos;
using Epidemiologia.Class;
using Microsoft.AspNetCore.Mvc;
using Epidemiologia.Data;

namespace Epidemiologia.Controllers
{
    public class EmpleadosController : Controller
    {
        public IActionResult Index()
        {
            List<EmpleadosL> listaPerSalL = new List<EmpleadosL>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listaPerSalL = (from salud in db.Empleados
                                join sexo in db.TiposSexo
                                on salud.IdTipoSexo equals sexo.IdTipoSexo
                                join pais in db.Paises
                                on salud.IdPais equals pais.IdPais
                                //join profesion in db.Profesion
                                //on salud.ProfesionId equals profesion.ProfesionId
                                //join depart in db.Departamento
                                //on salud.DepartamentoId equals depart.DepartamentoId
                                //join provincia in db.Provincia
                                //on salud.ProvinciaId equals provincia.ProvinciaId
                                //join distrito in db.Distrito
                                //on salud.DistritoId equals distrito.DistritoId
                                select new EmpleadosL
                                {
                                    IdEmpleado = salud.IdEmpleado,
                                    //Nombres = salud.ApellidoPaterno+' '+salud.ApellidoMaterno+' '+salud.Nombres,
                                    Completo = salud.ApellidoPaterno + ' ' + salud.ApellidoMaterno + ' ' + salud.Nombres,
                                    Dni = salud.Dni,
                                    FechaIngreso = salud.FechaIngreso,
                                    FechaNacimiento = salud.FechaNacimiento,
                                    TipoSexo = sexo.Descripcion,
                                    Pais = pais.Nombre
                                }).ToList();
            }
            return View(listaPerSalL);
        }
    }
}
