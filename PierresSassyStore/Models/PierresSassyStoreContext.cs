using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PierresSassyStore.Models
{
    public class PierresSassyStoreContext : IdentityDbContext<ApplicationUser>
    {

        public PierresSassyStoreContext(DbContextOptions options) : base(options) { }
    }
}