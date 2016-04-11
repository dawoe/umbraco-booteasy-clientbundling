namespace Our.Umbraco.BootEasy.ClientBundling
{
    using System;
    using System.Web.Optimization;

    using global::Umbraco.Core.Logging;
    using global::Umbraco.Web;

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
            try
            {
                this.RegisterCssBundles();
                this.RegisterScriptBundles();
            }
            catch (Exception e)
            {
                LogHelper.Error<ClientBundlingRegistrar>("Error registering client side bundles", e);
            }
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
