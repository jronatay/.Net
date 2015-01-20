using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projector.Models;
using System.Data.Entity;
using Projector.Models.DAL;

namespace Projector.Models
{
    public class ProjectService:IDisposable
    {
        private ProjectorContext db;
         public ProjectService(ProjectorContext db)
        {
            this.db = db;
        }
         public void CreateProject(Projector.Models.Project project)
         {
             //Add Entity to dbase
             db.Projects.Add(project);
             db.SaveChanges();
         }
         public IEnumerable<Project> ViewProjects()
         {
             //return list of projects
             return db.Projects.ToList();
         }
         public Project ViewProjectDetail(int id)
         {
             //get Project Details
             Project project = db.Projects.Find(id);
             return project;
         }
         public List<ProjectAssignmentsViewModel> GetUnAssigned()
         {
             //Get List of Unassign
             int id =int.Parse(HttpContext.Current.Session["proj_id"].ToString());
             var sql = (from p in db.Persons join pa in db.ProjectAssignments on p.id equals pa.person_id into pp from pa in pp.DefaultIfEmpty() where pa == null select p ).ToList();
             List<ProjectAssignmentsViewModel> unassigned = new List<ProjectAssignmentsViewModel>();
             
             foreach (var row in sql)
             {
                 //populate View Model
                 ProjectAssignmentsViewModel AssignProject = new ProjectAssignmentsViewModel();
                 AssignProject.person_id = row.id;
                 AssignProject.last_name = row.last_name;
                 AssignProject.first_name = row.first_name;
                 AssignProject.project_id = id;
                 unassigned.Add(AssignProject);
                 
             }
             return unassigned;
         }

         public List<ProjectAssignmentsViewModel> GetProjectMembers()
         {
             //Get Project Members
             int id = (int)HttpContext.Current.Session["proj_id"];
             var sql = (from p in db.Persons join pa in db.ProjectAssignments on p.id equals pa.person_id  where pa.project_id == id select p).ToList();
             List<ProjectAssignmentsViewModel> assigned = new List<ProjectAssignmentsViewModel>();

             foreach (var row in sql)
             {
                 //Populate View Model
                 ProjectAssignmentsViewModel members = new ProjectAssignmentsViewModel(); 
                 members.first_name = row.first_name;
                 members.person_id = row.id;
                 members.last_name = row.last_name;
                 members.project_id = id;
                 assigned.Add(members);
             }
             return assigned;
         }
         public void UnassignPerson(UnassignProjectInputModel input)
         {
             //Unassign Person from a Project
             var sql = (from p in db.ProjectAssignments where p.person_id == input.person_id && p.project_id == input.project_id select p).First();
            
             ProjectAssignment assigned  = db.ProjectAssignments.Find(sql.id);
            db.ProjectAssignments.Remove(assigned);
             db.SaveChanges();
            
         }
         public void SaveProjectID(int id)
         {
             //Session since its just for reference usage 
             HttpContext.Current.Session["proj_id"] = id;
         }
         public void AssignProject(AssignProjectInputModel assign)
         {
             //Assign a person to a Project
             ProjectAssignment assigned = new ProjectAssignment();
             assigned.person_id = assign.person_id;
             assigned.project_id = assign.project_id;
             db.ProjectAssignments.Add(assigned);
             db.SaveChanges();
         }

        //DISPOSABLE INTERFACE
         private bool disposed = false;

         protected virtual void Dispose(bool disposing)
         {
             if (!this.disposed)
             {
                 if (disposing)
                 {
                     db.Dispose();
                 }
             }
             this.disposed = true;
         }

         public void Dispose()
         {
             Dispose(true);
             GC.SuppressFinalize(this);
         }
    }
}