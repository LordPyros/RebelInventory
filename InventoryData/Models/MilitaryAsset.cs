namespace InventoryData.Models
{
    public abstract class MilitaryAsset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public string ImageUrl { get; set; }

        public Repair Repairing { get; set; }
        public StorageLocation Location { get; set; }

    }
}
