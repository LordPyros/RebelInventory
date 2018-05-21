using InventoryData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RebelInventory.Models.Equipment;
using System.Linq;

namespace RebelInventory.Controllers
{
    public class EquipmentController : Controller
    {
        private IMilitaryAsset _equipments;
        private IChangeValues _changeValues;
        private IStorageLocations _storageLocations;

        public EquipmentController(IMilitaryAsset assets, IChangeValues changeValues, IStorageLocations locations)
        {
            _equipments = assets;
            _changeValues = changeValues;
            _storageLocations = locations;

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

        [Authorize]
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
                StorageLocation = _equipments.GetCurrentLocation(id).Name,
                LocationNames = _storageLocations.GetStorageLocationNames()
            };

            if (_equipments.GetType(id) == "Starship")
            {
                model.HasShields = _equipments.GetHasShields(id);
                model.NoOfLaserCannons = _equipments.GetNoOfLaserCannons(id);
                model.NoOfIonCannons = _equipments.GetNoOfIonCannons(id);
                model.NoOfProtonLaunchers = _equipments.GetNoOfProtonLaunchers(id);
                model.NoOfConcussionLaunchers = _equipments.GetNoOfConcussionLaunchers(id);
            }
            else if (_equipments.GetType(id) == "Vehicle")
            {
                model.VehicleHasShields = _equipments.GetVehicleHasShields(id);
                model.VehicleNoOfLasersCannons = _equipments.GetVehicleNoOfLasersCannons(id);
                model.MaxPassengers = _equipments.GetMaxPassengers(id);
            }
            else
            {
                model.IsOneHanded = _equipments.GetIsOneHanded(id);
                model.IsTwoHanded = _equipments.GetIsTwoHanded(id);
                model.IsTripodMounted = _equipments.GetIsTripodMounted(id);
            }


            return View(model);
        }

        [HttpPost]
        public IActionResult RelocateEquipment(int id, string relocateEquipmentDD)
        {
            // compare string to location names and get location id

            

            _changeValues.RelocateEquipment(id, relocateEquipmentDD);


            // change location id on equipment to new id


            return RedirectToAction("Detail", new { id = id });
        }
        
        [HttpPost]
        public IActionResult AddAmount(int id, int addAmountTB)
        {
            // get item and add amount to it, then save to db
            _changeValues.AddAmount(id, addAmountTB);

            return RedirectToAction("Detail", new { id = id });
        }

        [HttpPost]
        public IActionResult RemoveAmount(int id, int removeAmountTB)
        {
            // get item and remove amount from it, then save to db

            // need to alert user if number not accepted (number makes total go below 0)
            _changeValues.RemoveAmount(id, removeAmountTB);

            return RedirectToAction("Detail", new { id = id });
        }

        [HttpPost]
        public IActionResult SendToRepair(int id, int sendToRepairTB)
        {
            _changeValues.SendToRepair(id, sendToRepairTB);

            return RedirectToAction("Detail", new { id = id });
        }

        [HttpPost]
        public IActionResult ReturnFromRepair(int id, int returnFromRepairTB)
        {
            _changeValues.ReturnFromRepair(id, returnFromRepairTB);

            return RedirectToAction("Detail", new { id = id });
        }
    }
}
