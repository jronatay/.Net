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

         public void CreateProject(Project project)
         {
             //Add Entity to dbase
             db.Projects.Add(project);
             db.SaveChanges();
         }

         public IEnumerable<Project> ProjectList()
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

         public List<ProjectAssignmentsViewModel> UnassignedPerson()
         {
             //Get List of Unassign
             int id =int.Parse(HttpContext.Current.Session["proj_id"].ToString());
             var sqlresult = (from p in db.Persons join pa in db.ProjectAssignments on p.id equals pa.person_id into pp from pa in pp.DefaultIfEmpty() where pa == null select p ).ToList();
             List<ProjectAssignmentsViewModel> unassignedPersonList = new List<ProjectAssignmentsViewModel>();

             foreach (var row in sqlresult)
             {
                 //populate View Model
                 ProjectAssignmentsViewModel projectAssignmentModel = new ProjectAssignmentsViewModel();
                 projectAssignmentModel.person_id = row.id;
                 projectAssignmentModel.last_name = row.last_name;
                 projectAssignmentModel.first_name = row.first_name;
                 projectAssignmentModel.project_id = id;
                 unassignedPersonList.Add(projectAssignmentModel);
                 
             }
             return unassignedPersonList;
         }

         public List<ProjectAssignmentsViewModel> ProjectMembersList()
         {
             //Get Project Members
             int projectId = (int)HttpContext.Current.Session["proj_id"];
             var sqlresult = (from p in db.Persons join pa in db.ProjectAssignments on p.id equals pa.person_id where pa.project_id == projectId select p).ToList();
             List<ProjectAssignmentsViewModel> ProjectMembers = new List<ProjectAssignmentsViewModel>();

             foreach (var row in sqlresult)
             {
                 //Populate View Model
                 ProjectAssignmentsViewModel members = new ProjectAssignmentsViewModel(); 
                 members.first_name = row.first_name;
                 members.person_id = row.id;
                 members.last_name = row.last_name;
                 members.project_id = projectId;
                 ProjectMembers.Add(members);
             }
             return ProjectMembers;
         }

         public void UnassignPerson(UnassignProjectInputModel input)
         {
             //Unassign Person from a Project
             var sqlresult = (from p in db.ProjectAssignments where p.person_id == input.person_id && p.project_id == input.project_id select p).First();
             ProjectAssignment assignedPerson = db.ProjectAssignments.Find(sqlresult.id);
             db.ProjectAssignments.Remove(assignedPerson);
             db.SaveChanges();
            
         }
         public List<SubProjectTree> ParentsSubProjects(int id)
         {
             var sqlresult = (from projects in db.Projects where projects.id == id ||  projects.parentprojectid == null select projects).ToList();
             List<SubProjectTree> tree = new List<SubProjectTree>();
             List<Project> project = typeofProject(id);
             foreach (var projectdata in project)
             {
                 SubProjectTree subtree = new SubProjectTree( );
                 subtree.id = projectdata.id;
                 subtree.name = projectdata.name;
                 GetChildrens(subtree);
                 tree.Add(subtree);
             }
             
             return tree;
         }

         public List<Project> typeofProject(int id)
         {
              var sqlresult =(from projects in db.Projects where projects.id==id select projects).First();
              if (sqlresult.parentprojectid != null)
              {
                  var sqlqueryresult = (from projects in db.Projects where projects.id == id && projects.parentprojectid == sqlresult.parentprojectid select projects).ToList();
                  return sqlqueryresult;
              }
              else
              {
                  var sqlqueryresult = (from projects in db.Projects where projects.id == id && projects.parentprojectid == null select projects).ToList();
                  return sqlqueryresult;
              }
         }
         public void GetChildrens(SubProjectTree parent)
         {
             var sqlresult = (from projects in db.Projects where projects.parentprojectid == parent.id select projects).ToList();
             foreach (var project in sqlresult)
             {
                 SubProjectTree subtree = new SubProjectTree();
                 subtree.id = project.id;
                 subtree.name = project.name;
                 GetChildrens(subtree);

                 parent.tree.Add(subtree);

             }
         }
             
         public void SaveProjectID(int id)
         {
             //Session since its just for reference usage 
             HttpContext.Current.Session["proj_id"] = id;
         }
         public void AssignPersonToProject(AssignProjectInputModel AssigningPersonInput)
         {
             //Assign a person to a Project
             ProjectAssignment person = new ProjectAssignment();
             person.person_id = AssigningPersonInput.person_id;
             person.project_id = AssigningPersonInput.project_id;
             db.ProjectAssignments.Add(person);
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