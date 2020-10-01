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
    public class ResponsableController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResponsableController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Responsable
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Responsable.Include(r => r.Departamento).Include(r => r.Distrito).Include(r => r.Profesion).Include(r => r.Provincia).Include(r => r.Tipdoc).Include(r => r.UnidLab);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Responsable/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsable = await _context.Responsable
                .Include(r => r.Departamento)
                .Include(r => r.Distrito)
                .Include(r => r.Profesion)
                .Include(r => r.Provincia)
                .Include(r => r.Tipdoc)
                .Include(r => r.UnidLab)
                .FirstOrDefaultAsync(m => m.ResponsableId == id);
            if (responsable == null)
            {
                return NotFound();
            }

            return View(responsable);
        }

        // GET: Responsable/Create
        public IActionResult Create()
        {
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "DepartamentoId", "Descripcion");
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "DistritoId", "Descripcion");
            ViewData["ProfesionId"] = new SelectList(_context.Profesion, "ProfesionId", "Descripcion");
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "ProvinciaId", "Descripcion");
            ViewData["TipdocId"] = new SelectList(_context.Tipdoc, "TipdocId", "Descripcion");
            ViewData["UnidLabId"] = new SelectList(_context.UnidLab, "UnidLabId", "Descripcion");
            return View();
        }

        // POST: Responsable/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResponsableId,UnidLabId,Nombres,Apellidos,ProfesionId,TipdocId,NdocIden,Celular,Correo,DepartamentoId,ProvinciaId,DistritoId,Direccion,Condicion")] Responsable responsable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "DepartamentoId", "Descripcion", responsable.DepartamentoId);
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "DistritoId", "Descripcion", responsable.DistritoId);
            ViewData["ProfesionId"] = new SelectList(_context.Profesion, "ProfesionId", "Descripcion", responsable.ProfesionId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "ProvinciaId", "Descripcion", responsable.ProvinciaId);
            ViewData["TipdocId"] = new SelectList(_context.Tipdoc, "TipdocId", "Descripcion", responsable.TipdocId);
            ViewData["UnidLabId"] = new SelectList(_context.UnidLab, "UnidLabId", "Descripcion", responsable.UnidLabId);
            return View(responsable);
        }

        // GET: Responsable/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsable = await _context.Responsable.FindAsync(id);
            if (responsable == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "DepartamentoId", "Descripcion", responsable.DepartamentoId);
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "DistritoId", "Descripcion", responsable.DistritoId);
            ViewData["ProfesionId"] = new SelectList(_context.Profesion, "ProfesionId", "Descripcion", responsable.ProfesionId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "ProvinciaId", "Descripcion", responsable.ProvinciaId);
            ViewData["TipdocId"] = new SelectList(_context.Tipdoc, "TipdocId", "Descripcion", responsable.TipdocId);
            ViewData["UnidLabId"] = new SelectList(_context.UnidLab, "UnidLabId", "Descripcion", responsable.UnidLabId);
            return View(responsable);
        }

        // POST: Responsable/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResponsableId,UnidLabId,Nombres,Apellidos,ProfesionId,TipdocId,NdocIden,Celular,Correo,DepartamentoId,ProvinciaId,DistritoId,Direccion,Condicion")] Responsable responsable)
        {
            if (id != responsable.ResponsableId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsableExists(responsable.ResponsableId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "DepartamentoId", "Descripcion", responsable.DepartamentoId);
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "DistritoId", "Descripcion", responsable.DistritoId);
            ViewData["ProfesionId"] = new SelectList(_context.Profesion, "ProfesionId", "Descripcion", responsable.ProfesionId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "ProvinciaId", "Descripcion", responsable.ProvinciaId);
            ViewData["TipdocId"] = new SelectList(_context.Tipdoc, "TipdocId", "Descripcion", responsable.TipdocId);
            ViewData["UnidLabId"] = new SelectList(_context.UnidLab, "UnidLabId", "Descripcion", responsable.UnidLabId);
            return View(responsable);
        }

        
        // POST: Responsable/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var responsable = await _context.Responsable.FindAsync(id);
            _context.Responsable.Remove(responsable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsableExists(int id)
        {
            return _context.Responsable.Any(e => e.ResponsableId == id);
        }
    }
}
