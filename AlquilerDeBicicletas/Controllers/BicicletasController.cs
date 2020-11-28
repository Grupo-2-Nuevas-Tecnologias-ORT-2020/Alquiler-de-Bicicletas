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
    public class BicicletasController : Controller
    {
        private readonly AlquilerDeBicisDatabseContext _context;

        public BicicletasController(AlquilerDeBicisDatabseContext context)
        {
            _context = context;
        }

        // GET: Bicicletas
        public async Task<IActionResult> Index()
        {
            var alquilerDeBicisDatabseContext = _context.Bicicletas.Include(b => b.tipoDeBici);
            return View(await alquilerDeBicisDatabseContext.ToListAsync());
        }

        // GET: Bicicletas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Bicicletas
                .Include(b => b.tipoDeBici)
                .FirstOrDefaultAsync(m => m.bicicletaID == id);
            if (bicicleta == null)
            {
                return NotFound();
            }

            return View(bicicleta);
        }

        // GET: Bicicletas/Create
        public IActionResult Create()
        {
            ViewData["tipoDeBiciID"] = new SelectList(_context.TiposDeBici, "tipoDeBiciID", "tipoDeBiciID");
            return View();
        }

        // POST: Bicicletas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("bicicletaID,fechaDeIngreso,color,tipoDeBiciID")] Bicicleta bicicleta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bicicleta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tipoDeBiciID"] = new SelectList(_context.TiposDeBici, "tipoDeBiciID", "tipoDeBiciID", bicicleta.tipoDeBiciID);
            return View(bicicleta);
        }

        // GET: Bicicletas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Bicicletas.FindAsync(id);
            if (bicicleta == null)
            {
                return NotFound();
            }
            ViewData["tipoDeBiciID"] = new SelectList(_context.TiposDeBici, "tipoDeBiciID", "tipoDeBiciID", bicicleta.tipoDeBiciID);
            return View(bicicleta);
        }

        // POST: Bicicletas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("bicicletaID,fechaDeIngreso,color,tipoDeBiciID")] Bicicleta bicicleta)
        {
            if (id != bicicleta.bicicletaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bicicleta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BicicletaExists(bicicleta.bicicletaID))
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
            ViewData["tipoDeBiciID"] = new SelectList(_context.TiposDeBici, "tipoDeBiciID", "tipoDeBiciID", bicicleta.tipoDeBiciID);
            return View(bicicleta);
        }

        // GET: Bicicletas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Bicicletas
                .Include(b => b.tipoDeBici)
                .FirstOrDefaultAsync(m => m.bicicletaID == id);
            if (bicicleta == null)
            {
                return NotFound();
            }

            return View(bicicleta);
        }

        // POST: Bicicletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bicicleta = await _context.Bicicletas.FindAsync(id);
            _context.Bicicletas.Remove(bicicleta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BicicletaExists(int id)
        {
            return _context.Bicicletas.Any(e => e.bicicletaID == id);
        }
    }
}
