using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StillWorkingThatList_BlakeShaw.Models
{
    public class RegistrationViewModel
    {
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Preferred Date"), DataType(DataType.Date)]
        public Nullable<System.DateTime> AttendanceDate { get; set; }
        [Required]
        public string Attending { get; set; }
        [Required, Display(Name = "Email"), EmailAddress]
        public string EmailAddress { get; set; }
        [Display(Name = "Guest Name (if applicable)")]
        public string Guest1 { get; set; }
        [DataType(DataType.Password), StringLength(100, MinimumLength = 6, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password"), DataType(DataType.Password), Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Your Character")]
        public string CharacterUrl { get; set; }
    }
}