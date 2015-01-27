using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Projector.Models
{
    public class SignInInputModel
    {
        [Required(ErrorMessage = "Please enter your User Name in email form")]
        [RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 5 characters required")]
        [StringLength(200, ErrorMessage = "Maximum 200 characters exceeded")]
        [Display(Name = "User Name")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [Display(Name = "Password")]
        [RegularExpression(@"^.{7,}$", ErrorMessage = "Minimum 7 characters required")]
        [MaxLength(11,ErrorMessage="Maximum of 11 characters exceeded")]
        [DataType(DataType.Password)]
        public string Password { get; set; } 
    }
}