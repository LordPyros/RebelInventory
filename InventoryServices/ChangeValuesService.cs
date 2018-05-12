using InventoryData;
using InventoryData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventoryServices
{
    public class ChangeValuesService : IChangeValues
    {
        private InventoryContext _context;

        public ChangeValuesService(InventoryContext context)
        {
            _context = context;
        }
        
        public void AddAmount(int equipmentId, int amount)
        {
            var equipment = GetById(equipmentId);

            equipment.Amount += amount;

            _context.Update(equipment);
            _context.SaveChanges();
        }

        public IEnumerable<MilitaryAsset> GetAll()
        {
            return _context.MilitaryAssets
                .Include(asset => asset.Repairing)
                .Include(asset => asset.Location);
        }

        public MilitaryAsset GetById(int equipmentId)
        {
            return GetAll()
                .FirstOrDefault(asset => asset.Id == equipmentId);
        }

        public Repair GetRepair(int equipmentId)
        {
            return GetById(equipmentId).Repairing;
        }

        public void RemoveAmount(int equipmentId, int amount)
        {
            var equipment = GetById(equipmentId);

            equipment.Amount -= amount;

            if (equipment.Amount >= 0)
            {
                _context.Update(equipment);
                _context.SaveChanges();
            }
        }

        public void ReturnFromRepair(int equipmentId, int amount)
        {
            var repair = GetRepair(equipmentId);

            // check the new amount being returned is not more than the amount already under repairs
            if (repair.AmountUnderRepair >= amount)
            {
                repair.AmountUnderRepair -= amount;

                _context.Update(repair);
                _context.SaveChanges();
            }
        }

        public void SendToRepair(int equipmentId, int amount)
        {
            var equipment = GetById(equipmentId);
            var repair = GetRepair(equipmentId);

            // check the new amount to be repaired is not more than the amount of operational items
            var chkAmount = equipment.Amount - repair.AmountUnderRepair;

            if (!(chkAmount < amount))
            {
                repair.AmountUnderRepair += amount;

                _context.Update(repair);
                _context.SaveChanges();
            }
        }
    }
}
