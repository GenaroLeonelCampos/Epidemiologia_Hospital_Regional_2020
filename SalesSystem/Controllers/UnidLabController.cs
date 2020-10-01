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
    public class UnidLabController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UnidLabController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UnidLab
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UnidLab.Include(u => u.Cartserv);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UnidLab/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidLab = await _context.UnidLab
                .Include(u => u.Cartserv)
                .FirstOrDefaultAsync(m => m.UnidLabId == id);
            if (unidLab == null)
            {
                return NotFound();
            }

            return View(unidLab);
        }

        // GET: UnidLab/Create
        public IActionResult Create()
        {
            ViewData["CartservId"] = new SelectList(_context.Cartserv, "CartservId", "Descripcion");
            return View();
        }

        // POST: UnidLab/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnidLabId,Descripcion,CartservId")] UnidLab unidLab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidLab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CartservId"] = new SelectList(_context.Cartserv, "CartservId", "Descripcion", unidLab.CartservId);
            return View(unidLab);
        }

        // GET: UnidLab/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidLab = await _context.UnidLab.FindAsync(id);
            if (unidLab == null)
            {
                return NotFound();
            }
            ViewData["CartservId"] = new SelectList(_context.Cartserv, "CartservId", "Descripcion", unidLab.CartservId);
            return View(unidLab);
        }

        // POST: UnidLab/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnidLabId,Descripcion,CartservId")] UnidLab unidLab)
        {
            if (id != unidLab.UnidLabId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidLab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidLabExists(unidLab.UnidLabId))
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
            ViewData["CartservId"] = new SelectList(_context.Cartserv, "CartservId", "Descripcion", unidLab.CartservId);
            return View(unidLab);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var unidLab = await _context.UnidLab.FindAsync(id);
            _context.UnidLab.Remove(unidLab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidLabExists(int id)
        {
            return _context.UnidLab.Any(e => e.UnidLabId == id);
        }
    }
}
