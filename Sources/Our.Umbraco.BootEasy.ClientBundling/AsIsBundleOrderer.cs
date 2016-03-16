namespace Our.Umbraco.BootEasy.ClientBundling
{
    using System.Collections.Generic;
    using System.Web.Optimization;

    /// <summary>
    /// The as is bundle orderer.
    /// </summary>
    internal class AsIsBundleOrderer : IBundleOrderer
    {        
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}
