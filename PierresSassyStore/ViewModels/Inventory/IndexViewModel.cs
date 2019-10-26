using PierresSassyStore.Models;
using System.Collections.Generic;

namespace PierresSassyStore.ViewModels
{
    public class InventoryIndexViewModel
    {
        public List<Treat> AllTreats { get; set; }
        public List<Flavor> AllFlavors { get; set; }
        public List<FlavorTreat> AllCombinations { get; set; }
    }
}