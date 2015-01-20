using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projector.Models;
using Projector.Models.DAL;

namespace Projector.Controllers
{
    public class PersonsController : Controller
    {
        private ProjectorContext db = new ProjectorContext();

        //
        // GET: /Persons/
      

        public ActionResult Index()
        {
            return View(db.Persons.ToList());
        }

        //
        // GET: /Persons/Details/5

        public ActionResult Details(int id = 0)
        {
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // GET: /Persons/Create

        public ActionResult Create()
        {
            PersonService pservice = new PersonService(db);
            if (pservice.IsLoggedIn())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "SignIn");
            }
           
        }

        //
        // POST: /Persons/Create

        [HttpPost]
        public ActionResult Create(Person person)
        {
            PersonService pservice = new PersonService(db);
            if (pservice.IsLoggedIn())
            {
                if (ModelState.IsValid)
                {
                    PersonService service = new PersonService(db);
                    service.Save(person);
                    return RedirectToAction("Index");
                }

                return View(person);
            }
            else
            {
                return RedirectToAction("Index", "SignIn");
            }
           
        }
        //Signout
        public ActionResult signout()
        {
            PersonService service = new PersonService(db);
            service.signout();
            return RedirectToAction("Index", "signin");
        }

        //
        // GET: /Persons/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // POST: /Persons/Edit/5

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        //
        // GET: /Persons/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // POST: /Persons/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Persons.Find(id);
            db.Persons.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}