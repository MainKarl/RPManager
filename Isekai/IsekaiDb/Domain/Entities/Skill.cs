using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IsekaiDb.Data.Enumerable;

namespace IsekaiDb.Domain.Entities
{
    public class Skill
    {
        public Guid SkillId { get; set; }
        public string Name { get; set; }

        public int Power { get; set; }
        public int PowerGain { get; set; }

        public int Accuracy { get; set; }
        public int AccuracyGain { get; set; }

        public int Crit { get; set; }
        public int CritGain { get; set; }

        public int ManaUsed { get; set; }

        // nav
        public ICollection<Passive> SkillPassives { get; set; }
        public ICollection<Character> CharacterSkill { get; set; }
        public SkillType Type { get; set; }
        public SkillPurpose Purpose { get; set; }
        public MagicType MagicType { get; set; }

        // function
        public string GetSkillType()
        {
            switch (Type) {
                case SkillType.MAGIC:
                    return "Magic";

                case SkillType.SPIRIT:
                    return "Spirit";

                case SkillType.OTHER:
                    return "Other";

                default:
                    return "";
            }
        }
        public string GetPurpose()
        {
            switch (Purpose) {
                case SkillPurpose.OFFENCE:
                    return "Offence";

                case SkillPurpose.OFFENCE_BOOST:
                    return "Offensive boost";

                case SkillPurpose.DEFENSE:
                    return "Defense";

                case SkillPurpose.SUPPORT:
                    return "Support";

                default:
                    return "";
            }
        }
        public string GetMagicType()
        {
            switch (MagicType) {
                case MagicType.PHYSICAL:
                    return "Physical";
                case MagicType.ILLUSION:
                    return "Illusion";
                case MagicType.MIND:
                    return "Mind";
                case MagicType.HEAT:
                    return "Heat";
                case MagicType.LAVA:
                    return "Lava";
                case MagicType.LIQUID:
                    return "Liquid";
                case MagicType.ICE:
                    return "Ice";
                case MagicType.WIND:
                    return "Wind";
                case MagicType.LIGHTNING:
                    return "Lightning";
                case MagicType.NATURE:
                    return "Nature";
                case MagicType.POISON:
                    return "Poison";
                case MagicType.HOLY:
                    return "Holy";
                case MagicType.SPACE:
                    return "Space";
                case MagicType.CURSE:
                    return "Curse";
                case MagicType.NECROMANCY:
                    return "Necromancy";
                case MagicType.CHAOS:
                    return "Chaos";
                case MagicType.CORRUPTED_HOLY:
                    return "Corrupted Holy";
                case MagicType.OTHER_WORLD:
                    return "Other World";
                case MagicType.SPATIAL_TIME:
                    return "Spatial Time";
                case MagicType.VOID:
                    return "Void";
                default:
                    return "";
            }
        }
        public bool isMagic() {
            if (Type == SkillType.MAGIC)
                return true;
            else
                return false;
        }
        public bool isBoost()
        {
            if (Purpose == SkillPurpose.OFFENCE_BOOST)
                return true;
            else
                return false;
        }
        public int penetration(int resistance) {
            int response = resistance;

            if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "ArmorPen-10").Single()))
                response = (int)(response * .9);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "ArmorPen-20").Single()))
                response = (int)(response * .80);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "ArmorPen-25").Single()))
                response = (int)(response * .75);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "ArmorPen-50").Single()))
                response = (int)(response * .5);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "ArmorPen-75").Single()))
                response = (int)(response * .25);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "ArmorPen-100").Single()) ||
                     (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "DefensePiercer").Single()) && !isMagic()) ||
                     (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "ResistancePiercer").Single())) && isMagic())
                response = 0;

            return response;
        }

        public void addStatus(Character enemy) {
            if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "Burn").Single()))
                enemy.addStatus(CharacterStatus.BURNED);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "Paralyze").Single()))
                enemy.addStatus(CharacterStatus.PARALYZED);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "Freeze").Single()))
                enemy.addStatus(CharacterStatus.FREEZE);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "Wet").Single()))
                enemy.addStatus(CharacterStatus.WET);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "Poison").Single()))
                enemy.addStatus(CharacterStatus.POISON);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "Petrify").Single()))
                enemy.addStatus(CharacterStatus.PETRIFIED);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "Curse-HP").Single()))
                enemy.addStatus(CharacterStatus.CURSE_HP);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "Curse-Strength").Single()))
                enemy.addStatus(CharacterStatus.CURSE_STRENGTH);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "Curse-Magic").Single()))
                enemy.addStatus(CharacterStatus.CURSE_MAGIC);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "Curse-Defense").Single()))
                enemy.addStatus(CharacterStatus.CURSE_DEFENSE);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "Curse-Resistance").Single()))
                enemy.addStatus(CharacterStatus.CURSE_RESISTANCE);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "Curse-Speed").Single()))
                enemy.addStatus(CharacterStatus.CURSE_SPEED);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "Curse-Skill").Single()))
                enemy.addStatus(CharacterStatus.CURSE_SKILL);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "Curse-Luck").Single()))
                enemy.addStatus(CharacterStatus.CURSE_LUCK);
            else if (SkillPassives.Contains(SkillPassives.Where(c => c.Name == "Curse-Spirit").Single()))
                enemy.addStatus(CharacterStatus.CURSE_SPIRIT);
        }

        public float getEffectivePassive(Character enemy) {
            float effective = 1;
            foreach (Passive passive in SkillPassives.ToList()) {
                if (passive.Name == "Armored-Eff" && enemy.Types.Contains(CharacterType.ARMORED))
                    effective *= 1.5f;
                else if (passive.Name == "Mounted-Eff" && enemy.Types.Contains(CharacterType.MOUNTED))
                    effective *= 1.5f;
                else if (passive.Name == "Flying-Eff" && enemy.Types.Contains(CharacterType.FLYING))
                    effective *= 1.5f;
                else if (passive.Name == "Beast-Eff" && enemy.Types.Contains(CharacterType.BEAST))
                    effective *= 1.5f;
                else if (passive.Name == "Dragon-Eff" && enemy.Types.Contains(CharacterType.DRAGONOID))
                    effective *= 1.5f;
                else if (passive.Name == "Void-Eff" && enemy.Types.Contains(CharacterType.VOID))
                    effective *= 1.5f;
                else if (passive.Name == "Undead-Eff" && enemy.Types.Contains(CharacterType.UNDEAD))
                    effective *= 1.5f;
                else if (passive.Name == "Demon-Eff" && enemy.Types.Contains(CharacterType.DEMONOID))
                    effective *= 1.5f;
                else if (passive.Name == "Monster-Eff" && enemy.Types.Contains(CharacterType.MONSTER))
                    effective *= 1.5f;
                else if (passive.Name == "Human-Eff" && enemy.Types.Contains(CharacterType.HUMANOID))
                    effective *= 1.5f;
            }

            return effective;
        }
        public float getEffectiveDamage(Character enemy) {
            float effective = 1;

            if ((MagicType == MagicType.LIGHTNING || MagicType == MagicType.WIND) && enemy.Types.Contains(CharacterType.FLYING))
                effective *= 1.5f;
            if ((MagicType == MagicType.CURSE || MagicType == MagicType.NECROMANCY) && enemy.Types.Contains(CharacterType.VOID))
                effective *= 1.5f;
            if ((MagicType == MagicType.CURSE || MagicType == MagicType.NECROMANCY) && enemy.Types.Contains(CharacterType.HOLY))
                effective /= 2;
            if (MagicType == MagicType.HOLY &&
                (enemy.Types.Contains(CharacterType.UNDEAD) || enemy.Types.Contains(CharacterType.UNDEAD) || enemy.Types.Contains(CharacterType.MONSTER) || enemy.Types.Contains(CharacterType.DEMONOID)))
                effective *= 1.5f;
            if (MagicType == MagicType.HOLY && enemy.Types.Contains(CharacterType.VOID))
                effective /= 2;
            if (MagicType == MagicType.VOID && enemy.Types.Contains(CharacterType.HOLY))
                effective *= 1.5f;
            if (MagicType == MagicType.VOID &&
                (enemy.Types.Contains(CharacterType.UNDEAD) || enemy.Types.Contains(CharacterType.UNDEAD) || enemy.Types.Contains(CharacterType.MONSTER) || enemy.Types.Contains(CharacterType.DEMONOID)))
                effective /= 2;
            if (MagicType == MagicType.PHYSICAL && enemy.Types.Contains(CharacterType.ARMORED))
                effective /= 1.5f;
            if (MagicType == MagicType.CHAOS && enemy.Types.Contains(CharacterType.HUMANOID))
                effective *= 1.5f;
            if (MagicType == MagicType.CORRUPTED_HOLY &&
                (enemy.Types.Contains(CharacterType.UNDEAD) || enemy.Types.Contains(CharacterType.UNDEAD) || enemy.Types.Contains(CharacterType.MONSTER) || enemy.Types.Contains(CharacterType.DEMONOID) || enemy.Types.Contains(CharacterType.HOLY)))
                effective *= 1.5f;

            return effective;
        }
        public float getEffective(Character enemy)
        {
            float effective = 0;
            effective += getEffectivePassive(enemy);
            effective += getEffectiveDamage(enemy);
            return effective;
        }
    }
}
