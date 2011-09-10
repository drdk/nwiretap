using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using System.IO;
using System.Linq;

namespace NWiretap.Mvc
{
    public class NWiretapResourceProvider : VirtualPathProvider
    {
        private readonly List<AssemblyResource> _resources = new List<AssemblyResource>();
        private readonly Assembly _containingAssembly;
        public NWiretapResourceProvider()
        {
            var t = GetType();
            _containingAssembly = t.Assembly;
            var ns = t.Namespace ?? "NWiretap.Mvc";
            _resources.AddRange(_containingAssembly.GetManifestResourceNames().Select(a => new AssemblyResource()
                                                                                      {
                                                                                          ResourceName = a,
                                                                                          ResourcePath = GetProperPath(a, ns).ToLower()
                                                                                      }));

            var bla = "";

        }

        private static string GetProperPath(string resourceName, string ns)
        {
            var path = resourceName.Replace(ns, "").Replace(".", "/").Replace("/cshtml", ".cshtml").Replace("/css", ".css").Replace("/js", ".js");
            if(!path.EndsWith(".cshtml"))
            {
                return "/nwiretap" + path;
            }

            return path;
        }

        private bool IsAppResourcePath(string virtualPath)
        {
            var path = VirtualPathUtility.ToAbsolute(virtualPath).ToLower();
            var result = _resources.Any(a => a.ResourcePath == path);
            return result;
        }

        public override bool FileExists(string virtualPath)
        {
            return (IsAppResourcePath(virtualPath) || base.FileExists(virtualPath));
        }

        public override VirtualFile GetFile(string virtualPath)
        {
            var path = VirtualPathUtility.ToAbsolute(virtualPath).ToLower();
            return IsAppResourcePath(virtualPath) ? new AssemblyResourceVirtualFile(_resources.Single(a => a.ResourcePath == path)) : base.GetFile(virtualPath);
        }

        public override System.Web.Caching.CacheDependency GetCacheDependency(string virtualPath, System.Collections.IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            return IsAppResourcePath(virtualPath) ? null : base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
        }
    }

    class AssemblyResourceVirtualFile : VirtualFile
    {
        private readonly AssemblyResource _resource;
        public AssemblyResourceVirtualFile(AssemblyResource resource) : base(resource.ResourcePath)
        {
            _resource = resource;
        }

        public override Stream Open()
        {
            return GetType().Assembly.GetManifestResourceStream(_resource.ResourceName);
        }
    }

    class AssemblyResource
    {
        public string ResourceName;
        public string ResourcePath;
    }
}
