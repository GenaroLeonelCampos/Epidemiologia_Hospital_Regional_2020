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
    public class DepmedicoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public static List<Depmedico> lista;

        public DepmedicoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Depmedico
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Depmedico.Include(d => d.Establecimiento);
            return View(await applicationDbContext.ToListAsync());
        }
        public List<Depmedico> ListarDepmedico()
        {
            List<Depmedico> listarDepmedico = new List<Depmedico>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                listarDepmedico = (from depmedico in db.Depmedico
                                join establecimiento in db.Establecimiento
                                on depmedico.EstablecimientoId equals establecimiento.EstablecimientoId
                                select new Depmedico
                                {
                                    DepmedicoId = depmedico.DepmedicoId,
                                    Descripcion = depmedico.Descripcion,
                                    EstablecimientoId=establecimiento.EstablecimientoId
                                }).ToList();
            }
            lista = listarDepmedico;
            return listarDepmedico;
        }

        
        // GET: Depmedico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depmedico = await _context.Depmedico
                .Include(d => d.Establecimiento)
                .FirstOrDefaultAsync(m => m.DepmedicoId == id);
            if (depmedico == null)
            {
                return NotFound();
            }

            return View(depmedico);
        }

        // GET: Depmedico/Create
        public IActionResult Create()
        {
            ViewData["EstablecimientoId"] = new SelectList(_context.Establecimiento, "EstablecimientoId", "Descripcion");
            return View();
        }

        // POST: Depmedico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepmedicoId,Descripcion,EstablecimientoId")] Depmedico depmedico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(depmedico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstablecimientoId"] = new SelectList(_context.Establecimiento, "EstablecimientoId", "Descripcion", depmedico.EstablecimientoId);
            return View(depmedico);
        }

        // GET: Depmedico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depmedico = await _context.Depmedico.FindAsync(id);
            if (depmedico == null)
            {
                return NotFound();
            }
            ViewData["EstablecimientoId"] = new SelectList(_context.Establecimiento, "EstablecimientoId", "Descripcion", depmedico.EstablecimientoId);
            return View(depmedico);
        }

        // POST: Depmedico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepmedicoId,Descripcion,EstablecimientoId")] Depmedico depmedico)
        {
            if (id != depmedico.DepmedicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(depmedico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepmedicoExists(depmedico.DepmedicoId))
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
            ViewData["EstablecimientoId"] = new SelectList(_context.Establecimiento, "EstablecimientoId", "Descripcion", depmedico.EstablecimientoId);
            return View(depmedico);
        }

        // POST: Depmedico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var depmedico = await _context.Depmedico.FindAsync(id);
            _context.Depmedico.Remove(depmedico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepmedicoExists(int id)
        {
            return _context.Depmedico.Any(e => e.DepmedicoId == id);
        }
    }
}
