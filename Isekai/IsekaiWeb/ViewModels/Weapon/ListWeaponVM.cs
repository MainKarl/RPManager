using static IsekaiDb.Data.Enumerable;

namespace IsekaiWeb.ViewModels.Weapon
{
    public class ListWeaponVM
    {
        public string SearchFilter { get; set; }
        public WeaponType WeaponFilter { get; set; }
    }
}
