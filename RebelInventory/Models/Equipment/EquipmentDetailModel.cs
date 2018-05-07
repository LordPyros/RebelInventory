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
    }
}
