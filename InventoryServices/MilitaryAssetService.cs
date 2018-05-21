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

        public bool GetHasShields(int id)
        {
            return _context.Starships.FirstOrDefault(a => a.Id == id).HasShields;
        }

        public int GetNoOfLaserCannons(int id)
        {
            return _context.Starships.FirstOrDefault(a => a.Id == id).NoOfLasersCannons;
        }

        public int GetNoOfIonCannons(int id)
        {
            return _context.Starships.FirstOrDefault(a => a.Id == id).NoOfIonCannons;
        }

        public int GetNoOfProtonLaunchers(int id)
        {
            return _context.Starships.FirstOrDefault(a => a.Id == id).NoOfProtonTorpedoLaunchers;
        }

        public int GetNoOfConcussionLaunchers(int id)
        {
            return _context.Starships.FirstOrDefault(a => a.Id == id).NoOfConcussionMissileLaunchers;
        }

        public int GetVehicleNoOfLasersCannons(int id)
        {
            return _context.Vehicles.FirstOrDefault(a => a.Id == id).NoOfLasersCannons;
        }

        public bool GetVehicleHasShields(int id)
        {
            return _context.Vehicles.FirstOrDefault(a => a.Id == id).HasShields;
        }

        public int GetMaxPassengers(int id)
        {
            return _context.Vehicles.FirstOrDefault(a => a.Id == id).MaxPassengers;
        }

        public bool GetIsOneHanded(int id)
        {
            return _context.Weapons.FirstOrDefault(a => a.Id == id).IsOneHanded;
        }

        public bool GetIsTwoHanded(int id)
        {
            return _context.Weapons.FirstOrDefault(a => a.Id == id).IsTwoHanded;
        }

        public bool GetIsTripodMounted(int id)
        {
            return _context.Weapons.FirstOrDefault(a => a.Id == id).IsTripodMounted;
        }

    }
}
