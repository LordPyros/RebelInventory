using InventoryData;
using Microsoft.AspNetCore.Mvc;
using RebelInventory.Models.Equipment;
using System.Linq;

namespace RebelInventory.Controllers
{
    public class EquipmentController : Controller
    {
        private IMilitaryAsset _equipments;

        public EquipmentController(IMilitaryAsset assets)
        {
            _equipments = assets;
        }

        public IActionResult Index()
        {
            var equipmentModels = _equipments.GetAll();

            var listingResult = equipmentModels
                .Select(result => new EquipmentIndexListingModel
                {
                    Id = result.Id,
                    ImageUrl = result.ImageUrl,
                    Name = result.Name,
                    Type = _equipments.GetType(result.Id),
                    Amount = result.Amount
                });

            var model = new EquipmentIndexModel()
            {
                Equipments = listingResult
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var equipment = _equipments.GetById(id);

            var model = new EquipmentDetailModel
            {
                EquipmentId = id,
                Name = equipment.Name,
                Description = equipment.Description,
                Amount = equipment.Amount,
                AmountUnderRepair = _equipments.GetAmountUnderRepair(id).AmountUnderRepair,
                AmountAvailable = equipment.Amount - _equipments.GetAmountUnderRepair(id).AmountUnderRepair,
                ImageUrl = equipment.ImageUrl,
                Type = _equipments.GetType(id),
                StorageLocation = _equipments.GetCurrentLocation(id).Name
            };

            return View(model);
        }
    }
}
