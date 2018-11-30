using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PutMeOnTheList_BlakeShaw.Models
{
    public class Attendee
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string Email { get; set; }
        [Required]
        public string Attending { get; set; }
        public string Date { get; set; }
        public string GuestName { get; set; }
    }
}
