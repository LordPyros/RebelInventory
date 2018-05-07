using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelInventory.Models.StorageLocations
{
    public class StorageLocationIndexModel
    {
        public IEnumerable<StorageLocationDetailModel> Locations { get; set; }
    }
}
