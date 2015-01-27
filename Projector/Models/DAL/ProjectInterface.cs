using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projector.Models.DAL
{
    interface ProjectInterface:IDisposable
    {
        void CreateProject(Project project);
        IEnumerable<Project> ViewProjects();
        Project ViewProjectDetail(int id);
        List<ProjectAssignmentsViewModel> GetUnAssigned();
        List<ProjectAssignmentsViewModel> GetProjectMembers();
        
        void AssignProject(AssignProjectInputModel assign);
        void UnassignPerson(UnassignProjectInputModel unassign);
    }
}
