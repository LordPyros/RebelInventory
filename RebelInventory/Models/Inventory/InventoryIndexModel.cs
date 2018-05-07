using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelInventory.Models.Inventory
{
    public class InventoryIndexModel
    {
        public IEnumerable<InventoryDetailModel> InventoryItems { get; set; }
    }
}
