using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsekaiDb.Data;
using IsekaiDb.Domain.User;
using IsekaiDb.Domain.Entities;
using static IsekaiDb.Data.Enumerable;
using System.Diagnostics.Tracing;

namespace IsekaiDb.Data
{
    public static class SeedExtension
    {
        private static readonly PasswordHasher<ApplicationUser> PASSWORD_HASHER = new();

        #region User
        private static ApplicationUser createUser(string userName, string email, string password)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = userName,
                NormalizedUserName = userName.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper()
            };
            user.PasswordHash = PASSWORD_HASHER.HashPassword(user, password);

            return user;
        }
        #endregion

        #region Role
        private static IdentityRole createRole(string name)
        { return new IdentityRole(name); }
        #endregion

        #region Passive
        private static Passive createPassive(string name, string description, PassiveType type)
        { return new Passive { PassiveId = Guid.NewGuid(), Name = name, Description = description, Type = type }; }
        #endregion

        #region Skill
        public static Skill createSkill(string name, int power, int powerGain, int accuracy, int accuracyGain, int crit, int critGain, int manaUsed, SkillType stype, SkillPurpose purpose, MagicType mtype)
        {
            return new Skill
            {
                SkillId = Guid.NewGuid(),
                Name = name,
                Power = power,
                PowerGain = powerGain,
                Accuracy = accuracy,
                AccuracyGain = accuracyGain,
                Crit = crit,
                CritGain = critGain,
                ManaUsed = manaUsed,
                Type = stype,
                Purpose = purpose,
                MagicType = mtype
            };
        }
        #endregion

        #region Armor
        public static Armor createArmor(string name, int power, List<Passive> passives, string path = "")
        {
            if (path != "")
                return new Armor(name, power, passives, path);
            else
                return new Armor(name, power, passives);
        }
        #endregion

        #region Weapon
        public static Weapon createWeapon(string name, int damage, int accuracy, float price, int crit, DamageType type, WeaponRank rank, WeaponType wtype, List<Passive> passives)
        {
            return new Weapon
            {
                WeaponId = Guid.NewGuid(),
                Name = name,
                Damage = damage,
                Accuracy = accuracy,
                Crit = crit,
                Price = price,
                DamageType = type,
                Rank = rank,
                Type = wtype,
                WeaponPassives = passives
            };
        }
        #endregion

        #region Class
        public static Class createClass(string name, int hp, int strength, int magic, int defense, int resistance, int speed, int skill, int luck, int spirit, ClassSeries serie, List<Passive> passives)
        {
            return new Class
            {
                ClassId = Guid.NewGuid(),
                Name = name,
                HPGrowth = hp,
                StrengthGrowth = strength,
                MagicGrowth = magic,
                DefenseGrowth = defense,
                ResistanceGrowth = resistance,
                SpeedGrowth = speed,
                SkillGrowth = skill,
                LuckGrowth = luck,
                SpiritGrowth = spirit,
                Serie = serie,
                ClassPassives = passives
            };
        }
        #endregion

        #region Character
        public static Character createCharacter(string name, int level, RaceType race,
                                                int HP, int Strength, int Magic, int Defense, int Resistance, int Speed, int Skill, int Luck, int Spirit,
                                                int HPG, int StrengthG, int MagicG, int DefenseG, int ResistanceG, int SpeedG, int SkillG, int LuckG, int SpiritG,
                                                Class classes, List<Skill> skills)
        {
            return new Character
            {
                CharacterId = Guid.NewGuid(),
                Name = name,
                Level = level,
                Race = race,
                Class = classes,
                CharacterSkill = skills,
                Types = new List<CharacterType>(),

                HP = HP,
                Strength = Strength,
                Magic = Magic,
                Defense = Defense,
                Resistance = Resistance,
                Speed = Speed,
                Skill = Skill,
                Luck = Luck,
                Spirit = Spirit,

                HPGrowth = HPG,
                StrengthGrowth = StrengthG,
                MagicGrowth = MagicG,
                DefenseGrowth = DefenseG,
                ResistanceGrowth = ResistanceG,
                SpeedGrowth = SpeedG,
                SkillGrowth = SkillG,
                LuckGrowth = LuckG,
                SpiritGrowth = SpiritG,

                ArcaneLevel = 0,
                IllusionLevel = 0,
                MindLevel = 0,
                FireLevel = 0,
                LavaLevel = 0,
                HeatLevel = 0,
                WaterLevel = 0,
                LiquidLevel = 0,
                IceLevel = 0,
                AirLevel = 0,
                LightningLevel = 0,
                WindLevel = 0,
                EarthLevel = 0,
                NatureLevel = 0,
                PoisonLevel = 0,
                LightLevel = 0,
                HolyLevel = 0,
                SpaceLevel = 0,
                DarkLevel = 0,
                CurseLevel = 0,
                NecromancyLevel = 0,

                Fist = WeaponRank.E,
                Sword = WeaponRank.E,
                Spear = WeaponRank.E,
                Axe = WeaponRank.E,
                Dagger = WeaponRank.E,
                Staff = WeaponRank.E,
                Bow = WeaponRank.E,

                StatRank = Level.BASIC,
                MagicRank = Level.BASIC,
                SpiritRank = Level.BASIC,
                Status = new List<CharacterStatus>()
            };
        }

        #endregion

        public static void Seed(this ModelBuilder builder)
        {
            List<IdentityRole> roles = new List<IdentityRole>
            {
                createRole("ADMINISTRATOR"),
                createRole("VISITOR")
            };

            builder.Entity<IdentityRole>().HasData(roles);

            List<ApplicationUser> users = new List<ApplicationUser>
            {
                createUser("Ardyn" , "lordardyn26@gmail.com", "bibba"),
                createUser("Guttenberg71", "remi-bellefleur71@gmail.com", "anus")
            };

            builder.Entity<ApplicationUser>().HasData(users);

            builder.Entity<IdentityUserRole<string>>().HasData(new List<IdentityUserRole<string>> {
                new IdentityUserRole<string> { UserId = users[0].Id, RoleId = roles[0].Id },
                new IdentityUserRole<string> { UserId = users[1].Id, RoleId = roles[1].Id }
            });
        }

        public static async Task Seed(IsekaiDbContext context)
        {
            #region Passive
            List<Passive> passives = new List<Passive>() {
                /* 0 */ createPassive("Cannot Crit", "The weapon cannot make critical hit", PassiveType.WEAPON),
                /* 1 */ createPassive("Two Attacks", "The weapon always attack two times", PassiveType.WEAPON),
                /* 2 */ createPassive("Magic Damage+I", "The weapon add 1 magic damage to the user", PassiveType.WEAPON),
                /* 3 */ createPassive("Magic Damage+II", "The weapon add 2 magic damage to the user", PassiveType.WEAPON),
                /* 4 */ createPassive("Magic Damage+III", "The weapon add 3 magic damage to the user", PassiveType.WEAPON),
                /* 5 */ createPassive("Magic Damage+IV", "The weapon add 4 magic damage to the user", PassiveType.WEAPON),
                /* 6 */ createPassive("Magic Damage+V", "The weapon add 5 magic damage to the user", PassiveType.WEAPON),
                /* 7 */ createPassive("Magic Damage+VI", "The weapon add 6 magic damage to the user", PassiveType.WEAPON),
                /* 8 */ createPassive("Magic Damage+VII", "The weapon add 7 magic damage to the user", PassiveType.WEAPON),
                /* 9 */ createPassive("Magic Damage+VIII", "The weapon add 8 magic damage to the user", PassiveType.WEAPON),
                /* 10 */ createPassive("Magic Damage+IX", "The weapon add 9 magic damage to the user", PassiveType.WEAPON),
                /* 11 */ createPassive("Magic Damage+X", "The weapon add 10 magic damage to the user", PassiveType.WEAPON),
                /* 12 */ createPassive("Strength+I", "The weapon give the user +1 strength", PassiveType.WEAPON),
                /* 13 */ createPassive("Strength+II", "The weapon give the user +2 strength", PassiveType.WEAPON),
                /* 14 */ createPassive("Strength+III", "The weapon give the user +3 strength", PassiveType.WEAPON),
                /* 15 */ createPassive("Strength+IV", "The weapon give the user +4 strength", PassiveType.WEAPON),
                /* 16 */ createPassive("Strength+V", "The weapon give the user +5 strength", PassiveType.WEAPON),
                /* 17 */ createPassive("Strength+VI", "The weapon give the user +6 strength", PassiveType.WEAPON),
                /* 18 */ createPassive("Strength+VII", "The weapon give the user +7 strength", PassiveType.WEAPON),
                /* 19 */ createPassive("Strength+VIII", "The weapon give the user +8 strength", PassiveType.WEAPON),
                /* 20 */ createPassive("Strength+IX", "The weapon give the user +9 strength", PassiveType.WEAPON),
                /* 21 */ createPassive("Strength+X", "The weapon give the user +10 strength", PassiveType.WEAPON),
                /* 22 */ createPassive("Magic+I", "The weapon give the user +1 magic", PassiveType.WEAPON),
                /* 23 */ createPassive("Magic+II", "The weapon give the user +2 magic", PassiveType.WEAPON),
                /* 24 */ createPassive("Magic+III", "The weapon give the user +3 magic", PassiveType.WEAPON),
                /* 25 */ createPassive("Magic+IV", "The weapon give the user +4 magic", PassiveType.WEAPON),
                /* 26 */ createPassive("Magic+V", "The weapon give the user +5 magic", PassiveType.WEAPON),
                /* 27 */ createPassive("Magic+VI", "The weapon give the user +6 magic", PassiveType.WEAPON),
                /* 28 */ createPassive("Magic+VII", "The weapon give the user +7 magic", PassiveType.WEAPON),
                /* 29 */ createPassive("Magic+VIII", "The weapon give the user +8 magic", PassiveType.WEAPON),
                /* 30 */ createPassive("Magic+IX", "The weapon give the user +9 magic", PassiveType.WEAPON),
                /* 31 */ createPassive("Magic+X", "The weapon give the user +10 magic", PassiveType.WEAPON),
                /* 32 */ createPassive("Defense+I", "The weapon give the user +1 defense", PassiveType.WEAPON), 
                /* 33 */ createPassive("Defense+II", "The weapon give the user +2 defense", PassiveType.WEAPON),
                /* 34 */ createPassive("Defense+III", "The weapon give the user +3 defense", PassiveType.WEAPON),
                /* 35 */ createPassive("Defense+IV", "The weapon give the user +4 defense", PassiveType.WEAPON),
                /* 36 */ createPassive("Defense+V", "The weapon give the user +5 defense", PassiveType.WEAPON),
                /* 37 */ createPassive("Defense+VI", "The weapon give the user +6 defense", PassiveType.WEAPON),
                /* 38 */ createPassive("Defense+VII", "The weapon give the user +7 defense", PassiveType.WEAPON),
                /* 39 */ createPassive("Defense+VIII", "The weapon give the user +8 defense", PassiveType.WEAPON),
                /* 40 */ createPassive("Defense+IX", "The weapon give the user +9 defense", PassiveType.WEAPON),
                /* 41 */ createPassive("Defense+X", "The weapon give the user +10 defense", PassiveType.WEAPON),
                /* 42 */ createPassive("Resistance+I", "The weapon give the user +1 resistance", PassiveType.WEAPON),
                /* 43 */ createPassive("Resistance+II", "The weapon give the user +2 resistance", PassiveType.WEAPON),
                /* 44 */ createPassive("Resistance+III", "The weapon give the user +3 resistance", PassiveType.WEAPON),
                /* 45 */ createPassive("Resistance+IV", "The weapon give the user +4 resistance", PassiveType.WEAPON),
                /* 46 */ createPassive("Resistance+V", "The weapon give the user +5 resistance", PassiveType.WEAPON),
                /* 47 */ createPassive("Resistance+VI", "The weapon give the user +6 resistance", PassiveType.WEAPON),
                /* 48 */ createPassive("Resistance+VII", "The weapon give the user +7 resistance", PassiveType.WEAPON),
                /* 49 */ createPassive("Resistance+VIII", "The weapon give the user +8 resistance", PassiveType.WEAPON),
                /* 50 */ createPassive("Resistance+IX", "The weapon give the user +9 resistance", PassiveType.WEAPON),
                /* 51 */ createPassive("Resistance+X", "The weapon give the user +10 resistance", PassiveType.WEAPON),
                /* 52 */ createPassive("Speed+I", "The weapon give the user +1 speed", PassiveType.WEAPON),
                /* 53 */ createPassive("Speed+II", "The weapon give the user +2 speed", PassiveType.WEAPON),
                /* 54 */ createPassive("Speed+III", "The weapon give the user +3 speed", PassiveType.WEAPON),
                /* 55 */ createPassive("Speed+IV", "The weapon give the user +4 speed", PassiveType.WEAPON),
                /* 56 */ createPassive("Speed+V", "The weapon give the user +5 speed", PassiveType.WEAPON),
                /* 57 */ createPassive("Speed+VI", "The weapon give the user +6 speed", PassiveType.WEAPON),
                /* 58 */ createPassive("Speed+VII", "The weapon give the user +7 speed", PassiveType.WEAPON),
                /* 59 */ createPassive("Speed+VIII", "The weapon give the user +8 speed", PassiveType.WEAPON),
                /* 60 */ createPassive("Speed+IX", "The weapon give the user +9 speed", PassiveType.WEAPON),
                /* 61 */ createPassive("Speed+X", "The weapon give the user +10 speed", PassiveType.WEAPON),
                /* 62 */ createPassive("Skill+I", "The weapon give the user +1 skill", PassiveType.WEAPON),
                /* 63 */ createPassive("Skill+II", "The weapon give the user +2 skill", PassiveType.WEAPON),
                /* 64 */ createPassive("Skill+III", "The weapon give the user +3 skill", PassiveType.WEAPON),
                /* 65 */ createPassive("Skill+IV", "The weapon give the user +4 skill", PassiveType.WEAPON),
                /* 66 */ createPassive("Skill+V", "The weapon give the user +5 skill", PassiveType.WEAPON),
                /* 67 */ createPassive("Skill+VI", "The weapon give the user +6 skill", PassiveType.WEAPON),
                /* 68 */ createPassive("Skill+VII", "The weapon give the user +7 skill", PassiveType.WEAPON),
                /* 69 */ createPassive("Skill+VIII", "The weapon give the user +8 skill", PassiveType.WEAPON),
                /* 70 */ createPassive("Skill+IX", "The weapon give the user +9 skill", PassiveType.WEAPON),
                /* 71 */ createPassive("Skill+X", "The weapon give the user +10 skill", PassiveType.WEAPON),
                /* 72 */ createPassive("Luck+I", "The weapon give the user +1 luck", PassiveType.WEAPON),
                /* 73 */ createPassive("Luck+II", "The weapon give the user +2 luck", PassiveType.WEAPON),
                /* 74 */ createPassive("Luck+III", "The weapon give the user +3 luck", PassiveType.WEAPON),
                /* 75 */ createPassive("Luck+IV", "The weapon give the user +4 luck", PassiveType.WEAPON),
                /* 76 */ createPassive("Luck+V", "The weapon give the user +5 luck", PassiveType.WEAPON),
                /* 77 */ createPassive("Luck+VI", "The weapon give the user +6 luck", PassiveType.WEAPON),
                /* 78 */ createPassive("Luck+VII", "The weapon give the user +7 luck", PassiveType.WEAPON),
                /* 79 */ createPassive("Luck+VIII", "The weapon give the user +8 luck", PassiveType.WEAPON),
                /* 80 */ createPassive("Luck+IX", "The weapon give the user +9 luck", PassiveType.WEAPON),
                /* 81 */ createPassive("Luck+X", "The weapon give the user +10 luck", PassiveType.WEAPON),
                /* 82 */ createPassive("Effective agains't Armored", "The weapon is effective agains't armored characters", PassiveType.WEAPON),
                /* 83 */ createPassive("Effective agains't Flying", "The weapon is effective agains't flying characters", PassiveType.WEAPON),
                /* 84 */ createPassive("Effective agains't Mounted", "The weapon is effective agains't mounted characters", PassiveType.WEAPON),
                /* 85 */ createPassive("Effective agains't Beast", "The weapon is effective agains't beast characters", PassiveType.WEAPON),
                /* 86 */ createPassive("Effective agains't Dragon", "The weapon is effective agains't dragon characters", PassiveType.WEAPON),
                /* 87 */ createPassive("Effective agains't Void", "The weapon is effective agains't void characters", PassiveType.WEAPON),
                /* 88 */ createPassive("Effective agains't Undead", "The weapon is effective agains't undead characters", PassiveType.WEAPON),
                /* 89 */ createPassive("Effective agains't Demon", "The weapon is effective agains't demon characters", PassiveType.WEAPON),
                /* 90 */ createPassive("Effective agains't Monster", "The weapon is effective agains't monster characters", PassiveType.WEAPON),
                /* 91 */ createPassive("Effective agains't Human", "The weapon is effective agains't humain characters", PassiveType.WEAPON),
                /* 92 */ createPassive("50% Lifesteal", "The weapon has a permanent 50% lifesteal on the damage it does", PassiveType.WEAPON),
                /* 93 */ createPassive("100% Lifesteal", "The weapon has a permanent 100% lifesteal on the damage it does", PassiveType.WEAPON),
                /* 94 */ createPassive("50% Crit Lifesteal", "The weapon has a permanent 50% lifesteal on the crit damage it does", PassiveType.WEAPON),
                /* 95 */ createPassive("100% Crit Lifesteal", "The weapon has a permanent 100% lifesteal on the crit damage it does", PassiveType.WEAPON),
                /* 96 */ createPassive("Magical Weapon", "The weapon scale on Magic and does damage to Resistance stats", PassiveType.WEAPON),

                /* 97 */ createPassive("Defense+I", "The armor give the user +1 defense", PassiveType.ARMOR),
                /* 98 */ createPassive("Defense+II", "The armor give the user +2 defense", PassiveType.ARMOR),
                /* 99 */ createPassive("Defense+III", "The armor give the user +3 defense", PassiveType.ARMOR),
                /* 100 */ createPassive("Defense+IV", "The armor give the user +4 defense", PassiveType.ARMOR),
                /* 101 */ createPassive("Defense+V", "The armor give the user +5 defense", PassiveType.ARMOR),
                /* 102 */ createPassive("Defense+VI", "The armor give the user +6 defense", PassiveType.ARMOR),
                /* 103 */ createPassive("Defense+VII", "The armor give the user +7 defense", PassiveType.ARMOR),
                /* 104 */ createPassive("Defense+VIII", "The armor give the user +8 defense", PassiveType.ARMOR),
                /* 105 */ createPassive("Defense+IX", "The armor give the user +9 defense", PassiveType.ARMOR),
                /* 106 */ createPassive("Defense+X", "The armor give the user +10 defense", PassiveType.ARMOR),
                /* 107 */ createPassive("Resistance+I", "The armor give the user +1 resistance", PassiveType.ARMOR),
                /* 108 */ createPassive("Resistance+II", "The armor give the user +2 resistance", PassiveType.ARMOR),
                /* 109 */ createPassive("Resistance+III", "The armor give the user +3 resistance", PassiveType.ARMOR),
                /* 110 */ createPassive("Resistance+IV", "The armor give the user +4 resistance", PassiveType.ARMOR),
                /* 111 */ createPassive("Resistance+V", "The armor give the user +5 resistance", PassiveType.ARMOR),
                /* 112 */ createPassive("Resistance+VI", "The armor give the user +6 resistance", PassiveType.ARMOR),
                /* 113 */ createPassive("Resistance+VII", "The armor give the user +7 resistance", PassiveType.ARMOR),
                /* 114 */ createPassive("Resistance+VIII", "The armor give the user +8 resistance", PassiveType.ARMOR),
                /* 115 */ createPassive("Resistance+IX", "The armor give the user +9 resistance", PassiveType.ARMOR),
                /* 116 */ createPassive("Resistance+X", "The armor give the user +10 resistance", PassiveType.ARMOR),
                /* 117 */ createPassive("Speed-I", "The armor give the user -1 speed", PassiveType.ARMOR),
                /* 118 */ createPassive("Speed-II", "The armor give the user -2 speed", PassiveType.ARMOR),
                /* 119 */ createPassive("Speed-III", "The armor give the user -3 speed", PassiveType.ARMOR),
                /* 120 */ createPassive("Speed-IV", "The armor give the user -4 speed", PassiveType.ARMOR),
                /* 121 */ createPassive("Speed-V", "The armor give the user -5 speed", PassiveType.ARMOR),
                /* 122 */ createPassive("Speed-VI", "The armor give the user -6 speed", PassiveType.ARMOR),
                /* 123 */ createPassive("Speed-VII", "The armor give the user -7 speed", PassiveType.ARMOR),
                /* 124 */ createPassive("Speed-VIII", "The armor give the user -8 speed", PassiveType.ARMOR),
                /* 125 */ createPassive("Speed-IX", "The armor give the user -9 speed", PassiveType.ARMOR),
                /* 126 */ createPassive("Speed-X", "The armor give the user -10 speed", PassiveType.ARMOR),

                /* 127 */ createPassive("Seal Defense", "After a attack, enemy defense is reduced", PassiveType.CLASS),
                /* 128 */ createPassive("Defense+II", "The character defense is increased by 2", PassiveType.CLASS),
                /* 129 */ createPassive("Strength+II", "The character strength is increased by 2", PassiveType.CLASS),
                /* 130 */ createPassive("Gamble", "Hit -5, Crit Rate +10", PassiveType.CLASS),
                /* 131 */ createPassive("Perfect Attack", "[Skill/2] The attack is 1.25 time stronger", PassiveType.CLASS),
                /* 132 */ createPassive("Skill+II", "The character skill is increased by 2", PassiveType.CLASS),
                /* 133 */ createPassive("Ranged", "+1 Damage per tile away", PassiveType.CLASS),
                /* 134 */ createPassive("Resistance+II", "The character resistance is increased by 2", PassiveType.CLASS),
                /* 135 */ createPassive("Holy Proficiency", "The character holy proficiency is increased by 10", PassiveType.CLASS),
                /* 136 */ createPassive("Magic Proficiency", "The character magic proficiency is increased by 5", PassiveType.CLASS),
                /* 137 */ createPassive("Magic+II", "The character magic is increased by 2", PassiveType.CLASS),
                /* 138 */ createPassive("Aptitude", "The character stat growth rate is increased by 10%", PassiveType.CLASS),
                /* 139 */ createPassive("Underdog", "If the enemy level is higher than the character, hit/avoid is increased by 10", PassiveType.CLASS),
                /* 140 */ createPassive("Creature of Magic", "The character's mana is double", PassiveType.CLASS),
                /* 141 */ createPassive("Magic Control", "The user can control the surrounding magicules", PassiveType.CLASS),
                /* 142 */ createPassive("Nocture Creature", "If it is night, hit/avoid is increased by 10", PassiveType.CLASS),
                /* 143 */ createPassive("Hunter", "The character recover 10% HP when finishing a enemy", PassiveType.CLASS),
                /* 144 */ createPassive("Magic Affinity", "The character magic proficiency is boosted by 25", PassiveType.CLASS),
                /* 145 */ createPassive("Fly Mobility", "The character avoid is increased by 15", PassiveType.CLASS),
                /* 146 */ createPassive("Great Armor", "The character damage taken is reduced by 4", PassiveType.CLASS),
                /* 147 */ createPassive("Patience", "Doing nothing grant the character defense", PassiveType.CLASS),
                /* 148 */ createPassive("Mounted Soldier", "The character speed is increase", PassiveType.CLASS),
                /* 149 */ createPassive("Elbow Room", "The character damage is increased by 3 when fighting outdoors", PassiveType.CLASS),
                /* 150 */ createPassive("Inspiring", "Increase Hit/Avoid of ally", PassiveType.CLASS),
                /* 151 */ createPassive("All Seeing-Eye", "The character can see the stats of others", PassiveType.CLASS),
                /* 152 */ createPassive("Seal Strength", "After a attack, the enemy strength is reduced", PassiveType.CLASS),
                /* 153 */ createPassive("Mount Bane", "The character damage is increased by 5 when attacking a mounted enemy", PassiveType.CLASS),
                /* 154 */ createPassive("Outdoor Fighter", "The character hit/avoid is increase by 20 when fighting outdoors", PassiveType.CLASS),
                /* 155 */ createPassive("Great Movement", "The character can move after a attack", PassiveType.CLASS),
                /* 156 */ createPassive("Zeal", "The character crit rate is increase by 5", PassiveType.CLASS),
                /* 157 */ createPassive("Enrage", "The character crit rate is increase by 10 when he has less than 50% HP", PassiveType.CLASS),
                /* 158 */ createPassive("Swordfaire", "The character damage is incerase by 5 when using a sword", PassiveType.CLASS),
                /* 159 */ createPassive("Duelist Blow", "The character avoid is increase by 10 when initiating a battle", PassiveType.CLASS),
                /* 160 */ createPassive("Steal", "The character can steal easily another character", PassiveType.CLASS),
                /* 161 */ createPassive("Shadow Step", "The character's step is soundless", PassiveType.CLASS),
                /* 162 */ createPassive("Avoid+X", "The character avoid is increase by 10", PassiveType.CLASS),
                /* 163 */ createPassive("No Honor", "The character hit is increase by 15", PassiveType.CLASS),
                /* 164 */ createPassive("Bowfaire", "The character damage is increased by 5 when using a bow/crossbow", PassiveType.CLASS),
                /* 165 */ createPassive("Prescience", "The character hit/crit rate is increase by 10 when initiating a fight", PassiveType.CLASS),
                /* 166 */ createPassive("Quick Draw", "The character damage is increase by 4 when initiating a fight", PassiveType.CLASS),
                /* 167 */ createPassive("Fly Breaker", "The character hit is increase by 30 and avoid is increased by 10 when attacking a flying character", PassiveType.CLASS),
                /* 168 */ createPassive("Holy Mage", "The character holy proficiency is increased by 25", PassiveType.CLASS),
                /* 169 */ createPassive("Live to Serve", "The character  recover the same amount of healing when healing", PassiveType.CLASS),
                /* 170 */ createPassive("Heartseeker", "The enemy's avoid is reduced by 20 when close to the character", PassiveType.CLASS),
                /* 171 */ createPassive("Malefic Aura", "The enemy take 2 more damage when close to the character", PassiveType.CLASS),
                /* 172 */ createPassive("Heroic Deeds", "The character defense and resistance is increased after healing someone", PassiveType.CLASS),
                /* 173 */ createPassive("Mounted Healer", "The character can move after healing", PassiveType.CLASS),
                /* 174 */ createPassive("Magic Sense", "The character can sense magicules around himself", PassiveType.CLASS),
                /* 175 */ createPassive("Arcane Mastery", "The character arcane proficiency is increased by 25", PassiveType.CLASS),
                /* 176 */ createPassive("Seal Magic", "After a attack, the enemy's magic is reduced", PassiveType.CLASS),
                /* 177 */ createPassive("Magic Breaker", "The character hit and avoid is increased when fighting a magic user", PassiveType.CLASS),
                /* 178 */ createPassive("Elemental Mage", "The character elemental proficiency is increased by 25", PassiveType.CLASS),
                /* 179 */ createPassive("Future Sight", "The character have vision of the near future", PassiveType.CLASS),
                /* 180 */ createPassive("Mind Master", "The character mind proficiency is increased by 100", PassiveType.CLASS),
                /* 181 */ createPassive("Life Drain", "The character gain 10% HP after a attack", PassiveType.CLASS),
                /* 182 */ createPassive("The Death", "The character is immune to Poison attack", PassiveType.CLASS),
                /* 183 */ createPassive("Dead Creature", "The character hit and avoid is increased by 10 agains't void and reduced by 10 agains't holy", PassiveType.CLASS),
                /* 184 */ createPassive("Void Mastery", "The character gain access to void magic", PassiveType.CLASS),
                /* 185 */ createPassive("Creature of the Void", "The character hit and avoid is increased by 10 agains't holy and reduced by 10 agains't dark", PassiveType.CLASS),
                /* 186 */ createPassive("Magic Overload", "The character has control of his own magicules perfectly", PassiveType.CLASS),
                /* 187 */ createPassive("All rounder Mage", "The character magic proficiency is increased by 25", PassiveType.CLASS),
                /* 188 */ createPassive("Ancient Resistance", "The character has resistance of magic", PassiveType.CLASS),
                /* 189 */ createPassive("Seal Stat", "After a attack, the enemy's stats are reduced", PassiveType.CLASS),
                /* 190 */ createPassive("Strength+III", "The character's strength is increased by 3", PassiveType.CLASS),
                /* 191 */ createPassive("Fire Mastery", "The character fire proficiency is increased by 50", PassiveType.CLASS),
                /* 192 */ createPassive("Wolf Transformation", "The character can transform into a wolf", PassiveType.CLASS),
                /* 193 */ createPassive("Beastbane", "The character deals effective damage agains't beast character", PassiveType.CLASS),
                /* 194 */ createPassive("Fox Transformation", "The character can transform into a fox", PassiveType.CLASS),
                /* 195 */ createPassive("Draconic Gift", "The character stats are increase by 2", PassiveType.CLASS),
                /* 196 */ createPassive("Wrymsbane", "The character deals effective damage agains't dragonoid character", PassiveType.CLASS),
                /* 197 */ createPassive("Armored Blow", "The character damage taken is reduced by 10", PassiveType.CLASS),
                /* 198 */ createPassive("Wary Fighter", "the ability to double attack is impossible for the user and the enemy", PassiveType.CLASS),
                /* 199 */ createPassive("Heavy Blade", "The character strength is increased by 3 but his speed is reduced by 1", PassiveType.CLASS),
                /* 200 */ createPassive("Strengthtaker", "The character gain strength after attacking", PassiveType.CLASS),
                /* 201 */ createPassive("Protector", "The character gain defense and resistance when close to ally", PassiveType.CLASS),
                /* 202 */ createPassive("Luna", "[Skill] The attack negate enemy's defense and resistance", PassiveType.CLASS),
                /* 203 */ createPassive("Lunge", "The character switch places with his enemy after attacking", PassiveType.CLASS),
                /* 204 */ createPassive("Swordbreaker", "The character's hit and avoid is increased by 50 agains't sword", PassiveType.CLASS),
                /* 205 */ createPassive("Good Instruction", "The ally have their defense and resistance increased", PassiveType.CLASS),
                /* 206 */ createPassive("Perfect Execution", "The ally have their strength and magic increased", PassiveType.CLASS),
                /* 207 */ createPassive("Exemple", "The character's hit rate is increased by 10", PassiveType.CLASS),
                /* 208 */ createPassive("Inspiration", "The ally have their hit and avoid increased by 15", PassiveType.CLASS),
                /* 209 */ createPassive("Lancefaire", "The character's damage is increased by 5 when using a spear", PassiveType.CLASS),
                /* 210 */ createPassive("Seal Speed", "The character gain speed after attacking", PassiveType.CLASS),
                /* 211 */ createPassive("Air Superiority", "The character's hit and avoid is increased by 30 when fighting flying character", PassiveType.CLASS),
                /* 212 */ createPassive("Aggressor", "The character's damage is increased by 10 when initiating the fight", PassiveType.CLASS),
                /* 213 */ createPassive("Sword Breaker", "The character's hit and avoid is increased by 50 agains't a sword", PassiveType.CLASS),
                /* 214 */ createPassive("Focus", "The character crit rate is increased by 10 when alone", PassiveType.CLASS),
                /* 215 */ createPassive("Speedtaker", "The character gain speed is increased when attacking", PassiveType.CLASS),
                /* 216 */ createPassive("Bond", "The character restore 10 HP when close to allies", PassiveType.CLASS),
                /* 217 */ createPassive("Savage Blow", "After a attack, the enemy's HP is reduced", PassiveType.CLASS),
                /* 218 */ createPassive("Axefaire", "The character's damage is increased by 5 when using a axe", PassiveType.CLASS),
                /* 219 */ createPassive("Aether", "[Skill/2] The attack use Sol and Luna", PassiveType.CLASS),
                /* 220 */ createPassive("Slayer", "The character's hit and avoid is increased by 15 agains't non-human", PassiveType.CLASS),
                /* 221 */ createPassive("Raikiri", "[Skill] The attack is 1.5 time stronger", PassiveType.CLASS),
                /* 222 */ createPassive("Astra", "[Skill/2] The character do 5 consecutive attack at 75% Power", PassiveType.CLASS),
                /* 223 */ createPassive("Vantage", "The character always attack first", PassiveType.CLASS),
                /* 224 */ createPassive("Life and Death", "The damage the character does and takes is increased by 10", PassiveType.CLASS),
                /* 225 */ createPassive("Dancing Blade", "The character speed is increased by 3, but his defense is reduced by 1", PassiveType.CLASS),
                /* 226 */ createPassive("Parry", "[Skill/3] The character resend the damage to the enemy", PassiveType.CLASS),
                /* 227 */ createPassive("Lethality", "[Skill/4] The character one shot the enemy", PassiveType.CLASS),
                /* 228 */ createPassive("Pass", "The character can pass through enemy and ally", PassiveType.CLASS),
                /* 229 */ createPassive("Duelist", "The character and enemy skill activation is increase by 15", PassiveType.CLASS),
                /* 230 */ createPassive("Sol", "[Skill] The attack restore HP to the character", PassiveType.CLASS),
                /* 231 */ createPassive("Poison Weapon", "The weapon of the character does 5% max HP to the enemy", PassiveType.CLASS),
                /* 232 */ createPassive("Galeforce", "After killing a enemy, the character can act again", PassiveType.CLASS),
                /* 233 */ createPassive("Great Bow", "The character's range is increased by 1", PassiveType.CLASS),
                /* 234 */ createPassive("Beast Killer", "The character's hit and avoid is increased by 25 agains't mounted character", PassiveType.CLASS),
                /* 235 */ createPassive("Quick Burn", "The character's hit and avoid is increased by 15", PassiveType.CLASS),
                /* 236 */ createPassive("No Mercy", "The character damage is increased by 15 agains't lower leveled enemy", PassiveType.CLASS),
                /* 237 */ createPassive("Certain Blow", "The character's hit is increased by 40 when initiating", PassiveType.CLASS),
                /* 238 */ createPassive("Ultra Bowfaire", "The character's damage is increased by 10 when using a bow/crossbow", PassiveType.CLASS),
                /* 239 */ createPassive("Movement+I", "The character's movement is increased by 1", PassiveType.CLASS),
                /* 240 */ createPassive("Dagger Breaker", "The character's hit and avoid is increased by 50 when attacking a dagger", PassiveType.CLASS),
                /* 241 */ createPassive("Creature of Light", "The character's light proficiency is increased by 25", PassiveType.CLASS),
                /* 242 */ createPassive("Miracle", "[Luck] The character survive a fatal blow at 1 HP", PassiveType.CLASS),
                /* 243 */ createPassive("Witch Hunt", "The character's damage is increased by 1 for each Dark proficiency the enemy has", PassiveType.CLASS),
                /* 244 */ createPassive("Holy Crusade", "The character's damage is increased by 20 agains't monster and demon", PassiveType.CLASS),
                /* 245 */ createPassive("Sorcery", "The character's curse magic proficiency is increased by 50", PassiveType.CLASS),
                /* 246 */ createPassive("Lifetaker", "[Luck] The character gain half the damage dealt as HP", PassiveType.CLASS),
                /* 247 */ createPassive("Darkness", "The character's dark magic proficiency is increased by 50", PassiveType.CLASS),
                /* 248 */ createPassive("Malevolent Prayer", "The character can summon dark entities", PassiveType.CLASS),
                /* 249 */ createPassive("Veteran Intuition", "The character's crit avoid is increased by 15", PassiveType.CLASS),
                /* 250 */ createPassive("Angel's Blessing", "The character's hit and avoid is increased by 1 for each Dark proficiency the enemy has", PassiveType.CLASS),
                /* 251 */ createPassive("Relief", "The character recover 20% HP if no one is close", PassiveType.CLASS),
                /* 252 */ createPassive("Warding Blow", "The character's magic damage taken is reduced by 10 when initiating", PassiveType.CLASS),
                /* 253 */ createPassive("Arcane Control", "The character can take control over other people's arcane spell", PassiveType.CLASS),
                /* 254 */ createPassive("Arcane Burst", "[Skill] The character add Magic to the damage dealt", PassiveType.CLASS),
                /* 255 */ createPassive("Illusion Master", "The character's illusion magic proficiency is increased by 100", PassiveType.CLASS),
                /* 256 */ createPassive("Protected Dream", "The character is immune to illusion magic", PassiveType.CLASS),
                /* 257 */ createPassive("Aeromancy", "The character's air magic proficiency is increased by 60", PassiveType.CLASS),
                /* 258 */ createPassive("Aegis", "[Skill] The character take half the magic damage", PassiveType.CLASS),
                /* 259 */ createPassive("Hydromancy", "The character's water magic proficiency is increased by 60", PassiveType.CLASS),
                /* 260 */ createPassive("Pavise", "[Skill] The character take half the physical damage", PassiveType.CLASS),
                /* 261 */ createPassive("Pyromancy", "The character's fire magic proficiency is increased by 60", PassiveType.CLASS),
                /* 262 */ createPassive("Body of Fire", "The character's magic damage is increased by 5 when his HP is full", PassiveType.CLASS),
                /* 263 */ createPassive("Geomancy", "The character's earth magic proficiency is increased by 60", PassiveType.CLASS),
                /* 264 */ createPassive("Nature's Blessing", "The character's restore 20% HP if he wait", PassiveType.CLASS),
                /* 265 */ createPassive("Conquest", "The character is immune to effective attack agains't him", PassiveType.CLASS),
                /* 266 */ createPassive("King of Blood Giovanni", "The character's curse and mind magic proficiency is increased by 100, he his immune to curse and mind magic", PassiveType.CLASS),
                /* 267 */ createPassive("Magic User", "The character's arcane and dark magic proficiency is increased by 30", PassiveType.CLASS),
                /* 268 */ createPassive("Lifetaking", "The character recover 50% HP when he kills a enemy", PassiveType.CLASS),
                /* 269 */ createPassive("Reminiscence of Battle", "[Skill/2] The character make a attack effective", PassiveType.CLASS),
                /* 270 */ createPassive("Instinct of Survival", "[Luck] The character dodge a attack", PassiveType.CLASS),
                /* 271 */ createPassive("Ghost Body", "The character can pass through walls and others", PassiveType.CLASS),
                /* 272 */ createPassive("Untouchable", "The character's avoid is increased by 50", PassiveType.CLASS),
                /* 273 */ createPassive("Fear of the Void", "After a attack, the enemy's hit and avoid is reduced", PassiveType.CLASS),
                /* 274 */ createPassive("Fistfaire", "The character's damage is increased by 10 when using fist", PassiveType.CLASS),
                /* 275 */ createPassive("Voidmancy", "The character gain absolute control over void magic", PassiveType.CLASS),
                /* 276 */ createPassive("Vengeance", "Add half the user lost HP to the character's damage", PassiveType.CLASS),
                /* 277 */ createPassive("Lord of Wisdow Azathoth", "The character knows everything", PassiveType.CLASS),
                /* 278 */ createPassive("God of Magic Asha", "The character's crit rate is increased by 15 when using magic, the crit damage is triple for magic", PassiveType.CLASS),
                /* 279 */ createPassive("Merciless", "The character can instantly kill any enemy who doesn't have the will to fight", PassiveType.CLASS),
                /* 280 */ createPassive("Lord of Pride Lucifer", "The character can copy other people passive, skill and magic", PassiveType.CLASS),
                /* 281 */ createPassive("Lord of Tempter Azazel", "The character can dominate and control the mind of the weak", PassiveType.CLASS),
                /* 282 */ createPassive("Reality Domination", "The character can send people into his imaginary world and this reality can affect the reality", PassiveType.CLASS),
                /* 283 */ createPassive("God of Chaos Urgash", "The strength and magic of the character is double, the character gain access to chaos magic", PassiveType.CLASS),
                /* 284 */ createPassive("Primordial Chaos", "The character is immune to dark magic, the character's dark magic proficiency is increased by 150", PassiveType.CLASS),
                /* 285 */ createPassive("Rightful Lord", "The character's skill activation is increased by 10", PassiveType.CLASS),
                /* 286 */ createPassive("Ignis", "[Skill/2] Add half Strength and Magic to the damage dealt", PassiveType.CLASS),
                /* 287 */ createPassive("Destroyer of World", "The character's strength is increased when full health", PassiveType.CLASS),
                /* 288 */ createPassive("Demonic Luck", "The character's crit damage is 1.5 time stronger when full health", PassiveType.CLASS),
                /* 289 */ createPassive("Werewolf Transformation", "The character can transform into a werewolf", PassiveType.CLASS),
                /* 290 */ createPassive("Grisly Wound", "The enemy's HP is reduced by 20% after combat", PassiveType.CLASS),
                /* 291 */ createPassive("Nine-Tails Transformation", "The character can transform into a nine-tails", PassiveType.CLASS),
                /* 292 */ createPassive("Defensive Scale", "The character is resistant to physical damage", PassiveType.CLASS),
                /* 293 */ createPassive("Trample", "The character's damage is increased by 5 if the enemy is not mounted", PassiveType.CLASS),
                /* 294 */ createPassive("Dark Artist", "The character's dark magic proficiency by 80", PassiveType.CLASS),
                /* 295 */ createPassive("Soulless", "The character is immune to mind magic", PassiveType.CLASS),
                /* 296 */ createPassive("Necromancy", "The character's necromancy magic proficiency is increased by 100, and his dark magic proficiency by 50", PassiveType.CLASS),
                /* 297 */ createPassive("Dark Art Protection", "The character is resistant to dark magic", PassiveType.CLASS),
                /* 298 */ createPassive("Death's Touch", "[Skill/3] The character release 50% of the enemy HP", PassiveType.CLASS),
                /* 299 */ createPassive("Magic Armor", "The character is resistant to magic damage", PassiveType.CLASS),
                /* 300 */ createPassive("Magic Mastery", "The character's magic proficiency is increased by 100", PassiveType.CLASS),
                /* 301 */ createPassive("Draconic Ancestry", "The character mana is triple", PassiveType.CLASS),

                /* 302 */ createPassive("Lord of Despair Abaddon", "The character have access to infinite magicules", PassiveType.OTHER),
                /* 303 */ createPassive("God of Justice Elrath", "The character have divine might when fighting to what the character consider right", PassiveType.OTHER),
                /* 304 */ createPassive("God of Nature Sylvanna", "The character cab create and use the nature as he please", PassiveType.OTHER),
                /* 305 */ createPassive("Ascended God of Humanity Arkath", "The character's stat growth rate are increased by 100", PassiveType.OTHER),
                /* 306 */ createPassive("Forgotten God Ylath", "The character gain access to forbidden magic", PassiveType.OTHER),
                /* 307 */ createPassive("Goddess of Success Elira", "The character have divine luck", PassiveType.OTHER),
                /* 308 */ createPassive("God of Hope Sariel", "The character never loss hope", PassiveType.OTHER),
                /* 309 */ createPassive("God of Happiness Saraphiel", "The character have divine protection", PassiveType.OTHER),
                /* 310 */ createPassive("Hero of Heroes Godric", "The character have divine might agains't demon and monster", PassiveType.OTHER),
                /* 311 */ createPassive("God-Slayer Yuuki", "The character ignore divine protection and resistant", PassiveType.OTHER),
                /* 312 */ createPassive("Limit-Breaker Yami", "The character have unlimited stamina, limit break is less dangerous for him", PassiveType.OTHER),
                /* 313 */ createPassive("Conqueror of Space-Time Gehrman", "The character gain access to time & space magic", PassiveType.OTHER),
                /* 314 */ createPassive("Magicless Asta", "The character don't have magicules, his strength is limitless (Strength growth +200)", PassiveType.OTHER),
                /* 315 */ createPassive("Great Liberator Xeno", "The character have divine might agains't humanoid", PassiveType.OTHER),
                /* 316 */ createPassive("Supreme Nine-Tails Kurama", "The character have control over every magicules that exists", PassiveType.OTHER),
                /* 317 */ createPassive("Supreme Wolfssegner Keaton", "The character can control very Wolfssegner that exists", PassiveType.OTHER),
                /* 318 */ createPassive("True Dragon of Wrath Arthan", "The character's crit rate is increased by 15, his crit damage is triple", PassiveType.OTHER),
                /* 319 */ createPassive("True Dragon of Weather Silvanus", "The character gain access to weather manipulation", PassiveType.OTHER),
                /* 320 */ createPassive("True Dragon of Skill Yuimoji", "The character's talent are limitless", PassiveType.OTHER),
                /* 321 */ createPassive("True Dragon of Power Byleth", "The character's attack ignore defense and resistance", PassiveType.OTHER),
                /* 322 */ createPassive("True Dragon of Existance Corrin", "The character gain access to existance manipulation", PassiveType.OTHER),
                /* 323 */ createPassive("True Dragon of Fate Nantharu", "The character gain access to law manipulation", PassiveType.OTHER),
                /* 324 */ createPassive("True Dragon of Faith Rhea", "The character's stats are double is someone believe in him", PassiveType.OTHER),
                /* 325 */ createPassive("Creator of Skills Tirmis", "The character is immune to active", PassiveType.OTHER),
                /* 326 */ createPassive("Great Corruption Ythil", "The character is immune to passive", PassiveType.OTHER),
                /* 327 */ createPassive("Master of Though Adelia", "The character have control over the world of your though and can send people in it", PassiveType.OTHER),
                /* 328 */ createPassive("Corrupted Hero of Dusk Ardyn", "The character gain access to corrupted holy magic", PassiveType.OTHER),

                /* 329 */ createPassive("ArmorPen-10", "The skill have a 10% armor penetration", PassiveType.SKILL),
                /* 330 */ createPassive("ArmorPen-20", "The skill have a 20% armor penetration",  PassiveType.SKILL),
                /* 331 */ createPassive("ArmorPen-25", "The skill have a 25% armor penetration",  PassiveType.SKILL),
                /* 332 */ createPassive("ArmorPen-50", "The skill have a 50% armor penetration",  PassiveType.SKILL),
                /* 333 */ createPassive("ArmorPen-75", "The skill have a 75% armor penetration",  PassiveType.SKILL),
                /* 334 */ createPassive("ArmorPen-100", "The skill have a 100% armor penetration",  PassiveType.SKILL),
                /* 335 */ createPassive("Burn", "The skill burn the target", PassiveType.SKILL),
                /* 336 */ createPassive("Paralyse", "The skill paralyse the target", PassiveType.SKILL),
                /* 337 */ createPassive("Freeze", "The skill freeze the target", PassiveType.SKILL),
                /* 338 */ createPassive("Wet", "The skill wet the target", PassiveType.SKILL),
                /* 339 */ createPassive("Poison", "The skill poison the target", PassiveType.SKILL),
                /* 340 */ createPassive("Petrify", "The skill petrify the target", PassiveType.SKILL),
                /* 341 */ createPassive("Curse-HP", "The skill drop the target HP", PassiveType.SKILL),
                /* 342 */ createPassive("Curse-Strength", "The skill drop the target strength", PassiveType.SKILL),
                /* 343 */ createPassive("Curse-Magic", "The skill drop the target magic", PassiveType.SKILL),
                /* 344 */ createPassive("Curse-Defense", "The skill drop the target defense", PassiveType.SKILL),
                /* 345 */ createPassive("Curse-Resistance", "The skill drop the target resistance", PassiveType.SKILL),
                /* 346 */ createPassive("Curse-Speed", "The skill drop the target speed", PassiveType.SKILL),
                /* 347 */ createPassive("Curse-Skill", "The skill drop the target skill", PassiveType.SKILL),
                /* 348 */ createPassive("Curse-Luck", "The skill drop the target luck", PassiveType.SKILL),
                /* 349 */ createPassive("Curse-Spirit", "The skill drop the target spirit", PassiveType.SKILL),
                /* 350 */ createPassive("Armored-Eff", "The skill is effective agains't armored character", PassiveType.SKILL),
                /* 351 */ createPassive("Mounted-Eff", "The skill is effective agains't mounted character", PassiveType.SKILL),
                /* 352 */ createPassive("Flying-Eff", "The skill is effective agains't flying character", PassiveType.SKILL),
                /* 353 */ createPassive("Beast-Eff", "The skill is effective agains't beast character", PassiveType.SKILL),
                /* 354 */ createPassive("Dragon-Eff", "The skill is effective agains't dragon character", PassiveType.SKILL),
                /* 355 */ createPassive("Void-Eff", "The skill is effective agains't void character", PassiveType.SKILL),
                /* 356 */ createPassive("Undead-Eff", "The skill is effective agains't undead character", PassiveType.SKILL),
                /* 357 */ createPassive("Demon-Eff", "The skill is effective agains't demon character", PassiveType.SKILL),
                /* 358 */ createPassive("Monster-Eff", "The skill is effective agains't monster character", PassiveType.SKILL),
                /* 359 */ createPassive("Human-Eff", "The skill is effective agains't human character", PassiveType.SKILL),
                /* 360 */ createPassive("DefensePiercer", "The skill ignore defense", PassiveType.SKILL),
                /* 361 */ createPassive("ResistancePiercer", "The skill ignore resistance", PassiveType.SKILL),

                /* 362 */ createPassive("Though Acceleration", "The character can stop time to think", PassiveType.OTHER),
                /* 363 */ createPassive("Though Creation/Manipulation", "The character can create and manipulation matter", PassiveType.OTHER),
                /* 364 */ createPassive("Heroic Desire", "The character's stats growth are increased by 5", PassiveType.OTHER),
                /* 365 */ createPassive("Mage Prodigy", "The characer's magic and spirit growth by 15", PassiveType.OTHER),
                /* 366 */ createPassive("Manipulator", "The character can easily trick and manipulate other people", PassiveType.OTHER),
                /* 367 */ createPassive("Royal", "Experience gain is 1.2 time higher", PassiveType.OTHER),
                /* 368 */ createPassive("Perseverant", "The character's HP Growth is increased by 10", PassiveType.OTHER),
                /* 369 */ createPassive("Strong", "The character's Strength Growth is increased by 10", PassiveType.OTHER),
                /* 370 */ createPassive("Intelligent", "The character's Magic Growth is increased by 10", PassiveType.OTHER),
                /* 371 */ createPassive("Tanky", "The character's Defense Growth is increased by 10", PassiveType.OTHER),
                /* 372 */ createPassive("Resilient", "The character's Resistance Growth is increased by 10", PassiveType.OTHER),
                /* 373 */ createPassive("Skilled", "The character's Skill Growth is increased by 10", PassiveType.OTHER),
                /* 374 */ createPassive("Fast", "The character's Speed Growth is increased by 10", PassiveType.OTHER),
                /* 375 */ createPassive("Lucky", "The character's Luck Growth is increased by 10", PassiveType.OTHER),
                /* 376 */ createPassive("Adept", "The character's Spirit Growth is increased by 10", PassiveType.OTHER),
                /* 377 */ createPassive("Generosity", "The character's healing done is 1.5 time stronger", PassiveType.OTHER),
                /* 378 */ createPassive("Knightly Will", "The character's defense and strength is increased when fighting monster and demon", PassiveType.OTHER),
                /* 379 */ createPassive("Unkillable", "The character's HP is double", PassiveType.OTHER),
                /* 380 */ createPassive("Powerful", "The character's strength is double", PassiveType.OTHER),
                /* 381 */ createPassive("Mastermind", "The character's magic is double", PassiveType.OTHER),
                /* 382 */ createPassive("Defender", "The character's defense is double", PassiveType.OTHER),
                /* 383 */ createPassive("Robust", "The character's resistance is double", PassiveType.OTHER),
                /* 384 */ createPassive("Swift", "The character's speed is double", PassiveType.OTHER),
                /* 385 */ createPassive("Talented", "The character's skill is double", PassiveType.OTHER),
                /* 386 */ createPassive("Fortunate", "The character's Luck is double", PassiveType.OTHER),
                /* 387 */ createPassive("Gifted", "The character's spirit is double", PassiveType.OTHER),
                /* 388 */ createPassive("Trash", "The character's stats growth is reduced by 5", PassiveType.OTHER),
                /* 389 */ createPassive("Spirit Gift", "You are gifted with spirit", PassiveType.OTHER),
                /* 390 */ createPassive("Skilled Artist", "The character's skills damage are 1.5 time higher", PassiveType.OTHER),
            };

            if (context.Passives.Count() == 0)
                await context.Passives.AddRangeAsync(passives);
            await context.SaveChangesAsync();
            #endregion

            #region Skill
            List<Skill> skills = new List<Skill> {

            };

            if (context.Skills.Count() == 0)
                await context.Skills.AddRangeAsync(skills);
            await context.SaveChangesAsync();
            #endregion

            #region Armor
            List<Armor> armors = new List<Armor>() {
                /* 0 */ createArmor("clothe", 0, new List<Passive>()),
                /* 1 */ createArmor("leather armor", 2, new List<Passive> { passives[99] }, "https://i.pinimg.com/564x/0b/eb/3d/0beb3d74f5c6e8731e5c4d0567a220b5.jpg"),
                /* 2 */ createArmor("adventurer armor", 4, new List<Passive> { passives[100], passives[109] }, "https://i.pinimg.com/564x/5c/79/49/5c7949fbafffc4a3311f88fdb03155fb.jpg"),
                /* 3 */ createArmor("mage robes", 3, new List<Passive> { passives[113] }, "https://i.pinimg.com/564x/81/d3/e4/81d3e4245c79d1605f0266e87eb952be.jpg"),
                /* 4 */ createArmor("chainmail", 6, new List<Passive> { passives[103] }, "https://i.pinimg.com/564x/13/f3/c2/13f3c2057207b65445266a6733927eb1.jpg"),
                /* 5 */ createArmor("Full Plate", 8, new List<Passive> { passives[105] }, "https://i.pinimg.com/564x/7e/e9/d3/7ee9d3a42f82f1bfa74d60d94fb39571.jpg"),
                /* 6 */ createArmor("Royal Armor", 12, new List<Passive> { passives[105], passives[111] }, "https://i.pinimg.com/564x/80/78/70/807870658176653e7c90351e3733057a.jpg")
            };

            if (context.Armors.Count() == 0)
                await context.Armors.AddRangeAsync(armors);
            await context.SaveChangesAsync();
            #endregion

            #region Weapon
            List<Weapon> weapons = new List<Weapon>() {
                /* 0 */ createWeapon("Fist", 1, 100, 0, 0, DamageType.PHYSICAL, WeaponRank.E, WeaponType.FIST, new List<Passive> { passives[0], passives[1] }),
                /* 1 */ createWeapon("Bronze Gauntlet", 2, 90, 6, 0, DamageType.PHYSICAL, WeaponRank.E, WeaponType.FIST, new List<Passive> { passives[1] }),
                /* 2 */ createWeapon("Iron Gauntlet", 4, 85, 15, 0, DamageType.PHYSICAL, WeaponRank.D, WeaponType.FIST, new List<Passive> { passives[1] }),
                /* 3 */ createWeapon("Steel Gauntlet", 7, 85, 30, 0, DamageType.PHYSICAL, WeaponRank.C, WeaponType.FIST, new List<Passive> { passives[1] }),
                /* 4 */ createWeapon("Magisteel Gauntlet", 6, 80, 60, 0, DamageType.PHYSICAL, WeaponRank.B, WeaponType.FIST, new List<Passive> { passives[1], passives[5] }),
                /* 5 */ createWeapon("Silver Gauntlet", 8, 90, 120, 0, DamageType.PHYSICAL, WeaponRank.A, WeaponType.FIST, new List<Passive> { passives[1] }),
                /* 6 */ createWeapon("Caestus", 3, 100, 3, 0, DamageType.PHYSICAL, WeaponRank.D, WeaponType.FIST, new List<Passive> { passives[1], passives[54] }),
                /* 7 */ createWeapon("Spiked Caestus", 4, 100, 12, 0, DamageType.PHYSICAL, WeaponRank.C, WeaponType.FIST, new List<Passive> { passives[1], passives[55] }),
                /* 8 */ createWeapon("Katar", 6, 95, 70, 15, DamageType.PHYSICAL, WeaponRank.B, WeaponType.FIST, new List<Passive> { passives[1] }),

                /* 9 */ createWeapon("Bronze Sword", 2, 100, 8, 0, DamageType.PHYSICAL, WeaponRank.E, WeaponType.SWORD, new List<Passive> { passives[0] }),
                /* 10 */ createWeapon("Iron Sword", 5, 100, 16, 0, DamageType.PHYSICAL, WeaponRank.D, WeaponType.SWORD, new List<Passive> { }),
                /* 11 */ createWeapon("Steel Sword", 8, 95, 32, 0, DamageType.PHYSICAL, WeaponRank.C, WeaponType.SWORD, new List<Passive> { }),
                /* 12 */ createWeapon("Magisteel Sword", 6, 95, 64, 0, DamageType.PHYSICAL, WeaponRank.B, WeaponType.SWORD, new List<Passive> { passives[5] }),
                /* 13 */ createWeapon("Silver Sword", 12, 100, 128, 0, DamageType.PHYSICAL, WeaponRank.A, WeaponType.SWORD, new List<Passive> { }),
                /* 14 */ createWeapon("Katana", 9, 95, 75, 25, DamageType.PHYSICAL, WeaponRank.A, WeaponType.SWORD, new List<Passive> { passives[53], passives[63] }),
                /* 15 */ createWeapon("Rapier", 10, 100, 100, 10, DamageType.PHYSICAL, WeaponRank.A, WeaponType.SWORD, new List<Passive> { passives[66] }),
                /* 16 */ createWeapon("Armorslayer", 7, 90, 40, 0, DamageType.PHYSICAL, WeaponRank.C, WeaponType.SWORD, new List<Passive> { passives[82] }),
                /* 17 */ createWeapon("Wrymslayer", 7, 85, 50, 0, DamageType.PHYSICAL, WeaponRank.C, WeaponType.SWORD, new List<Passive> { passives[86] }),
                /* 18 */ createWeapon("Brave Sword", 8, 90, 150, 5, DamageType.PHYSICAL, WeaponRank.A, WeaponType.SWORD, new List<Passive> { passives[1] }),
                /* 19 */ createWeapon("Levin Sword", 9, 95, 200, 0, DamageType.ARCANE, WeaponRank.A, WeaponType.SWORD, new List<Passive> { passives[96] }),
                /* 20 */ createWeapon("Creator Sword", 10, 95, 0, 5, DamageType.PHYSICAL, WeaponRank.B, WeaponType.SWORD, new List<Passive> { }),
                /* 21 */ createWeapon("Thunderbrand", 12, 80, 0, 5, DamageType.PHYSICAL, WeaponRank.S, WeaponType.SWORD, new List<Passive> { passives[1] }),
                /* 22 */ createWeapon("Blutgang", 8, 90, 0, 5, DamageType.PHYSICAL, WeaponRank.B, WeaponType.SWORD, new List<Passive> { passives[84], passives[86] }),
                /* 23 */ createWeapon("Sword of Seiros", 6, 95, 0, 0, DamageType.PHYSICAL, WeaponRank.C, WeaponType.SWORD, new List<Passive> { passives[92] }),
                /* 24 */ createWeapon("Sword of Moralta", 6, 90, 0, 10, DamageType.PHYSICAL, WeaponRank.C, WeaponType.SWORD, new List<Passive> { passives[95] }),

                /* 25 */ createWeapon("Bronze Spear", 3, 90, 10, 0, DamageType.PHYSICAL, WeaponRank.E, WeaponType.SPEAR, new List<Passive> { passives[0] }),
                /* 26 */ createWeapon("Iron Spear", 6, 85, 20, 5, DamageType.PHYSICAL, WeaponRank.D, WeaponType.SPEAR, new List<Passive> { }),
                /* 27 */ createWeapon("Steel Spear", 9, 80, 40, 5, DamageType.PHYSICAL, WeaponRank.C, WeaponType.SPEAR, new List<Passive> { }),
                /* 28 */ createWeapon("Magisteel Spear", 7, 80, 80, 5, DamageType.PHYSICAL, WeaponRank.B, WeaponType.SPEAR, new List<Passive> { passives[5] }),
                /* 29 */ createWeapon("Silver Spear", 13, 85, 160, 10, DamageType.PHYSICAL, WeaponRank.A, WeaponType.SPEAR, new List<Passive> { }),
                /* 30 */ createWeapon("Naginata", 9, 100, 40, 5, DamageType.PHYSICAL, WeaponRank.B, WeaponType.SPEAR, new List<Passive> { }),
                /* 31 */ createWeapon("Javelin", 6, 80, 25, 5, DamageType.PHYSICAL, WeaponRank.C, WeaponType.SPEAR, new List<Passive> { }),
                /* 32 */ createWeapon("Killer Spear", 7, 80, 95, 30, DamageType.PHYSICAL, WeaponRank.B, WeaponType.SPEAR, new List<Passive> { }),
                /* 33 */ createWeapon("Beastslayer", 8, 85, 50, 5, DamageType.PHYSICAL, WeaponRank.C, WeaponType.SPEAR, new List<Passive> { passives[84] }),
                /* 34 */ createWeapon("Brave Spear", 11, 80, 170, 15, DamageType.PHYSICAL, WeaponRank.A, WeaponType.SPEAR, new List<Passive> { passives[1] }),
                /* 35 */ createWeapon("Blessed Trident", 9, 75, 100, 5, DamageType.HOLY, WeaponRank.B, WeaponType.SPEAR, new List<Passive> { passives[90] }),
                /* 36 */ createWeapon("Aredbhar", 12, 90, 0, 20, DamageType.PHYSICAL, WeaponRank.S, WeaponType.SPEAR, new List<Passive> { passives[16] }),
                /* 37 */ createWeapon("Lùin", 8, 80, 0, 10, DamageType.PHYSICAL, WeaponRank.B, WeaponType.SPEAR, new List<Passive> { passives[86] }),
                /* 38 */ createWeapon("Spear of Assal", 10, 90, 0, 5, DamageType.PHYSICAL, WeaponRank.C, WeaponType.SPEAR, new List<Passive> { passives[66] }),
                /* 39 */ createWeapon("Crescent Sariel", 14, 75, 0, 10, DamageType.ARCANE, WeaponRank.A, WeaponType.SPEAR, new List<Passive> { }),

                /* 40 */ createWeapon("Bronze Axe", 5, 85, 12, 0, DamageType.PHYSICAL, WeaponRank.E, WeaponType.AXE, new List<Passive> { passives[0] }),
                /* 41 */ createWeapon("Iron Axe", 7, 80, 24, 0, DamageType.PHYSICAL, WeaponRank.D, WeaponType.AXE, new List<Passive> { }),
                /* 42 */ createWeapon("Steel Axe", 10, 75, 48, 0, DamageType.PHYSICAL, WeaponRank.C, WeaponType.AXE, new List<Passive> { }),
                /* 43 */ createWeapon("Magisteel Axe", 9, 60, 96, 0, DamageType.PHYSICAL, WeaponRank.B, WeaponType.AXE, new List<Passive> { passives[5] }),
                /* 44 */ createWeapon("Silver Axe", 15, 65, 192, 0, DamageType.PHYSICAL, WeaponRank.A, WeaponType.AXE, new List<Passive> { }),
                /* 45 */ createWeapon("Hand Axe", 6, 60, 30, 0, DamageType.PHYSICAL, WeaponRank.D, WeaponType.AXE, new List<Passive> { }),
                /* 46 */ createWeapon("Tomahawk", 13, 50, 100, 5, DamageType.PHYSICAL, WeaponRank.B, WeaponType.AXE, new List<Passive> { }),
                /* 47 */ createWeapon("Hammer", 9, 55, 50, 0, DamageType.PHYSICAL, WeaponRank.C, WeaponType.AXE, new List<Passive> { passives[82] }),
                /* 48 */ createWeapon("Mace", 6, 65, 26, 5, DamageType.PHYSICAL, WeaponRank.D, WeaponType.AXE, new List<Passive> { passives[82] }),
                /* 49 */ createWeapon("Killer Axe", 9, 45, 55, 20, DamageType.PHYSICAL, WeaponRank.C, WeaponType.AXE, new List<Passive> { }),
                /* 50 */ createWeapon("Brave Axe", 11, 55, 200, 5, DamageType.PHYSICAL, WeaponRank.A, WeaponType.AXE, new List<Passive> { passives[1] }),
                /* 51 */ createWeapon("Aymr", 15, 65, 0, 5, DamageType.PHYSICAL, WeaponRank.B, WeaponType.AXE, new List<Passive> { passives[86] }),
                /* 52 */ createWeapon("Freikugel", 16, 70, 0, 10, DamageType.PHYSICAL, WeaponRank.S, WeaponType.AXE, new List<Passive> { passives[16] }),
                /* 53 */ createWeapon("Axe of Ukonvasara", 13, 60, 0, 5, DamageType.PHYSICAL, WeaponRank.A, WeaponType.AXE, new List<Passive> { passives[36], passives[46] }),

                /* 54 */ createWeapon("Bronze Dagger", 2, 100, 3, 0, DamageType.PHYSICAL, WeaponRank.E, WeaponType.DAGGER, new List<Passive> { passives[0], passives[53] }),
                /* 55 */ createWeapon("Iron Dagger", 4, 95, 6, 5, DamageType.PHYSICAL, WeaponRank.D, WeaponType.DAGGER, new List<Passive> { passives[54] }),
                /* 56 */ createWeapon("Steel Dagger", 6, 90, 12, 5, DamageType.PHYSICAL, WeaponRank.C, WeaponType.DAGGER, new List<Passive> { passives[53] }),
                /* 57 */ createWeapon("Magisteel Dagger", 5, 80, 24, 5, DamageType.PHYSICAL, WeaponRank.B, WeaponType.DAGGER, new List<Passive> { passives[5], passives[52] }),
                /* 58 */ createWeapon("Silver Dagger", 8, 85, 48, 5, DamageType.PHYSICAL, WeaponRank.A, WeaponType.DAGGER, new List<Passive> { passives[54] }),
                /* 59 */ createWeapon("Shuriken", 3, 100, 10, 15, DamageType.PHYSICAL, WeaponRank.D, WeaponType.DAGGER, new List<Passive> { passives[53] }),
                /* 60 */ createWeapon("Chakram", 5, 100, 15, 15, DamageType.PHYSICAL, WeaponRank.C, WeaponType.DAGGER, new List<Passive> { passives[55] }),
                /* 61 */ createWeapon("Hunter's Knife", 5, 90, 8, 10, DamageType.PHYSICAL, WeaponRank.D, WeaponType.DAGGER, new List<Passive> { passives[54], passives[64] }),
                /* 62 */ createWeapon("Killer Dagger", 6, 80, 20, 25, DamageType.PHYSICAL, WeaponRank.C, WeaponType.DAGGER, new List<Passive> { passives[56] }),
                /* 63 */ createWeapon("Brave Dagger", 8, 80, 56, 10, DamageType.PHYSICAL, WeaponRank.A, WeaponType.DAGGER, new List<Passive> { passives[1], passives[55] }),
                /* 64 */ createWeapon("Mortem", 9, 95, 0, 15, DamageType.PHYSICAL, WeaponRank.S, WeaponType.DAGGER, new List<Passive> { passives[58], passives[91] }),
                /* 65 */ createWeapon("Ragnell", 11, 75, 0, 10, DamageType.PHYSICAL, WeaponRank.A, WeaponType.DAGGER, new List<Passive> { passives[56], passives[82] }),
                /* 66 */ createWeapon("Bölverk", 15, 65, 0, 5, DamageType.PHYSICAL, WeaponRank.B, WeaponType.DAGGER, new List<Passive> { passives[14], passives[54] }),
                /* 67 */ createWeapon("Siegfried", 7, 85, 0, 10, DamageType.PHYSICAL, WeaponRank.A, WeaponType.DAGGER, new List<Passive> { passives[61] }),

                /* 68 */ createWeapon("Wooden Staff", 1, 100, 1, 0, DamageType.ARCANE, WeaponRank.E, WeaponType.STAFF, new List<Passive> { passives[0], passives[5], passives[96] }),
                /* 69 */ createWeapon("Iron Staff", 3, 80, 6, 0, DamageType.ARCANE, WeaponRank.D, WeaponType.STAFF, new List<Passive> { passives[7], passives[96] }),
                /* 70 */ createWeapon("Magisteel Staff", 6, 70, 24, 0, DamageType.ARCANE, WeaponRank.B, WeaponType.STAFF, new List<Passive> { passives[9], passives[96] }),
                /* 71 */ createWeapon("Byrnhildr", 8, 75, 0, 10, DamageType.ARCANE, WeaponRank.S, WeaponType.STAFF, new List<Passive> { passives[11], passives[96] }),

                /* 72 */ createWeapon("Bronze Bow", 3, 95, 5, 0, DamageType.PHYSICAL, WeaponRank.E, WeaponType.BOW, new List<Passive> { passives[0], passives[63] }),
                /* 73 */ createWeapon("Iron Bow", 5, 95, 10, 0, DamageType.PHYSICAL, WeaponRank.D, WeaponType.BOW, new List<Passive> { passives[64] }),
                /* 74 */ createWeapon("Steel Bow", 8, 85, 20, 0, DamageType.PHYSICAL, WeaponRank.C, WeaponType.BOW, new List<Passive> { passives[1], passives[62] }),
                /* 75 */ createWeapon("Magisteel Bow", 6, 80, 40, 0, DamageType.PHYSICAL, WeaponRank.B, WeaponType.BOW, new List<Passive> { passives[64] }),
                /* 76 */ createWeapon("Silver Bow", 11, 85, 80, 0, DamageType.PHYSICAL, WeaponRank.A, WeaponType.BOW, new List<Passive> { passives[65] }),
                /* 77 */ createWeapon("Greatbow", 15, 60, 60, 0, DamageType.PHYSICAL, WeaponRank.B, WeaponType.BOW, new List<Passive> { }),
                /* 78 */ createWeapon("Short Bow", 7, 90, 30, 0, DamageType.PHYSICAL, WeaponRank.C, WeaponType.BOW, new List<Passive> { passives[64] }),
                /* 79 */ createWeapon("Long Bow", 9, 80, 50, 0, DamageType.PHYSICAL, WeaponRank.B, WeaponType.BOW, new List<Passive> { passives[64] }),
                /* 80 */ createWeapon("Killer Bow", 7, 75, 45, 20, DamageType.PHYSICAL, WeaponRank.C, WeaponType.BOW, new List<Passive> { passives[63] }),
                /* 81 */ createWeapon("Brave Bow", 10, 80, 100, 5, DamageType.PHYSICAL, WeaponRank.A, WeaponType.BOW, new List<Passive> { passives[1], passives[64] }),
                /* 82 */ createWeapon("Failnaught", 12, 90, 0, 10, DamageType.PHYSICAL, WeaponRank.S, WeaponType.BOW, new List<Passive> { passives[65] }),
                /* 83 */ createWeapon("Fujin Yumi", 9, 85, 0, 5, DamageType.WIND, WeaponRank.A, WeaponType.BOW, new List<Passive> { passives[64], passives[96] }),
                /* 84 */ createWeapon("Skadi", 7, 80, 0, 10, DamageType.PHYSICAL, WeaponRank.B, WeaponType.BOW, new List<Passive> { passives[71] })
            };

            if (context.Weapons.Count() == 0)
                await context.Weapons.AddRangeAsync(weapons);
            await context.SaveChangesAsync();
            #endregion

            #region Class
            List<Class> classes = new List<Class>() {
                /* 0 */ createClass("Militia", 15, 15, 0, 20, 5, 5, 10, 5, 0, ClassSeries.MILITIA, new List<Passive> { passives[127], passives[128] }),
                /* 1 */ createClass("Fighter", 20, 20, 0, 10, 5, 10, 10, 0, 0, ClassSeries.FIGHTER, new List<Passive> { passives[129], passives[130] }),
                /* 2 */ createClass("Skirmisher", 10, 10, 0, 5, 5, 10, 15, 5, 0, ClassSeries.SKIRMISHER, new List<Passive> { passives[131], passives[132] }),
                /* 3 */ createClass("Bowman", 5, 10, 5, 5, 10, 15, 20, 10, 0, ClassSeries.BOWMAN, new List<Passive> { passives[133], passives[134] }),
                /* 4 */ createClass("Medic", 15, 5, 15, 5, 20, 5, 5, 15, 10, ClassSeries.MEDIC, new List<Passive> { passives[135], passives[136] }),
                /* 5 */ createClass("Apprentice", 10, 0, 20, 0, 15, 5, 10, 10, 20, ClassSeries.APPRENTICE, new List<Passive> { passives[137], passives[138] }),
                /* 6 */ createClass("Monster", 20, 10, 10, 10, 10, 10, 10, 10, 10, ClassSeries.MONSTER, new List<Passive> { passives[139], passives[140] }),
                /* 7 */ createClass("Demon", 15, 15, 15, 10, 10, 5, 10, 0, 15, ClassSeries.DEMON, new List<Passive> { passives[141], passives[143] }),
                /* 8 */ createClass("Beastman", 20, 25, 0, 20, 5, 15, 10, 0, 0, ClassSeries.BEASTMAN, new List<Passive> { passives[143], passives[144] }),
                /* 9 */ createClass("Drakeling", 20, 10, 5, 10, 10, 5, 10, 10, 15, ClassSeries.DRAKELING, new List<Passive> { passives[145], passives[146] }),

                /* 10 */ createClass("Soldier", 25, 20, 5, 40, 10, 5, 15, 15, 10, ClassSeries.MILITIA, new List<Passive> { passives[147], passives[128] }),
                /* 11 */ createClass("Cavalier", 20, 25, 5, 20, 15, 30, 25, 10, 5, ClassSeries.MILITIA, new List<Passive> { passives[149], passives[128] }),
                /* 12 */ createClass("Captain", 35, 15, 10, 25, 10, 15, 20, 30, 25, ClassSeries.MILITIA, new List<Passive> { passives[151], passives[128] }),
                /* 13 */ createClass("Spearman", 20, 35, 15, 25, 10, 15, 25, 10, 15, ClassSeries.FIGHTER, new List<Passive> { passives[153], passives[128] }),
                /* 14 */ createClass("Scout", 25, 25, 15, 20, 15, 30, 20, 20, 20, ClassSeries.FIGHTER, new List<Passive> { passives[155], passives[128] }),
                /* 15 */ createClass("Barbarian", 35, 40, 0, 15, 10, 15, 25, 20, 0, ClassSeries.FIGHTER, new List<Passive> { passives[157], passives[128] }),
                /* 16 */ createClass("Swordsman", 25, 25, 5, 20, 15, 25, 35, 15, 5, ClassSeries.SKIRMISHER, new List<Passive> { passives[159], passives[160] }),
                /* 17 */ createClass("Rogue", 20, 15, 20, 10, 20, 35, 30, 10, 25, ClassSeries.SKIRMISHER, new List<Passive> { passives[161], passives[162] }),
                /* 18 */ createClass("Mercenary", 25, 25, 10, 20, 20, 25, 25, 20, 10, ClassSeries.SKIRMISHER, new List<Passive> { passives[163], passives[164] }),
                /* 19 */ createClass("Crossbowman", 25, 40, 0, 25, 15, 15, 30, 10, 0, ClassSeries.BOWMAN, new List<Passive> { passives[165], passives[166] }),
                /* 20 */ createClass("Archer", 20, 25, 15, 20, 25, 25, 30, 15, 20, ClassSeries.BOWMAN, new List<Passive> { passives[167], passives[168] }),
                /* 21 */ createClass("Priest", 25, 5, 30, 10, 35, 15, 10, 25, 20, ClassSeries.MEDIC, new List<Passive> { passives[169], passives[170] }),
                /* 22 */ createClass("Siren", 20, 0, 40, 10, 35, 20, 15, 25, 30, ClassSeries.MEDIC, new List<Passive> { passives[171], passives[172] }),
                /* 23 */ createClass("Hospitaller", 30, 10, 25, 25, 25, 25, 15, 20, 10, ClassSeries.MEDIC, new List<Passive> { passives[173], passives[174] }),
                /* 24 */ createClass("Arcanist", 15, 0, 35, 10, 20, 25, 20, 20, 40, ClassSeries.APPRENTICE, new List<Passive> { passives[175], passives[176] }),
                /* 25 */ createClass("Battlemage", 30, 15, 25, 30, 35, 10, 20, 15, 25, ClassSeries.APPRENTICE, new List<Passive> { passives[177], passives[178] }),
                /* 26 */ createClass("Conjurer", 20, 0, 40, 10, 25, 10, 20, 15, 25, ClassSeries.APPRENTICE, new List<Passive> { passives[179], passives[180] }),
                /* 27 */ createClass("Vampire", 40, 25, 30, 20, 25, 20, 15, 10, 30, ClassSeries.MONSTER, new List<Passive> { passives[181], passives[182] }),
                /* 28 */ createClass("Undead", 30, 30, 15, 30, 15, 10, 20, 10, 20, ClassSeries.MONSTER, new List<Passive> { passives[183], passives[184] }),
                /* 29 */ createClass("Voidling", 25, 25, 40, 20, 20, 25, 20, 20, 25, ClassSeries.MONSTER, new List<Passive> { passives[185], passives[186] }),
                /* 30 */ createClass("Demon Lord", 30, 10, 40, 20, 35, 20, 25, 30, 40, ClassSeries.DEMON, new List<Passive> { passives[187], passives[188] }),
                /* 31 */ createClass("Ancient Demon", 30, 40, 35, 30, 30, 35, 35, 15, 20, ClassSeries.DEMON, new List<Passive> { passives[189], passives[190] }),
                /* 32 */ createClass("Pit Fiend", 25, 35, 20, 30, 25, 10, 25, 0, 30, ClassSeries.DEMON, new List<Passive> { passives[191], passives[192] }),
                /* 33 */ createClass("Wolfskin", 30, 40, 10, 25, 25, 15, 30, 10, 20, ClassSeries.BEASTMAN, new List<Passive> { passives[193], passives[194] }),
                /* 34 */ createClass("Kitsune", 30, 30, 25, 20, 20, 30, 15, 20, 30, ClassSeries.BEASTMAN, new List<Passive> { passives[195], passives[194] }),
                /* 35 */ createClass("Wrym", 30, 25, 30, 25, 25, 20, 25, 25, 40, ClassSeries.DRAKELING, new List<Passive> { passives[196], passives[197] }),

                /* 36 */ createClass("Sentinel", 45, 55, 25, 60, 30, 10, 40, 45, 20, ClassSeries.MILITIA, new List<Passive> { passives[198], passives[199] }),
                /* 37 */ createClass("Champion", 55, 60, 10, 40, 25, 30, 55, 30, 15, ClassSeries.MILITIA, new List<Passive> { passives[200], passives[201] }),
                /* 38 */ createClass("Knight", 35, 45, 30, 45, 30, 50, 45, 20, 15, ClassSeries.MILITIA, new List<Passive> { passives[202], passives[203] }),
                /* 39 */ createClass("Wyvern Lord", 35, 55, 15, 35, 50, 50, 40, 20, 20, ClassSeries.MILITIA, new List<Passive> { passives[204], passives[205] }),
                /* 40 */ createClass("General", 40, 35, 25, 50, 45, 30, 35, 30, 30, ClassSeries.MILITIA, new List<Passive> { passives[206], passives[207] }),
                /* 41 */ createClass("Exemplar", 45, 35, 30, 30, 20, 35, 45, 50, 40, ClassSeries.MILITIA, new List<Passive> { passives[208], passives[209] }),
                /* 42 */ createClass("Centurion", 40, 50, 25, 35, 20, 35, 45, 15, 25, ClassSeries.FIGHTER, new List<Passive> { passives[210], passives[211] }),
                /* 43 */ createClass("Kishin Knight", 35, 40, 40, 30, 30, 55, 45, 30, 35, ClassSeries.FIGHTER, new List<Passive> { passives[212], passives[213] }),
                /* 44 */ createClass("Hussar", 40, 50, 35, 35, 30, 60, 40, 35, 30, ClassSeries.FIGHTER, new List<Passive> { passives[214], passives[215] }),
                /* 45 */ createClass("Dragoon", 45, 40, 25, 45, 25, 60, 55, 40, 25, ClassSeries.FIGHTER, new List<Passive> { passives[216], passives[217] }),
                /* 46 */ createClass("Berserker", 60, 70, 10, 40, 20, 30, 45, 10, 10, ClassSeries.FIGHTER, new List<Passive> { passives[218], passives[219] }),
                /* 47 */ createClass("Hero", 40, 55, 35, 45, 30, 50, 45, 30, 40, ClassSeries.FIGHTER, new List<Passive> { passives[220], passives[221] }),
                /* 48 */ createClass("Swordsmaster", 40, 40, 15, 30, 25, 40, 50, 25, 15, ClassSeries.SKIRMISHER, new List<Passive> { passives[222], passives[223] }),
                /* 49 */ createClass("Samurai", 45, 50, 5, 40, 30, 30, 50, 30, 5, ClassSeries.SKIRMISHER, new List<Passive> { passives[224], passives[225] }),
                /* 50 */ createClass("Ranger", 30, 45, 40, 35, 40, 55, 50, 15, 25, ClassSeries.SKIRMISHER, new List<Passive> { passives[226], passives[227] }),
                /* 51 */ createClass("Assassin", 25, 45, 50, 15, 25, 45, 70, 15, 40, ClassSeries.SKIRMISHER, new List<Passive> { passives[228], passives[229] }),
                /* 52 */ createClass("Strider", 30, 45, 20, 30, 35, 45, 60, 30, 25, ClassSeries.SKIRMISHER, new List<Passive> { passives[230], passives[231] }),
                /* 53 */ createClass("Master Ninja", 25, 35, 30, 25, 25, 60, 60, 35, 30, ClassSeries.SKIRMISHER, new List<Passive> { passives[232], passives[233] }),
                /* 54 */ createClass("Warbow", 30, 45, 15, 40, 20, 45, 55, 20, 25, ClassSeries.BOWMAN, new List<Passive> { passives[234], passives[235] }),
                /* 55 */ createClass("Raider", 40, 60, 0, 35, 20, 55, 50, 15, 0, ClassSeries.BOWMAN, new List<Passive> { passives[236], passives[237] }),
                /* 56 */ createClass("Sniper", 25, 45, 30, 25, 35, 55, 60, 25, 40, ClassSeries.BOWMAN, new List<Passive> { passives[238], passives[239] }),
                /* 57 */ createClass("Horsebow", 25, 40, 35, 35, 35, 55, 45, 30, 40, ClassSeries.BOWMAN, new List<Passive> { passives[240], passives[241] }),
                /* 58 */ createClass("Templar", 35, 30, 45, 30, 40, 20, 30, 40, 35, ClassSeries.MEDIC, new List<Passive> { passives[242], passives[243] }),
                /* 59 */ createClass("Inquisitor", 30, 15, 50, 25, 45, 20, 15, 30, 40, ClassSeries.MEDIC, new List<Passive> { passives[244], passives[245] }),
                /* 60 */ createClass("Sorceress", 30, 0, 60, 15, 50, 45, 30, 35, 50, ClassSeries.MEDIC, new List<Passive> { passives[246], passives[247] }),
                /* 61 */ createClass("Acolyte", 35, 10, 50, 20, 40, 35, 40, 25, 55, ClassSeries.MEDIC, new List<Passive> { passives[248], passives[249] }),
                /* 62 */ createClass("Paladin", 50, 45, 30, 50, 50, 25, 30, 25, 20, ClassSeries.MEDIC, new List<Passive> { passives[250], passives[251] }),
                /* 63 */ createClass("Valkyrie", 40, 25, 45, 35, 35, 50, 25, 40, 20, ClassSeries.MEDIC, new List<Passive> { passives[252], passives[253] }),
                /* 64 */ createClass("Wizard", 25, 0, 60, 15, 50, 30, 40, 35, 55, ClassSeries.APPRENTICE, new List<Passive> { passives[254], passives[255] }),
                /* 65 */ createClass("Illusionnist", 20, 30, 40, 20, 35, 40, 35, 45, 60, ClassSeries.APPRENTICE, new List<Passive> { passives[256], passives[257] }),
                /* 66 */ createClass("Aegis", 50, 25, 30, 55, 60, 15, 30, 25, 35, ClassSeries.APPRENTICE, new List<Passive> { passives[258], passives[259] }),
                /* 67 */ createClass("Astral Seeker", 45, 40, 50, 60, 45, 20, 35, 15, 25, ClassSeries.APPRENTICE, new List<Passive> { passives[260], passives[261] }),
                /* 68 */ createClass("Pyromancer", 35, 5, 55, 20, 40, 30, 40, 30, 50, ClassSeries.APPRENTICE, new List<Passive> { passives[262], passives[263] }),
                /* 69 */ createClass("Druid", 45, 15, 45, 35, 45, 25, 30, 25, 40, ClassSeries.APPRENTICE, new List<Passive> { passives[264], passives[265] }),
                /* 70 */ createClass("Vampire Lord", 60, 50, 55, 35, 40, 40, 35, 30, 55, ClassSeries.MONSTER, new List<Passive> { passives[266], passives[267] }),
                /* 71 */ createClass("Lich", 30, 30, 60, 30, 55, 10, 40, 10, 60, ClassSeries.MONSTER, new List<Passive> { passives[268], passives[269] }),
                /* 72 */ createClass("Squeleton", 50, 50, 20, 50, 20, 25, 45, 20, 30, ClassSeries.MONSTER, new List<Passive> { passives[270], passives[271] }),
                /* 73 */ createClass("Specter", 30, 35, 35, 30, 45, 60, 55, 15, 25, ClassSeries.MONSTER, new List<Passive> { passives[272], passives[273] }),
                /* 74 */ createClass("Legion", 40, 55, 40, 45, 45, 30, 50, 20, 30, ClassSeries.MONSTER, new List<Passive> { passives[274], passives[275] }),
                /* 75 */ createClass("Voidmancer", 35, 35, 55, 30, 30, 45, 40, 35, 45, ClassSeries.MONSTER, new List<Passive> { passives[276], passives[277] }),
                /* 76 */ createClass("Supreme Demon", 40, 20, 60, 30, 50, 20, 35, 55, 60, ClassSeries.DEMON, new List<Passive> { passives[278], passives[279] }),
                /* 77 */ createClass("True Demon", 55, 35, 40, 45, 60, 25, 30, 35, 40, ClassSeries.DEMON, new List<Passive> { passives[280], passives[281] }),
                /* 78 */ createClass("Primordial Demon", 45, 50, 50, 30, 30, 45, 45, 30, 40, ClassSeries.DEMON, new List<Passive> { passives[282], passives[283] }),
                /* 79 */ createClass("Urgash", 60, 55, 45, 35, 35, 35, 40, 25, 35, ClassSeries.DEMON, new List<Passive> { passives[284], passives[285] }),
                /* 80 */ createClass("Pit Lord", 40, 40, 35, 50, 35, 20, 30, 5, 50, ClassSeries.DEMON, new List<Passive> { passives[286], passives[287] }),
                /* 81 */ createClass("Ravager", 55, 65, 20, 45, 40, 35, 40, 10, 35, ClassSeries.DEMON, new List<Passive> { passives[288], passives[289] }),
                /* 82 */ createClass("Wolfssegner", 50, 60, 25, 40, 35, 30, 55, 20, 35, ClassSeries.BEASTMAN, new List<Passive> { passives[290], passives[291] }),
                /* 83 */ createClass("Nine-Tails", 50, 55, 45, 35, 35, 50, 35, 40, 60, ClassSeries.BEASTMAN, new List<Passive> { passives[292], passives[291] }),
                /* 84 */ createClass("Dragon", 55, 50, 55, 40, 40, 25, 35, 25, 60, ClassSeries.DRAKELING, new List<Passive> { passives[293], passives[294] }),

                /* 85 */ createClass("True Dragon", 200, 100, 150, 105, 120, 90, 100, 80, 150, ClassSeries.MILITIA, new List<Passive> { passives[295], passives[296] }),
                /* 86 */ createClass("Great Lich", 30, 0, 80, 60, 80, 40, 60, 55, 65, ClassSeries.MONSTER, new List<Passive> { passives[297], passives[298] }),
                /* 87 */ createClass("Necromancer", 35, 15, 80, 60, 80, 15, 60, 55, 65, ClassSeries.MONSTER, new List<Passive> { passives[299], passives[300] }),
                /* 88 */ createClass("Oathbound", 75, 80, 25, 80, 55, 60, 60, 80, 30, ClassSeries.MONSTER, new List<Passive> { passives[301], passives[302] })
            };

            if (context.Classes.Count() == 0)
                await context.Classes.AddRangeAsync(classes);
            await context.SaveChangesAsync();
            #endregion

            #region Character
            List<Character> characters = new List<Character>() {
                
            };

            if (context.Characters.Count() == 0)
                await context.Characters.AddRangeAsync(characters);
            await context.SaveChangesAsync();
            #endregion
        }
    }
}
