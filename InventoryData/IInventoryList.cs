using InventoryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryData
{
    public interface IInventoryList
    {
        IEnumerable<MilitaryAsset> GetAll();

        MilitaryAsset GetById(int id);

        string GetType(int id);
        string GetName(int id);
        int GetAmount(int id);

        Repair GetAmountUnderRepair(int id);
        StorageLocation GetCurrentLocation(int id);
    }
}
