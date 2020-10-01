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
    public class TipdocController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipdocController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tipdoc
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipdoc.ToListAsync());
        }

        // GET: Tipdoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipdoc = await _context.Tipdoc
                .FirstOrDefaultAsync(m => m.TipdocId == id);
            if (tipdoc == null)
            {
                return NotFound();
            }

            return View(tipdoc);
        }

        // GET: Tipdoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipdoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipdocId,Descripcion")] Tipdoc tipdoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipdoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipdoc);
        }

        // GET: Tipdoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipdoc = await _context.Tipdoc.FindAsync(id);
            if (tipdoc == null)
            {
                return NotFound();
            }
            return View(tipdoc);
        }

        // POST: Tipdoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipdocId,Descripcion")] Tipdoc tipdoc)
        {
            if (id != tipdoc.TipdocId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipdoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipdocExists(tipdoc.TipdocId))
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
            return View(tipdoc);
        }
               
        public async Task<IActionResult> Delete(int? id)
        {
            var tipdoc = await _context.Tipdoc.FindAsync(id);
            _context.Tipdoc.Remove(tipdoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipdocExists(int id)
        {
            return _context.Tipdoc.Any(e => e.TipdocId == id);
        }
    }
}
