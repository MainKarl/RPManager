using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace IsekaiWeb.ViewModels.Weapon
{
    public class WeaponAddVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Accuracy { get; set; }
        public int Crit { get; set; }
        public float Price { get; set; }
        public string Path { get; set; }
        public string Passive { get; set; }
        public string WeaponType { get; set; }
        public string DamageType { get; set; }
        public string Rank { get; set; }

        public bool Update { get; set; }

        public List<string> DamageTypes { get; set; }
        public List<string> WeaponTypes { get; set; }
        public List<string> Ranks { get; set; }
        public List<string> Passives { get; set; }
    }
}
