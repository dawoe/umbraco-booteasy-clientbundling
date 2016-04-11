namespace Our.Umbraco.BootEasy.ClientBundling.Config
{
    /// <summary>
    /// The client bundling config.
    /// </summary>
    internal class ClientBundlingConfig
    {
        private static ClientBundlingConfig instance;
        private static ClientBundlingSection section;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientBundlingConfig"/> class.
        /// </summary>
        public ClientBundlingConfig()
        {
            section = (ClientBundlingSection)System.Configuration.ConfigurationManager.GetSection("BootEasyClientBundling");
            instance = this;           
        }

        /// <summary>
        /// Gets a client bunlde config instance.
        /// </summary>
        public static ClientBundlingConfig Current
        {
            get
            {
                return instance ?? new ClientBundlingConfig();
            }
        }

        public BundlesCollection CssBundles
        {
            get
            {
                return section.CssBundles;
            }
        }

        public BundlesCollection ScriptBundles
        {
            get
            {
                return section.ScriptBundles;
            }
        }
    }
}
