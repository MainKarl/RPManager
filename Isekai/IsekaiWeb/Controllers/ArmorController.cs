using IsekaiDb.Data;
using static IsekaiDb.Data.Enumerable;
using IsekaiDb.Domain.Entities;
using IsekaiWeb.ViewModels.Armor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

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
        public bool Add(string name, int power, string passive = "")
        {
            try {
                List<Passive> list = new List<Passive>();
                if (passive != null)
                    foreach (string item in passive.Split(";"))
                        list.Add(_context.Passives.Where(c => c.Type == PassiveType.ARMOR && c.Name == item).SingleOrDefault());

                Armor armor = new Armor {
                    ArmorId = Guid.NewGuid(),
                    Name = name,
                    Power = power,
                    ArmorPassives = list
                };

                if (armor.Name != null && armor.Name != "") {
                    _context.Armors.Add(armor);
                    _context.SaveChanges();
                    return true;
                }
                else
                    throw new Exception();
            }
            catch (Exception) {
                return false;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public bool Delete(string id)
        {
            try {
                Armor armor = _context.Armors.Where(c => c.ArmorId == Guid.Parse(id)).SingleOrDefault();
                string name = armor.Name;
                _context.Armors.Remove(armor);
                _context.SaveChanges();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
    }
}
