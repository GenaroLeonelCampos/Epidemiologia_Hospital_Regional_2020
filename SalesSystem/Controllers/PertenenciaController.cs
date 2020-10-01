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
    public class PertenenciaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PertenenciaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pertenencia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pertenencia.ToListAsync());
        }

        // GET: Pertenencia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pertenencia = await _context.Pertenencia
                .FirstOrDefaultAsync(m => m.PertenenciaId == id);
            if (pertenencia == null)
            {
                return NotFound();
            }

            return View(pertenencia);
        }

        // GET: Pertenencia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pertenencia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PertenenciaId,Descripcion")] Pertenencia pertenencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pertenencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pertenencia);
        }

        // GET: Pertenencia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pertenencia = await _context.Pertenencia.FindAsync(id);
            if (pertenencia == null)
            {
                return NotFound();
            }
            return View(pertenencia);
        }

        // POST: Pertenencia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PertenenciaId,Descripcion")] Pertenencia pertenencia)
        {
            if (id != pertenencia.PertenenciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pertenencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PertenenciaExists(pertenencia.PertenenciaId))
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
            return View(pertenencia);
        }
              
        // POST: Pertenencia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var pertenencia = await _context.Pertenencia.FindAsync(id);
            _context.Pertenencia.Remove(pertenencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PertenenciaExists(int id)
        {
            return _context.Pertenencia.Any(e => e.PertenenciaId == id);
        }
    }
}
