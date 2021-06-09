using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharpProject.Engine
{
    /// <summary>
    /// SolutionEngine
    /// </summary>
    public class SolutionEngine
    {
        /// <summary>
        /// Generate
        /// </summary>
        /// <param name="solution"></param>
        /// <param name="codeWriter"></param>
        public void Generate(Solution solution, CodeWriter codeWriter)
        {
            codeWriter.WriteLine();
            codeWriter.WriteLine("Microsoft Visual Studio Solution File, Format Version 12.00");
            codeWriter.WriteLine("# Visual Studio Version 16");
            codeWriter.WriteLine("VisualStudioVersion = 16.0.28803.452");
            codeWriter.WriteLine("MinimumVisualStudioVersion = 10.0.40219.1");

            if (solution.ProjectList != null && solution.ProjectList.Count > 0)
            {
                foreach (var project in solution.ProjectList)
                {
                    codeWriter.WriteLine($"Project(\"{project.ProjectTypeGuid}\") = \"{project.ProjectName}\", \"{project.ProjectPath}\", \"{project.ProjectGuid}\"");
                    codeWriter.WriteLine("EndProject");
                }
            }

            codeWriter.WriteLine("Global");

            codeWriter.WriteLine("	GlobalSection(SolutionConfigurationPlatforms) = preSolution");
            codeWriter.WriteLine("		Debug|Any CPU = Debug|Any CPU");
            codeWriter.WriteLine("		Release|Any CPU = Release|Any CPU");
            codeWriter.WriteLine("	EndGlobalSection");

            if (solution.ProjectList != null && solution.ProjectList.Count > 0)
            {
                codeWriter.WriteLine("	GlobalSection(ProjectConfigurationPlatforms) = postSolution");
                foreach (var project in solution.ProjectList)
                {
                    codeWriter.WriteLine($"		{project.ProjectGuid}.Debug|Any CPU.ActiveCfg = Debug|Any CPU");
                    codeWriter.WriteLine($"		{project.ProjectGuid}.Debug|Any CPU.Build.0 = Debug|Any CPU");
                    codeWriter.WriteLine($"		{project.ProjectGuid}.Release|Any CPU.ActiveCfg = Release|Any CPU");
                    codeWriter.WriteLine($"		{project.ProjectGuid}.Release|Any CPU.Build.0 = Release|Any CPU");
                }
                codeWriter.WriteLine("	EndGlobalSection");
            }

            codeWriter.WriteLine("	GlobalSection(SolutionProperties) = preSolution");
            codeWriter.WriteLine("		HideSolutionNode = FALSE");
            codeWriter.WriteLine("	EndGlobalSection");

            codeWriter.WriteLine("	GlobalSection(ExtensibilityGlobals) = postSolution");
            codeWriter.WriteLine($"		SolutionGuid = {solution.SolutionGuid}");
            codeWriter.WriteLine("	EndGlobalSection");

            codeWriter.WriteLine("EndGlobal");
        }
    }
}
