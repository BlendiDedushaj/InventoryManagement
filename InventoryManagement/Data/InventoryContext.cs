using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions options): base(options) { }

        public virtual DbSet<Unit> Units { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }

        
    }
}
