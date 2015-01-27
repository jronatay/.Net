using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Projector.Filters;
using Projector.Models;
using Projector.Models.DAL;

namespace Projector.Controllers
{
    public class PersonsController : Controller
    {
        private ProjectorContext db = new ProjectorContext();
        private PersonService personService = new PersonService(new ProjectorContext());
        //
        // GET: /Persons/

        [Authorize]
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
        [Authorize]
        public ActionResult Create()
        {
           return View();
   
        }

        //
        // POST: /Persons/Create

       

        [HttpPost]
        [Authorize]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                if (personService.IsNotNull(person) && personService.IsLengthRight(person) && personService.IsInputMatchesRegex(person))
                {
                    personService.Save(person);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Please put a valid info");
                    return View(person);
                }
            }
            
                return View(person);
            

                    
        }
        
        [Authorize]
        public JsonResult IsUsernameExist(string userName)
        {
            var isExist=personService.IsUserNameExist(userName);
            if (isExist)
            {
                return Json("Sorry, this name already exists", JsonRequestBehavior.AllowGet);
                
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            
        }

        //Signout
        [Authorize]
        public ActionResult signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
           
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