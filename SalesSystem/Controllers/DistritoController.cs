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
    public class DistritoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DistritoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Distrito
        public async Task<IActionResult> Index()
        {
            var appicationDbContext = _context.Distrito.Include(d => d.Provincia);
            return View(await appicationDbContext.ToListAsync());
        }

        // GET: Distrito/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distrito = await _context.Distrito
                .Include(d => d.Provincia)
                .FirstOrDefaultAsync(m => m.DistritoId == id);
            if (distrito == null)
            {
                return NotFound();
            }

            return View(distrito);
        }

        // GET: Distrito/Create
        public IActionResult Create()
        {
            ViewData["ProvinciaId"] = new SelectList(_context.Set<Provincia>(), "ProvinciaId", "Descripcion");
            return View();
        }

        // POST: Distrito/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DistritoId,Descripcion,ProvinciaId")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(distrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProvinciaId"] = new SelectList(_context.Set<Provincia>(), "ProvinciaId", "Descripcion", distrito.ProvinciaId);
            return View(distrito);
        }

        // GET: Distrito/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distrito = await _context.Distrito.FindAsync(id);
            if (distrito == null)
            {
                return NotFound();
            }
            ViewData["ProvinciaId"] = new SelectList(_context.Set<Provincia>(), "ProvinciaId", "Descripcion", distrito.ProvinciaId);
            return View(distrito);
        }

        // POST: Distrito/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DistritoId,Descripcion,ProvinciaId")] Distrito distrito)
        {
            if (id != distrito.DistritoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(distrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistritoExists(distrito.DistritoId))
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
            ViewData["ProvinciaId"] = new SelectList(_context.Set<Provincia>(), "ProvinciaId", "Descripcion", distrito.ProvinciaId);
            return View(distrito);
        }
              
        // POST: Distrito/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var distrito = await _context.Distrito.FindAsync(id);
            _context.Distrito.Remove(distrito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DistritoExists(int id)
        {
            return _context.Distrito.Any(e => e.DistritoId == id);
        }
    }
}
