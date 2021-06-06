using System;
using System.Collections.Generic;

namespace Panosen.CodeDom.CSharpProject
{
    public class Project
    {
        /// <summary>
        /// Microsoft.NET.Sdk.Web 或 Microsoft.NET.Sdk
        /// </summary>
        public string Sdk { get; set; }

        /// <summary>
        /// ProjectName
        /// </summary>
        public string ProjectName { get; set; }

        public string ProjectPath { get; set; }

        public string ProjectGuid { get; set; }

        public string ProjectTypeGuid { get; set; }

        /// <summary>
        /// 目标框架
        /// </summary>
        public List<string> TargetFrameworkList { get; set; }

        /// <summary>
        /// 包引用
        /// </summary>
        public Dictionary<string, string> PackageReferenceMap { get; set; }

        /// <summary>
        /// 框架引用
        /// </summary>
        public Dictionary<string, string> FrameworkReferenceMap { get; set; }

        /// <summary>
        /// 项目引用
        /// </summary>
        public List<string> ProjectReferenceList { get; set; }

        /// <summary>
        /// 是否包含DocumentationFile
        /// </summary>
        public bool WithDocumentationFile { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Authors { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 程序集名称
        /// </summary>
        public string AssemblyName { get; set; }

        /// <summary>
        /// 根命名空间
        /// </summary>
        public string RootNamespace { get; set; }

        /// <summary>
        /// ClientApp\dist\** 或 ClientApp\**
        /// </summary>
        public string DistFilesPath { get; set; }

        public bool? GeneratePackageOnBuild { get; set; }
    }
}
