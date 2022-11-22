using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsekaiDb.Domain.Entities
{
    public class Armor
    {
        public Guid ArmorId { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public ICollection<Passive> ArmorPassives { get; set; }

        // function
        public int getBonusDefense() {
            if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Defense+I").Single()))
                return 1;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Defense+II").Single()))
                return 2;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Defense+III").Single()))
                return 3;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Defense+IV").Single()))
                return 4;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Defense+V").Single()))
                return 5;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Defense+VI").Single()))
                return 6;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Defense+VII").Single()))
                return 7;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Defense+VIII").Single()))
                return 8;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Defense+IX").Single()))
                return 9;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Defense+X").Single()))
                return 10;
            else
                return 0;
        }
        public int getBonusResistance() {
            if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Resistance+I").Single()))
                return 1;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Resistance+II").Single()))
                return 2;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Resistance+III").Single()))
                return 3;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Resistance+IV").Single()))
                return 4;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Resistance+V").Single()))
                return 5;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Resistance+VI").Single()))
                return 6;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Resistance+VII").Single()))
                return 7;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Resistance+VIII").Single()))
                return 8;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Resistance+IX").Single()))
                return 9;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Resistance+X").Single()))
                return 10;
            else
                return 0;
        }
        public int getBonusSpeed() {
            if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Speed-I").Single()))
                return -1;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Speed-II").Single()))
                return -2;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Speed-III").Single()))
                return -3;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Speed-IV").Single()))
                return -4;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Speed-V").Single()))
                return -5;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Speed-VI").Single()))
                return -6;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Speed-+VII").Single()))
                return -7;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Speed-+VIII").Single()))
                return -8;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Speed-+IX").Single()))
                return -9;
            else if (ArmorPassives.Contains(ArmorPassives.Where(c => c.Name == "Speed-+X").Single()))
                return -10;
            else
                return 0;
        }
    }
}
