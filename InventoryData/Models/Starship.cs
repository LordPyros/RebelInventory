namespace InventoryData.Models
{
    public class Starship : MilitaryAsset
    {
        public int NoOfLasersCannons { get; set; }
        public int NoOfIonCannons { get; set; }
        public int NoOfProtonTorpedoLaunchers { get; set; }
        public int NoOfConcussionMissileLaunchers { get; set; }
        public bool HasShields { get; set; }

    }
}
