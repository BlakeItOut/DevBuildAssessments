using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PutMeOnTheList_BlakeShaw.Models
{
    public class Dish
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string DishName { get; set; }
        public string DishDescription { get; set; }
        public List<string> DishOptions { get; set; }
    }
}
