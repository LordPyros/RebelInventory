namespace InventoryData.Models
{
    public class Vehicle : MilitaryAsset
    {
        public int NoOfLasersCannons { get; set; }
        public int HasShields { get; set; }
        public int MaxPassengers { get; set; }
    }
}
