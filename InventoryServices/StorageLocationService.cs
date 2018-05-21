using InventoryData;
using InventoryData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventoryServices
{
    public class StorageLocationService : IStorageLocations
    {
        private InventoryContext _context;

        public StorageLocationService(InventoryContext context)
        {
            _context = context;
        }

        public int GetEquipmentTotalAtLocation(int locationId)
        {
            // need to get all equipment at current location
            // add all amounts together
            var equipments = GetAllEquipmentAtLocation(locationId);
            int total = 0;
            foreach (MilitaryAsset m in equipments)
            {
                total += m.Amount;
            }
            return total;
        }

        public StorageLocation Get(int locationId)
        {
            return _context.StorageLocations
                .FirstOrDefault(l => l.Id == locationId);
        }

        public IEnumerable<StorageLocation> GetAll()
        {
            return _context.StorageLocations;
        }

        public IEnumerable<MilitaryAsset> GetAllEquipment()
        {
            return _context.MilitaryAssets
                .Include(asset => asset.Repairing)
                .Include(asset => asset.Location);
        }

        public IEnumerable<MilitaryAsset> GetAllEquipmentAtLocation(int locationId)
        {
            // need to get all equipment, then separate assets with matching locationId
            List<MilitaryAsset> equipmentAtLocation = new List<MilitaryAsset>();
            foreach (MilitaryAsset m in GetAllEquipment())
            {
                if (m.Location.Id == locationId)
                {
                    equipmentAtLocation.Add(m);
                }
            }

            return equipmentAtLocation;
        }

        public int GetTotalAmountUnderRepair(int locationId)
        {
            // need to get all equipment at location
            var allEquipmentAtLocation = GetAllEquipmentAtLocation(locationId);
            // then need to get all repairs with matching id's and add them together
            var AllRepairs = GetAllRepairs();

            int totalRepairs = 0;

            foreach (MilitaryAsset m in allEquipmentAtLocation)
            {
                foreach (Repair r in AllRepairs)
                {
                    if (m.Id == r.Id)
                    {
                        totalRepairs += r.AmountUnderRepair;
                    }
                }
            }

            return totalRepairs;
        }

        public IEnumerable<Repair> GetAllRepairs()
        {
            return _context.Repairs;
        }

        public int GetTotalAmountAvaiilable(int locationId)
        {
            return GetEquipmentTotalAtLocation(locationId) - GetTotalAmountUnderRepair(locationId);
        }

        public string GetType(int equipmentId)
        {
            var equipment = GetById(equipmentId);

            if (equipment.GetType() == typeof(Starship))
                return "Starship";
            else if (equipment.GetType() == typeof(Vehicle))
                return "Vehicle";
            else
                return "Weapon";
        }

        public MilitaryAsset GetById(int id)
        {
            return GetAllEquipment()
                .FirstOrDefault(asset => asset.Id == id);
        }

        public Repair GetAmountUnderRepair(int equipmentId)
        {
            return GetById(equipmentId).Repairing;
        }

        public List<string> GetStorageLocationNames()
        {
            List<string> names = new List<string>();

            foreach (StorageLocation s in GetAll())
            {
                names.Add(s.Name);
            }

            return names;
        }
    }
}
