using System.Collections.Generic;

namespace RebelInventory.Models.Equipment
{
    public class EquipmentDetailModel
    {
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int AmountUnderRepair { get; set; }
        public int AmountAvailable { get; set; }
        public string ImageUrl { get; set; }
        public string StorageLocation { get; set; }
        public string Type { get; set; }
        //starship
        public bool HasShields { get; set; }
        public int NoOfLaserCannons { get; set; }
        public int NoOfIonCannons { get; set; }
        public int NoOfProtonLaunchers { get; set; }
        public int NoOfConcussionLaunchers { get; set; }
        //vehicle
        public int VehicleNoOfLasersCannons { get; set; }
        public bool VehicleHasShields { get; set; }
        public int MaxPassengers { get; set; }
        //weapon
        public bool IsOneHanded { get; set; }
        public bool IsTwoHanded { get; set; }
        public bool IsTripodMounted { get; set; }

        public List<string> LocationNames { get; set; }
    }
}
