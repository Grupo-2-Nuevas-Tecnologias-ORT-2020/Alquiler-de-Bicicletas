using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlquilerDeBicicletas.Areas.Identity.Data;
using AlquilerDeBicicletas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlquilerDeBicicletas.Data
{
    public class AlquilerDeBicicletasContext : IdentityDbContext<AlquilerDeBicicletasUsers>
    {
        public AlquilerDeBicicletasContext(DbContextOptions<AlquilerDeBicicletasContext> options)
            : base(options)
        {
        }

        public DbSet<Accesorio> Accesorios { get; set; }
        public DbSet<Alquiler> Alquileres { get; set; }
        public DbSet<AlquilerAccesorio> AlquilerAccesorio { get; set; }
        public DbSet<Bicicleta> Bicicletas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<TipoDeAccesorio> TiposDeAccesorio { get; set; }
        public DbSet<TipoDeBici> TiposDeBici { get; set; }
        /*public DbSet<Usuario> Usuarios { get; set; }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlquilerAccesorio>()
                .HasKey(alac => new { alac.alquilerID, alac.accesorioID });

            modelBuilder.Entity<AlquilerAccesorio>()
                .HasOne(al => al.accesorio)
                .WithMany(ac => ac.alquileresAccesorio)
                .HasForeignKey(al => al.accesorioID);

            modelBuilder.Entity<AlquilerAccesorio>()
                .HasOne(ac => ac.alquiler)
                .WithMany(al => al.accesoriosAlquiler)
                .HasForeignKey(ac => ac.alquilerID);

            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
