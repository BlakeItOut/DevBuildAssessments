using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StillWorkingThatList_BlakeShaw.Models
{
    public class LoginViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}