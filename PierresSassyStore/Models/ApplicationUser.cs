using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PierresSassyStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Whole Name")]
        public string WholeName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
    }

}