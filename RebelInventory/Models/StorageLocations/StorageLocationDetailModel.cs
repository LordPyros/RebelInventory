using System.Collections.Generic;

namespace RebelInventory.Models.StorageLocations
{
    public class StorageLocationDetailModel
    {
        public int Id { get; set; }

        public string LocationName { get; set; }
        public string ImageUrl { get; set; }
        public string LocationDescription { get; set; }

        public int TotalAmountUnderRepair { get; set; }
        public int TotalAmountAvailable { get; set; }
        public int TotalAmountOfEquipment { get; set; }
        
        public IEnumerable<StorageLocationDetailListingModel> ListingDetails { get; set; }
    }
}
