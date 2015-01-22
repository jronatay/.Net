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
        private ProjectService projectService = new ProjectService(new ProjectorContext());
        
        //
        // GET: /Projects/
        [Authorize]
        public ActionResult Index()
        {
            return View(projectService.ProjectList());
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
           [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Projects/Create

        [HttpPost]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                projectService.CreateProject(project);
                return RedirectToAction("Index");
            }

            return View(project);
        }

        //GET Assignment
        [Authorize]
        public ActionResult assignments()
        {
            projectService.ViewProjectDetail((int)HttpContext.Session["proj_id"]);
            return View();
        }


        //Project Assignments post method
        [HttpPost]
        public ActionResult assignments(int id=0)
        {
           if (id.Equals(0))
          {
           return View(projectService.ViewProjectDetail((int)HttpContext.Session["proj_id"]));
          }
           else
          {
            projectService.SaveProjectID(id);
            return View(projectService.ViewProjectDetail(id));
          }
        }

       //POST METHOD of Assigning of Person 
        [HttpPost]
        [OutputCache(Duration = 0)]
        public JsonResult assign(AssignProjectInputModel assign)
        {
            projectService.AssignPersonToProject(assign);
            return Json(new { Success = true, Message = "Successfully" });
        }

        //get unassigned persons
        [Authorize]
        public ActionResult unassigned()
        {
            return PartialView("unassigned", projectService.UnassignedPerson());
        }

        //get project members
        [Authorize]
        public ActionResult getprojectmembers()
        {
            return PartialView("getprojectmembers", projectService.ProjectMembersList());
        }

        //unassign Project Input Model 
        [HttpPost]
        public JsonResult unassign(UnassignProjectInputModel input)
        {
            projectService.UnassignPerson(input);
            return Json(new { Success2 = true });
        }
       

        [HttpPost]
        public ActionResult subproject(int id)
        {
            List<SubProjectTree> subprojects = projectService.ParentsSubProjects(id);
           return View(subprojects);
        }
       
        public ActionResult subprojects()
        {
            return PartialView();
        }

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