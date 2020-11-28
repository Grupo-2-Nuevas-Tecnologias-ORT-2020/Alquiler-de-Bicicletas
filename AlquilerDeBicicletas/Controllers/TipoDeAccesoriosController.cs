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
    public class TipoDeAccesoriosController : Controller
    {
        private readonly AlquilerDeBicisDatabseContext _context;

        public TipoDeAccesoriosController(AlquilerDeBicisDatabseContext context)
        {
            _context = context;
        }

        // GET: TipoDeAccesorios
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposDeAccesorio.ToListAsync());
        }

        // GET: TipoDeAccesorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeAccesorio = await _context.TiposDeAccesorio
                .FirstOrDefaultAsync(m => m.tipoDeAccesorioID == id);
            if (tipoDeAccesorio == null)
            {
                return NotFound();
            }

            return View(tipoDeAccesorio);
        }

        // GET: TipoDeAccesorios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeAccesorios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tipoDeAccesorioID,nombre,precioBase")] TipoDeAccesorio tipoDeAccesorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeAccesorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDeAccesorio);
        }

        // GET: TipoDeAccesorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeAccesorio = await _context.TiposDeAccesorio.FindAsync(id);
            if (tipoDeAccesorio == null)
            {
                return NotFound();
            }
            return View(tipoDeAccesorio);
        }

        // POST: TipoDeAccesorios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tipoDeAccesorioID,nombre,precioBase")] TipoDeAccesorio tipoDeAccesorio)
        {
            if (id != tipoDeAccesorio.tipoDeAccesorioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeAccesorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeAccesorioExists(tipoDeAccesorio.tipoDeAccesorioID))
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
            return View(tipoDeAccesorio);
        }

        // GET: TipoDeAccesorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeAccesorio = await _context.TiposDeAccesorio
                .FirstOrDefaultAsync(m => m.tipoDeAccesorioID == id);
            if (tipoDeAccesorio == null)
            {
                return NotFound();
            }

            return View(tipoDeAccesorio);
        }

        // POST: TipoDeAccesorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDeAccesorio = await _context.TiposDeAccesorio.FindAsync(id);
            _context.TiposDeAccesorio.Remove(tipoDeAccesorio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeAccesorioExists(int id)
        {
            return _context.TiposDeAccesorio.Any(e => e.tipoDeAccesorioID == id);
        }
    }
}
