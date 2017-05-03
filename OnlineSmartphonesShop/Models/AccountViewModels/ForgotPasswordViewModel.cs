

using System.ComponentModel.DataAnnotations;

namespace OnlineSmartphonesShop.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}