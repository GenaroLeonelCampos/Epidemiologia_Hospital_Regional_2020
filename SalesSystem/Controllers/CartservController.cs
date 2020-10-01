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
    public class CartservController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartservController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cartserv
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cartserv.Include(c => c.Depmedico);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cartserv/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartserv = await _context.Cartserv
                .Include(c => c.Depmedico)
                .FirstOrDefaultAsync(m => m.CartservId == id);
            if (cartserv == null)
            {
                return NotFound();
            }

            return View(cartserv);
        }

        // GET: Cartserv/Create
        public IActionResult Create()
        {
            ViewData["DepmedicoId"] = new SelectList(_context.Depmedico, "DepmedicoId", "Descripcion");
            return View();
        }

        // POST: Cartserv/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartservId,Descripcion,DepmedicoId")] Cartserv cartserv)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartserv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepmedicoId"] = new SelectList(_context.Depmedico, "DepmedicoId", "Descripcion", cartserv.DepmedicoId);
            return View(cartserv);
        }

        // GET: Cartserv/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartserv = await _context.Cartserv.FindAsync(id);
            if (cartserv == null)
            {
                return NotFound();
            }
            ViewData["DepmedicoId"] = new SelectList(_context.Depmedico, "DepmedicoId", "Descripcion", cartserv.DepmedicoId);
            return View(cartserv);
        }

        // POST: Cartserv/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartservId,Descripcion,DepmedicoId")] Cartserv cartserv)
        {
            if (id != cartserv.CartservId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartserv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartservExists(cartserv.CartservId))
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
            ViewData["DepmedicoId"] = new SelectList(_context.Depmedico, "DepmedicoId", "Descripcion", cartserv.DepmedicoId);
            return View(cartserv);
        }
               
        // POST: Cartserv/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var cartserv = await _context.Cartserv.FindAsync(id);
            _context.Cartserv.Remove(cartserv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartservExists(int id)
        {
            return _context.Cartserv.Any(e => e.CartservId == id);
        }
    }
}
