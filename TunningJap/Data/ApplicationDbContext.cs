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
    }
}