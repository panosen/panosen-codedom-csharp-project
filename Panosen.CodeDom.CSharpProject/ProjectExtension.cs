using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharpProject
{
    /// <summary>
    /// NetStandardCsprojTemplate extension
    /// </summary>
    public static class ProjectExtension
    {
        /// <summary>
        /// add FrameworkReference
        /// </summary>
        public static Project AddFrameworkReference(this Project template, string frameworkName)
        {
            if (template.FrameworkReferenceList == null)
            {
                template.FrameworkReferenceList = new List<string>();
            }

            template.FrameworkReferenceList.Add(frameworkName);

            return template;
        }

        /// <summary>
        /// add PackageReference
        /// </summary>
        public static Project AddPackageReference(this Project template, string packageName, string version)
        {
            if (template.PackageReferenceMap == null)
            {
                template.PackageReferenceMap = new Dictionary<string, string>();
            }

            if (template.PackageReferenceMap.ContainsKey(packageName))
            {
                return template;
            }

            template.PackageReferenceMap.Add(packageName, version);

            return template;
        }

        /// <summary>
        /// AddProjectReference
        /// </summary>
        public static Project AddProjectReference(this Project template, string projectReference)
        {
            if (template.ProjectReferenceList == null)
            {
                template.ProjectReferenceList = new List<string>();
            }

            if (template.ProjectReferenceList.Contains(projectReference))
            {
                return template;
            }

            template.ProjectReferenceList.Add(projectReference);

            return template;
        }

        /// <summary>
        /// add TargetFramework
        /// </summary>
        public static Project AddTargetFramework(this Project template, string targeFramework)
        {
            if (template.TargetFrameworkList == null)
            {
                template.TargetFrameworkList = new List<string>();
            }

            if (template.TargetFrameworkList.Contains(targeFramework))
            {
                return template;
            }

            template.TargetFrameworkList.Add(targeFramework);

            return template;
        }
    }
}
