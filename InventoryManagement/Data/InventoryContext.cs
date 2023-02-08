using InventoryManagement.Areas.Admin.Models;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Data
{
    public class InventoryContext : IdentityDbContext
    {
        public InventoryContext(DbContextOptions options): base(options) { }

        public virtual DbSet<Unit> Units { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<PoHeader> PoHeaders { get; set; }
        public virtual DbSet<PoDetail> PoDetails { get; set; }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }

        public virtual DbSet<ProductProfile> ProductProfiles { get; set; }

        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>()
                .ToTable("AspNetUsers")
                .HasDiscriminator<string>("Discriminator")
                .HasValue<IdentityUser>("IdentityUser");
        }

    }
}
