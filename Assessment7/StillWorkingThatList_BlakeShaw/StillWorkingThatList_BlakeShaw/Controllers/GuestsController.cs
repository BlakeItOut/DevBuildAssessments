using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using PagedList;
using StillWorkingThatList_BlakeShaw.Models;

namespace StillWorkingThatList_BlakeShaw.Controllers
{
    public class GuestsController : Controller
    {
        private UserManager<IdentityUser> _userManager => HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>();
        private BlakePartyDBEntities db = new BlakePartyDBEntities();
        private const string _userAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0";

        // GET: Guests
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var guests = from g in db.Guests
                         where g.Attending
                         select g;

            if (!String.IsNullOrEmpty(searchString))
            {
                guests = guests
                            .Where(a => a.FirstName.Contains(searchString) || a.LastName.Contains(searchString) || a.Guest1.Contains(searchString));
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(guests.OrderBy(g => g.FirstName).ToPagedList(pageNumber, pageSize));
        }

        // GET: Guests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        // GET: Guests/Create
        public ActionResult Create()
        {
            var house = new House();

            var characters = new List<Character>();

            HttpWebRequest houseRequest = WebRequest.CreateHttp($"https://www.anapioficeandfire.com/api/houses/271");

            houseRequest.UserAgent = _userAgent;

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

                    characterRequest.UserAgent = _userAgent;

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

            

            
            ViewBag.CharacterUrl = new SelectList(characters, "Url", "Name");
            return View();
        }

        // POST: Guests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GuestId,FirstName,LastName,AttendanceDate,EmailAddress,Guest1,CharcterUrl")] Guest guest, string Attending)
        {
            if (ModelState.IsValid)
            {
                if(Attending == "Yes")
                {
                    if (db.Characters.Find(guest.CharacterUrl) == null)
                    {
                        var serializer = new JsonSerializer();

                        HttpWebRequest characterRequest = WebRequest.CreateHttp(guest.CharacterUrl);

                        characterRequest.UserAgent = _userAgent;

                        HttpWebResponse characterResponse = (HttpWebResponse)characterRequest.GetResponse();

                        if (characterResponse.StatusCode == HttpStatusCode.OK)
                        {
                            using (var data = new StreamReader(characterResponse.GetResponseStream()))
                            using (var jsonReader = new JsonTextReader(data))
                            {
                                var fullCharacter = serializer.Deserialize<FullCharacter>(jsonReader);
                                db.Characters.Add(fullCharacter.ToModel());
                            }

                        }
                    }
                    
                    db.Guests.Add(guest);
                    db.SaveChanges();
                    TempData["Guest"] = guest;
                    return RedirectToAction("Create", "Dishes");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                
            }

            return View(guest);
        }

        // GET: Guests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        // POST: Guests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GuestId,FirstName,LastName,AttendanceDate,EmailAddress,Guest1,CharacterUrl")] Guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guest);
        }

        // GET: Guests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        // POST: Guests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Guest guest = db.Guests.Find(id);
            db.Guests.Remove(guest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
