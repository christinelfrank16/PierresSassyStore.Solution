using PierresSassyStore.Models;
using System.Collections.Generic;

namespace PierresSassyStore.ViewModels
{
    public class FlavorsDetailsViewModel
    {
        public Flavor Flavor { get; set; }
        public List<Treat> AllTreats { get; set; }
    }
}