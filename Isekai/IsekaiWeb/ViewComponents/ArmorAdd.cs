using IsekaiDb.Data;
using IsekaiDb.Domain.Entities;
using IsekaiWeb.ViewModels.Armor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IsekaiDb.Data.Enumerable;

namespace IsekaiWeb.ViewComponents
{
    public class ArmorAdd : ViewComponent
    {
        private readonly IsekaiDbContext _context;

        public ArmorAdd(IsekaiDbContext context)
        { _context = context; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = "1", Text = "None" });
            int index = 1;
            foreach (Passive item in _context.Passives.Where(c => c.Type == PassiveType.ARMOR).OrderBy(c => c.Name).ToList()) {
                index++;
                list.Add(new SelectListItem { Value = index.ToString(), Text = item.Name });
            }

            ArmorAddVM model = new ArmorAddVM { 
                ArmorPassive = list,
                Passive = ""
            };

            return View(model); 
        }
    }
}
