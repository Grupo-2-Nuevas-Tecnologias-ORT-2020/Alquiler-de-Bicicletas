using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlquilerDeBicicletas.Models;
using AlquilerDeBicicletas.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

using System.Drawing;

namespace AlquilerDeBicicletas.Controllers
{
    public class HomeController : Controller
    {
        private readonly AlquilerDeBicisDatabseContext _context;

        public HomeController(AlquilerDeBicisDatabseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int tipoDeBici)
        {
            ViewData["tipoDeBiciList"] = _context.TiposDeBici.ToList();


            ViewData["tipoDeBiciID"] = new SelectList(_context.TiposDeBici, "tipoDeBiciID", "nombre");
            var alquilerDeBicisDatabseContext = _context.TiposDeBici.ToListAsync();

            if (tipoDeBici != 0)
            {
                //https://docs.microsoft.com/es-es/ef/ef6/querying/related-data
                alquilerDeBicisDatabseContext = _context.TiposDeBici.Where(tp => tp.tipoDeBiciID == tipoDeBici).ToListAsync();
            }
            return View(await alquilerDeBicisDatabseContext);
        }

        //public async Task<IActionResult> Filtrar(TipoDeBici tipoDeBici)
        //{
            
        //    return View(await alquilerDeBicisDatabseContext.ToListAsync());
        //}
        /*public IActionResult Index()
        {
            return View();
        }*/

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
