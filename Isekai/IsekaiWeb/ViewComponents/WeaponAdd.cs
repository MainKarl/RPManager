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
            List<SelectListItem> ranks = new List<SelectListItem>() {
                new SelectListItem { Value = "1", Text = "E", Selected = true },
                new SelectListItem { Value = "2", Text = "D" },
                new SelectListItem { Value = "3", Text = "C" },
                new SelectListItem { Value = "4", Text = "B" },
                new SelectListItem { Value = "5", Text = "A" },
                new SelectListItem { Value = "6", Text = "S" }
            };
            List<SelectListItem> damages = new List<SelectListItem>() {
                new SelectListItem { Value = "1", Text = "Physical" },
                new SelectListItem { Value = "2", Text = "Arcane" },
                new SelectListItem { Value = "3", Text = "Fire" },
                new SelectListItem { Value = "4", Text = "Water" },
                new SelectListItem { Value = "5", Text = "Wind" },
                new SelectListItem { Value = "6", Text = "Lightning" },
                new SelectListItem { Value = "7", Text = "Earth" },
                new SelectListItem { Value = "8", Text = "Holy" },
                new SelectListItem { Value = "9", Text = "Dark" }
            };
            List<SelectListItem> weaponTypes = new List<SelectListItem>() {
                new SelectListItem { Value = "Default", Text = "-- Weapon Type --", Selected = true },
                new SelectListItem { Value = "Sword", Text = "Sword" },
                new SelectListItem { Value = "Spear", Text = "Spear" },
                new SelectListItem { Value = "Axe", Text = "Axe" },
                new SelectListItem { Value = "Fist", Text = "Fist" },
                new SelectListItem { Value = "Dagger", Text = "Dagger" },
                new SelectListItem { Value = "Staff", Text = "Staff" },
                new SelectListItem { Value = "Bow", Text = "Bow" }
            };

            List<SelectListItem> passives = new List<SelectListItem>();
            int index = 1;
            passives.Add(new SelectListItem { Value = "1", Text = "None" });
            foreach (Passive item in _context.Passives.Where(c => c.Type == PassiveType.WEAPON)) {
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
                    Passive = ""
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
