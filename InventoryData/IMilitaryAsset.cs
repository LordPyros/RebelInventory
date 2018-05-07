using InventoryData.Models;
using System.Collections.Generic;

namespace InventoryData
{
    public interface IMilitaryAsset
    {
        IEnumerable<MilitaryAsset> GetAll();
        MilitaryAsset GetById(int id);

        // no adding new equipment at this stage
        //void Add(MilitaryAsset newAsset);

        string GetType(int id);
        string GetName(int id);
        int GetAmount(int id);

        Repair GetAmountUnderRepair(int id);
        StorageLocation GetCurrentLocation(int id);
    }
}
