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
    public class PagoesController : Controller
    {
        private readonly AlquilerDeBicisDatabseContext _context;

        public PagoesController(AlquilerDeBicisDatabseContext context)
        {
            _context = context;
        }

        // GET: Pagoes
        public async Task<IActionResult> Index()
        {
            var alquilerDeBicisDatabseContext = _context.Pagos.Include(p => p.alquiler);
            return View(await alquilerDeBicisDatabseContext.ToListAsync());
        }

        // GET: Pagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .Include(p => p.alquiler)
                .FirstOrDefaultAsync(m => m.pagoID == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // GET: Pagoes/Create
        public IActionResult Create()
        {
            //ViewData["alquilerID"] = new SelectList(_context.Alquileres, "alquilerID", "alquilerID");
                        
            ViewData["formaDePago"] = Enum.GetValues(typeof(TIPO_DE_PAGO))
                   .Cast<TIPO_DE_PAGO>()
                   .Select(e => new SelectListItem
                   {
                       Value = e.ToString(),
                       Text = e.ToString()
                   });
            return View();
        }

        // POST: Pagoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("pagoID,fechaDePago,monto,formaDePago,esPagoBase,alquilerID")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["formaDePago"] = Enum.GetValues(typeof(TIPO_DE_PAGO))
                   .Cast<TIPO_DE_PAGO>()
                   .Select(e => new SelectListItem
                   {
                       Value = e.ToString(),
                       Text = e.ToString()
                   });
            ViewData["alquilerID"] = new SelectList(_context.Alquileres, "alquilerID", "alquilerID", pago.alquilerID);
            return View(pago);
        }

        // GET: Pagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }
            ViewData["alquilerID"] = new SelectList(_context.Alquileres, "alquilerID", "alquilerID", pago.alquilerID);
            return View(pago);
        }

        // POST: Pagoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("pagoID,fechaDePago,monto,formaDePago,esPagoBase,alquilerID")] Pago pago)
        {
            if (id != pago.pagoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoExists(pago.pagoID))
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
            ViewData["formaDePago"] = Enum.GetValues(typeof(TIPO_DE_PAGO))
                   .Cast<TIPO_DE_PAGO>()
                   .Select(e => new SelectListItem
                   {
                       Value = e.ToString(),
                       Text = e.ToString()
                   });
            ViewData["alquilerID"] = new SelectList(_context.Alquileres, "alquilerID", "alquilerID", pago.alquilerID);
            return View(pago);
        }

        // GET: Pagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .Include(p => p.alquiler)
                .FirstOrDefaultAsync(m => m.pagoID == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // POST: Pagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagoExists(int id)
        {
            return _context.Pagos.Any(e => e.pagoID == id);
        }
    }
}
