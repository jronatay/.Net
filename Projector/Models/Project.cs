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
    
    public partial class Project
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter Project Code")]
        [StringLength(50, ErrorMessage = "The Project Code must be at least 5 to 50 characters long.", MinimumLength = 5)]
        [RegularExpression(@"^[^\d^`~!@#\$%\^&\*\(\)\+=<>\?,;:'\|/\[\]\{\}]+[^\d^`~!@#\$%\^&\*\(\)\+=<>\?,;:\|/\[\]\{\}]{5,50}$", ErrorMessage = "Input valid characters")]
        [Display(Name = "Code")]
        public string code { get; set; }

        [Required(ErrorMessage = "Please enter Project Name")]
        [StringLength(50, ErrorMessage = "The Project Name must be at least 5 to 50 characters long.", MinimumLength = 5)]
        [RegularExpression(@"^[^\d^`~!@#\$%\^&\*\(\)\+=<>\?,;:'\|/\[\]\{\}]+[^\d^`~!@#\$%\^&\*\(\)\+=<>\?,;:\|/\[\]\{\}]{5,50}$", ErrorMessage = "Input valid characters")]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter Project Remarks")]
        [AllowHtml]
        [RegularExpression(@"^.{5,}$", ErrorMessage = "Remarks have to be 5 or more characters")]
        [Display(Name = "Remarks")]
        public string remarks { get; set; }

        [Required(ErrorMessage = "Please enter Project Budget")]
        [Display(Name = "Budget")]
        [RegularExpression(@"^\d+.\d{0,4}$", ErrorMessage = "Match input (eg 1000.0002,1000,2000.23)")]
        [Range(0, 9999999999999999.9999)]
        
        public decimal budget { get; set; }
        public Nullable<int> parentprojectid { get; set; }
    }
}
