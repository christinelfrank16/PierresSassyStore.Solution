using PierresSassyStore.Models;
using System.Collections.Generic;

namespace PierresSassyStore.ViewModels
{
    public class TreatsDetailsViewModel
    {
        public Treat Treat { get; set; }
        public List<Flavor> AllFlavors { get; set; }
    }
}