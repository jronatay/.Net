//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projector.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    
    public partial class Person
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Please enter Last Name")]
        [StringLength(50, ErrorMessage = "The Last Name must be at least 2 to 50 characters long.", MinimumLength = 2)]
        [RegularExpression(@"^[^\d^`~!@#\$%\^&\*\(\)\-_\+=<>\?,;:'\|/\[\]\{\}""]+[^\d^`~!@#\$%\^&\*\(\)\-_\+=<>\?,;:\|/\[\]\{\}""]$", ErrorMessage = "Input valid characters")]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }

        [Required(ErrorMessage = "Please enter First Name")]
        [StringLength(50, ErrorMessage = "The First Name must be at least 2 to 50 characters long.", MinimumLength = 2)]
        [RegularExpression(@"^[^\d^`~!@#\$%\^&\*\(\)\-_\+=<>\?,;:'\|/\[\]\{\}""]+[^\d^`~!@#\$%\^&\*\(\)\-_\+=<>\?,;:\|/\[\]\{\}""]$", ErrorMessage = "Input valid characters")]
        [Display(Name = "First Name")]
        public string first_name { get; set; }

        [Required(ErrorMessage = "Please enter User Name")]
        [StringLength(200, ErrorMessage = "Maximum 200 characters exceeded")]
        [Remote("IsUsernameExist", "Persons")]
        [Display(Name = "User Name")]
        [DataType(DataType.EmailAddress, ErrorMessage = "User Name must be in email format")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [StringLength(11, ErrorMessage = "Maximum 11 characters exceeded", MinimumLength=7)]
        [RegularExpression(@"^[^\s^<>]*$", ErrorMessage = "Input valid characters")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
