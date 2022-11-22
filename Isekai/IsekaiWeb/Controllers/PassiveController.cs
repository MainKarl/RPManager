using IsekaiDb.Data;
using IsekaiWeb.ViewModels.Passive;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static IsekaiDb.Data.Enumerable;

namespace IsekaiWeb.Controllers
{
    [Authorize]
    public class PassiveController : Controller
    {
        private readonly IsekaiDbContext _context;
        public PassiveController(IsekaiDbContext context)
        { _context = context; }

        [AllowAnonymous]
        public IActionResult List(PassiveType CategoryFilter = PassiveType.ALL)
        {
            ListPassiveVM model = new ListPassiveVM {
                CategoryFilter = CategoryFilter
            };

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Refresh(int pageNumber, string search = "", PassiveType passiveType = PassiveType.ALL)
        {
            return ViewComponent("PassiveList", new { searchString = search, categoryFilter = passiveType, pageNumber = pageNumber });
        }
    }
}
