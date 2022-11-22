using IsekaiDb.Data;
using IsekaiDb.Domain.Entities;
using IsekaiWeb.ViewModels.Armor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace IsekaiWeb.Controllers
{
    [Authorize]
    public class ArmorController : Controller
    {
        private readonly IsekaiDbContext _context;

        public ArmorController(IsekaiDbContext context)
        { _context = context; }

        [AllowAnonymous]
        public IActionResult List()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Refresh(int pageNumber)
        {
            return ViewComponent("ArmorList", new { pageNumber = pageNumber });
        }

        [AllowAnonymous]
        public IActionResult Add()
        {
            return ViewComponent("ArmorAdd");
        }

        [AllowAnonymous]
        [HttpPost]
        public async void Add(string name, int power, string passive)
        {
            try {
                Armor armor = new Armor {
                    ArmorId = Guid.NewGuid(),
                    Name = name,
                    Power = power,
                    //ArmorPassives = model.Passive
                };

                _context.Armors.Add(armor);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex) {
                
            }
        }
    }
}
