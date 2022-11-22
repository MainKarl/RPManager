using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IsekaiDb.Data.Enumerable;

namespace IsekaiDb.Domain.Entities
{
    public class Class
    {
        public Guid ClassId { get; set; }
        public string Name { get; set; }

        public int HPGrowth { get; set; }
        public int StrengthGrowth { get; set; }
        public int MagicGrowth { get; set; }
        public int DefenseGrowth { get; set; }
        public int ResistanceGrowth { get; set; }
        public int SpeedGrowth { get; set; }
        public int SkillGrowth { get; set; }
        public int LuckGrowth { get; set; }
        public int SpiritGrowth { get; set; }

        public ClassSeries Serie { get; set; }
        public List<Passive> ClassPassives { get; set; }

        // Function
        public string GetSerie()
        {
            switch (Serie) {
                case ClassSeries.MILITIA:
                    return "Militia";
                case ClassSeries.FIGHTER:
                    return "Fighter";
                case ClassSeries.SKIRMISHER:
                    return "Skirmisher";
                case ClassSeries.BOWMAN:
                    return "Bowman";
                case ClassSeries.MEDIC:
                    return "Medic";
                case ClassSeries.APPRENTICE:
                    return "Apprentice";
                case ClassSeries.MONSTER:
                    return "Monster";
                case ClassSeries.BEASTMAN:
                    return "Beastman";
                case ClassSeries.DEMON:
                    return "Demon";
                case ClassSeries.DRAKELING:
                    return "Drakeling";
                default:
                    return "";
            }
        }
    }
}
