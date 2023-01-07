using InventoryManagement.Models;
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
    }
}
