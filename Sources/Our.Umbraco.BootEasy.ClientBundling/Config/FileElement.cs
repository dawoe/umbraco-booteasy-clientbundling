namespace Our.Umbraco.BootEasy.ClientBundling.Config
{
    using System.Configuration;

    /// <summary>
    /// The file configuration element
    /// </summary>
    public class FileElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        [ConfigurationProperty("path", IsRequired = true, IsKey = true)]
        public string Path
        {
            get
            {
                return (string)this["path"];
            }

            set
            {
                this["path"] = value;
            }
        }
    }
}
