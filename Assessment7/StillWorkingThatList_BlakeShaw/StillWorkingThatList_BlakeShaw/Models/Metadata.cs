using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StillWorkingThatList_BlakeShaw.Models
{
    public class GuestMetadata
    {
        public int GuestId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Preferred Date"), DataType(DataType.Date)]
        public Nullable<System.DateTime> AttendanceDate { get; set; }
        [Display(Name = "Email"), EmailAddress]
        public string EmailAddress { get; set; }
        [Display(Name = "Guest Name (if applicable)")]
        public string Guest1 { get; set; }
    }

    public class DishMetadata
    {
        public int DishId { get; set; }
        [Display(Name = "First and Last Name")]
        public string PersonName { get; set; }
        [Display(Name = "Phone Number"), Phone]
        public string PhoneNumber { get; set; }
        [Display(Name = "Dish Name")]
        public string DishName { get; set; }
        [Display(Name = "Description"), DataType(DataType.MultilineText)]
        public string DishDescription { get; set; }
        [Display(Name = "Special Characteristics (Vegan, Vegetarian, Gluten-Free, etc.)")]
        public string Catagory { get; set; }
    }
}