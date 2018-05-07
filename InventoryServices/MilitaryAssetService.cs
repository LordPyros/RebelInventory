using InventoryData;
using InventoryData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventoryServices
{
    public class MilitaryAssetService : IMilitaryAsset
    {
        private InventoryContext _context;

        public MilitaryAssetService(InventoryContext context)
        {
            _context = context;
        }

        //public void Add(MilitaryAsset newAsset)
        //{
        //    _context.Add(newAsset);
        //    _context.SaveChanges();
        //}

        public IEnumerable<MilitaryAsset> GetAll()
        {
            return _context.MilitaryAssets
                .Include(asset => asset.Repairing)
                .Include(asset => asset.Location);
        }

        public int GetAmount(int id)
        {
            return GetById(id).Amount;
        }

        public MilitaryAsset GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(asset => asset.Id == id);
        }

        public Repair GetAmountUnderRepair(int id)
        {
            return GetById(id).Repairing;
        }

        public StorageLocation GetCurrentLocation(int id)
        {
            return GetById(id).Location;
        }

        public string GetName(int id)
        {
            return GetById(id).Name;
        }

        public string GetType(int id)
        {
            var equipment = GetById(id);

            if (equipment.GetType() == typeof(Starship))
                return "Starship";
            else if (equipment.GetType() == typeof(Vehicle))
                return "Vehicle";
            else
                return "Weapon";
        }

    }
}
