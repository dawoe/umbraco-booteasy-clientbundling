namespace Our.Umbraco.BootEasy.ClientBundling.Config
{
    using System.Configuration;

    /// <summary>
    /// The client bundling configuration section.
    /// </summary>
    public class ClientBundlingSection : ConfigurationSection
    {
        /// <summary>
        /// Gets or sets the css bundles.
        /// </summary>
        [ConfigurationProperty("CssBundles", IsRequired = true)]
        public BundlesCollection CssBundles
        {
            get
            {
                return (BundlesCollection)base["CssBundles"];
            }

            set
            {
                base["CssBundles"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the script bundles.
        /// </summary>
        [ConfigurationProperty("ScriptBundles", IsRequired = true)]
        public BundlesCollection ScriptBundles
        {
            get
            {
                return (BundlesCollection)base["ScriptBundles"];
            }

            set
            {
                base["ScriptBundles"] = value;
            }
        }
    }
}
