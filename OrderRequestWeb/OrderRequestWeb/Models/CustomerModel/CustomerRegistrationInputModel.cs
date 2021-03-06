﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderRequestWeb.Models.CustomerModel
{
    public class CustomerRegistrationInputModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter First Name")]
        [StringLength(20, ErrorMessage = "The First Name must be at least 2 to 20 characters long.", MinimumLength = 2)]
        [RegularExpression(@"^[^\d^`~!@#\$%\^&\*\(\)\-_\+=<>\?,;:'\|/\[\]\{\}""]+[^\d^`~!@#\$%\^&\*\(\)\-_\+=<>\?,;:\|/\[\]\{\}""]$", ErrorMessage = "Input valid characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        [StringLength(20, ErrorMessage = "The Last Name must be at least 2 to 20 characters long.", MinimumLength = 2)]
        [RegularExpression(@"^[^\d^`~!@#\$%\^&\*\(\)\-_\+=<>\?,;:'\|/\[\]\{\}""]+[^\d^`~!@#\$%\^&\*\(\)\-_\+=<>\?,;:\|/\[\]\{\}""]$", ErrorMessage = "Input valid characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        [StringLength(200, ErrorMessage = "The Address must be at least 15 to 200 characters long.", MinimumLength = 15)]
        [RegularExpression(@"^[^\d^`~!@#\$%\^&\*\(\)_\+=<>\?,;:'\|/\[\]\{\}""]+[^\d^`~!@#\$%\^&\*\(\)_\+=<>\?,;:\|/\[\]\{\}""]$", ErrorMessage = "Input valid characters")]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [StringLength(200, ErrorMessage = "The Address must be at least 15 to 200 characters long.", MinimumLength = 15)]
        [RegularExpression(@"^[^\d^`~!@#\$%\^&\*\(\)_\+=<>\?,;:'\|/\[\]\{\}""]+[^\d^`~!@#\$%\^&\*\(\)_\+=<>\?,;:\|/\[\]\{\}""]$", ErrorMessage = "Input valid characters")]
        [Display(Name = "Address 2 - Optional")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Please enter ZipCode")]
        [StringLength(20, ErrorMessage = "The ZipCode must be at least 2 to 20 characters long.", MinimumLength = 2)]
        //[RegularExpression(@"^[^\d^`~!@#\$%\^&\*\(\)_\+=<>\?,;:'\|/\[\]\{\}""]+[^\d^`~!@#\$%\^&\*\(\)_\+=<>\?,;:\|/\[\]\{\}""]$", ErrorMessage = "Input valid characters")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please enter City")]
        [StringLength(50, ErrorMessage = "The City must be at least 5 to 50 characters long.", MinimumLength = 5)]
       // [RegularExpression(@"^[^\d^`~!@#\$%\^&\*\(\)_\+=<>\?;:'\|/\[\]\{\}""]+[^\d^`~!@#\$%\^&\*\(\)_\+=<>\?;:\|/\[\]\{\}""]$", ErrorMessage = "Input valid characters")]
        [Display(Name = "City")]
        public string City { get; set; }

        [StringLength(50, ErrorMessage = "The Region must be at least 5 to 50 characters long.", MinimumLength = 5)]
        [RegularExpression(@"^[^\d^`~!@#\$%\^&\*\(\)_\+=<>\?;:'\|/\[\]\{\}""]+[^\d^`~!@#\$%\^&\*\(\)_\+=<>\?;:\|/\[\]\{\}""]$", ErrorMessage = "Input valid characters")]
        [Display(Name = "Region - Optional")]
        public string Region { get; set; }

        [StringLength(50, ErrorMessage = "The Country must be at least 5 to 50 characters long.", MinimumLength = 5)]
        //[RegularExpression(@"^[^\d^`~!@#\$%\^&\*\(\)_\+=<>\?;:'\|/\[\]\{\}""]+[^\d^`~!@#\$%\^&\*\(\)_\+=<>\?;:\|/\[\]\{\}""]$", ErrorMessage = "Input valid characters")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [StringLength(50, ErrorMessage = "The Email must be at least 5 to 50 characters long.", MinimumLength = 5)]
        [DataType(DataType.EmailAddress,ErrorMessage="Please Enter a valid Email")]
        [Remote("IsEmailExist", "Customers")]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
        public System.DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [StringLength(11, ErrorMessage = "Maximum 11 characters exceeded", MinimumLength = 7)]
        [RegularExpression(@"^[^\s^<>]*$", ErrorMessage = "Input valid characters")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public List<SelectListItem> LoadCountries()
        {
            List<SelectListItem> Countries = new List<SelectListItem>();
            Countries.Add(new SelectListItem { Text = "Select", Value = "0" });
            Countries.Add(new SelectListItem { Text = "Afghanistan", Value = "Afghanistan" });
            Countries.Add(new SelectListItem { Text = "Åland Islands", Value = "Åland Islands" });
            Countries.Add(new SelectListItem { Text = "Albania", Value = "Albania" });
            Countries.Add(new SelectListItem { Text = "Algeria", Value = "Algeria" });
            Countries.Add(new SelectListItem { Text = "American Samoa", Value = "American Samoa" });
            Countries.Add(new SelectListItem { Text = "Andorra", Value = "Andorra" });
            Countries.Add(new SelectListItem { Text = "Angola", Value = "Angola" });
            Countries.Add(new SelectListItem { Text = "Anguilla", Value = "Anguilla" });
            Countries.Add(new SelectListItem { Text = "Antarctica", Value = "Antarctica" });
            Countries.Add(new SelectListItem { Text = "Antigua and Barbuda", Value = "Antigua and Barbuda" });
            Countries.Add(new SelectListItem { Text = "Argentina", Value = "Argentina" });
            Countries.Add(new SelectListItem { Text = "Armenia", Value = "Armenia" });
            Countries.Add(new SelectListItem { Text = "Aruba", Value = "Aruba" });
            Countries.Add(new SelectListItem { Text = "Australia", Value = "Australia" });
            Countries.Add(new SelectListItem { Text = "Austria", Value = "Austria" });
            Countries.Add(new SelectListItem { Text = "Azerbaijan", Value = "Azerbaijan" });
            Countries.Add(new SelectListItem { Text = "Bahamas", Value = "Bahamas" });
            Countries.Add(new SelectListItem { Text = "Bahrain", Value = "Bahrain" });
            Countries.Add(new SelectListItem { Text = "Bangladesh", Value = "Bangladesh" });
            Countries.Add(new SelectListItem { Text = "Barbados", Value = "Barbados" });
            Countries.Add(new SelectListItem { Text = "Belarus", Value = "Belarus" });
            Countries.Add(new SelectListItem { Text = "Belgium", Value = "Belgium" });
            Countries.Add(new SelectListItem { Text = "Belize", Value = "Belize" });
            Countries.Add(new SelectListItem { Text = "Benin", Value = "Benin" });
            Countries.Add(new SelectListItem { Text = "Bermuda", Value = "Bermuda" });
            Countries.Add(new SelectListItem { Text = "Bhutan", Value = "Bhutan" });
            Countries.Add(new SelectListItem { Text = "Bolivia, Plurinational State of", Value = "Bolivia, Plurinational State of" });
            Countries.Add(new SelectListItem { Text = "Bonaire, Sint Eustatius and Saba", Value = "Bonaire, Sint Eustatius and Saba" });
            Countries.Add(new SelectListItem { Text = "Bosnia and Herzegovina", Value = "Bosnia and Herzegovina" });
            Countries.Add(new SelectListItem { Text = "Botswana", Value = "Botswana" });
            Countries.Add(new SelectListItem { Text = "Bouvet Island", Value = "Bouvet Island" });
            Countries.Add(new SelectListItem { Text = "Brazil", Value = "Brazil" });
            Countries.Add(new SelectListItem { Text = "British Indian Ocean Territory", Value = "British Indian Ocean Territory" });
            Countries.Add(new SelectListItem { Text = "Brunei Darussalam", Value = "Brunei Darussalam" });
            Countries.Add(new SelectListItem { Text = "Bulgaria", Value = "Bulgaria" });
            Countries.Add(new SelectListItem { Text = "Burkina Faso", Value = "Burkina Faso" });
            Countries.Add(new SelectListItem { Text = "Burundi", Value = "Burundi" });
            Countries.Add(new SelectListItem { Text = "Cambodia", Value = "Cambodia" });
            Countries.Add(new SelectListItem { Text = "Cameroon", Value = "Cameroon" });
            Countries.Add(new SelectListItem { Text = "Canada", Value = "Canada" });
            Countries.Add(new SelectListItem { Text = "Cape Verde", Value = "Cape Verde" });
            Countries.Add(new SelectListItem { Text = "Cayman Islands", Value = "Cayman Islands" });
            Countries.Add(new SelectListItem { Text = "Central African Republic", Value = "Central African Republic" });
            Countries.Add(new SelectListItem { Text = "Chad", Value = "Chad" });
            Countries.Add(new SelectListItem { Text = "Chile", Value = "Chile" });
            Countries.Add(new SelectListItem { Text = "China", Value = "China" });
            Countries.Add(new SelectListItem { Text = "Christmas Island", Value = "Christmas Island" });
            Countries.Add(new SelectListItem { Text = "Cocos (Keeling) Islands", Value = "Cocos (Keeling) Islands" });
            Countries.Add(new SelectListItem { Text = "Colombia", Value = "Colombia" });
            Countries.Add(new SelectListItem { Text = "Comoros", Value = "Comoros" });
            Countries.Add(new SelectListItem { Text = "Congo", Value = "Congo" });
            Countries.Add(new SelectListItem { Text = "Congo, the Democratic Republic of the", Value = "Congo, the Democratic Republic of the" });
            Countries.Add(new SelectListItem { Text = "Cook Islands", Value = "Cook Islands" });
            Countries.Add(new SelectListItem { Text = "Costa Rica", Value = "Costa Rica" });
            Countries.Add(new SelectListItem { Text = "Côte d'Ivoire", Value = "Côte d'Ivoire" });
            Countries.Add(new SelectListItem { Text = "Croatia", Value = "Croatia" });
            Countries.Add(new SelectListItem { Text = "Cuba", Value = "Cuba" });
            Countries.Add(new SelectListItem { Text = "Curaçao", Value = "Curaçao" });
            Countries.Add(new SelectListItem { Text = "Cyprus", Value = "Cyprus" });
            Countries.Add(new SelectListItem { Text = "Czech Republic", Value = "Czech Republic" });
            Countries.Add(new SelectListItem { Text = "Denmark", Value = "Denmark" });
            Countries.Add(new SelectListItem { Text = "Djibouti", Value = "Djibouti" });
            Countries.Add(new SelectListItem { Text = "Dominica", Value = "Dominica" });
            Countries.Add(new SelectListItem { Text = "Dominican Republic", Value = "Dominican Republic" });
            Countries.Add(new SelectListItem { Text = "Ecuador", Value = "Ecuador" });
            Countries.Add(new SelectListItem { Text = "Egypt", Value = "Egypt" });
            Countries.Add(new SelectListItem { Text = "El Salvador", Value = "El Salvador" });
            Countries.Add(new SelectListItem { Text = "Equatorial Guinea", Value = "Equatorial Guinea" });
            Countries.Add(new SelectListItem { Text = "Eritrea", Value = "Eritrea" });
            Countries.Add(new SelectListItem { Text = "Estonia", Value = "Estonia" });
            Countries.Add(new SelectListItem { Text = "Ethiopia", Value = "Ethiopia" });
            Countries.Add(new SelectListItem { Text = "Fiji", Value = "Fiji" });
            Countries.Add(new SelectListItem { Text = "Finland", Value = "Finland" });
            Countries.Add(new SelectListItem { Text = "France", Value = "France" });
            Countries.Add(new SelectListItem { Text = "Gabon", Value = "Gabon" });
            Countries.Add(new SelectListItem { Text = "Gambia", Value = "Gambia" });
            Countries.Add(new SelectListItem { Text = "Georgia", Value = "Georgia" });
            Countries.Add(new SelectListItem { Text = "Germany", Value = "Germany" });
            Countries.Add(new SelectListItem { Text = "Ghana", Value = "Ghana" });
            Countries.Add(new SelectListItem { Text = "Greece", Value = "Greece" });
            Countries.Add(new SelectListItem { Text = "Guam", Value = "Guam" });
            Countries.Add(new SelectListItem { Text = "Guatemala", Value = "Guatemala" });
            Countries.Add(new SelectListItem { Text = "Guyana", Value = "Guyana" });
            Countries.Add(new SelectListItem { Text = "Haiti", Value = "Haiti" });
            Countries.Add(new SelectListItem { Text = "Holy See", Value = "Holy See" });
            Countries.Add(new SelectListItem { Text = "Honduras", Value = "Honduras" });
            Countries.Add(new SelectListItem { Text = "Hong Kong", Value = "Hong Kong" });
            Countries.Add(new SelectListItem { Text = "Guyana", Value = "Guyana" });
            Countries.Add(new SelectListItem { Text = "Haiti", Value = "Haiti" });
            Countries.Add(new SelectListItem { Text = "Holy See", Value = "Holy See" });
            Countries.Add(new SelectListItem { Text = "Honduras", Value = "Honduras" });
            Countries.Add(new SelectListItem { Text = "Hong Kong", Value = "Hong Kong" });
            Countries.Add(new SelectListItem { Text = "Hungary", Value = "Hungary" });
            Countries.Add(new SelectListItem { Text = "Iceland", Value = "Iceland" });
            Countries.Add(new SelectListItem { Text = "India", Value = "India" });
            Countries.Add(new SelectListItem { Text = "Indonesia", Value = "Indonesia" });
            Countries.Add(new SelectListItem { Text = "Iran, Islamic Republic of", Value = "Iran, Islamic Republic of" });
            Countries.Add(new SelectListItem { Text = "Iraq", Value = "Iraq" });
            Countries.Add(new SelectListItem { Text = "Ireland", Value = "Ireland" });
            Countries.Add(new SelectListItem { Text = "Israel", Value = "Israel" });
            Countries.Add(new SelectListItem { Text = "Italy", Value = "Italy" });
            Countries.Add(new SelectListItem { Text = "Jamaica", Value = "Jamaica" });
            Countries.Add(new SelectListItem { Text = "Japan", Value = "Japan" });
            Countries.Add(new SelectListItem { Text = "Jordan", Value = "Jordan" });
            Countries.Add(new SelectListItem { Text = "Kazakhstan", Value = "Kazakhstan" });
            Countries.Add(new SelectListItem { Text = "Kenya", Value = "Kenya" });
            Countries.Add(new SelectListItem { Text = "Korea, Democratic People's Republic of", Value = "Korea, Democratic People's Republic of" });
            Countries.Add(new SelectListItem { Text = "Korea, Republic of", Value = "Korea, Republic of" });
            Countries.Add(new SelectListItem { Text = "Kuwait", Value = "Kuwait" });
            Countries.Add(new SelectListItem { Text = "Kyrgyzstan", Value = "Kyrgyzstan" });
            Countries.Add(new SelectListItem { Text = "Latvia", Value = "Latvia" });
            Countries.Add(new SelectListItem { Text = "Lebanon", Value = "Lebanon" });
            Countries.Add(new SelectListItem { Text = "Liberia", Value = "Liberia" });
            Countries.Add(new SelectListItem { Text = "Libya", Value = "Libya" });
            Countries.Add(new SelectListItem { Text = "Lithuania", Value = "Lithuania" });
            Countries.Add(new SelectListItem { Text = "Macao", Value = "Macao" });
            Countries.Add(new SelectListItem { Text = "Macedonia", Value = "Macedonia" });
            Countries.Add(new SelectListItem { Text = "Madagascar", Value = "Madagascar" });
            Countries.Add(new SelectListItem { Text = "Malaysia", Value = "Malaysia" });
            Countries.Add(new SelectListItem { Text = "Maldives", Value = "Maldives" });
            Countries.Add(new SelectListItem { Text = "Mali", Value = "Mali" });
            Countries.Add(new SelectListItem { Text = "Mexico", Value = "Mexico" });
            Countries.Add(new SelectListItem { Text = "Micronesia, Federated States of", Value = "Micronesia, Federated States of" });
            Countries.Add(new SelectListItem { Text = "Moldova", Value = "Moldova" });
            Countries.Add(new SelectListItem { Text = "Monaco", Value = "Monaco" });
            Countries.Add(new SelectListItem { Text = "Mongolia", Value = "Mongolia" });
            Countries.Add(new SelectListItem { Text = "Montenegro", Value = "Montenegro" });
            Countries.Add(new SelectListItem { Text = "Montserrat", Value = "Montserrat" });
            Countries.Add(new SelectListItem { Text = "Morocco", Value = "Morocco" });
            Countries.Add(new SelectListItem { Text = "Mozambique", Value = "Mozambique" });
            Countries.Add(new SelectListItem { Text = "Myanmar", Value = "Myanmar" });
            Countries.Add(new SelectListItem { Text = "Nepal", Value = "Nepal" });
            Countries.Add(new SelectListItem { Text = "Netherlands", Value = "Netherlands" });
            Countries.Add(new SelectListItem { Text = "New Zealand", Value = "New Zealand" });
            Countries.Add(new SelectListItem { Text = "Nicaragua", Value = "Nicaragua" });
            Countries.Add(new SelectListItem { Text = "Nigeria", Value = "Nigeria" });
            Countries.Add(new SelectListItem { Text = "Norway", Value = "Norway" });
            Countries.Add(new SelectListItem { Text = "Oman", Value = "Oman" });
            Countries.Add(new SelectListItem { Text = "Pakistan", Value = "Pakistan" });
            Countries.Add(new SelectListItem { Text = "Palau", Value = "Palau" });
            Countries.Add(new SelectListItem { Text = "Palestine", Value = "Palestine" });
            Countries.Add(new SelectListItem { Text = "Panama", Value = "Panama" });
            Countries.Add(new SelectListItem { Text = "Papua New Guinea", Value = "Papua New Guinea" });
            Countries.Add(new SelectListItem { Text = "Paraguay", Value = "Paraguay" });
            Countries.Add(new SelectListItem { Text = "Peru", Value = "Peru" });
            Countries.Add(new SelectListItem { Text = "Philippines", Value = "Philippines" });
            Countries.Add(new SelectListItem { Text = "Pitcairn", Value = "Pitcairn" });
            Countries.Add(new SelectListItem { Text = "Poland", Value = "Poland" });
            Countries.Add(new SelectListItem { Text = "Portugal", Value = "Portugal" });
            Countries.Add(new SelectListItem { Text = "Puerto Rico", Value = "Puerto Rico" });
            Countries.Add(new SelectListItem { Text = "Qatar", Value = "Qatar" });
            Countries.Add(new SelectListItem { Text = "Romania", Value = "Romania" });
            Countries.Add(new SelectListItem { Text = "Russia", Value = "Russia" });
            Countries.Add(new SelectListItem { Text = "San Marino", Value = "San Marino" });
            Countries.Add(new SelectListItem { Text = "Saudi Arabia", Value = "Saudi Arabia" });
            Countries.Add(new SelectListItem { Text = "Senegal", Value = "Senegal" });
            Countries.Add(new SelectListItem { Text = "Serbia", Value = "Serbia" });
            Countries.Add(new SelectListItem { Text = "Slovakia", Value = "Slovakia" });
            Countries.Add(new SelectListItem { Text = "Slovenia", Value = "Slovenia" });
            Countries.Add(new SelectListItem { Text = "South Africa", Value = "South Africa" });
            Countries.Add(new SelectListItem { Text = "Spain", Value = "Spain" });
            Countries.Add(new SelectListItem { Text = "Sri Lanka", Value = "Sri Lanka" });
            Countries.Add(new SelectListItem { Text = "Swaziland", Value = "Swaziland" });
            Countries.Add(new SelectListItem { Text = "Sweden", Value = "Sweden" });
            Countries.Add(new SelectListItem { Text = "Switzerland", Value = "Switzerland" });
            Countries.Add(new SelectListItem { Text = "Syria", Value = "Syria" });
            Countries.Add(new SelectListItem { Text = "Taiwan", Value = "Taiwan" });
            Countries.Add(new SelectListItem { Text = "Tanzania", Value = "Tanzania" });
            Countries.Add(new SelectListItem { Text = "Thailand", Value = "Thailand" });
            Countries.Add(new SelectListItem { Text = "Turkey", Value = "Turkey" });
            Countries.Add(new SelectListItem { Text = "Turkmenistan", Value = "Turkmenistan" });
            Countries.Add(new SelectListItem { Text = "Uganda", Value = "Uganda" });
            Countries.Add(new SelectListItem { Text = "Ukraine", Value = "Ukraine" });
            Countries.Add(new SelectListItem { Text = "United Arab Emirates", Value = "United Arab Emirates" });
            Countries.Add(new SelectListItem { Text = "United Kingdom", Value = "United Kingdom" });
            Countries.Add(new SelectListItem { Text = "United States", Value = "United States" });
            Countries.Add(new SelectListItem { Text = "Uruguay", Value = "Uruguay" });
            Countries.Add(new SelectListItem { Text = "Uzbekistan", Value = "Uzbekistan" });
            Countries.Add(new SelectListItem { Text = "Venezuela", Value = "Venezuela" });
            Countries.Add(new SelectListItem { Text = "Viet Nam", Value = "Viet Nam" });
            Countries.Add(new SelectListItem { Text = "Yemen", Value = "Yemen" });
            Countries.Add(new SelectListItem { Text = "Zambia", Value = "Zambia" });
            Countries.Add(new SelectListItem { Text = "Zimbabwe", Value = "Zimbabwe" });
            return Countries;
        }
    }
}