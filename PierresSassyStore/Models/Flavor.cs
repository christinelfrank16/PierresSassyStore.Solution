using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace PierresSassyStore.Models
{
    public class Flavor
    {
        public int FlavorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsSeasonal { get; set; }
        [Display(Name = "Season Available")]
        public string AvailableSeason { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<FlavorTreat> Treats { get; set; }
        public string Image_url { get; set; }

        public Flavor()
        {
            this.Treats = new HashSet<FlavorTreat>();
        }
    }
}