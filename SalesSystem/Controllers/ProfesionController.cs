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
    public class ProfesionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfesionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Profesion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profesion.ToListAsync());
        }

        // GET: Profesion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesion = await _context.Profesion
                .FirstOrDefaultAsync(m => m.ProfesionId == id);
            if (profesion == null)
            {
                return NotFound();
            }

            return View(profesion);
        }

        // GET: Profesion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfesionId,Descripcion")] Profesion profesion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profesion);
        }

        // GET: Profesion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesion = await _context.Profesion.FindAsync(id);
            if (profesion == null)
            {
                return NotFound();
            }
            return View(profesion);
        }

        // POST: Profesion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfesionId,Descripcion")] Profesion profesion)
        {
            if (id != profesion.ProfesionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesionExists(profesion.ProfesionId))
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
            return View(profesion);
        }
               
        // POST: Profesion/Delete/5       
        public async Task<IActionResult> Delete(int? id)
        {
            var profesion = await _context.Profesion.FindAsync(id);
            _context.Profesion.Remove(profesion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesionExists(int id)
        {
            return _context.Profesion.Any(e => e.ProfesionId == id);
        }
    }
}
