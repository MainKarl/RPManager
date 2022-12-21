using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using IsekaiDb.Data;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.CodeAnalysis;
using static IsekaiDb.Data.Enumerable;

namespace IsekaiDb.Domain.Entities
{
    public class Character
    {
        public Guid CharacterId { get; set; }
        public string Name { get; set; }
        public RaceType Race { get; set; }
        public int Level { get; set; }
        public string Path { get; set; }

        #region Stats
        public int HP { get; set; }
        public int CombatHP { get; set; }
        public int HPGrowth { get; set; }

        public int Strength { get; set; }
        public int CombatStrength { get; set; }
        public int StrengthGrowth { get; set; }

        public int Magic { get; set; }
        public int CombatMagic { get; set; }
        public int MagicGrowth { get; set; }

        public int Defense { get; set; }
        public int CombatDefense { get; set; }
        public int DefenseGrowth { get; set; }

        public int Resistance { get; set; }
        public int CombatResistance { get; set; }
        public int ResistanceGrowth { get; set; }

        public int Speed { get; set; }
        public int CombatSpeed { get; set; }
        public int SpeedGrowth { get; set; }

        public int Skill { get; set; }
        public int CombatSkill { get; set; }
        public int SkillGrowth { get; set; }

        public int Luck { get; set; }
        public int CombatLuck { get; set; }
        public int LuckGrowth { get; set; }

        public int Spirit { get; set; }
        public int CombatSpirit { get; set; }
        public int SpiritGrowth { get; set; }


        public int GetHPGrowth
        {
            get { return HPGrowth + Class.HPGrowth; }
        }
        public int GetStrengthGrowth
        {
            get { return StrengthGrowth + Class.StrengthGrowth; }
        }
        public int GetMagicGrowth
        {
            get { return MagicGrowth + Class.MagicGrowth; }
        }
        public int GetDefenseGrowth
        {
            get { return DefenseGrowth + Class.DefenseGrowth; }
        }
        public int GetResistanceGrowth
        {
            get { return ResistanceGrowth + Class.ResistanceGrowth; }
        }
        public int GetSpeedGrowth
        {
            get { return SpeedGrowth + Class.SpeedGrowth; }
        }
        public int GetSkillGrowth
        {
            get { return SkillGrowth + Class.SkillGrowth; }
        }
        public int GetLuckGrowth
        {
            get { return LuckGrowth + Class.LuckGrowth; }
        }
        public int GetSpiritGrowth
        {
            get { return SpiritGrowth + Class.SpiritGrowth; }
        }
        #endregion

        #region Magic
        public int ArcaneLevel { get; set; }
        public int IllusionLevel { get; set; }
        public int MindLevel { get; set; }

        public int FireLevel { get; set; }
        public int LavaLevel { get; set; }
        public int HeatLevel { get; set; }

        public int WaterLevel { get; set; }
        public int LiquidLevel { get; set; }
        public int IceLevel { get; set; }

        public int AirLevel { get; set; }
        public int LightningLevel { get; set; }
        public int WindLevel { get; set; }

        public int EarthLevel { get; set; }
        public int NatureLevel { get; set; }
        public int PoisonLevel { get; set; }

        public int LightLevel { get; set; }
        public int HolyLevel { get; set; }
        public int SpaceLevel { get; set; }

        public int DarkLevel { get; set; }
        public int CurseLevel { get; set; }
        public int NecromancyLevel { get; set; }
        #endregion

        #region Weapon
        public WeaponRank Fist { get; set; }
        public WeaponRank Sword { get; set; }
        public WeaponRank Spear { get; set; }
        public WeaponRank Axe { get; set; }
        public WeaponRank Dagger { get; set; }
        public WeaponRank Staff { get; set; }
        public WeaponRank Bow { get; set; }
        #endregion

        #region Rank
        public Level StatRank { get; set; }
        public Level MagicRank { get; set; }
        public Level SpiritRank { get; set; }
        #endregion

        // nav
        public ICollection<CharacterType> Types { get; set; }
        public ICollection<CharacterStatus> Status { get; set; }
        public Class Class { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public ICollection<Passive> CharacterPassives { get; set; }
        public ICollection<Skill> CharacterSkill { get; set; }

        // Function
        public Character()
        { }
        public Character(string name, RaceType race, 
                int hp, int strength, int magic, int defense, int resistance, int speed, int skill, int luck, int spirit,
                int ghp, int gstrength, int gmagic, int gdefense, int gresistance, int gspeed, int gskill, int gluck, int gspirit,
                int arcane, int illusion, int mind, int fire, int lava, int heat, int water, int liquid, int ice,
                int air, int wind, int lightning, int earth, int poison, int nature, int light, int space, int holy,
                int dark, int curse, int necromancy,
                WeaponRank sword, WeaponRank spear, WeaponRank axe, WeaponRank fist, WeaponRank dagger, WeaponRank staff, WeaponRank bow,
                Level lmagic, Level lspirit, List<CharacterType> types, List<CharacterStatus> status,
                Class cclass, Weapon weapon, Armor armor, List<Passive> passives, List<Skill> skills)
        {
            Name = name;
            Race = race;
            Level = 1;
            HP = hp;
            Strength = strength; 
            Magic = magic;
            Defense = defense;
            Resistance = resistance;
            Speed = speed;
            Skill = skill;
            Luck = luck;
            Spirit = spirit;

            ArcaneLevel = arcane;
            IllusionLevel = illusion;
            MindLevel = mind;
            FireLevel = fire;
            LavaLevel = lava;
            HeatLevel = heat;
            WaterLevel = water;
            LiquidLevel = liquid;
            IceLevel = ice;
            AirLevel = air;
            WindLevel = wind;
            LightningLevel = lightning;
            EarthLevel = earth;
            PoisonLevel = poison;
            NatureLevel = nature;
            LightLevel = light;
            HolyLevel = holy;
            SpaceLevel = space;
            DarkLevel = dark;
            CurseLevel = curse;
            NecromancyLevel = necromancy;

            Sword = sword;
            Spear = spear;
            Axe = axe;
            Fist = fist;
            Dagger = dagger;
            Staff = staff;
            Bow = bow;

            MagicRank = lmagic;
            SpiritRank = lspirit;
            verifyStatRank();

            Types = types;
            Status = status;
            Class = cclass;
            Weapon = weapon;
            Armor = armor;
            CharacterPassives = passives;
            CharacterSkill = skills;

            HPGrowth = ghp + Class.HPGrowth;
            StrengthGrowth = gstrength + Class.StrengthGrowth;
            MagicGrowth = gmagic + Class.MagicGrowth;
            DefenseGrowth = gdefense + Class.DefenseGrowth;
            ResistanceGrowth = gresistance + Class.ResistanceGrowth;
            SpeedGrowth = gspeed + Class.SpeedGrowth;
            SkillGrowth = gskill + Class.SkillGrowth;
            LuckGrowth = gluck + Class.LuckGrowth;
            SpiritGrowth = gspirit + Class.SpiritGrowth;

            rest();
        }

        public Character(string name, RaceType race,
                int hp, int strength, int magic, int defense, int resistance, int speed, int skill, int luck, int spirit,
                int ghp, int gstrength, int gmagic, int gdefense, int gresistance, int gspeed, int gskill, int gluck, int gspirit,
                int arcane, int illusion, int mind, int fire, int lava, int heat, int water, int liquid, int ice,
                int air, int wind, int lightning, int earth, int poison, int nature, int light, int space, int holy,
                int dark, int curse, int necromancy,
                WeaponRank sword, WeaponRank spear, WeaponRank axe, WeaponRank fist, WeaponRank dagger, WeaponRank staff, WeaponRank bow,
                Level lmagic, Level lspirit, List<CharacterType> types, List<CharacterStatus> status,
                Class cclass, Weapon weapon, Armor armor, List<Passive> passives, List<Skill> skills, string path)
        {
            Name = name;
            Race = race;
            Level = 1;
            HP = hp;
            Strength = strength;
            Magic = magic;
            Defense = defense;
            Resistance = resistance;
            Speed = speed;
            Skill = skill;
            Luck = luck;
            Spirit = spirit;

            ArcaneLevel = arcane;
            IllusionLevel = illusion;
            MindLevel = mind;
            FireLevel = fire;
            LavaLevel = lava;
            HeatLevel = heat;
            WaterLevel = water;
            LiquidLevel = liquid;
            IceLevel = ice;
            AirLevel = air;
            WindLevel = wind;
            LightningLevel = lightning;
            EarthLevel = earth;
            PoisonLevel = poison;
            NatureLevel = nature;
            LightLevel = light;
            HolyLevel = holy;
            SpaceLevel = space;
            DarkLevel = dark;
            CurseLevel = curse;
            NecromancyLevel = necromancy;

            Sword = sword;
            Spear = spear;
            Axe = axe;
            Fist = fist;
            Dagger = dagger;
            Staff = staff;
            Bow = bow;

            MagicRank = lmagic;
            SpiritRank = lspirit;
            verifyStatRank();

            Types = types;
            Status = status;
            Class = cclass;
            Weapon = weapon;
            Armor = armor;
            CharacterPassives = passives;
            CharacterSkill = skills;

            HPGrowth = ghp + Class.HPGrowth;
            StrengthGrowth = gstrength + Class.StrengthGrowth;
            MagicGrowth = gmagic + Class.MagicGrowth;
            DefenseGrowth = gdefense + Class.DefenseGrowth;
            ResistanceGrowth = gresistance + Class.ResistanceGrowth;
            SpeedGrowth = gspeed + Class.SpeedGrowth;
            SkillGrowth = gskill + Class.SkillGrowth;
            LuckGrowth = gluck + Class.LuckGrowth;
            SpiritGrowth = gspirit + Class.SpiritGrowth;

            rest();

            string extension = path.Substring(path.LastIndexOf('.'));
            string fileName = "wwwroot/img/Armor/" + name + "-" + id + extension;
            string fileNameReturn = "../img/Armor/" + name + "-" + id + extension;
            if (!File.Exists(fileName))
                using (WebClient client = new WebClient())
                    client.DownloadFile(new Uri(path), fileName);
            Path = fileNameReturn;
        }

        public int getTotalStat() { return HP + Strength + Magic + Defense + Resistance + Speed + Skill + Luck + Spirit; }
        public int getTotalMagic() { return ArcaneLevel + MindLevel + IllusionLevel + FireLevel + HeatLevel + LavaLevel + WaterLevel + LiquidLevel + IceLevel + AirLevel + WindLevel + LightningLevel + EarthLevel + PoisonLevel + NatureLevel + LightLevel + SpaceLevel + HolyLevel + DarkLevel + CurseLevel + NecromancyLevel; }
        public int getSpiritLevel() {
            switch (SpiritRank) {
                case Data.Enumerable.Level.BASIC:
                    return 0;
                case Data.Enumerable.Level.EXPERT:
                    return 1;
                case Data.Enumerable.Level.SAGE:
                    return 2;
                case Data.Enumerable.Level.DRAGON:
                    return 3;
                case Data.Enumerable.Level.GOD:
                    return 4;
                default:
                    return 0;
            }
        }
        private void verifyStatRank()
        {
            int stat = getTotalStat();
            if (stat <= 150)
                StatRank = Data.Enumerable.Level.BASIC;
            else if (stat <= 200)
                StatRank = Data.Enumerable.Level.EXPERT;
            else if (stat <= 300)
                StatRank = Data.Enumerable.Level.SAGE;
            else if (stat <= 600)
                StatRank = Data.Enumerable.Level.DRAGON;
            else
                StatRank = Data.Enumerable.Level.GOD;
        }
        public void addPassive(Passive passive)
        {
            if (!CharacterPassives.Contains(passive))
            {
                CharacterPassives.Add(passive);

                if (passive.Name == "Defense+II") Defense += 2;
                else if (passive.Name == "Strength+II") Strength += 2;
                else if (passive.Name == "Skill+II") Skill += 2;
                else if (passive.Name == "Resistance+II") Resistance += 2;
                else if (passive.Name == "Magic+II") Magic += 2;
                else if (passive.Name == "Strength+III") Strength += 3;
                else if (passive.Name == "Unkillable") HP *= 2;
                else if (passive.Name == "Powerful") Strength *= 2;
                else if (passive.Name == "Mastermind") Magic *= 2;
                else if (passive.Name == "Defender") Defense *= 2;
                else if (passive.Name == "Robust") Resistance *= 2;
                else if (passive.Name == "Swift") Speed *= 2;
                else if (passive.Name == "Talented") Skill *= 2;
                else if (passive.Name == "Fortunate") Luck *= 2;
                else if (passive.Name == "Gifted") Spirit *= 2;
                else if (passive.Name == "True Dragon of Faith Rhea")
                {
                    HP *= 2;
                    Strength *= 2;
                    Magic *= 2;
                    Defense *= 2;
                    Resistance *= 2;
                    Speed *= 2;
                    Skill *= 2;
                    Luck *= 2;
                    Spirit *= 2;
                }

                else if (passive.Name == "Holy Proficiency")
                {
                    HolyLevel += 10;
                    if (HolyLevel > LightLevel)
                        LightLevel = HolyLevel;
                }
                else if (passive.Name == "Magic Proficiency")
                {
                    ArcaneLevel += 5;
                    MindLevel += 5;
                    IllusionLevel += 5;
                    FireLevel += 5;
                    HeatLevel += 5;
                    LavaLevel += 5;
                    WaterLevel += 5;
                    LiquidLevel += 5;
                    IceLevel += 5;
                    AirLevel += 5;
                    WindLevel += 5;
                    LightningLevel += 5;
                    EarthLevel += 5;
                    PoisonLevel += 5;
                    NatureLevel += 5;
                    LightLevel += 5;
                    HolyLevel += 5;
                    SpaceLevel += 5;
                    DarkLevel += 5;
                    CurseLevel += 5;
                    NecromancyLevel += 5;
                }
                else if (passive.Name == "Magic Affinity")
                {
                    ArcaneLevel += 25;
                    MindLevel += 25;
                    IllusionLevel += 25;
                    FireLevel += 25;
                    HeatLevel += 25;
                    LavaLevel += 25;
                    WaterLevel += 25;
                    LiquidLevel += 25;
                    IceLevel += 25;
                    AirLevel += 25;
                    WindLevel += 25;
                    LightningLevel += 25;
                    EarthLevel += 25;
                    PoisonLevel += 25;
                    NatureLevel += 25;
                    LightLevel += 25;
                    HolyLevel += 25;
                    SpaceLevel += 25;
                    DarkLevel += 25;
                    CurseLevel += 25;
                    NecromancyLevel += 25;
                }
                else if (passive.Name == "Holy Mage")
                {
                    HolyLevel += 25;
                    if (HolyLevel > LightLevel)
                        LightLevel = HolyLevel;
                }
                else if (passive.Name == "Arcane Mastery")
                {
                    ArcaneLevel += 25;
                    IllusionLevel += 25;
                    MindLevel += 25;
                }
                else if (passive.Name == "Elemental Mage")
                {
                    FireLevel += 25;
                    HeatLevel += 25;
                    LavaLevel += 25;

                    WaterLevel += 25;
                    LiquidLevel += 25;
                    IceLevel += 25;

                    AirLevel += 25;
                    WindLevel += 25;
                    LightningLevel += 25;

                    EarthLevel += 25;
                    NatureLevel += 25;
                    PoisonLevel += 25;
                }
                else if (passive.Name == "Mind Master")
                {
                    MindLevel += 100;
                    if (MindLevel > ArcaneLevel)
                        ArcaneLevel = MindLevel;
                }
                else if (passive.Name == "All rounder Mage")
                {
                    ArcaneLevel += 25;
                    MindLevel += 25;
                    IllusionLevel += 25;
                    FireLevel += 25;
                    HeatLevel += 25;
                    LavaLevel += 25;
                    WaterLevel += 25;
                    LiquidLevel += 25;
                    IceLevel += 25;
                    AirLevel += 25;
                    WindLevel += 25;
                    LightningLevel += 25;
                    EarthLevel += 25;
                    PoisonLevel += 25;
                    NatureLevel += 25;
                    LightLevel += 25;
                    HolyLevel += 25;
                    SpaceLevel += 25;
                    DarkLevel += 25;
                    CurseLevel += 25;
                    NecromancyLevel += 25;
                }
                else if (passive.Name == "Fire Mastery")
                {
                    FireLevel += 50;
                    HeatLevel += 50;
                    LavaLevel += 50;
                }
                else if (passive.Name == "Creature of Light")
                {
                    LightLevel += 25;
                    HolyLevel += 25;
                    SpaceLevel += 25;
                }
                else if (passive.Name == "Sorcery")
                {
                    CurseLevel += 50;
                    if (CurseLevel > DarkLevel)
                        DarkLevel = CurseLevel;
                }
                else if (passive.Name == "Darkness")
                {
                    DarkLevel += 50;
                    CurseLevel += 50;
                    NecromancyLevel += 50;
                }
                else if (passive.Name == "Illusion Master")
                {
                    IllusionLevel += 100;
                    if (IllusionLevel > ArcaneLevel)
                        ArcaneLevel = IllusionLevel;
                }
                else if (passive.Name == "Aeromancy")
                {
                    AirLevel += 60;
                    WindLevel += 60;
                    LightningLevel += 60;
                }
                else if (passive.Name == "Hydromancy")
                {
                    WaterLevel += 60;
                    LiquidLevel += 60;
                    IceLevel += 60;
                }
                else if (passive.Name == "Pyromancy")
                {
                    FireLevel += 60;
                    LavaLevel += 60;
                    HeatLevel += 60;
                }
                else if (passive.Name == "Geomancy")
                {
                    EarthLevel += 60;
                    PoisonLevel += 60;
                    NatureLevel += 60;
                }
                else if (passive.Name == "King of Blood Giovanni")
                {
                    CurseLevel += 100;
                    if (CurseLevel > DarkLevel)
                        DarkLevel = CurseLevel;

                    MindLevel += 100;
                    if (MindLevel > ArcaneLevel)
                        ArcaneLevel = MindLevel;
                }
                else if (passive.Name == "Magic User")
                {
                    ArcaneLevel += 30;
                    MindLevel += 30;
                    IllusionLevel += 30;

                    DarkLevel += 30;
                    CurseLevel += 30;
                    NecromancyLevel += 30;
                }
                else if (passive.Name == "Primordial Chaos")
                {
                    DarkLevel += 150;
                    CurseLevel += 150;
                    NecromancyLevel += 150;
                }
                else if (passive.Name == "Dark Artist")
                {
                    DarkLevel += 80;
                    CurseLevel += 80;
                    NecromancyLevel += 80;
                }
                else if (passive.Name == "Necromancy")
                {
                    DarkLevel += 150;
                    CurseLevel += 50;
                    NecromancyLevel += 100;
                }
                else if (passive.Name == "Magic Mastery")
                {
                    ArcaneLevel += 100;
                    MindLevel += 100;
                    IllusionLevel += 100;
                    FireLevel += 100;
                    HeatLevel += 100;
                    LavaLevel += 100;
                    WaterLevel += 100;
                    LiquidLevel += 100;
                    IceLevel += 100;
                    AirLevel += 100;
                    WindLevel += 100;
                    LightningLevel += 100;
                    EarthLevel += 100;
                    PoisonLevel += 100;
                    NatureLevel += 100;
                    LightLevel += 100;
                    HolyLevel += 100;
                    SpaceLevel += 100;
                    DarkLevel += 100;
                    CurseLevel += 100;
                    NecromancyLevel += 100;
                }

                else if (passive.Name == "Aptitude")
                {
                    HPGrowth += 10;
                    StrengthGrowth += 10;
                    MagicGrowth += 10;
                    DefenseGrowth += 10;
                    ResistanceGrowth += 10;
                    SpeedGrowth += 10;
                    SkillGrowth += 10;
                    LuckGrowth += 10;
                    SpiritGrowth += 10;
                }
                else if (passive.Name == "Ascended God of Humanity Arkath")
                {
                    HPGrowth += 100;
                    StrengthGrowth += 100;
                    MagicGrowth += 100;
                    DefenseGrowth += 100;
                    ResistanceGrowth += 100;
                    SpeedGrowth += 100;
                    SkillGrowth += 100;
                    LuckGrowth += 100;
                    SpiritGrowth += 100;
                }
                else if (passive.Name == "Magicless Asta") StrengthGrowth += 200;
                else if (passive.Name == "Heroic Desire")
                {
                    HPGrowth += 5;
                    StrengthGrowth += 5;
                    MagicGrowth += 5;
                    DefenseGrowth += 5;
                    ResistanceGrowth += 5;
                    SpeedGrowth += 5;
                    SkillGrowth += 5;
                    LuckGrowth += 5;
                    SpiritGrowth += 5;
                }
                else if (passive.Name == "Mage Prodigy")
                {
                    MagicGrowth += 15;
                    SpiritGrowth += 15;
                }
                else if (passive.Name == "Perseverant") HPGrowth += 10;
                else if (passive.Name == "Strong") Strength += 10;
                else if (passive.Name == "Intelligent") MagicGrowth += 10;
                else if (passive.Name == "Tanky") DefenseGrowth += 10;
                else if (passive.Name == "Resilient") ResistanceGrowth += 10;
                else if (passive.Name == "Skilled") SkillGrowth += 10;
                else if (passive.Name == "Fast") SpeedGrowth += 10;
                else if (passive.Name == "Lucky") LuckGrowth += 10;
                else if (passive.Name == "Adept") SpiritGrowth += 10;
                else if (passive.Name == "Trash")
                {
                    HPGrowth -= 5;
                    StrengthGrowth -= 5;
                    MagicGrowth -= 5;
                    DefenseGrowth -= 5;
                    ResistanceGrowth -= 5;
                    SpeedGrowth -= 5;
                    SkillGrowth -= 5;
                    LuckGrowth -= 5;
                    SpiritGrowth -= 5;
                }
            }
        }
        public void addStatus(CharacterStatus status) {
            if (!Status.Contains(status)) {
                switch (status)
                {
                    case CharacterStatus.BURNED:
                        Status.Add(CharacterStatus.BURNED);
                        break;
                    case CharacterStatus.PARALYZED:
                        Status.Add(CharacterStatus.PARALYZED);
                        break;
                    case CharacterStatus.FREEZE:
                        Status.Add(CharacterStatus.FREEZE);
                        break;
                    case CharacterStatus.WET:
                        Status.Add(CharacterStatus.WET);
                        break;
                    case CharacterStatus.POISON:
                        Status.Add(CharacterStatus.POISON);
                        break;
                    case CharacterStatus.PETRIFIED:
                        Status.Add(CharacterStatus.PETRIFIED);
                        break;
                    case CharacterStatus.BLEEDING:
                        Status.Add(CharacterStatus.BLEEDING);
                        break;
                    case CharacterStatus.CURSE_HP:
                        Status.Add(CharacterStatus.CURSE_HP);
                        CombatHP -= 10;
                        break;
                    case CharacterStatus.CURSE_STRENGTH:
                        Status.Add(CharacterStatus.CURSE_STRENGTH);
                        CombatStrength -= 5;
                        break;
                    case CharacterStatus.CURSE_MAGIC:
                        Status.Add(CharacterStatus.CURSE_MAGIC);
                        CombatMagic -= 5;
                        break;
                    case CharacterStatus.CURSE_DEFENSE:
                        Status.Add(CharacterStatus.CURSE_DEFENSE);
                        CombatDefense -= 5;
                        break;
                    case CharacterStatus.CURSE_RESISTANCE:
                        Status.Add(CharacterStatus.CURSE_RESISTANCE);
                        CombatResistance -= 5;
                        break;
                    case CharacterStatus.CURSE_SPEED:
                        Status.Add(CharacterStatus.CURSE_SPEED);
                        CombatSpeed -= 5;
                        break;
                    case CharacterStatus.CURSE_SKILL:
                        Status.Add(CharacterStatus.CURSE_SKILL);
                        CombatSkill -= 5;
                        break;
                    case CharacterStatus.CURSE_LUCK:
                        Status.Add(CharacterStatus.CURSE_LUCK);
                        CombatLuck -= 5;
                        break;
                    case CharacterStatus.CURSE_SPIRIT:
                        Status.Add(CharacterStatus.CURSE_SPIRIT);
                        CombatSpirit -= 10;
                        break;
                    case CharacterStatus.BLESS_HP:
                        Status.Add(CharacterStatus.BLESS_HP);
                        CombatHP += 10;
                        break;
                    case CharacterStatus.BLESS_STRENGTH:
                        Status.Add(CharacterStatus.BLESS_STRENGTH);
                        CombatStrength += 5;
                        break;
                    case CharacterStatus.BLESS_MAGIC:
                        Status.Add(CharacterStatus.BLESS_MAGIC);
                        CombatMagic += 5;
                        break;
                    case CharacterStatus.BLESS_DEFENSE:
                        Status.Add(CharacterStatus.BLESS_DEFENSE);
                        CombatDefense += 5;
                        break;
                    case CharacterStatus.BLESS_RESISTANCE:
                        Status.Add(CharacterStatus.BLESS_RESISTANCE);
                        CombatResistance += 5;
                        break;
                    case CharacterStatus.BLESS_SPEED:
                        Status.Add(CharacterStatus.BLESS_SPEED);
                        CombatSpeed += 5;
                        break;
                    case CharacterStatus.BLESS_SKILL:
                        Status.Add(CharacterStatus.BLESS_SKILL);
                        CombatSkill += 5;
                        break;
                    case CharacterStatus.BLESS_LUCK:
                        Status.Add(CharacterStatus.BLESS_LUCK);
                        CombatLuck += 5;
                        break;
                    case CharacterStatus.BLESS_SPIRIT:
                        Status.Add(CharacterStatus.BLESS_SPIRIT);
                        CombatSpirit += 10;
                        break;
                    default:
                        break;
                }
            }
        }

        public void levelUp(int levelLimit)
        {
            if (Level < levelLimit)
            {
                Random rnd = new Random();
                Level++;

                if (Level == 10)
                    addPassive(Class.ClassPassives[0]);
                else if (Level == 20)
                    addPassive(Class.ClassPassives[1]);

                int hp = GetHPGrowth;
                int strength = GetStrengthGrowth;
                int magic = GetMagicGrowth;
                int defense = GetDefenseGrowth;
                int resistance = GetResistanceGrowth;
                int speed = GetSpeedGrowth;
                int skill = GetSkillGrowth;
                int luck = GetLuckGrowth;
                int spirit = GetSpiritGrowth;

                if (hp >= 100) 
                {
                    HP += (hp - (hp % 100));
                    hp = hp % 100;
                }
                if (strength >= 100)
                {
                    Strength += (strength - (strength % 100));
                    strength = strength % 100;
                }
                if (magic >= 100)
                {
                    Magic += (magic - (magic % 100));
                    magic = magic % 100;
                }
                if (defense >= 100)
                {
                    
                    Defense += (defense - (defense % 100));
                    defense = defense % 100;
                }
                if (resistance >= 100)
                {
                    Resistance += (resistance - (resistance % 100));
                    resistance = resistance % 100;
                }
                if (speed >= 100)
                {
                    Speed += (speed - (speed % 100));
                    speed = speed % 100;
                }
                if (skill >= 100)
                {
                    Skill += (skill - (skill % 100));
                    skill = skill % 100;
                }
                if (luck >= 100)
                {
                    Luck += (luck - (luck % 100));
                    luck = luck % 100;
                }
                if (spirit >= 100)
                {
                    Spirit += (spirit - (spirit % 100));
                    spirit = spirit % 100;
                }

                if (rnd.Next(0, 101) <= hp) HP++;
                if (rnd.Next(0, 101) <= strength) Strength++;
                if (rnd.Next(0, 101) <= magic) Magic++;
                if (rnd.Next(0, 101) <= defense) Defense++;
                if (rnd.Next(0, 101) <= resistance) Resistance++;
                if (rnd.Next(0, 101) <= speed) Speed++;
                if (rnd.Next(0, 101) <= skill) Skill++;
                if (rnd.Next(0, 101) <= luck) Luck++;
                if (rnd.Next(0, 101) <= spirit) Spirit++;

                verifyStatRank();
            }
        }
        public void rest()
        {
            CombatHP = HP;
            CombatStrength = Strength + Weapon.getBonusStrength();
            CombatMagic = Magic + Weapon.getBonusMagic();
            CombatDefense = Defense + Weapon.getBonusDefense() + Armor.getBonusDefense();
            CombatResistance = Resistance + Weapon.getBonusResistance() + Armor.getBonusResistance();
            CombatSpeed = Speed + Weapon.getBonusSpeed() + Armor.getBonusSpeed();
            CombatSkill = Skill + Weapon.getBonusSkill();
            CombatLuck = Luck + Weapon.getBonusLuck();
            CombatSpirit = Spirit;
        }


        public void takeDamage(int damageTaken) {
            if (CombatHP >= damageTaken)
                CombatHP -= damageTaken;
            else
                CombatHP = 0;
        }
        public void healDamage(int healReceived) {
            if (healReceived >= HP)
                CombatHP = HP;
            else
                CombatHP += healReceived;
        }
        public void useMana(int manaUsed) {
            if (CombatSpirit >= manaUsed)
                CombatSpirit -= manaUsed;
            else
                CombatSpirit = 0;
        }


        private int weaponRankBonusDamage()
        {
            int bonus = 0;
            switch (Weapon.Type) {
                case WeaponType.SWORD:
                    switch (Sword) {
                        case WeaponRank.D:
                            bonus += 1;
                            break;
                        case WeaponRank.C:
                            bonus += 2;
                            break;
                        case WeaponRank.B:
                            bonus += 3;
                            break;
                        case WeaponRank.A:
                            bonus += 4;
                            break;
                        case WeaponRank.S:
                            bonus += 5;
                            break;
                    }
                    break;

                case WeaponType.SPEAR:
                    switch (Spear)
                    {
                        case WeaponRank.D:
                            bonus += 1;
                            break;
                        case WeaponRank.C:
                            bonus += 2;
                            break;
                        case WeaponRank.B:
                            bonus += 3;
                            break;
                        case WeaponRank.A:
                            bonus += 4;
                            break;
                        case WeaponRank.S:
                            bonus += 5;
                            break;
                    }
                    break;

                case WeaponType.AXE:
                    switch (Axe)
                    {
                        case WeaponRank.D:
                            bonus += 1;
                            break;
                        case WeaponRank.C:
                            bonus += 2;
                            break;
                        case WeaponRank.B:
                            bonus += 3;
                            break;
                        case WeaponRank.A:
                            bonus += 4;
                            break;
                        case WeaponRank.S:
                            bonus += 5;
                            break;
                    }
                    break;

                case WeaponType.FIST:
                    switch (Fist)
                    {
                        case WeaponRank.D:
                            bonus += 1;
                            break;
                        case WeaponRank.C:
                            bonus += 2;
                            break;
                        case WeaponRank.B:
                            bonus += 3;
                            break;
                        case WeaponRank.A:
                            bonus += 4;
                            break;
                        case WeaponRank.S:
                            bonus += 5;
                            break;
                    }
                    break;

                case WeaponType.DAGGER:
                    switch (Dagger)
                    {
                        case WeaponRank.D:
                            bonus += 1;
                            break;
                        case WeaponRank.C:
                            bonus += 2;
                            break;
                        case WeaponRank.B:
                            bonus += 3;
                            break;
                        case WeaponRank.A:
                            bonus += 4;
                            break;
                        case WeaponRank.S:
                            bonus += 5;
                            break;
                    }
                    break;

                case WeaponType.STAFF:
                    switch (Staff)
                    {
                        case WeaponRank.D:
                            bonus += 1;
                            break;
                        case WeaponRank.C:
                            bonus += 2;
                            break;
                        case WeaponRank.B:
                            bonus += 3;
                            break;
                        case WeaponRank.A:
                            bonus += 4;
                            break;
                        case WeaponRank.S:
                            bonus += 5;
                            break;
                    }
                    break;

                case WeaponType.BOW:
                    switch (Bow)
                    {
                        case WeaponRank.D:
                            bonus += 1;
                            break;
                        case WeaponRank.C:
                            bonus += 2;
                            break;
                        case WeaponRank.B:
                            bonus += 3;
                            break;
                        case WeaponRank.A:
                            bonus += 4;
                            break;
                        case WeaponRank.S:
                            bonus += 5;
                            break;
                    }
                    break;

                default:
                    break;
            }

            return bonus;
        }
        private int weaponRankBonusHit()
        {
            int bonus = 0;
            switch (Weapon.Type)
            {
                case WeaponType.SWORD:
                    switch (Sword)
                    {
                        case WeaponRank.D:
                            bonus += 2;
                            break;
                        case WeaponRank.C:
                            bonus += 4;
                            break;
                        case WeaponRank.B:
                            bonus += 6;
                            break;
                        case WeaponRank.A:
                            bonus += 8;
                            break;
                        case WeaponRank.S:
                            bonus += 10;
                            break;
                    }
                    break;

                case WeaponType.SPEAR:
                    switch (Spear)
                    {
                        case WeaponRank.D:
                            bonus += 2;
                            break;
                        case WeaponRank.C:
                            bonus += 4;
                            break;
                        case WeaponRank.B:
                            bonus += 6;
                            break;
                        case WeaponRank.A:
                            bonus += 8;
                            break;
                        case WeaponRank.S:
                            bonus += 10;
                            break;
                    }
                    break;

                case WeaponType.AXE:
                    switch (Axe)
                    {
                        case WeaponRank.D:
                            bonus += 2;
                            break;
                        case WeaponRank.C:
                            bonus += 4;
                            break;
                        case WeaponRank.B:
                            bonus += 6;
                            break;
                        case WeaponRank.A:
                            bonus += 8;
                            break;
                        case WeaponRank.S:
                            bonus += 10;
                            break;
                    }
                    break;

                case WeaponType.FIST:
                    switch (Fist)
                    {
                        case WeaponRank.D:
                            bonus += 2;
                            break;
                        case WeaponRank.C:
                            bonus += 4;
                            break;
                        case WeaponRank.B:
                            bonus += 6;
                            break;
                        case WeaponRank.A:
                            bonus += 8;
                            break;
                        case WeaponRank.S:
                            bonus += 10;
                            break;
                    }
                    break;

                case WeaponType.DAGGER:
                    switch (Dagger)
                    {
                        case WeaponRank.D:
                            bonus += 2;
                            break;
                        case WeaponRank.C:
                            bonus += 4;
                            break;
                        case WeaponRank.B:
                            bonus += 6;
                            break;
                        case WeaponRank.A:
                            bonus += 8;
                            break;
                        case WeaponRank.S:
                            bonus += 10;
                            break;
                    }
                    break;

                case WeaponType.STAFF:
                    switch (Staff)
                    {
                        case WeaponRank.D:
                            bonus += 2;
                            break;
                        case WeaponRank.C:
                            bonus += 4;
                            break;
                        case WeaponRank.B:
                            bonus += 6;
                            break;
                        case WeaponRank.A:
                            bonus += 8;
                            break;
                        case WeaponRank.S:
                            bonus += 10;
                            break;
                    }
                    break;

                case WeaponType.BOW:
                    switch (Bow)
                    {
                        case WeaponRank.D:
                            bonus += 2;
                            break;
                        case WeaponRank.C:
                            bonus += 4;
                            break;
                        case WeaponRank.B:
                            bonus += 6;
                            break;
                        case WeaponRank.A:
                            bonus += 8;
                            break;
                        case WeaponRank.S:
                            bonus += 10;
                            break;
                    }
                    break;

                default:
                    break;
            }

            return bonus;
        }


        private int avoidBonus(Character enemy, bool IsNight, bool IsIndoor, bool Initiated)
        {
            int avoid = 0;

            foreach (Passive passive in CharacterPassives.ToList()) {
                if (passive.Name == "Underdog" && Level < enemy.Level)
                    avoid += 10;
                else if (passive.Name == "Nocture Creature" && IsNight)
                    avoid += 10;
                else if (passive.Name == "Fly Mobility")
                    avoid += 15;
                else if (passive.Name == "Outdoor Fighter" && !IsIndoor)
                    avoid += 20;
                else if (passive.Name == "Duelist Blow" && Initiated)
                    avoid += 10;
                else if (passive.Name == "Avoid+X")
                    avoid += 10;
                else if (passive.Name == "Fly Breaker" && enemy.Types.Contains(CharacterType.FLYING))
                    avoid += 10;
                else if (passive.Name == "Magic Breaker" && enemy.getTotalMagic() >= 50)
                    avoid += 20;
                else if (passive.Name == "Dead Creature" && enemy.Types.Contains(CharacterType.VOID))
                    avoid += 10;
                else if (passive.Name == "Creature of the Void" && enemy.Types.Contains(CharacterType.HOLY))
                    avoid += 10;
                else if (passive.Name == "Swordbreaker" && enemy.Weapon.Type == WeaponType.SWORD)
                    avoid += 50;
                else if (passive.Name == "Sword Breaker" && enemy.Weapon.Type == WeaponType.SWORD)
                    avoid += 50;
                else if (passive.Name == "Air Superiority" && enemy.Types.Contains(CharacterType.FLYING))
                    avoid += 30;
                else if (passive.Name == "Slayer" && !enemy.Types.Contains(CharacterType.HUMANOID))
                    avoid += 15;
                else if (passive.Name == "Beast Killer" && enemy.Types.Contains(CharacterType.MOUNTED))
                    avoid += 25;
                else if (passive.Name == "Quick Burn")
                    avoid += 15;
                else if (passive.Name == "Dagger Breaker" && enemy.Weapon.Type == WeaponType.DAGGER)
                    avoid += 50;
                else if (passive.Name == "Angel's Blessing")
                    avoid += (int)(0.5 * enemy.DarkLevel);
                else if (passive.Name == "Untouchable")
                    avoid += 50;
            }

            foreach (Passive passive in CharacterPassives.ToList()) {
                if (passive.Name == "Heartseeker")
                    avoid -= 20;
            }

            return avoid;
        }
        public int characterAvoid(Character enemy, bool isNight, bool isIndoor, bool initiated)
        {
            int bonusAvoid = 0;
            if (!enemy.CharacterPassives.Contains(enemy.CharacterPassives.Where(c => c.Name == "Great Corruption Ythil").SingleOrDefault()))
                bonusAvoid = avoidBonus(enemy, isNight, isIndoor, initiated);
            return ((Speed * 3 + Luck) / 2) + bonusAvoid;
        }


        private int hitBonus(Character enemy, bool isNight, bool isIndoor, bool initiated)
        {
            int bonus = 0;

            if (!enemy.CharacterPassives.Contains(enemy.CharacterPassives.Where(c => c.Name == "Great Corruption Ythil").SingleOrDefault())) {
                foreach (Passive passive in CharacterPassives.ToList()) {
                    if (passive.Name == "Gamble")
                        bonus -= 5;
                    else if (passive.Name == "Underdog" && Level < enemy.Level)
                        bonus += 10;
                    else if (passive.Name == "Nocture Creature" && isNight)
                        bonus += 10;
                    else if (passive.Name == "Outdoor Fighter" && !isIndoor)
                        bonus += 20;
                    else if (passive.Name == "No Honor")
                        bonus += 15;
                    else if (passive.Name == "Prescience" && initiated)
                        bonus += 10;
                    else if (passive.Name == "Fly Breaker" && enemy.Types.Contains(CharacterType.FLYING))
                        bonus += 30;
                    else if (passive.Name == "Magic Breaker" && enemy.getTotalMagic() >= 50)
                        bonus += 25;
                    else if (passive.Name == "Dead Creature" && enemy.Types.Contains(CharacterType.VOID))
                        bonus += 10;
                    else if (passive.Name == "Creature of the Void" && enemy.Types.Contains(CharacterType.HOLY))
                        bonus += 10;
                    else if (passive.Name == "Swordbreaker" && enemy.Weapon.Type == WeaponType.SWORD)
                        bonus += 50;
                    else if (passive.Name == "Sword Breaker" && enemy.Weapon.Type == WeaponType.SWORD)
                        bonus += 50;
                    else if (passive.Name == "Exemple")
                        bonus += 10;
                    else if (passive.Name == "Slayer" && !enemy.Types.Contains(CharacterType.HUMANOID))
                        bonus += 15;
                    else if (passive.Name == "Beast Killer" && enemy.Types.Contains(CharacterType.MOUNTED))
                        bonus += 25;
                    else if (passive.Name == "Quick Burn")
                        bonus += 15;
                    else if (passive.Name == "Dagger Breaker" && enemy.Weapon.Type == WeaponType.DAGGER)
                        bonus += 50;
                    else if (passive.Name == "Certain Blow" && initiated)
                        bonus += 40;
                    else if (passive.Name == "Angel's Blessing")
                        bonus += (int)(0.5 * enemy.DarkLevel);
                }
            }

            if (!CharacterPassives.Contains(CharacterPassives.Where(c => c.Name == "Great Corruption Ythil").SingleOrDefault())) {
                foreach (Passive passive in enemy.CharacterPassives.ToList()) {
                    if (passive.Name == "Heartseeker")
                        bonus -= 20;
                }
            }

            return bonus;
        }
        public int characterNormalHit(Character enemy, bool isNight, bool isIndoor, bool initiated)
        {
            int bonusHit;
            bonusHit = hitBonus(enemy, isNight, isIndoor, initiated);
            return Weapon.Accuracy + weaponRankBonusHit() + ((Skill * 3 + Luck) / 2) + bonusHit;
        }
        public int characterSkillHit(Character enemy, Skill skill, bool isNight, bool isIndoor, bool initiated)
        {
            int bonusHit;
            bonusHit = hitBonus(enemy, isNight, isIndoor, initiated);
            bonusHit += skill.Purpose == SkillPurpose.OFFENCE_BOOST ? Weapon.Accuracy : 0;
            bonusHit += skill.Purpose == SkillPurpose.OFFENCE_BOOST ? weaponRankBonusHit() : 0;
            bonusHit += getSpiritLevel() * skill.AccuracyGain;

            return skill.Accuracy + ((Skill * 3 + Luck) / 2) + bonusHit;
        }


        private int critBonus(Character enemy, bool alone, bool isMagic, bool initiated)
        {
            int bonus = 0;

            if (!enemy.CharacterPassives.Contains(enemy.CharacterPassives.Where(c => c.Name == "Great Corruption Ythil").SingleOrDefault())) {
                foreach (Passive passive in CharacterPassives.ToList()) {
                    if (passive.Name == "Gamble")
                        bonus += 10;
                    else if (passive.Name == "Zeal")
                        bonus += 5;
                    else if (passive.Name == "Enrage" && CombatHP <= HP / 2)
                        bonus += 10;
                    else if (passive.Name == "Prescience" && initiated)
                        bonus += 10;
                    else if (passive.Name == "Focus" && alone)
                        bonus += 10;
                    else if (passive.Name == "God of Magic Asha" && isMagic)
                        bonus += 15;
                    else if (passive.Name == "True Dragon of Wrath Arthan")
                        bonus += 15;
                }
            }

            if (!CharacterPassives.Contains(CharacterPassives.Where(c => c.Name == "Great Corruption Ythil").SingleOrDefault())) {
                foreach (Passive passive in enemy.CharacterPassives.ToList()) {
                    if (passive.Name == "Veteran Intuition")
                        bonus -= 15;
                }
            }

            return bonus;
        }
        public int characterNormalCrit(Character enemy, bool alone, bool isMagic, bool initiated)
        {
            int bonusCrit;
            bonusCrit = critBonus(enemy, alone, isMagic, initiated);
            return Weapon.Crit + (Skill / 2) + bonusCrit;
        }
        public int characterSkillCrit(Character enemy, Skill skill, bool alone, bool isMagic, bool initiated) {
            int bonusCrit;
            bonusCrit = critBonus(enemy, alone, isMagic, initiated);
            bonusCrit += skill.Purpose == SkillPurpose.OFFENCE_BOOST ? Weapon.Crit : 0;
            bonusCrit += getSpiritLevel() * skill.CritGain;
            return skill.Crit + (Skill / 2) + bonusCrit;
        }


        private int damageBonus(Character enemy, int tileAway, bool isIndoor, bool isMagic, bool initiated, bool hasWeapon)
        {
            int bonus = 0;

            if (!enemy.CharacterPassives.Contains(enemy.CharacterPassives.Where(c => c.Name == "Great Corruption Ythil").SingleOrDefault())) {
                foreach (Passive passive in CharacterPassives.ToList()) {
                    if (passive.Name == "Ranged")
                        bonus += 1 * tileAway;
                    else if (passive.Name == "Elbow Room" && !isIndoor)
                        bonus += 3;
                    else if (passive.Name == "Mount Bane" && enemy.Types.Contains(CharacterType.MOUNTED) && hasWeapon)
                        bonus += 5;
                    else if (passive.Name == "Swordfaire" && Weapon.Type == WeaponType.SWORD && hasWeapon)
                        bonus += 5;
                    else if (passive.Name == "Bowfaire" && Weapon.Type == WeaponType.BOW && hasWeapon)
                        bonus += 5;
                    else if (passive.Name == "Quick Draw" && initiated)
                        bonus += 4;
                    else if (passive.Name == "Malefic Aura" && tileAway <= 2)
                        bonus += 2;
                    else if (passive.Name == "Lancefaire" && Weapon.Type == WeaponType.SPEAR && hasWeapon)
                        bonus += 5;
                    else if (passive.Name == "Aggressor" && initiated)
                        bonus += 10;
                    else if (passive.Name == "Axefaire" && Weapon.Type == WeaponType.AXE && hasWeapon)
                        bonus += 5;
                    else if (passive.Name == "Life and Death")
                        bonus += 10;
                    else if (passive.Name == "No Mercy" && Level > enemy.Level)
                        bonus += 15;
                    else if (passive.Name == "Ultra Bowfaire" && Weapon.Type == WeaponType.BOW && hasWeapon)
                        bonus += 10;
                    else if (passive.Name == "Witch Hunt")
                        bonus += (int)(0.5 * enemy.DarkLevel);
                    else if (passive.Name == "Holy Crusade" && (enemy.Types.Contains(CharacterType.DEMONOID) || enemy.Types.Contains(CharacterType.MONSTER)))
                        bonus += 20;
                    else if (passive.Name == "Body of Fire" && isMagic && CombatHP == HP)
                        bonus += 5;
                    else if (passive.Name == "Fistfaire" && Weapon.Type == WeaponType.FIST && hasWeapon)
                        bonus += 10;
                    else if (passive.Name == "Vengeance")
                        bonus += (HP - CombatHP) / 2;
                    else if (passive.Name == "Trample" && !enemy.Types.Contains(CharacterType.MOUNTED))
                        bonus += 5;
                }
            }

            return bonus;
        }
        public int characterNormalDamage(Character enemy, int tileAway, int multiplicator, bool isIndoor, bool isMagic, bool initiated)
        {
            int damage = 0;
            int reduction = 0;
            float effective = 1;

            damage += damageBonus(enemy, tileAway, isIndoor, isMagic, initiated, true);

            if (isMagic)
                damage += Magic + weaponRankBonusDamage() + Weapon.Damage;
            else
                damage += Strength + weaponRankBonusDamage() + Weapon.Damage + Weapon.bonusMagicDamage();

            if (!CharacterPassives.Contains(CharacterPassives.Where(c => c.Name == "Great Corruption Ythil").SingleOrDefault()))
                reduction += enemy.resistance(isMagic, initiated);
            reduction += enemy.Armor.Power;
            reduction += damage*enemy.resistance(Weapon.DamageType);

            

            effective = effectivness(enemy, true);

            // Enemy defensive active

            return (int)(((damage*multiplicator)*effective)-reduction);
        }

        public float effectivness(Character enemy, bool isWeapon, Skill skill = null)
        {
            float effective = 1;

            if (!enemy.CharacterPassives.Contains(enemy.CharacterPassives.Where(c => c.Name == "Conquest").SingleOrDefault()) &&
                !CharacterPassives.Contains(CharacterPassives.Where(c => c.Name == "Great Corruption Ythil").SingleOrDefault())) {
                if (!enemy.CharacterPassives.Contains(enemy.CharacterPassives.Where(c => c.Name == "Great Corruption Ythil").SingleOrDefault())) {
                    foreach (Passive passive in CharacterPassives.ToList())
                    {
                        if (passive.Name == "Beastbane" && enemy.Types.Contains(CharacterType.BEAST))
                            effective *= 1.5f;
                        else if (passive.Name == "Wrymsbane" && enemy.Types.Contains(CharacterType.DRAGONOID))
                            effective *= 1.5f;
                    }
                }

                if (isWeapon) {
                    foreach (Passive passive in Weapon.WeaponPassives.ToList()) {
                        if (passive.Name == "Effective agains't Armored" && enemy.Types.Contains(CharacterType.ARMORED))
                            effective *= 1.5f;
                        else if (passive.Name == "Effective agains't Flying" && enemy.Types.Contains(CharacterType.FLYING))
                            effective *= 1.5f;
                        else if (passive.Name == "Effective agains't Mounted" && enemy.Types.Contains(CharacterType.MOUNTED))
                            effective *= 1.5f;
                        else if (passive.Name == "Effective agains't Beast" && enemy.Types.Contains(CharacterType.BEAST))
                            effective *= 1.5f;
                        else if (passive.Name == "Effective agains't Dragon" && enemy.Types.Contains(CharacterType.DRAGONOID))
                            effective *= 1.5f;
                        else if (passive.Name == "Effective agains't Void" && enemy.Types.Contains(CharacterType.VOID))
                            effective *= 1.5f;
                        else if (passive.Name == "Effective agains't Undead" && enemy.Types.Contains(CharacterType.UNDEAD))
                            effective *= 1.5f;
                        else if (passive.Name == "Effective agains't Demon" && enemy.Types.Contains(CharacterType.DEMONOID))
                            effective *= 1.5f;
                        else if (passive.Name == "Effective agains't Monster" && enemy.Types.Contains(CharacterType.MONSTER))
                            effective *= 1.5f;
                        else if (passive.Name == "Effective agains't Human" && enemy.Types.Contains(CharacterType.HUMANOID))
                            effective *= 1.5f;
                    }

                    if ((Weapon.DamageType == DamageType.LIGHTNING || Weapon.DamageType == DamageType.WIND) && enemy.Types.Contains(CharacterType.FLYING))
                        effective *= 1.5f;
                    if (Weapon.DamageType == DamageType.PHYSICAL && enemy.Types.Contains(CharacterType.ARMORED))
                        effective /= 2;
                    if (Weapon.DamageType == DamageType.HOLY &&
                        (enemy.Types.Contains(CharacterType.UNDEAD) || enemy.Types.Contains(CharacterType.UNDEAD) || enemy.Types.Contains(CharacterType.MONSTER) || enemy.Types.Contains(CharacterType.DEMONOID)))
                        effective *= 1.5f;
                    if (Weapon.DamageType == DamageType.HOLY && enemy.Types.Contains(CharacterType.VOID))
                        effective /= 2;
                    if (Weapon.DamageType == DamageType.DARK && enemy.Types.Contains(CharacterType.VOID))
                        effective *= 1.5f;
                    if (Weapon.DamageType == DamageType.DARK && enemy.Types.Contains(CharacterType.HOLY))
                        effective /= 2;
                }

                if (skill != null) {
                    foreach (Passive passive in skill.SkillPassives.ToList()) {
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

                    if ((skill.MagicType == MagicType.LIGHTNING || skill.MagicType == MagicType.WIND) && enemy.Types.Contains(CharacterType.FLYING))
                        effective *= 1.5f;
                    if ((skill.MagicType == MagicType.CURSE || skill.MagicType == MagicType.NECROMANCY) && enemy.Types.Contains(CharacterType.VOID))
                        effective *= 1.5f;
                    if ((skill.MagicType == MagicType.CURSE || skill.MagicType == MagicType.NECROMANCY) && enemy.Types.Contains(CharacterType.HOLY))
                        effective /= 2;
                    if (skill.MagicType == MagicType.HOLY &&
                        (enemy.Types.Contains(CharacterType.UNDEAD) || enemy.Types.Contains(CharacterType.UNDEAD) || enemy.Types.Contains(CharacterType.MONSTER) || enemy.Types.Contains(CharacterType.DEMONOID)))
                        effective *= 1.5f;
                    if (skill.MagicType == MagicType.HOLY && enemy.Types.Contains(CharacterType.VOID))
                        effective /= 2;
                    if (skill.MagicType == MagicType.VOID && enemy.Types.Contains(CharacterType.HOLY))
                        effective *= 1.5f;
                    if (skill.MagicType == MagicType.VOID &&
                        (enemy.Types.Contains(CharacterType.UNDEAD) || enemy.Types.Contains(CharacterType.UNDEAD) || enemy.Types.Contains(CharacterType.MONSTER) || enemy.Types.Contains(CharacterType.DEMONOID)))
                        effective /= 2;
                    if (skill.MagicType == MagicType.PHYSICAL && enemy.Types.Contains(CharacterType.ARMORED))
                        effective /= 1.5f;
                    if (skill.MagicType == MagicType.CHAOS && enemy.Types.Contains(CharacterType.HUMANOID))
                        effective *= 1.5f;
                    if (skill.MagicType == MagicType.CORRUPTED_HOLY &&
                        (enemy.Types.Contains(CharacterType.UNDEAD) || enemy.Types.Contains(CharacterType.UNDEAD) || enemy.Types.Contains(CharacterType.MONSTER) || enemy.Types.Contains(CharacterType.DEMONOID) || enemy.Types.Contains(CharacterType.HOLY)))
                        effective *= 1.5f;
                }
            }
            

            if (!CharacterPassives.Contains(CharacterPassives.Where(c => c.Name == "Great Corruption Ythil").SingleOrDefault()) &&
                !CharacterPassives.Contains(CharacterPassives.Where(c => c.Name == "God-Slayer Yuuki").SingleOrDefault())) {
                foreach (Passive passive in enemy.CharacterPassives.ToList()) {
                    if (passive.Name == "Defensive Scale" && isWeapon && Weapon.DamageType == DamageType.PHYSICAL)
                        effective /= 2;
                    else if (passive.Name == "Defensive Scale" && skill.MagicType == MagicType.PHYSICAL)
                        effective /= 2;
                    else if (passive.Name == "Dark Art Protection" && isWeapon && Weapon.DamageType == DamageType.DARK)
                        effective /= 2;
                    else if (passive.Name == "Dark Art Protection" && (skill.MagicType == MagicType.CURSE || skill.MagicType == MagicType.NECROMANCY))
                        effective /= 2;
                    else if (passive.Name == "God of Happiness Saraphiel")
                        effective /= 3;
                }
            }

            return effective;
        }
        public int resistance(bool isMagic, bool initiated) {
            int resistance = 0;

            foreach (Passive passive in CharacterPassives) {
                if (passive.Name == "Great Armor")
                    resistance += 4;
                else if (passive.Name == "Armored Blow")
                    resistance += 10;
                else if (passive.Name == "Life and Death")
                    resistance -= 10;
                else if (passive.Name == "Warding Blow" && isMagic && initiated)
                    resistance += 10;
            }

            return resistance;
        }
        public int resistance(DamageType type)
        {
            switch (type) {
                case DamageType.PHYSICAL:
                    return 0;
                case DamageType.ARCANE:
                    return (MindLevel/2)/100;
                case DamageType.FIRE:
                    return (HeatLevel/2)/100;
                case DamageType.WATER:
                    return (LiquidLevel/2)/100;
                case DamageType.WIND:
                    return (WindLevel/2)/100;
                case DamageType.LIGHTNING:
                    return (LightningLevel/2)/100;
                case DamageType.EARTH:
                    return (NatureLevel/2)/100;
                case DamageType.HOLY:
                    return (HolyLevel/2)/100;
                case DamageType.DARK:
                    return (CurseLevel/2)/100;
                default:
                    return 0;
            }
        }
        public int resistance(MagicType type) {
            switch (type)
            {
                case MagicType.PHYSICAL:
                    return 0;
                case MagicType.ILLUSION:
                    return (IllusionLevel / 2) / 100;
                case MagicType.MIND:
                    return (MindLevel / 2) / 100;
                case MagicType.LAVA:
                    return (LavaLevel / 2) / 100;
                case MagicType.HEAT:
                    return (HeatLevel / 2) / 100;
                case MagicType.LIQUID:
                    return (LiquidLevel / 2) / 100;
                case MagicType.ICE:
                    return (IceLevel / 2) / 100;
                case MagicType.LIGHTNING:
                    return (LightningLevel / 2) / 100;
                case MagicType.WIND:
                    return (WindLevel / 2) / 100;
                case MagicType.NATURE:
                    return (NatureLevel / 2) / 100;
                case MagicType.POISON:
                    return (PoisonLevel / 2) / 100;
                case MagicType.HOLY:
                    return (HolyLevel / 2) / 100;
                case MagicType.SPACE:
                    return (SpaceLevel / 2) / 100;
                case MagicType.CURSE:
                    return (CurseLevel / 2) / 100;
                case MagicType.NECROMANCY:
                    return (NecromancyLevel / 2) / 100;
                case MagicType.CORRUPTED_HOLY:
                    return 0;
                case MagicType.OTHER_WORLD:
                    return 0;
                case MagicType.SPATIAL_TIME:
                    return 0;
                case MagicType.CHAOS:
                    return 0;
                default:
                    return 0;
            }
        }
    }
}
