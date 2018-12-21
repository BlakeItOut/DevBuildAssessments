using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StillWorkingThatList_BlakeShaw.Models
{
    public class Joke
    {
        public string[] category { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }
}