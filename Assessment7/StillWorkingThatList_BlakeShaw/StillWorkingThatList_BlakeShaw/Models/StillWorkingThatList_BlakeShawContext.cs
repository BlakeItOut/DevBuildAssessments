using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StillWorkingThatList_BlakeShaw.Models
{
    public class StillWorkingThatList_BlakeShawContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public StillWorkingThatList_BlakeShawContext() : base("name=PartyDBEntities")
        {
        }

        public System.Data.Entity.DbSet<StillWorkingThatList_BlakeShaw.Models.Guest> Guests { get; set; }

        public System.Data.Entity.DbSet<StillWorkingThatList_BlakeShaw.Models.Dish> Dishes { get; set; }
    }
}
