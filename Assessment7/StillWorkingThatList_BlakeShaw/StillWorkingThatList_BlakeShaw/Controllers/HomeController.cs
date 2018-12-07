using StillWorkingThatList_BlakeShaw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StillWorkingThatList_BlakeShaw.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new ViewModel()
            {
                Dish = new Dish(),
                Guest = new Guest()
            };
            return View(model);
        }
    }
}