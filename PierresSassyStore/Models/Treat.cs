using System.Collections.Generic;
namespace PierresSassyStore.Models
{
    public class Treat
    {
        public int TreatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public ICollection<FlavorTreat> Treats { get; set; }

        public Treat()
        {
            this.Treats = new HashSet<FlavorTreat>();
        }
    }
}