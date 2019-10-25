using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace PierresSassyStore.Models
{
    public class Treat
    {
        public int TreatId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public string Image_url { get; set; }
        
        public ICollection<FlavorTreat> Flavors { get; set; }

        public Treat()
        {
            this.Flavors = new HashSet<FlavorTreat>();
        }
    }
}