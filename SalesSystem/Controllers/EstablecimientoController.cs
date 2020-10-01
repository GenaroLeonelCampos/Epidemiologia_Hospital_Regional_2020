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
    public class EstablecimientoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstablecimientoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Establecimiento
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Establecimiento.Include(e => e.Distrito);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Establecimiento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var establecimiento = await _context.Establecimiento
                .Include(e => e.Distrito)
                .FirstOrDefaultAsync(m => m.EstablecimientoId == id);
            if (establecimiento == null)
            {
                return NotFound();
            }

            return View(establecimiento);
        }

        // GET: Establecimiento/Create
        public IActionResult Create()
        {
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "DistritoId", "Descripcion");
            return View();
        }

        // POST: Establecimiento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstablecimientoId,Renaes,Descripcion,DistritoId")] Establecimiento establecimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(establecimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "DistritoId", "Descripcion", establecimiento.DistritoId);
            return View(establecimiento);
        }

        // GET: Establecimiento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var establecimiento = await _context.Establecimiento.FindAsync(id);
            if (establecimiento == null)
            {
                return NotFound();
            }
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "DistritoId", "Descripcion", establecimiento.DistritoId);
            return View(establecimiento);
        }

        // POST: Establecimiento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstablecimientoId,Renaes,Descripcion,DistritoId")] Establecimiento establecimiento)
        {
            if (id != establecimiento.EstablecimientoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(establecimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstablecimientoExists(establecimiento.EstablecimientoId))
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
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "DistritoId", "Descripcion", establecimiento.DistritoId);
            return View(establecimiento);
        }

        // POST: Establecimiento/Delete/5        
        public async Task<IActionResult> Delete(int? id)
        {
            var establecimiento = await _context.Establecimiento.FindAsync(id);
            _context.Establecimiento.Remove(establecimiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstablecimientoExists(int id)
        {
            return _context.Establecimiento.Any(e => e.EstablecimientoId == id);
        }
    }
}
