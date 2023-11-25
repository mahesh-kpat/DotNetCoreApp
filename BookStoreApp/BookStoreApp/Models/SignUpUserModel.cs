using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BookStoreApp.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }


        [Required(ErrorMessage ="Please enter your email")]
        [Display(Name ="Email address")]
        [EmailAddress(ErrorMessage ="Please enter a valid email")]
        public string Email { get; set; }
       
        [Required(ErrorMessage = "Please enter a strong password")]
        [Compare("ConfirmPassword",ErrorMessage = "Password do not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        
        public string Password { get; set; }
        [Required(ErrorMessage = "Please confirm your email")]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
