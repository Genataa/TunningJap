using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TunningJap.Models;
using TunningJap.Data;

namespace TunningJap.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        public DbSet<TunningJap.Data.Car> Car { get; set; } = default!;
      
        public DbSet<TunningJap.Data.Brand> Brand { get; set; } = default!;
        public DbSet<TunningJap.Data.Category> Category { get; set; } = default!;
        public DbSet<TunningJap.Data.ModelCar> ModelCar { get; set; } = default!;
        public DbSet<TunningJap.Data.Parts> Parts { get; set; } = default!;
        public DbSet<TunningJap.Data.Parts_Model> Parts_Model { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Коригиране на имената за връзките между модели
            //modelBuilder.Entity<Parts_Model>()
            //    .HasKey(pm => new { pm.ID_model, pm.ID_Parts});

            modelBuilder.Entity<Parts_Model>()
                .HasOne(pm => pm.ModelCar)
                .WithMany(m => m.Parts_Models)  // Използвайте PartsModels тук
                .HasForeignKey(pm => pm.ID_model);

            modelBuilder.Entity<Parts_Model>()
                .HasOne(pm => pm.Parts)
                .WithMany(p => p.Parts_Models)  // Използвайте PartsModels тук
                .HasForeignKey(pm => pm.ID_Parts);
        }

        public DbSet<TunningJap.Data.Wheels> Wheels { get; set; } = default!;
        public DbSet<Coilovers> Coilovers { get; set; }
    }
}