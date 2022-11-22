using IsekaiDb.Data;
using IsekaiDb.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsekaiWeb.ViewComponents
{
    public class ArmorList : ViewComponent
    {
        private readonly IsekaiDbContext _context;

        public ArmorList(IsekaiDbContext context)
        { _context = context; }

        public async Task<IViewComponentResult> InvokeAsync(int? pageNumber = 1)
        {
            int pageSize = 9;
            List<Armor> item = _context.Armors.Include(b => b.ArmorPassives).OrderBy(c => c.Power).ToList();
            return View(PaginatedList<Armor>.CreateAsync(item, pageNumber ?? 1, pageSize, "", ""));
        }
    }
}
