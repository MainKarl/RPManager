using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace IsekaiWeb.ViewModels.Armor
{
    public class ArmorAddVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public string Path { get; set; }

        public string Passive { get; set; }

        public bool Update { get; set; }

        public List<SelectListItem> ArmorPassive { get; set; }
    }
}
