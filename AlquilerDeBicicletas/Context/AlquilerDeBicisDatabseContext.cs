using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlquilerDeBicicletas.Models;

namespace AlquilerDeBicicletas.Context
{
    public class AlquilerDeBicisDatabseContext : DbContext
    {
        public AlquilerDeBicisDatabseContext(DbContextOptions<AlquilerDeBicisDatabseContext> options) : base(options)
        {

        }
        public DbSet<Accesorio> Accesorios { get; set; }
        public DbSet<Alquiler> Alquileres{ get; set; }
        public DbSet<AlquilerDeAccesorio> AlquileresDeAccesorios { get; set; }
        public DbSet<Bicicleta> Bicicletas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<TipoDeAccesorio> TiposDeAccesorio { get; set; }
        public DbSet<TipoDeBici> TiposDeBici { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
