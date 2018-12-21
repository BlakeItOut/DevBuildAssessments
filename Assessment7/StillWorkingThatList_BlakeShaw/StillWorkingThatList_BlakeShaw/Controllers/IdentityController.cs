using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using StillWorkingThatList_BlakeShaw.Models;

namespace StillWorkingThatList_BlakeShaw.Controllers
{
    public class IdentityController : Controller
    {
        private UserManager<IdentityUser> _userManager => HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>();
        private BlakePartyDBEntities _context = new BlakePartyDBEntities();

        // GET: Register
        public ActionResult Register()
        {
            var characters = GetCharacters(271);
            ViewBag.CharacterUrl = new SelectList(characters, "Url", "Name");
            return View();
        }

        public List<Character> GetCharacters(int houseId)
        {
            var house = new House();

            var characters = new List<Character>();

            HttpWebRequest houseRequest = WebRequest.CreateHttp($"https://www.anapioficeandfire.com/api/houses/{houseId}");

            houseRequest.UserAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0";

            HttpWebResponse houseResponse = (HttpWebResponse)houseRequest.GetResponse();

            if (houseResponse.StatusCode == HttpStatusCode.OK)
            {
                var serializer = new JsonSerializer();

                using (var data = new StreamReader(houseResponse.GetResponseStream()))
                using (var jsonReader = new JsonTextReader(data))
                {
                    house = serializer.Deserialize<House>(jsonReader);
                }

                foreach (var url in house.swornMembers)
                {
                    HttpWebRequest characterRequest = WebRequest.CreateHttp(url);

                    characterRequest.UserAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0";

                    HttpWebResponse characterResponse = (HttpWebResponse)characterRequest.GetResponse();

                    if (characterResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var data = new StreamReader(characterResponse.GetResponseStream()))
                        using (var jsonReader = new JsonTextReader(data))
                        {
                            characters.Add(serializer.Deserialize<Character>(jsonReader));
                        }

                    }
                }
            }

            return characters;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegistrationViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                if (_context.Characters.Find(newUser.CharacterUrl) == null)
                {
                    var serializer = new JsonSerializer();

                    HttpWebRequest characterRequest = WebRequest.CreateHttp(newUser.CharacterUrl);

                    characterRequest.UserAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0";

                    HttpWebResponse characterResponse = (HttpWebResponse)characterRequest.GetResponse();

                    if (characterResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var data = new StreamReader(characterResponse.GetResponseStream()))
                        using (var jsonReader = new JsonTextReader(data))
                        {
                            var fullCharacter = serializer.Deserialize<FullCharacter>(jsonReader);
                            _context.Characters.Add(fullCharacter.ToModel());
                        }

                    }
                }
                var guest = new Guest() { FirstName = newUser.FirstName, LastName = newUser.LastName, AttendanceDate = newUser.AttendanceDate, EmailAddress = newUser.EmailAddress, Guest1 = newUser.Guest1, Attending = (newUser.Attending == "Yes"), CharacterUrl = newUser.CharacterUrl};
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
            var characters = GetCharacters(271);
            ViewBag.CharacterUrl = new SelectList(characters, "Url", "Name");
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