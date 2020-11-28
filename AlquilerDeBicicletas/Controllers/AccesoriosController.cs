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
    public class AccesoriosController : Controller
    {
        private readonly AlquilerDeBicisDatabseContext _context;

        public AccesoriosController(AlquilerDeBicisDatabseContext context)
        {
            _context = context;
        }

        // GET: Accesorios
        public async Task<IActionResult> Index()
        {
            var alquilerDeBicisDatabseContext = _context.Accesorios.Include(a => a.tipoDeAccesorio);
            return View(await alquilerDeBicisDatabseContext.ToListAsync());
        }

        // GET: Accesorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesorio = await _context.Accesorios
                .Include(a => a.tipoDeAccesorio)
                .FirstOrDefaultAsync(m => m.accesorioID == id);
            if (accesorio == null)
            {
                return NotFound();
            }

            return View(accesorio);
        }

        // GET: Accesorios/Create
        public IActionResult Create()
        {
            ViewData["tipoDeAccesorioID"] = new SelectList(_context.TiposDeAccesorio, "tipoDeAccesorioID", "tipoDeAccesorioID");
            return View();
        }

        // POST: Accesorios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("accesorioID,fechaDeIngreso,color,tipoDeAccesorioID")] Accesorio accesorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accesorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tipoDeAccesorioID"] = new SelectList(_context.TiposDeAccesorio, "tipoDeAccesorioID", "tipoDeAccesorioID", accesorio.tipoDeAccesorioID);
            return View(accesorio);
        }

        // GET: Accesorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesorio = await _context.Accesorios.FindAsync(id);
            if (accesorio == null)
            {
                return NotFound();
            }
            ViewData["tipoDeAccesorioID"] = new SelectList(_context.TiposDeAccesorio, "tipoDeAccesorioID", "tipoDeAccesorioID", accesorio.tipoDeAccesorioID);
            return View(accesorio);
        }

        // POST: Accesorios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("accesorioID,fechaDeIngreso,color,tipoDeAccesorioID")] Accesorio accesorio)
        {
            if (id != accesorio.accesorioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accesorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccesorioExists(accesorio.accesorioID))
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
            ViewData["tipoDeAccesorioID"] = new SelectList(_context.TiposDeAccesorio, "tipoDeAccesorioID", "tipoDeAccesorioID", accesorio.tipoDeAccesorioID);
            return View(accesorio);
        }

        // GET: Accesorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesorio = await _context.Accesorios
                .Include(a => a.tipoDeAccesorio)
                .FirstOrDefaultAsync(m => m.accesorioID == id);
            if (accesorio == null)
            {
                return NotFound();
            }

            return View(accesorio);
        }

        // POST: Accesorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accesorio = await _context.Accesorios.FindAsync(id);
            _context.Accesorios.Remove(accesorio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccesorioExists(int id)
        {
            return _context.Accesorios.Any(e => e.accesorioID == id);
        }
    }
}
