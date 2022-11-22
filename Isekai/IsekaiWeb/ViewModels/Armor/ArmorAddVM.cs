using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace IsekaiWeb.ViewModels.Armor
{
    public class ArmorAddVM
    {
        public string Name { get; set; }
        public int Power { get; set; }

        public string Passive { get; set; }

        public List<SelectListItem> ArmorPassive { get; set; }
    }
}
