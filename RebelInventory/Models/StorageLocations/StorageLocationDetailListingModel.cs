using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelInventory.Models.StorageLocations
{
    public class StorageLocationDetailListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public int AmountUnderRepair { get; set; }
        public int AmountAvailable { get; set; }
    
    }
}
