using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharpProject.Engine
{
    /// <summary>
    /// SolutionExtension
    /// </summary>
    public static class SolutionExtension
    {
        /// <summary>
        /// TransformText
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        public static string TransformText(this Solution solution)
        {
            var builder = new StringBuilder();

            new SolutionEngine().Generate(solution, builder);

            return builder.ToString();
        }
    }
}
