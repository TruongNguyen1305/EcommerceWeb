using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.ModelView
{
    public class RegisterViewModel
    {
        [Key]
        public int CustomerId { get; set; }
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Please fill your Full name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please fill your Email")]
        [MaxLength(150)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MaxLength(11)]
        [Required(ErrorMessage = "Please fill your Number phone")]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please fill your Password")]
        [MinLength(5, ErrorMessage = "Your password must be longer than 5 characters")]
        public string Password { get; set; }
        [MinLength(5, ErrorMessage = "Your password must be longer than 5 characters")]
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("Password", ErrorMessage = "Please fill correct password")]
        public string ConfirmPassword { get; set; }
    }
}
