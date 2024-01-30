using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.CSharpProject.Engine.MSTest
{
    [TestClass]
    public class ProjectEngineTest2
    {

        [TestMethod]
        public void Test()
        {
            Project project = new Project();
            project.Sdk = "Microsoft.NET.Sdk";
            project.AddTargetFramework("net472");
            project.AddTargetFramework("netstandard20");
            project.AddFrameworkReference("Microsoft.AspNetCore.App");
            project.AddPackageReference("MySql.Data.EntityFrameworkCore", "8.0.22");
            project.GeneratePackageOnBuild = false;

            ProjectEngine engine = new ProjectEngine();

            var builder = new StringBuilder();

            engine.Generate(project, builder);

            var actual = builder.ToString();

            var expected = PrepareExpected();

            Assert.AreEqual(expected, actual);
        }

        private string PrepareExpected()
        {
            return @"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFrameworks>net472;netstandard20</TargetFrameworks>
    <GeneratePackageOnBuild>false</GeneratePackageOnBuild>
  </PropertyGroup>

  <ItemGroup>
    <FrameworkReference Include=""Microsoft.AspNetCore.App"" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include=""MySql.Data.EntityFrameworkCore"" Version=""8.0.22"" />
  </ItemGroup>

</Project>
";
        }
    }
}
