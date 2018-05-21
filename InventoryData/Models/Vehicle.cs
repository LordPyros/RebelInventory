namespace InventoryData.Models
{
    public class Vehicle : MilitaryAsset
    {
        public int NoOfLasersCannons { get; set; }
        public bool HasShields { get; set; }
        public int MaxPassengers { get; set; }
    }
}
