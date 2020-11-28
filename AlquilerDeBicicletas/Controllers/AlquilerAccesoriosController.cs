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
    public class AlquilerAccesoriosController : Controller
    {
        private readonly AlquilerDeBicisDatabseContext _context;

        public AlquilerAccesoriosController(AlquilerDeBicisDatabseContext context)
        {
            _context = context;
        }

        // GET: AlquilerAccesorios
        public async Task<IActionResult> Index()
        {
            var alquilerDeBicisDatabseContext = _context.AlquilerAccesorio.Include(a => a.accesorio).Include(a => a.alquiler);
            return View(await alquilerDeBicisDatabseContext.ToListAsync());
        }

        // GET: AlquilerAccesorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquilerAccesorio = await _context.AlquilerAccesorio
                .Include(a => a.accesorio)
                .Include(a => a.alquiler)
                .FirstOrDefaultAsync(m => m.alquilerID == id);
            if (alquilerAccesorio == null)
            {
                return NotFound();
            }

            return View(alquilerAccesorio);
        }

        // GET: AlquilerAccesorios/Create
        public IActionResult Create()
        {
            ViewData["accesorioID"] = new SelectList(_context.Accesorios, "accesorioID", "accesorioID");
            ViewData["alquilerID"] = new SelectList(_context.Alquileres, "alquilerID", "alquilerID");
            return View();
        }

        // POST: AlquilerAccesorios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("alquilerID,accesorioID")] AlquilerAccesorio alquilerAccesorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alquilerAccesorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["accesorioID"] = new SelectList(_context.Accesorios, "accesorioID", "accesorioID", alquilerAccesorio.accesorioID);
            ViewData["alquilerID"] = new SelectList(_context.Alquileres, "alquilerID", "alquilerID", alquilerAccesorio.alquilerID);
            return View(alquilerAccesorio);
        }

        // GET: AlquilerAccesorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquilerAccesorio = await _context.AlquilerAccesorio.FindAsync(id);
            if (alquilerAccesorio == null)
            {
                return NotFound();
            }
            ViewData["accesorioID"] = new SelectList(_context.Accesorios, "accesorioID", "accesorioID", alquilerAccesorio.accesorioID);
            ViewData["alquilerID"] = new SelectList(_context.Alquileres, "alquilerID", "alquilerID", alquilerAccesorio.alquilerID);
            return View(alquilerAccesorio);
        }

        // POST: AlquilerAccesorios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("alquilerID,accesorioID")] AlquilerAccesorio alquilerAccesorio)
        {
            if (id != alquilerAccesorio.alquilerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alquilerAccesorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlquilerAccesorioExists(alquilerAccesorio.alquilerID))
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
            ViewData["accesorioID"] = new SelectList(_context.Accesorios, "accesorioID", "accesorioID", alquilerAccesorio.accesorioID);
            ViewData["alquilerID"] = new SelectList(_context.Alquileres, "alquilerID", "alquilerID", alquilerAccesorio.alquilerID);
            return View(alquilerAccesorio);
        }

        // GET: AlquilerAccesorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquilerAccesorio = await _context.AlquilerAccesorio
                .Include(a => a.accesorio)
                .Include(a => a.alquiler)
                .FirstOrDefaultAsync(m => m.alquilerID == id);
            if (alquilerAccesorio == null)
            {
                return NotFound();
            }

            return View(alquilerAccesorio);
        }

        // POST: AlquilerAccesorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alquilerAccesorio = await _context.AlquilerAccesorio.FindAsync(id);
            _context.AlquilerAccesorio.Remove(alquilerAccesorio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlquilerAccesorioExists(int id)
        {
            return _context.AlquilerAccesorio.Any(e => e.alquilerID == id);
        }
    }
}
