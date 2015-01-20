using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projector.Models;

namespace Projector.Controllers
{
    
    public class ProjectsController : Controller
    {
        private ProjectorContext db = new ProjectorContext();

        //
        // GET: /Projects/

        public ActionResult Index()
        {
            PersonService service = new PersonService(db);
            if (service.IsLoggedIn())
            {
                ProjectService Service = new ProjectService(db);
                return View(Service.ViewProjects());
            }
            else
            {
                return RedirectToAction("Index","signin");
            }
        }

        //
        // GET: /Projects/Details/5

        public ActionResult Details(int id = 0)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // GET: /Projects/Create

        public ActionResult Create()
        {
             PersonService service = new PersonService(db);
             if (service.IsLoggedIn())
             {
                 return View();
             }
             else
             {
                 return RedirectToAction("Index", "SignIn");
             }
        }

        //
        // POST: /Projects/Create

        [HttpPost]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                ProjectService service = new ProjectService(db);
                service.CreateProject(project);
                return RedirectToAction("Index");
            }

            return View(project);
        }

        //GET Assignment
        public ActionResult assignments()
        {
            PersonService pservice = new PersonService(db);
            if (pservice.IsLoggedIn())
            {
            ProjectService service = new ProjectService(db);
            service.ViewProjectDetail((int)HttpContext.Session["proj_id"]);
             return View();
            }
            else
            {
                return RedirectToAction("Index", "SignIn");
            }
               

        }
        //Project Assignments post method
        [HttpPost]
        public ActionResult assignments(int id=0)
        {
            PersonService pservice = new PersonService(db);
            if (pservice.IsLoggedIn())
            {
                ProjectService service = new ProjectService(db);
                if (id.Equals(0))
                {
                    service.ViewProjectDetail((int)HttpContext.Session["proj_id"]);
                    return View(service.ViewProjectDetail((int)HttpContext.Session["proj_id"]));
                }
                else
                {


                    service.SaveProjectID(id);
                    service.ViewProjectDetail(id);
                    return View(service.ViewProjectDetail(id));
                }
            }
            else
            {
                return RedirectToAction("Index", "SignIn");
            }
            
      
          
        }
       //POST METHOD of Assigning of Person 
        [HttpPost]
        [OutputCache(Duration = 0)]
        public ActionResult assign(AssignProjectInputModel assign)
        {
            ProjectService service = new ProjectService(db);
            service.AssignProject(assign);
            ProjectService Service = new ProjectService(db);
            return PartialView("unassigned", Service.GetUnAssigned());

        }
        //get unassigned persons
        
        public ActionResult unassigned()
        {
            PersonService pservice = new PersonService(db);
            if (pservice.IsLoggedIn())
            {
                
                ProjectService Service = new ProjectService(db);
                return PartialView("unassigned",Service.GetUnAssigned());
            }
            else
            {
                return RedirectToAction("Index", "SignIn");
            }
        }
        //get project members
        public ActionResult getprojectmembers()
        {
        PersonService pservice = new PersonService(db);
            if (pservice.IsLoggedIn())
            {
                ProjectService Service = new ProjectService(db);
                return PartialView("getprojectmembers",Service.GetProjectMembers());
            }
            else
            {
                return RedirectToAction("Index", "SignIn");
            }
        }
        //unassign Project Input Model 
        [HttpPost]
        public ActionResult unassign(UnassignProjectInputModel input)
        {PersonService pservice = new PersonService(db);
            if (pservice.IsLoggedIn())
            {
            ProjectService service = new ProjectService(db);
            service.UnassignPerson(input);
           
            return PartialView("getprojectmembers", service.GetProjectMembers());
            }
            else
            {
                return RedirectToAction("Index", "SignIn");
            }
        }
        //
        // GET: /Projects/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // POST: /Projects/Edit/5

        [HttpPost]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        //
        // GET: /Projects/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // POST: /Projects/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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