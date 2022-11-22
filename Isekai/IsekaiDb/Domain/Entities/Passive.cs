using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IsekaiDb.Data.Enumerable;

namespace IsekaiDb.Domain.Entities
{
    public class Passive
    {
        public Guid PassiveId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PassiveType Type { get; set; }

        // nav
        public ICollection<Armor> ArmorPassives { get; set; }
        public ICollection<Weapon> WeaponPassives { get; set; }
        public ICollection<Character> CharacterPassives { get; set; }
        public ICollection<Class> ClassPassives { get; set; }
        public ICollection<Skill> SkillPassives { get; set; }

        // function
        public string getPassiveType()
        {
            switch (Type) {
                case PassiveType.CLASS:
                    return "Class";
                case PassiveType.ARMOR:
                    return "Armor";
                case PassiveType.WEAPON:
                    return "Weapon";
                case PassiveType.SKILL:
                    return "Skill";
                case PassiveType.OTHER:
                    return "Other";
                default:
                    return "";
            }
        }
    }
}
