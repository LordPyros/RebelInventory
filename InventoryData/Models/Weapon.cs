namespace InventoryData.Models
{
    public class Weapon : MilitaryAsset
    {
        public bool IsOneHanded { get; set; }
        public bool IsTwoHanded { get; set; }
        public bool IsTripodMounted { get; set; }
    }
}
