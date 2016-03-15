namespace Our.Umbraco.BootEasy.ClientBundling.Config
{
    using System.Configuration;

    /// <summary>
    /// The bundle configuration element.
    /// </summary>
    public class BundleElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }

            set
            {
                this["name"] = value;
            }
        }
    }
}
