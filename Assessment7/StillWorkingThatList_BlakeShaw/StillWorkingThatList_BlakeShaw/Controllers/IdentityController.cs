using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using StillWorkingThatList_BlakeShaw.Models;

namespace StillWorkingThatList_BlakeShaw.Controllers
{
    public class IdentityController : Controller
    {
        private UserManager<IdentityUser> _userManager => HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>();
        private StillWorkingThatList_BlakeShawContext _context = new StillWorkingThatList_BlakeShawContext();

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegistrationViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                var guest = new Guest() { FirstName = newUser.FirstName, LastName = newUser.LastName, AttendanceDate = newUser.AttendanceDate, EmailAddress = newUser.EmailAddress, Guest1 = newUser.Guest1, Attending = (newUser.Attending == "Yes") };
                _context.Guests.Add(guest);
                _context.SaveChanges();
                if (newUser.Attending == "Yes")
                {
                    var user = new IdentityUser() { UserName = newUser.EmailAddress };
                    var identityResult = _userManager.Create(user, newUser.Password);

                    if (identityResult.Succeeded)
                    {
                        TempData["Guest"] = guest;

                        var authManager = HttpContext.GetOwinContext().Authentication;
                        var ident = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                        authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);

                        return RedirectToAction("Create", "Dishes");
                    }
                    ModelState.AddModelError("", identityResult.Errors.FirstOrDefault());
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(newUser);
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel guest)
        {
            if (ModelState.IsValid)
            {
                var authManager = HttpContext.GetOwinContext().Authentication;
                IdentityUser user = _userManager.Find(guest.EmailAddress, guest.Password);
                if(user != null)
                {
                    var ident = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
                    return RedirectToAction("Index", "Dishes");
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(guest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignOut()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Index", "Home");
        }
    }
}