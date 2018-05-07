using InventoryData;
using Microsoft.AspNetCore.Mvc;
using RebelInventory.Models.StorageLocations;
using System.Linq;

namespace RebelInventory.Controllers
{
    public class LocationController : Controller
    {
        private IStorageLocations _location;

        public LocationController(IStorageLocations location)
        {
            _location = location;
        }

        public IActionResult Index()
        {
            var locations = _location.GetAll().Select(location => new StorageLocationDetailModel
            {
                Id = location.Id,
                LocationName = location.Name,
                TotalAmountOfEquipment = _location.GetEquipmentTotalAtLocation(location.Id)
            });

            var model = new StorageLocationIndexModel()
            {
                Locations = locations
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {

            // get list of equipment at current location
            var equipmentModels = _location.GetAllEquipmentAtLocation(id);

            var listingResult = equipmentModels
                .Select(result => new StorageLocationDetailListingModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    Type = _location.GetType(result.Id),
                    Amount = result.Amount,
                    AmountUnderRepair = _location.GetAmountUnderRepair(result.Id).AmountUnderRepair,
                    AmountAvailable = result.Amount - _location.GetAmountUnderRepair(result.Id).AmountUnderRepair
                });


            // get location details
            var location = _location.Get(id);

            var model = new StorageLocationDetailModel
            {
                Id = location.Id,
                LocationName = location.Name,
                LocationDescription = location.Description,
                ImageUrl = location.ImageUrl,
                TotalAmountOfEquipment = _location.GetEquipmentTotalAtLocation(location.Id),
                TotalAmountUnderRepair = _location.GetTotalAmountUnderRepair(location.Id),
                TotalAmountAvailable = _location.GetTotalAmountAvaiilable(location.Id),
                ListingDetails = listingResult
            };

            return View(model);
        }
    }
}
