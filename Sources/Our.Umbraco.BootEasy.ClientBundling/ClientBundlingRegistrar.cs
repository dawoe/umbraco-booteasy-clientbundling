namespace Our.Umbraco.BootEasy.ClientBundling
{
    using System.Web.Optimization;

    using Our.Umbraco.BootEasy.ClientBundling.Config;

    /// <summary>
    /// The client bundling registrar.
    /// </summary>
    public class ClientBundlingRegistrar : BootRegistrars.ApplicationStartedBootRegistrar
    {
        /// <summary>
        /// Gets the sort order.
        /// </summary>
        public override int SortOrder
        {
            get
            {
                return 99;
            } 
        }

        /// <summary>
        /// Registers the clientside bundles
        /// </summary>
        public override void Register()
        {
            this.RegisterCssBundles();
            this.RegisterScriptBundles();
        }

        private void RegisterScriptBundles()
        {
           
        }

        /// <summary>
        /// Register  css bundles.
        /// </summary>
        private void RegisterCssBundles()
        {
            foreach (BundleElement bundleConfig in ClientBundlingConfig.Current.CssBundles)
            {
                var cssBundle = new StyleBundle(bundleConfig.Path);

                foreach (FileElement file in bundleConfig.Files)
                {
                    cssBundle.Include(file.Path, new CssRewriteUrlTransform());
                }

                BundleTable.Bundles.Add(cssBundle);
            }
        }
    }
}
