using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace Mtf.Core
{
    public class MefLoader
    {
        private static MefLoader mefLoader;
        private static object sync = new object();

        public CompositionContainer GetCompositionContainerr(params string[] loadingAssemblies)
        {
            var aggregateCatalog = new AggregateCatalog();
            foreach (var loadingAssembly in loadingAssemblies)
            {
                var assembly = Assembly.Load(new AssemblyName(loadingAssembly));
                aggregateCatalog.Catalogs.Add(new AssemblyCatalog(assembly));
            }
            return new CompositionContainer(aggregateCatalog);
        }

        public static MefLoader Get()
        {
            lock (sync)
            {
                if (mefLoader == null)
                {
                    mefLoader = new MefLoader();
                    return mefLoader;
                }
                return mefLoader;
            }
        }
    }
}
