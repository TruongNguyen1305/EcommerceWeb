using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.ModelView
{
    public class ChangePasswordViewModel
    {
        [Key]
        public int CustomerId { get; set; }
        [Display(Name = "Current password")]
        [Required(ErrorMessage = "Please input your current password !")]
        public string PasswordNow { get; set; }
        [Display(Name = "New password")]
        [Required(ErrorMessage = "Please input your password !")]
        [MinLength(5, ErrorMessage = "Your password must be than 5 characters !")]
        public string Password { get; set; }
        [Display(Name = "Enter new password")]
        [Compare("Password", ErrorMessage = "Your confirm password isn't correct !")]
        public string ConfirmPassword { get; set; }
    }
}
