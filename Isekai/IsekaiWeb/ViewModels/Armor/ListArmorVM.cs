using System;
using System.Collections.Generic;


namespace IsekaiWeb.ViewModels.Armor
{
    public class ListArmorVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public ICollection<IsekaiDb.Domain.Entities.Passive> ArmorPassives { get; set; }
    }
}
