using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlquilerDeBicicletas.Data;
using AlquilerDeBicicletas.Models;
using System.Security.Claims;

namespace AlquilerDeBicicletas
{
    public class AlquileresController : Controller
    {
        private readonly AlquilerDeBicicletasContext _context;

        public AlquileresController(AlquilerDeBicicletasContext context)
        {
            _context = context;
        }

        // GET: Alquileres
        public async Task<IActionResult> Index()
        {
            var alquilerDeBicicletasContext = _context.Alquileres.Include(a => a.bicicleta).Include(u => u.AlquilerDeBicicletasUsers).Include(t => t.bicicleta.tipoDeBici);
            return View(await alquilerDeBicicletasContext.ToListAsync());
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
                .Include(u => u.AlquilerDeBicicletasUsers)
                .FirstOrDefaultAsync(m => m.alquilerID == id);
            if (alquiler == null)
            {
                return NotFound();
            }

            return View(alquiler);
        }

        // Cuando se carga la pagina con el formulario de creación
        // GET: Alquileres/Create
        public  IActionResult Create(int? id)
        {
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) == null)
            {
                return RedirectToAction("Login", "Identity/Account");
            }

            Bicicleta act;

            try
            {
                act = (from bici in _context.Bicicletas
                       where bici.tipoDeBiciID == id
                       select bici).First();
            }
            catch (InvalidOperationException e)
            {
                return NotFound();
            }

            List<bool> cantidades = new List<bool>();

            foreach (var tipo in _context.TiposDeAccesorio)
            {
                //consulta compleja a tabla de alquileres
                cantidades.Add(_context.Accesorios.Where(b => b.tipoDeAccesorioID == tipo.tipoDeAccesorioID).Count() != 0);
            }


            /*
             * Se envía:
             * - El estado como RESERVADO
             * - El id de la bici del tipo elegido que se encontró disponible
             * - El id del usuario que está loggeado
             * - El objeto del tipo de bici elegida
             * - La lista de accesorios para mostrarlos
             * - La disponibilidad de dichos accesorios
             */

            ViewData["estadoAlquiler"] = ESTADO_ALQUILER.RESERVADO;
            ViewData["bicicletaID"] = act.bicicletaID;
            ViewData["usuarioID"] = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["tipoDeBici"] = _context.TiposDeBici.Find(id);
            ViewData["accessoriosList"] = _context.TiposDeAccesorio.ToList();
            ViewData["accessoriosAvailable"] = cantidades;

            return View();
        }

        // POST: Alquileres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("alquilerID,estadoAlquiler,fechaDesde,fechaHasta,cambioFecha,horasBase,fechaEntregaFinal,horasExtras,totalAPagarBase,totalAPagarExtra,AlquilerDeBicicletasUsers_ID,bicicletaID")] Alquiler alquiler, [Bind("accesoriosUsados")] List<string> accesoriosUsados)
        {
            //[Bind("accesoriosSeleccionados")] 
            var prueba = accesoriosUsados.ToList();
            /*for(int i = 0; i < accesoriosUsados.Count(); i++)
            {
                Console.WriteLine("Valor " + accesoriosUsados.ToList()[i];
            }*/

            Console.WriteLine("Llegaron " + prueba.Count + " elementos");
            foreach(var ac in prueba)
            {
                Console.WriteLine("Valor " + ac);
            }
            alquiler.estadoAlquiler = ESTADO_ALQUILER.RESERVADO;
            alquiler.AlquilerDeBicicletasUsers_ID = User.FindFirstValue(ClaimTypes.NameIdentifier);

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
            ViewData["usuarioID"] = new SelectList(_context.Users, "ID", "AlquilerDeBicicletasUsers_ID", alquiler.AlquilerDeBicicletasUsers_ID);
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
            ViewData["usuarioID"] = new SelectList(_context.Users, "ID", "AlquilerDeBicicletasUsers_ID", alquiler.AlquilerDeBicicletasUsers_ID);
            return View(alquiler);
        }

        // POST: Alquileres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("alquilerID,estadoAlquiler,fechaDesde,fechaHasta,cambioFecha,horasBase,fechaEntregaFinal,horasExtras,totalAPagarBase,totalAPagarExtra,AlquilerDeBicicletasUsers_ID,bicicletaID")] Alquiler alquiler)
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
            ViewData["estadoAlquiler"] = (Enum.GetValues(typeof(ESTADO_ALQUILER))
            .Cast<ESTADO_ALQUILER>()
            .Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            }));
            ViewData["bicicletaID"] = new SelectList(_context.Bicicletas, "bicicletaID", "bicicletaID", alquiler.bicicletaID);
            ViewData["usuarioID"] = new SelectList(_context.Users, "ID", "AlquilerDeBicicletasUsers_ID", alquiler.AlquilerDeBicicletasUsers_ID);
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
