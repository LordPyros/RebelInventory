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

        //starship
        bool GetHasShields(int id);
        int GetNoOfLaserCannons(int id);
        int GetNoOfIonCannons(int id);
        int GetNoOfProtonLaunchers(int id);
        int GetNoOfConcussionLaunchers(int id);
        //vehicle
        int GetVehicleNoOfLasersCannons(int id);
        bool GetVehicleHasShields(int id);
        int GetMaxPassengers(int id);
        //weapon
        bool GetIsOneHanded(int id);
        bool GetIsTwoHanded(int id);
        bool GetIsTripodMounted(int id);
        
        Repair GetAmountUnderRepair(int id);
        StorageLocation GetCurrentLocation(int id);

    }
}
