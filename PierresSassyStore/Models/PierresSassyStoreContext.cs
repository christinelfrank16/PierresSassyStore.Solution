using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PierresSassyStore.Models
{
    public class PierresSassyStoreContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Flavor> Flavors { get; set; }
        public DbSet<FlavorTreat> FlavorTreats { get; set; }
        public DbSet<Treat> Treats { get; set; }
        public PierresSassyStoreContext(DbContextOptions options) : base(options) { }
    }
}