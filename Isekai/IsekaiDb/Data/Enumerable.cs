using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsekaiDb.Data {
    public class Enumerable {
        public enum CharacterType
        {
            HUMANOID,
            MONSTER,
            DEMONOID,
            UNDEAD,
            VOID,
            DRAGONOID,
            BEAST,
            ARMORED,
            MOUNTED,
            FLYING,
            HOLY
        };

        public enum WeaponType
        {
            ALL,
            SWORD,
            SPEAR,
            AXE,
            FIST,
            DAGGER,
            STAFF,
            BOW
        };

        public enum Level
        {
            BASIC,
            EXPERT,
            SAGE,
            DRAGON,
            GOD
        }

        public enum ClassSeries
        {
            MILITIA,
            FIGHTER,
            SKIRMISHER,
            BOWMAN,
            MEDIC,
            APPRENTICE,
            MONSTER,
            DEMON,
            BEASTMAN,
            DRAKELING
        }

        public enum PassiveType
        {
            ALL,
            WEAPON,
            ARMOR,
            CLASS,
            SKILL,
            OTHER
        }

        public enum SkillType
        {
            MAGIC,
            SPIRIT,
            OTHER
        }

        public enum SkillPurpose
        {
            OFFENCE,
            OFFENCE_BOOST,
            DEFENSE,
            SUPPORT
        }

        public enum WeaponRank
        {
            E,
            D,
            C,
            B,
            A,
            S
        }

        public enum MagicType
        {
            PHYSICAL,
            ILLUSION,
            MIND,
            LAVA,
            HEAT,
            LIQUID,
            ICE,
            LIGHTNING,
            WIND,
            NATURE,
            POISON,
            HOLY,
            SPACE,
            CURSE,
            NECROMANCY,
            CORRUPTED_HOLY,
            OTHER_WORLD,
            SPATIAL_TIME,
            CHAOS,
            VOID
        }

        public enum RaceType
        {
            HUMAN,
            ELF,
            DEMON,
            KITSUNE,
            WOLFSKIN,
            VOIDOID,
            UNDEAD,
            MONSTER
        }

        public enum CharacterStatus
        {
            BURNED,
            PARALYZED,
            FREEZE,
            WET,
            POISON,
            PETRIFIED,
            BLEEDING,

            CURSE_HP,
            CURSE_STRENGTH,
            CURSE_MAGIC,
            CURSE_DEFENSE,
            CURSE_RESISTANCE,
            CURSE_SPEED,
            CURSE_SKILL,
            CURSE_LUCK,
            CURSE_SPIRIT,

            BLESS_HP,
            BLESS_STRENGTH,
            BLESS_MAGIC,
            BLESS_DEFENSE,
            BLESS_RESISTANCE,
            BLESS_SPEED,
            BLESS_SKILL,
            BLESS_LUCK,
            BLESS_SPIRIT
        }

        public enum DamageType
        {
            PHYSICAL,
            ARCANE,
            FIRE,
            WATER,
            WIND,
            LIGHTNING,
            EARTH,
            HOLY,
            DARK
        }
    }
}
