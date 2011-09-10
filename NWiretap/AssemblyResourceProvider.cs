using System;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using System.IO;
using System.Linq;
namespace NWiretap
{
    public class AssemblyResourceProvider : System.Web.Hosting.VirtualPathProvider
    {
        public AssemblyResourceProvider() { }

        private static bool IsAppResourcePath(string virtualPath)
        {
            var checkPath = VirtualPathUtility.ToAppRelative(virtualPath);
            const string prefix = "~/Plugin/";

            if (checkPath.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
            {
                string[] parts = checkPath.Split('/');
                if (parts.Length < 4)
                    return false;

                var assemblyName = parts[2];
                var resourceName = parts[3];

                var assemblyPath = Path.Combine(HttpRuntime.BinDirectory, assemblyName);

                var asm = Assembly.LoadFrom(assemblyPath);
                var resources = asm.GetManifestResourceNames();

                return resources.Contains(resourceName);
            }

            return false;
        }
        public override bool FileExists(string virtualPath)
        {
            return (IsAppResourcePath(virtualPath) || base.FileExists(virtualPath));
        }
        public override VirtualFile GetFile(string virtualPath)
        {
            if (IsAppResourcePath(virtualPath))
                return new AssemblyResourceVirtualFile(virtualPath);
            else
                return base.GetFile(virtualPath);
        }
        public override System.Web.Caching.CacheDependency GetCacheDependency(string virtualPath, System.Collections.IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            if (IsAppResourcePath(virtualPath))
                return null;
            else
                return base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
        }
    }

    class AssemblyResourceVirtualFile : VirtualFile
    {
        string path;
        public AssemblyResourceVirtualFile(string virtualPath)
            : base(virtualPath)
        {
            path = VirtualPathUtility.ToAppRelative(virtualPath);
        }
        public override System.IO.Stream Open()
        {
            string[] parts = path.Split('/');
            string assemblyName = parts[2];
            string resourceName = parts[3];

            assemblyName = Path.Combine(HttpRuntime.BinDirectory, assemblyName);

            System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile(assemblyName);
            if (assembly != null)
            {
                Stream resourceStream = assembly.GetManifestResourceStream(resourceName);
                var bla = assembly.GetManifestResourceNames();
                return resourceStream;
            }
            return null;
        }
    }
}
