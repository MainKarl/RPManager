using IsekaiDb.Data;
using IsekaiDb.Domain.Entities;
using IsekaiWeb.ViewModels.Weapon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using static IsekaiDb.Data.Enumerable;

namespace IsekaiWeb.Controllers
{
    [Authorize]
    public class WeaponController : Controller
    {
        private readonly IsekaiDbContext _context;

        public WeaponController(IsekaiDbContext context)
        { _context = context; }

        [AllowAnonymous]
        public IActionResult List()
        { return View(new ListWeaponVM { SearchFilter = "", WeaponFilter = WeaponType.ALL }); }

        [AllowAnonymous]
        public IActionResult Refresh(int pageNumber, WeaponType type = WeaponType.ALL)
        { return ViewComponent("WeaponList", new { pageNumber = pageNumber, weaponType = type }); }

        [AllowAnonymous]
        public IActionResult Add()
        { return ViewComponent("WeaponAdd"); }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Update()
        { return ViewComponent("WeaponAdd", new { }); }

        [AllowAnonymous]
        [HttpPost]
        public bool Add(string name, int damage, int accuracy, int crit, float price, string rank, string damageType, string type, string path = "", string passive = "")
        {
            try {
                List<Passive> list = new List<Passive>();
                if (passive != null)
                    foreach (string item in passive.Split(";"))
                        list.Add(_context.Passives.Where(c => c.Type == PassiveType.WEAPON && c.Name == item).SingleOrDefault());

                WeaponRank wrank;
                WeaponType wtype;
                DamageType dtype;

                switch (rank)
                {
                    case "E":
                        wrank = WeaponRank.E;
                        break;
                    case "D":
                        wrank = WeaponRank.D;
                        break;
                    case "C":
                        wrank = WeaponRank.C;
                        break;
                    case "B":
                        wrank = WeaponRank.B;
                        break;
                    case "A":
                        wrank = WeaponRank.A;
                        break;
                    case "S":
                        wrank = WeaponRank.S;
                        break;
                    default:
                        wrank = WeaponRank.E;
                        break;
                }
                switch (damageType)
                {
                    case "PHYSICAL":
                        dtype = DamageType.PHYSICAL;
                        break;
                    case "ARCANE":
                        dtype = DamageType.ARCANE;
                        break;
                    case "FIRE":
                        dtype = DamageType.FIRE;
                        break;
                    case "WATER":
                        dtype = DamageType.WATER;
                        break;
                    case "WIND":
                        dtype = DamageType.WIND;
                        break;
                    case "LIGHTNING":
                        dtype = DamageType.LIGHTNING;
                        break;
                    case "EARTH":
                        dtype = DamageType.EARTH;
                        break;
                    case "HOLY":
                        dtype = DamageType.HOLY;
                        break;
                    case "DARK":
                        dtype = DamageType.DARK;
                        break;
                    default:
                        dtype = DamageType.PHYSICAL;
                        break;
                }
                switch (type)
                {
                    case "SWORD":
                        wtype = WeaponType.SWORD;
                        break;
                    case "SPEAR":
                        wtype = WeaponType.SPEAR;
                        break;
                    case "AXE":
                        wtype = WeaponType.AXE;
                        break;
                    case "FIST":
                        wtype = WeaponType.FIST;
                        break;
                    case "DAGGER":
                        wtype = WeaponType.DAGGER;
                        break;
                    case "STAFF":
                        wtype = WeaponType.STAFF;
                        break;
                    case "BOW":
                        wtype = WeaponType.BOW;
                        break;
                    default:
                        wtype = WeaponType.SWORD;
                        break;
                }

                Weapon weapon = new Weapon(name, damage, accuracy, crit, price, wrank, dtype, wtype, list);
                if (weapon.Name != null && weapon.Name != "") {
                    _context.Weapons.Add(weapon);
                    _context.SaveChanges();
                    return true;
                }
                else
                    throw new Exception();
            }
            catch (Exception) { return false; }
        }

        [AllowAnonymous]
        [HttpPost]
        public bool PostUpdate(string id, string name, int damage, int accuracy, int crit, float price, string rank, string damageType, string type, string passive = "")
        {
            try {
                Weapon weapon = _context.Weapons.Include(b => b.WeaponPassives).Where(c => c.WeaponId == Guid.Parse(id)).SingleOrDefault();
                weapon.Name = name;
                weapon.Damage = damage;
                weapon.Accuracy = accuracy;
                weapon.Crit = crit;
                weapon.Price = price;
                weapon.setRank(rank);
                weapon.setDamageType(damageType);
                weapon.setWeaponType(type);

                List<Passive> list = new List<Passive>();
                if (passive != null)
                    foreach (string item in passive.Split(";"))
                        list.Add(_context.Passives.Where(c => c.Type == PassiveType.WEAPON && c.Name == item).FirstOrDefault());

                weapon.WeaponPassives = list;

                _context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        [AllowAnonymous]
        [HttpPost]
        public bool Delete(string id)
        {
            try {
                Weapon weapon = _context.Weapons.Where(c => c.WeaponId == Guid.Parse(id)).SingleOrDefault();
                _context.Weapons.Remove(weapon);
                _context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
