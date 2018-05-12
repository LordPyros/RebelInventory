using InventoryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryData
{
    public interface IChangeValues
    {
        IEnumerable<MilitaryAsset> GetAll();
        MilitaryAsset GetById(int equipmentId);
        Repair GetRepair(int equipmentId);



        void AddAmount(int equipmentId, int amount);
        void RemoveAmount(int equipmentId, int amount);
        void SendToRepair(int equipmentId, int amount);
        void ReturnFromRepair(int equipmentId, int amount);



    }
}
