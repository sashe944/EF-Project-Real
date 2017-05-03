

using System.ComponentModel.DataAnnotations;

namespace OnlineSmartphonesShop.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}