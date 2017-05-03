
using System.ComponentModel.DataAnnotations;

namespace OnlineSmartphonesShop.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}