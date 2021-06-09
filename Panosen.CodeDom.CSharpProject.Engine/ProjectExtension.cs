using Panosen.CodeDom.CSharpProject.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharpProject.Engine
{
    /// <summary>
    /// ProjectExtension
    /// </summary>
    public static class ProjectExtension
    {
        /// <summary>
        /// TransformText
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public static string TransformText(this Project project)
        {
            var builder = new StringBuilder();

            new ProjectEngine().Generate(project, builder);

            return builder.ToString();
        }
    }
}
