using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StillWorkingThatList_BlakeShaw.Models
{
    [MetadataType(typeof(GuestMetadata))]
    public partial class Guest
    {
    }

    [MetadataType(typeof(DishMetadata))]
    public partial class Dish
    {
    }
}