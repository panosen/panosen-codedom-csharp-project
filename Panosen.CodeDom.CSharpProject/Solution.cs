using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharpProject
{
    /// <summary>
    /// Solution
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// SolutionGuid
        /// </summary>
        public string SolutionGuid { get; set; }

        /// <summary>
        /// ProjectList
        /// </summary>
        public List<Project> ProjectList { get; set; }
    }
}
