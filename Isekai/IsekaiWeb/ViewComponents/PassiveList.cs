using IsekaiDb.Data;
using IsekaiDb.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IsekaiDb.Data.Enumerable;

namespace IsekaiWeb.ViewComponents
{
    public class PassiveList : ViewComponent
    {
        private readonly IsekaiDbContext _context;

        public PassiveList(IsekaiDbContext context)
        { _context = context; }

        public async Task<IViewComponentResult> InvokeAsync(
            string searchString = null,
            PassiveType categoryFilter = PassiveType.ALL,
            int pageNumber = 1) {

            int pageSize = 15;
            int count = 0;
            List<Passive> item;

            switch (categoryFilter) {
                case PassiveType.ALL:
                    item = _context.Passives.OrderBy(c => c.Name).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                    count = _context.Passives.Count();
                    break;
                case PassiveType.WEAPON:
                    item = _context.Passives.Where(c => c.Type == PassiveType.WEAPON).OrderBy(c => c.Name).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                    count = _context.Passives.Where(c => c.Type == PassiveType.WEAPON).Count();
                    break;
                case PassiveType.ARMOR:
                    item = _context.Passives.Where(c => c.Type == PassiveType.ARMOR).OrderBy(c => c.Name).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                    count = _context.Passives.Where(c => c.Type == PassiveType.ARMOR).Count();
                    break;
                case PassiveType.CLASS:
                    item = _context.Passives.Where(c => c.Type == PassiveType.CLASS).OrderBy(c => c.Name).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                    count = _context.Passives.Where(c => c.Type == PassiveType.CLASS).Count();
                    break;
                case PassiveType.SKILL:
                    item = _context.Passives.Where(c => c.Type == PassiveType.SKILL).OrderBy(c => c.Name).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                    count = _context.Passives.Where(c => c.Type == PassiveType.SKILL).Count();
                    break;
                case PassiveType.OTHER:
                    item = _context.Passives.Where(c => c.Type == PassiveType.OTHER).OrderBy(c => c.Name).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                    count = _context.Passives.Where(c => c.Type == PassiveType.OTHER).Count();
                    break;
                default:
                    item = _context.Passives.OrderBy(c => c.Name).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                    count = _context.Passives.Count();
                    break;
            }

            if (searchString != null)
                if (searchString != "" && searchString != " ")
                    item = item.Where(c => c.Name.Contains(searchString)).ToList();

            return View(PaginatedList<Passive>.CreateAsync(item, count, pageNumber, pageSize, searchString, categoryFilter));
        }
    }
}
