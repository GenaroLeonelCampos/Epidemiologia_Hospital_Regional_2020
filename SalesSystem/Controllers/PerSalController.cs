using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Epidemiologia.Class;
using Epidemiologia.Data;

namespace Epidemiologia.Controllers
{
    public class PerSalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PerSalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PerSal
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PerSal.Include(p => p.Cartserv).Include(p => p.Departamento).Include(p => p.Distrito).Include(p => p.Profesion).Include(p => p.Provincia).Include(p => p.Tipdoc);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PerSal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perSal = await _context.PerSal
                .Include(p => p.Cartserv)
                .Include(p => p.Departamento)
                .Include(p => p.Distrito)
                .Include(p => p.Profesion)
                .Include(p => p.Provincia)
                .Include(p => p.Tipdoc)
                .FirstOrDefaultAsync(m => m.PerSalId == id);
            if (perSal == null)
            {
                return NotFound();
            }

            return View(perSal);
        }

        // GET: PerSal/Create
        public IActionResult Create()
        {
            ViewData["CartservId"] = new SelectList(_context.Cartserv, "CartservId", "Descripcion");
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "DepartamentoId", "Descripcion");
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "DistritoId", "Descripcion");
            ViewData["ProfesionId"] = new SelectList(_context.Profesion, "ProfesionId", "Descripcion");
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "ProvinciaId", "Descripcion");
            ViewData["TipdocId"] = new SelectList(_context.Tipdoc, "TipdocId", "Descripcion");
            return View();
        }

        // POST: PerSal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PerSalId,Nombres,Apellidos,TipdocId,NdocIden,CartservId,ProfesionId,NColegio,Celular,DepartamentoId,ProvinciaId,DistritoId,Direccion,Correo,Condicion")] PerSal perSal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perSal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CartservId"] = new SelectList(_context.Cartserv, "CartservId", "Descripcion", perSal.CartservId);
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "DepartamentoId", "Descripcion", perSal.DepartamentoId);
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "DistritoId", "Descripcion", perSal.DistritoId);
            ViewData["ProfesionId"] = new SelectList(_context.Profesion, "ProfesionId", "Descripcion", perSal.ProfesionId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "ProvinciaId", "Descripcion", perSal.ProvinciaId);
            ViewData["TipdocId"] = new SelectList(_context.Tipdoc, "TipdocId", "Descripcion", perSal.TipdocId);
            return View(perSal);
        }

        // GET: PerSal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perSal = await _context.PerSal.FindAsync(id);
            if (perSal == null)
            {
                return NotFound();
            }
            ViewData["CartservId"] = new SelectList(_context.Cartserv, "CartservId", "Descripcion", perSal.CartservId);
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "DepartamentoId", "Descripcion", perSal.DepartamentoId);
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "DistritoId", "Descripcion", perSal.DistritoId);
            ViewData["ProfesionId"] = new SelectList(_context.Profesion, "ProfesionId", "Descripcion", perSal.ProfesionId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "ProvinciaId", "Descripcion", perSal.ProvinciaId);
            ViewData["TipdocId"] = new SelectList(_context.Tipdoc, "TipdocId", "Descripcion", perSal.TipdocId);
            return View(perSal);
        }

        // POST: PerSal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PerSalId,Nombres,Apellidos,TipdocId,NdocIden,CartservId,ProfesionId,NColegio,Celular,DepartamentoId,ProvinciaId,DistritoId,Direccion,Correo,Condicion")] PerSal perSal)
        {
            if (id != perSal.PerSalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perSal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerSalExists(perSal.PerSalId))
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
            ViewData["CartservId"] = new SelectList(_context.Cartserv, "CartservId", "Descripcion", perSal.CartservId);
            ViewData["DepartamentoId"] = new SelectList(_context.Departamento, "DepartamentoId", "Descripcion", perSal.DepartamentoId);
            ViewData["DistritoId"] = new SelectList(_context.Distrito, "DistritoId", "Descripcion", perSal.DistritoId);
            ViewData["ProfesionId"] = new SelectList(_context.Profesion, "ProfesionId", "Descripcion", perSal.ProfesionId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "ProvinciaId", "Descripcion", perSal.ProvinciaId);
            ViewData["TipdocId"] = new SelectList(_context.Tipdoc, "TipdocId", "Descripcion", perSal.TipdocId);
            return View(perSal);
        }
               
        // POST: PerSal/Delete/5       
        public async Task<IActionResult> Delete(int? id)
        {
            var perSal = await _context.PerSal.FindAsync(id);
            _context.PerSal.Remove(perSal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerSalExists(int id)
        {
            return _context.PerSal.Any(e => e.PerSalId == id);
        }
    }
}
