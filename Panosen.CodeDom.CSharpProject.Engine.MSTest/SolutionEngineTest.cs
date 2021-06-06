using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panosen.CodeDom.CSharpProject.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharpProject.Engine.MSTest
{
    [TestClass]
    public class SolutionEngineTest
    {

        [TestMethod]
        public void Test()
        {
            Solution solution = new Solution();
            solution.SolutionGuid = "{0E37E368-E90C-4A4B-8383-FE038C277E84}";

            var project = solution.AddProject();
            project.ProjectName = "PanosenConfig.PConfig.Repository";
            project.ProjectGuid = "{5CDD64C7-9654-4D4A-92D5-A9A7BA196DB4}";
            project.ProjectPath = $"{project.ProjectName}\\{project.ProjectName}.csproj";
            project.ProjectTypeGuid = ProjectTypeGuids.CSharpLibrarySDK;

            var builder = new StringBuilder();

            new SolutionEngine().Generate(solution, new StringWriter(builder));

            var actual = builder.ToString();

            var expected = PrepareExpected();

            Assert.AreEqual(expected, actual);
        }

        private string PrepareExpected()
        {
            return @"
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 16
VisualStudioVersion = 16.0.28803.452
MinimumVisualStudioVersion = 10.0.40219.1
Project(""{9A19103F-16F7-4668-BE54-9A1E7A4F7556}"") = ""PanosenConfig.PConfig.Repository"", ""PanosenConfig.PConfig.Repository\PanosenConfig.PConfig.Repository.csproj"", ""{5CDD64C7-9654-4D4A-92D5-A9A7BA196DB4}""
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{5CDD64C7-9654-4D4A-92D5-A9A7BA196DB4}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{5CDD64C7-9654-4D4A-92D5-A9A7BA196DB4}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{5CDD64C7-9654-4D4A-92D5-A9A7BA196DB4}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{5CDD64C7-9654-4D4A-92D5-A9A7BA196DB4}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {0E37E368-E90C-4A4B-8383-FE038C277E84}
	EndGlobalSection
EndGlobal
";
        }
    }
}