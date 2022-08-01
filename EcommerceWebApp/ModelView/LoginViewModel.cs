using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.ModelView
{
    public class LoginViewModel
    {
        [Key]
        [MaxLength(100)]
        [Required(ErrorMessage = "Please fill your Email !!!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please fill your Password")]
        [Display(Name = "Password")]
        [MinLength(5, ErrorMessage ="Your password must be longer than 5 characters !!!")]
        public string Password { get; set; }
    }
}
