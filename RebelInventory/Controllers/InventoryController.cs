using InventoryData;
using Microsoft.AspNetCore.Mvc;
using RebelInventory.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelInventory.Controllers
{
    public class InventoryController : Controller
    {
        private IInventoryList _inventoryList;

        public InventoryController(IInventoryList inventoryList)
        {
            _inventoryList = inventoryList;
        }

        public IActionResult Index()
        {
            var allInventory = _inventoryList.GetAll();

            var inventoryListModels = allInventory.Select(result => new InventoryDetailModel
            {
                Id = result.Id,
                Name = result.Name,
                Type = _inventoryList.GetType(result.Id),
                Location = result.Location.Name,
                Amount = result.Amount,
                AmountUnderRepair = _inventoryList.GetAmountUnderRepair(result.Id).AmountUnderRepair,
                AmountAvailable = result.Amount - _inventoryList.GetAmountUnderRepair(result.Id).AmountUnderRepair
            }).ToList();

            var model = new InventoryIndexModel()
            {
                InventoryItems = inventoryListModels
            };

            return View(model);


        }
    }
}
