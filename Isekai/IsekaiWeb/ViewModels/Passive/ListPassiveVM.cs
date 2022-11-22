using IsekaiDb.Domain.Entities;
using System.Collections.Generic;
using static IsekaiDb.Data.Enumerable;

namespace IsekaiWeb.ViewModels.Passive
{
    public class ListPassiveVM
    {
        public string SearchFilter { get; set; }
        public PassiveType CategoryFilter { get; set; }
    }
}
