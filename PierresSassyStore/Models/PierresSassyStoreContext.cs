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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Treat>().HasData(
                new Treat { 
                    TreatId = 1, Name = "Cheesecake" , Description = "A decadent, creamy cake" , Image_url = "https://bakerbynature.com/wp-content/uploads/2018/05/extrathickandcreamycheesecake1234-1-of-1.jpg" 
                },
                new Treat 
                { 
                    TreatId = 2, Name = "Pretzel" , Description = "A tasty twist" , Image_url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAs9QjjltUw8XL4LO91DATFsNxnYh0_JA4KzOj0io3uOnTxiV9&s" 
                },
                new Treat 
                { 
                    TreatId = 3, Name = "Cookie" , Description = "Yummy goodness" , Image_url = "https://www.modernhoney.com/wp-content/uploads/2019/10/Double-Chocolate-Cookies-1.jpg" 
                },
                new Treat 
                { 
                    TreatId = 4, Name = "Tart" , Description = "Flaky deliciousness" , Image_url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcEhSt27f_MhJuD2c4Csjvs7d8iZFiMvOXDvowt76AmpzIDPvC2Q&s" 
                }
            );

            modelBuilder.Entity<Flavor>().HasData(
                new Flavor 
                { 
                    FlavorId = 1, Name = "Vanilla", Description = "Has warm, floral notes", Image_url = "https://www.wholesalesuppliesplus.com/Images/Products/647-Vanilla-Bean-Fragrance-Oil-240.jpg" 
                },
                new Flavor 
                { 
                    FlavorId = 2, Name = "Bacon", Description = "Nice crispy texture with a savory, smokey taste", Image_url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQOHpEVqdeHn3khXoSmAylqR5Z_iHR9VV4d9SWtIYNbrfJprsmJzQ&s" 
                },
                new Flavor 
                { 
                    FlavorId = 3, Name = "Chocolate", Description = "Rich silky smoothness", Image_url = "https://cdn11.bigcommerce.com/s-ham8sjk/images/stencil/1280x1280/products/276/836/Cacao_Chocolate_Chocolate_Liquor__1551729718_104.172.159.225__96045.1551729753.jpg?c=2&imbypass=on" 
                },
                new Flavor 
                { 
                    FlavorId = 4, Name = "Apple", Description = "Crisp and sweet", Image_url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRaDJTRef4PzpZpiYnwZqGROIFGM1tRFwcFo6Qsz74k7MpeAlAhYw&s" 
                }
            );
        }
    }
}