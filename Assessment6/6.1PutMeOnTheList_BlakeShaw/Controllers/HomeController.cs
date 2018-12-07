using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PutMeOnTheList_BlakeShaw.Models;

namespace _6._1PutMeOnTheList_BlakeShaw.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new ViewModel() { Attendee = new Attendee(), Dish = new Dish() };
            return View(model);
        }

        public IActionResult Attendees(Attendee attendee)
        {
            if(attendee.Attending == "no")
            {
                return RedirectToAction("Index", "Home");
            }
            return View(attendee);
        }

        public IActionResult Dishes(Dish dish)
        {
            return View(dish);
        }
    }
}
