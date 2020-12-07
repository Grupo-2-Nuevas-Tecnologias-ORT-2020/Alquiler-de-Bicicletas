using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlquilerDeBicicletas.Context;
using AlquilerDeBicicletas.Models;

namespace AlquilerDeBicicletas.Controllers
{
    public class AlquileresController : Controller
    {
        private readonly AlquilerDeBicisDatabseContext _context;

        public AlquileresController(AlquilerDeBicisDatabseContext context)
        {
            _context = context;
        }

        // GET: Alquileres
        public async Task<IActionResult> Index()
        {
            var alquilerDeBicisDatabseContext = _context.Alquileres.Include(a => a.bicicleta).Include(a => a.usuario);
            return View(await alquilerDeBicisDatabseContext.ToListAsync());
        }

        // GET: Alquileres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquileres
                .Include(a => a.bicicleta)
                .Include(a => a.usuario)
                .FirstOrDefaultAsync(m => m.alquilerID == id);
            if (alquiler == null)
            {
                return NotFound();
            }

            return View(alquiler);
        }

        // Cuando se carga la pagina con el formulario de creación
        // GET: Alquileres/Create
        public IActionResult Create(int? tipoDeBiciID)
        {
            ViewData["estadoAlquiler"] = Enum.GetValues(typeof(ESTADO_ALQUILER))
                    .Cast<ESTADO_ALQUILER>()
                    .Select(e => new SelectListItem
                    {
                        Value = e.ToString(),
                        Text = e.ToString()
                    });
            ViewData["bicicletaID"] = new SelectList(_context.Bicicletas, "bicicletaID", "bicicletaID");
            ViewData["usuarioID"] = new SelectList(_context.Usuarios, "usuarioID", "nombre");
            return View();
        }

        // POST: Alquileres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("alquilerID,estadoAlquiler,fechaDesde,fechaHasta,cambioFecha,horasBase,fechaEntregaFinal,horasExtras,totalAPagarBase,totalAPagarExtra,usuarioID,bicicletaID")] Alquiler alquiler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alquiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["estadoAlquiler"] = Enum.GetValues(typeof(ESTADO_ALQUILER))
                    .Cast<ESTADO_ALQUILER>()
                    .Select(e => new SelectListItem
                    {
                        Value = e.ToString(),
                        Text = e.ToString()
                    });
            ViewData["bicicletaID"] = new SelectList(_context.Bicicletas, "bicicletaID", "bicicletaID", alquiler.bicicletaID);
            ViewData["usuarioID"] = new SelectList(_context.Usuarios, "usuarioID", "usuarioID", alquiler.usuarioID);
            return View(alquiler);
        }

        // GET: Alquileres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquileres.FindAsync(id);
            if (alquiler == null)
            {
                return NotFound();
            }
            ViewData["estadoAlquiler"] = (Enum.GetValues(typeof(ESTADO_ALQUILER))
                    .Cast<ESTADO_ALQUILER>()
                    .Select(e => new SelectListItem
                    {
                        Value = e.ToString(),
                        Text = e.ToString()
                    }));
            ViewData["bicicletaID"] = new SelectList(_context.Bicicletas, "bicicletaID", "bicicletaID", alquiler.bicicletaID);
            ViewData["usuarioID"] = new SelectList(_context.Usuarios, "usuarioID", "usuarioID", alquiler.usuarioID);
            return View(alquiler);
        }

        // POST: Alquileres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("alquilerID,estadoAlquiler,fechaDesde,fechaHasta,cambioFecha,horasBase,fechaEntregaFinal,horasExtras,totalAPagarBase,totalAPagarExtra,usuarioID,bicicletaID")] Alquiler alquiler)
        {
            if (id != alquiler.alquilerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alquiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlquilerExists(alquiler.alquilerID))
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
            ViewData["estadoAlquiler"] = Enum.GetValues(typeof(ESTADO_ALQUILER))
                    .Cast<ESTADO_ALQUILER>()
                    .Select(e => new SelectListItem
                    {
                        Value = e.ToString(),
                        Text = e.ToString()
                    });
            ViewData["bicicletaID"] = new SelectList(_context.Bicicletas, "bicicletaID", "bicicletaID", alquiler.bicicletaID);
            ViewData["usuarioID"] = new SelectList(_context.Usuarios, "usuarioID", "usuarioID", alquiler.usuarioID);
            return View(alquiler);
        }

        // GET: Alquileres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquileres
                .Include(a => a.bicicleta)
                .Include(a => a.usuario)
                .FirstOrDefaultAsync(m => m.alquilerID == id);
            if (alquiler == null)
            {
                return NotFound();
            }

            return View(alquiler);
        }

        // POST: Alquileres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alquiler = await _context.Alquileres.FindAsync(id);
            _context.Alquileres.Remove(alquiler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlquilerExists(int id)
        {
            return _context.Alquileres.Any(e => e.alquilerID == id);
        }
    }
}
