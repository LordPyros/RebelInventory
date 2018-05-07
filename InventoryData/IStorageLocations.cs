using InventoryData.Models;
using System.Collections.Generic;

namespace InventoryData
{
    public interface IStorageLocations
    {
        IEnumerable<StorageLocation> GetAll();
        IEnumerable<MilitaryAsset> GetAllEquipmentAtLocation(int locationId);
        IEnumerable<MilitaryAsset> GetAllEquipment();

        StorageLocation Get(int locationId);

        int GetEquipmentTotalAtLocation(int locationId);
        int GetTotalAmountUnderRepair(int locationId);
        int GetTotalAmountAvaiilable(int locationId);

        string GetType(int equipmentId);

        MilitaryAsset GetById(int equipmentId);
        
        Repair GetAmountUnderRepair(int equipmentId);
        
    }
}
