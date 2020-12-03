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
    public class TipoDeBicisController : Controller
    {
        private readonly AlquilerDeBicisDatabseContext _context;

        public TipoDeBicisController(AlquilerDeBicisDatabseContext context)
        {
            _context = context;
        }

        // GET: TipoDeBicis
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposDeBici.ToListAsync());
        }

        // GET: TipoDeBicis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeBici = await _context.TiposDeBici
                .FirstOrDefaultAsync(m => m.tipoDeBiciID == id);
            if (tipoDeBici == null)
            {
                return NotFound();
            }

            return View(tipoDeBici);
        }

        // GET: TipoDeBicis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeBicis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tipoDeBiciID,nombre,precioBase")] TipoDeBici tipoDeBici)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeBici);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDeBici);
        }

        // GET: TipoDeBicis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeBici = await _context.TiposDeBici.FindAsync(id);
            if (tipoDeBici == null)
            {
                return NotFound();
            }
            return View(tipoDeBici);
        }

        // POST: TipoDeBicis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tipoDeBiciID,nombre,precioBase")] TipoDeBici tipoDeBici)
        {
            if (id != tipoDeBici.tipoDeBiciID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeBici);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeBiciExists(tipoDeBici.tipoDeBiciID))
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
            return View(tipoDeBici);
        }

        // GET: TipoDeBicis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeBici = await _context.TiposDeBici
                .FirstOrDefaultAsync(m => m.tipoDeBiciID == id);
            if (tipoDeBici == null)
            {
                return NotFound();
            }

            return View(tipoDeBici);
        }

        // POST: TipoDeBicis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDeBici = await _context.TiposDeBici.FindAsync(id);
            _context.TiposDeBici.Remove(tipoDeBici);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeBiciExists(int id)
        {
            return _context.TiposDeBici.Any(e => e.tipoDeBiciID == id);
        }
    }
}
