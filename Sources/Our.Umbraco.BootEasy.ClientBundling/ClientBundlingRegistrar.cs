namespace Our.Umbraco.BootEasy.ClientBundling
{
    using System.Web.Optimization;

    using Our.Umbraco.BootEasy.ClientBundling.Config;

    /// <summary>
    /// The client bundling registrar.
    /// </summary>
    internal class ClientBundlingRegistrar : BootRegistrars.ApplicationStartedBootRegistrar
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

        /// <summary>
        /// Register script bundles.
        /// </summary>
        private void RegisterScriptBundles()
        {
            foreach (BundleElement bundleConfig in ClientBundlingConfig.Current.ScriptBundles)
            {
                var scriptBundle = new ScriptBundle(bundleConfig.Path) { Orderer = new AsIsBundleOrderer() };

                foreach (FileElement file in bundleConfig.Files)
                {
                    scriptBundle.Include(file.Path);
                }

                BundleTable.Bundles.Add(scriptBundle);
            }
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
