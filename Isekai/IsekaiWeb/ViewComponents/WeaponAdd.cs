using IsekaiDb.Data;
using IsekaiDb.Domain.Entities;
using IsekaiWeb.ViewModels.Weapon;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IsekaiDb.Data.Enumerable;

namespace IsekaiWeb.ViewComponents
{
    public class WeaponAdd : ViewComponent
    {
        private readonly IsekaiDbContext _context;

        public WeaponAdd(IsekaiDbContext context)
        { _context = context; }

        public async Task<IViewComponentResult> InvokeAsync(
            string id = "",
            string name = "",
            int damage = 0,
            int accuracy = 0,
            int crit = 0,
            float price = 0,
            string passive = "")
        {
            List<string> ranks = new List<string>() {
                "E",
                "D",
                "C",
                "B",
                "A",
                "S"
            };
            List<string> damages = new List<string>() {
                "Physical",
                "Arcane",
                "Fire",
                "Water",
                "Wind",
                "Lightning",
                "Earth",
                "Holy",
                "Dark"
            };
            List<string> weaponTypes = new List<string>() {
                "Sword",
                "Spear",
                "Axe",
                "Fist",
                "Dagger",
                "Staff",
                "Bow",
                "Other"
            };

            List<SelectListItem> passives = new List<SelectListItem>();
            int index = 1;
            passives.Add(new SelectListItem { Value = "Default", Text = "-- Passives --", Selected = true });
            foreach (Passive item in _context.Passives.Where(c => c.Type == PassiveType.WEAPON).OrderBy(c => c.Name)) {
                index++;
                passives.Add(new SelectListItem { Value = index.ToString(), Text = item.Name });
            }

            WeaponAddVM model;
            if (id.Equals("")) {
                model = new WeaponAddVM {
                    Ranks = ranks,
                    WeaponTypes = weaponTypes,
                    DamageTypes = damages,
                    Passives = passives,
                    Passive = "",
                    Rank = "-- Weapon Rank --",
                    DamageType = "-- Damage Type --",
                    WeaponType = "-- Weapon Type --"
                };
            }
            else {
                model = new WeaponAddVM {
                    Id = id,
                    Name = name,
                    Damage = damage,
                    Accuracy = accuracy,
                    Crit = crit,
                    Price = price,
                    Ranks = ranks,
                    WeaponTypes = weaponTypes,
                    DamageTypes = damages,
                    Passives = passives,
                    Passive = ""
                };
            }
            return View(model);
        }
    }
}
