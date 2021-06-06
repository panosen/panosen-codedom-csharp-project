using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharpProject
{
    public static class SolutionExtension
    {
        public static Project AddProject(this Solution solution, string projectName = null, string projectGuid = null, string projectPath = null, string projectTypeGuid = null)
        {
            if (solution.ProjectList == null)
            {
                solution.ProjectList = new List<Project>();
            }

            Project project = new Project();
            project.ProjectGuid = projectGuid;
            project.ProjectName = projectName;
            project.ProjectPath = projectPath;
            project.ProjectTypeGuid = projectTypeGuid;

            solution.ProjectList.Add(project);

            return project;
        }
    }
}
