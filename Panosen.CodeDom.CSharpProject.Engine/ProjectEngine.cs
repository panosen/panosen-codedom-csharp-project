﻿using Panosen.CodeDom.Xml;
using Panosen.CodeDom.Xml.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.CSharpProject.Engine
{
    /// <summary>
    /// ProjectEngine
    /// </summary>
    public class ProjectEngine
    {
        /// <summary>
        /// Generate
        /// </summary>
        /// <param name="project"></param>
        /// <param name="codeWriter"></param>
        public void Generate(Project project, CodeWriter codeWriter)
        {
            var codeFile = BuildXmlNode(project);

            new XmlCodeEngine().Generate(codeFile, codeWriter, new GenerateOptions
            {
                TabString = "  "
            });
        }

        private XmlNode BuildXmlNode(Project project)
        {
            XmlNode root = new XmlNode { Name = "Project", NewLineBeforeEnd = true };

            if (!string.IsNullOrEmpty(project.Sdk))
            {
                root.AddAttribute("Sdk", project.Sdk);
            }

            BuildPropertyGroup(root, project);

            BuildFrameworkReference(root, project);

            BuildPackageReference(root, project);

            BuildProjectReference(root, project);

            BuildPublishRunWebpack(root, project);

            return root;
        }

        private void BuildPropertyGroup(XmlNode root, Project project)
        {
            var propertyGroup = new XmlNode { Name = "PropertyGroup", NewLineBeforeNode = true };

            root.AddChild(propertyGroup);

            if (project.TargetFrameworkList != null && project.TargetFrameworkList.Count > 0)
            {
                if (project.TargetFrameworkList.Count > 1)
                {
                    propertyGroup.AddChild(new XmlNode { Name = "TargetFrameworks", Content = string.Join(";", project.TargetFrameworkList) });
                }
                else
                {
                    propertyGroup.AddChild(new XmlNode { Name = "TargetFramework", Content = project.TargetFrameworkList.First() });
                }
            }

            if (!string.IsNullOrEmpty(project.AssemblyName))
            {
                propertyGroup.AddChild(new XmlNode { Name = "AssemblyName", Content = project.AssemblyName });
            }
            if (!string.IsNullOrEmpty(project.RootNamespace))
            {
                propertyGroup.AddChild(new XmlNode { Name = "RootNamespace", Content = project.RootNamespace });
            }
            if (!string.IsNullOrEmpty(project.Version))
            {
                propertyGroup.AddChild(new XmlNode { Name = "Version", Content = project.Version });
            }
            if (!string.IsNullOrEmpty(project.Authors))
            {
                propertyGroup.AddChild(new XmlNode { Name = "Authors", Content = project.Authors });
            }
            if (!string.IsNullOrEmpty(project.Company))
            {
                propertyGroup.AddChild(new XmlNode { Name = "Company", Content = project.Company });
            }
            if (project.GeneratePackageOnBuild != null)
            {
                propertyGroup.AddChild("GeneratePackageOnBuild").SetContent(project.GeneratePackageOnBuild.ToString().ToLower());
            }
            if (project.WithDocumentationFile)
            {
                propertyGroup.AddChild(new XmlNode { Name = "DocumentationFile", Content = $"bin\\$(Configuration)\\{project.AssemblyName}.xml" });
            }
        }

        private void BuildFrameworkReference(XmlNode root, Project project)
        {
            if (project.FrameworkReferenceList == null || project.FrameworkReferenceList.Count == 0)
            {
                return;
            }

            var itemGroup = new XmlNode { Name = "ItemGroup", NewLineBeforeNode = true };
            root.AddChild(itemGroup);

            foreach (var frameworkReference in project.FrameworkReferenceList)
            {
                var packageReferenceItem = new XmlNode { Name = "FrameworkReference" };
                packageReferenceItem.AddAttribute("Include", frameworkReference);

                itemGroup.AddChild(packageReferenceItem);
            }
        }

        private void BuildPackageReference(XmlNode root, Project project)
        {
            if (project.PackageReferenceMap == null || project.PackageReferenceMap.Count == 0)
            {
                return;
            }

            var itemGroup = new XmlNode { Name = "ItemGroup", NewLineBeforeNode = true };
            root.AddChild(itemGroup);

            var sortedPackageReferenceMap = new SortedDictionary<string, string>(project.PackageReferenceMap);

            foreach (var packageReference in sortedPackageReferenceMap)
            {
                var packageReferenceItem = new XmlNode { Name = "PackageReference" };
                packageReferenceItem.AddAttribute("Include", packageReference.Key);
                if (!string.IsNullOrEmpty(packageReference.Value))
                {
                    packageReferenceItem.AddAttribute("Version", packageReference.Value);
                }
                itemGroup.AddChild(packageReferenceItem);
            }
        }

        private void BuildProjectReference(XmlNode root, Project project)
        {
            if (project.ProjectReferenceList == null || project.ProjectReferenceList.Count == 0)
            {
                return;
            }

            var itemGroup = new XmlNode { Name = "ItemGroup", NewLineBeforeNode = true };
            root.AddChild(itemGroup);
            foreach (var projectReference in project.ProjectReferenceList)
            {
                var item = new XmlNode { Name = "ProjectReference" };
                item.AddAttribute("Include", projectReference);
                itemGroup.AddChild(item);
            }
        }

        private void BuildPublishRunWebpack(XmlNode root, Project project)
        {
            if (string.IsNullOrEmpty(project.DistFilesPath))
            {
                return;
            }

            var targetNode = new XmlNode { Name = "Target", NewLineBeforeNode = true };
            root.AddChild(targetNode);

            targetNode.AddAttribute("Name", "PublishRunWebpack");
            targetNode.AddAttribute("AfterTargets", "ComputeFilesToPublish");

            var itemGroup = new XmlNode { Name = "ItemGroup" };
            targetNode.AddChild(itemGroup);

            var distFiles = new XmlNode { Name = "DistFiles" };
            distFiles.AddAttribute("Include", project.DistFilesPath);
            itemGroup.AddChild(distFiles);

            var resolvedFileToPublish = new XmlNode { Name = "ResolvedFileToPublish" };
            itemGroup.AddChild(resolvedFileToPublish);
            resolvedFileToPublish.AddAttribute("Include", "@(DistFiles->'%(FullPath)')");
            resolvedFileToPublish.AddAttribute("Exclude", "@(ResolvedFileToPublish)");

            var relativePath = new XmlNode { Name = "RelativePath", Content = "%(DistFiles.Identity)" };
            resolvedFileToPublish.AddChild(relativePath);

            var copyToPublishDirectory = new XmlNode { Name = "CopyToPublishDirectory", Content = "PreserveNewest" };
            resolvedFileToPublish.AddChild(copyToPublishDirectory);
        }
    }
}
