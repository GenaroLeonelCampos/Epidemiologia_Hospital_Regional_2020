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
    public class GrupOcupController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GrupOcupController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GrupOcup
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GrupOcup.Include(g => g.UnidLab);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GrupOcup/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupOcup = await _context.GrupOcup
                .Include(g => g.UnidLab)
                .FirstOrDefaultAsync(m => m.GrupOcupId == id);
            if (grupOcup == null)
            {
                return NotFound();
            }

            return View(grupOcup);
        }

        // GET: GrupOcup/Create
        public IActionResult Create()
        {
            ViewData["UnidLabId"] = new SelectList(_context.UnidLab, "UnidLabId", "Descripcion");
            return View();
        }

        // POST: GrupOcup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GrupOcupId,Descripcion,UnidLabId")] GrupOcup grupOcup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupOcup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnidLabId"] = new SelectList(_context.UnidLab, "UnidLabId", "Descripcion", grupOcup.UnidLabId);
            return View(grupOcup);
        }

        // GET: GrupOcup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupOcup = await _context.GrupOcup.FindAsync(id);
            if (grupOcup == null)
            {
                return NotFound();
            }
            ViewData["UnidLabId"] = new SelectList(_context.UnidLab, "UnidLabId", "Descripcion", grupOcup.UnidLabId);
            return View(grupOcup);
        }

        // POST: GrupOcup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GrupOcupId,Descripcion,Descripcion")] GrupOcup grupOcup)
        {
            if (id != grupOcup.GrupOcupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupOcup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupOcupExists(grupOcup.GrupOcupId))
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
            ViewData["UnidLabId"] = new SelectList(_context.UnidLab, "UnidLabId", "Descripcion", grupOcup.UnidLabId);
            return View(grupOcup);
        }

       
        // POST: GrupOcup/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var grupOcup = await _context.GrupOcup.FindAsync(id);
            _context.GrupOcup.Remove(grupOcup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupOcupExists(int id)
        {
            return _context.GrupOcup.Any(e => e.GrupOcupId == id);
        }
    }
}
