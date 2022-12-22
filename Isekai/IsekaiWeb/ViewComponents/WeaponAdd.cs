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
                new SelectListItem { Value = "Default", Text = "-- Weapon Rank -- ", Selected = true },
                new SelectListItem { Value = "E", Text = "E" },
                new SelectListItem { Value = "D", Text = "D" },
                new SelectListItem { Value = "C", Text = "C" },
                new SelectListItem { Value = "B", Text = "B" },
                new SelectListItem { Value = "A", Text = "A" },
                new SelectListItem { Value = "S", Text = "S" }
            };
            List<SelectListItem> damages = new List<SelectListItem>() {
                new SelectListItem { Value = "Default", Text = "-- Damage Type --", Selected = true },
                new SelectListItem { Value = "Physical", Text = "Physical" },
                new SelectListItem { Value = "Arcane", Text = "Arcane" },
                new SelectListItem { Value = "Fire", Text = "Fire" },
                new SelectListItem { Value = "Water", Text = "Water" },
                new SelectListItem { Value = "Wind", Text = "Wind" },
                new SelectListItem { Value = "Lightning", Text = "Lightning" },
                new SelectListItem { Value = "Earth", Text = "Earth" },
                new SelectListItem { Value = "Holy", Text = "Holy" },
                new SelectListItem { Value = "Dark", Text = "Dark" }
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
