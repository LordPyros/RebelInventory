using InventoryData.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryData
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions options) : base(options) { }

        public DbSet<MilitaryAsset> MilitaryAssets { get; set; } 
        public DbSet<Starship> Starships { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<StorageLocation> StorageLocations { get; set; }
        public DbSet<Repair> Repairs { get; set; }

    }
}
