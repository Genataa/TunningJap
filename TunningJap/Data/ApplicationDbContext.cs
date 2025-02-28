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
        public DbSet<TunningJap.Data.testModel> testModel { get; set; } = default!;
      
        public DbSet<TunningJap.Data.Brand> Brand { get; set; } = default!;
        public DbSet<TunningJap.Data.Category> Category { get; set; } = default!;
        public DbSet<TunningJap.Data.ModelCar> ModelCar { get; set; } = default!;
        public DbSet<TunningJap.Data.Parts> Parts { get; set; } = default!;
        public DbSet<TunningJap.Data.Parts_Model> Parts_Model { get; set; } = default!;
    }
}