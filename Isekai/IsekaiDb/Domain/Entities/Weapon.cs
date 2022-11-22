using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IsekaiDb.Data.Enumerable;

namespace IsekaiDb.Domain.Entities
{
    public class Weapon
    {
        public Guid WeaponId { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Accuracy { get; set; }
        public int Crit { get; set; }
        public float Price { get; set; }

        // nav
        public WeaponRank Rank { get; set; }
        public DamageType DamageType { get; set; }
        public WeaponType Type { get; set; }
        public ICollection<Passive> WeaponPassives { get; set; }

        // function
        public string getRank()
        {
            switch (Rank) {
                case WeaponRank.E:
                    return "E Rank";
                case WeaponRank.D:
                    return "D Rank";
                case WeaponRank.C:
                    return "C Rank";
                case WeaponRank.B:
                    return "B Rank";
                case WeaponRank.A:
                    return "A Rank";
                case WeaponRank.S:
                    return "S Rank";
                default:
                    return "";
            }
        }
        public string getDamageType() {
            switch (DamageType) {
                case DamageType.PHYSICAL:
                    return "Physical";
                case DamageType.ARCANE:
                    return "Arcane";
                case DamageType.FIRE:
                    return "Fire";
                case DamageType.WATER:
                    return "Water";
                case DamageType.WIND:
                    return "Wind";
                case DamageType.LIGHTNING:
                    return "Lightning";
                case DamageType.EARTH:
                    return "Earth";
                case DamageType.HOLY:
                    return "Holy";
                case DamageType.DARK:
                    return "Dark";
                default:
                    return "";
            }
        }
        public string getWeaponType() {
            switch (Type)
            {
                case WeaponType.SWORD:
                    return "Sword";
                case WeaponType.SPEAR:
                    return "Spear";
                case WeaponType.AXE:
                    return "Axe";
                case WeaponType.FIST:
                    return "Fist";
                case WeaponType.DAGGER:
                    return "Dagger";
                case WeaponType.STAFF:
                    return "Staff";
                case WeaponType.BOW:
                    return "Bow";
                default:
                    return "";
            }
        }

        public bool isMagical()
        {
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magical Weapon").Single()))
                return true;
            else
                return false;
        }
        public bool canCrit() {
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Cannot Crit").Single()))
                return false;
            else
                return true;
        }
        public bool canDouble() {
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Two Attacks").Single()))
                return true;
            else
                return false;
        }
        public int bonusMagicDamage() {
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic Damage+I").Single()))
                return 1;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic Damage+II").Single()))
                return 2;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic Damage+III").Single()))
                return 3;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic Damage+IV").Single()))
                return 4;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic Damage+V").Single()))
                return 5;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic Damage+VI").Single()))
                return 6;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic Damage+VII").Single()))
                return 7;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic Damage+VIII").Single()))
                return 8;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic Damage+IX").Single()))
                return 9;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic Damage+X").Single()))
                return 10;
            else 
                return 0;
        }
        public int getHeal(int damageDealt, bool isCrit) {
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "50% Lifesteal").Single()))
                return damageDealt / 2;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "100% Lifesteal").Single()))
                return damageDealt;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "50% Crit Lifesteal").Single()) && isCrit)
                return damageDealt / 2;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "100% Crit Lifesteal").Single()))
                return damageDealt;
            else
                return 0;
        }

        public float getEffectivePassive(Character enemy) {
            float effective = 1;
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Effective agains't Flying").Single()) && enemy.Types.Contains(CharacterType.FLYING))
                effective *= 1.5f;
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Effective agains't Armored").Single()) && enemy.Types.Contains(CharacterType.ARMORED))
                effective *= 1.5f;
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Effective agains't Mounted").Single()) && enemy.Types.Contains(CharacterType.MOUNTED))
                effective *= 1.5f;
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Effective agains't Beast").Single()) && enemy.Types.Contains(CharacterType.BEAST))
                effective *= 1.5f;
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Effective agains't Dragon").Single()) && enemy.Types.Contains(CharacterType.DRAGONOID))
                effective *= 1.5f;
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Effective agains't Void").Single()) && enemy.Types.Contains(CharacterType.VOID))
                effective *= 1.5f;
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Effective agains't Undead").Single()) && enemy.Types.Contains(CharacterType.UNDEAD))
                effective *= 1.5f;
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Effective agains't Demon").Single()) && enemy.Types.Contains(CharacterType.DEMONOID))
                effective *= 1.5f;
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Effective agains't Monster").Single()) && enemy.Types.Contains(CharacterType.MONSTER))
                effective *= 1.5f;
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Effective agains't Human").Single()) && enemy.Types.Contains(CharacterType.HUMANOID))
                effective *= 1.5f;

            return effective;
        }
        public float getEffectiveDamage(Character enemy) {
            float effective = 1;
            if ((DamageType == DamageType.LIGHTNING || DamageType == DamageType.WIND) && enemy.Types.Contains(CharacterType.FLYING))
                effective *= 1.5f;
            if (DamageType == DamageType.PHYSICAL && enemy.Types.Contains(CharacterType.ARMORED))
                effective /= 2;
            if (DamageType == DamageType.HOLY &&
                (enemy.Types.Contains(CharacterType.UNDEAD) || enemy.Types.Contains(CharacterType.UNDEAD) || enemy.Types.Contains(CharacterType.MONSTER) || enemy.Types.Contains(CharacterType.DEMONOID)))
                effective *= 1.5f;
            if (DamageType == DamageType.HOLY && enemy.Types.Contains(CharacterType.VOID))
                effective /= 2;
            if (DamageType == DamageType.DARK && enemy.Types.Contains(CharacterType.VOID))
                effective *= 1.5f;
            if (DamageType == DamageType.DARK && enemy.Types.Contains(CharacterType.HOLY))
                effective /= 2;

            return effective;
        }
        public float getEffective(Character enemy) {
            float effective = 0;
            effective += getEffectivePassive(enemy);
            effective += getEffectiveDamage(enemy);
            return effective;
        }

        public int getBonusStrength()
        {
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Strength+I").Single()))
                return 1;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Strength+II").Single()))
                return 2;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Strength+III").Single()))
                return 3;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Strength+IV").Single()))
                return 4;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Strength+V").Single()))
                return 5;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Strength+VI").Single()))
                return 6;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Strength+VII").Single()))
                return 7;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Strength+VIII").Single()))
                return 8;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Strength+IX").Single()))
                return 9;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Strength+X").Single()))
                return 10;
            else
                return 0;
        }
        public int getBonusMagic()
        {
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic+I").Single()))
                return 1;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic+II").Single()))
                return 2;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic+III").Single()))
                return 3;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic+IV").Single()))
                return 4;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic+V").Single()))
                return 5;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic+VI").Single()))
                return 6;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic+VII").Single()))
                return 7;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic+VIII").Single()))
                return 8;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic+IX").Single()))
                return 9;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Magic+X").Single()))
                return 10;
            else
                return 0;
        }
        public int getBonusDefense()
        {
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Defense+I").Single()))
                return 1;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Defense+II").Single()))
                return 2;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Defense+III").Single()))
                return 3;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Defense+IV").Single()))
                return 4;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Defense+V").Single()))
                return 5;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Defense+VI").Single()))
                return 6;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Defense+VII").Single()))
                return 7;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Defense+VIII").Single()))
                return 8;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Defense+IX").Single()))
                return 9;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Defense+X").Single()))
                return 10;
            else
                return 0;
        }
        public int getBonusResistance()
        {
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Resistance+I").Single()))
                return 1;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Resistance+II").Single()))
                return 2;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Resistance+III").Single()))
                return 3;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Resistance+IV").Single()))
                return 4;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Resistance+V").Single()))
                return 5;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Resistance+VI").Single()))
                return 6;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Resistance+VII").Single()))
                return 7;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Resistance+VIII").Single()))
                return 8;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Resistance+IX").Single()))
                return 9;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Resistance+X").Single()))
                return 10;
            else
                return 0;
        }
        public int getBonusSpeed()
        {
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Speed+I").Single()))
                return 1;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Speed+II").Single()))
                return 2;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Speed+III").Single()))
                return 3;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Speed+IV").Single()))
                return 4;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Speed+V").Single()))
                return 5;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Speed+VI").Single()))
                return 6;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Speed+VII").Single()))
                return 7;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Speed+VIII").Single()))
                return 8;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Speed+IX").Single()))
                return 9;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Speed+X").Single()))
                return 10;
            else
                return 0;
        }
        public int getBonusSkill()
        {
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Skill+I").Single()))
                return 1;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Skill+II").Single()))
                return 2;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Skill+III").Single()))
                return 3;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Skill+IV").Single()))
                return 4;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Skill+V").Single()))
                return 5;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Skill+VI").Single()))
                return 6;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Skill+VII").Single()))
                return 7;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Skill+VIII").Single()))
                return 8;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Skill+IX").Single()))
                return 9;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Skill+X").Single()))
                return 10;
            else
                return 0;
        }
        public int getBonusLuck()
        {
            if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Luck+I").Single()))
                return 1;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Luck+II").Single()))
                return 2;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Luck+III").Single()))
                return 3;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Luck+IV").Single()))
                return 4;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Luck+V").Single()))
                return 5;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Luck+VI").Single()))
                return 6;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Luck+VII").Single()))
                return 7;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Luck+VIII").Single()))
                return 8;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Luck+IX").Single()))
                return 9;
            else if (WeaponPassives.Contains(WeaponPassives.Where(c => c.Name == "Luck+X").Single()))
                return 10;
            else
                return 0;
        }
    }
}
