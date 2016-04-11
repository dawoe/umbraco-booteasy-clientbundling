namespace Our.Umbraco.BootEasy.ClientBundling.Config
{
    using System.Configuration;

    /// <summary>
    /// The bundle configuration element.
    /// </summary>
    internal class BundleElement : ConfigurationElement
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

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        [ConfigurationProperty("path", IsRequired = true, IsKey = false)]
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

        /// <summary>
        /// Gets or sets the files.
        /// </summary>       
         [ConfigurationProperty("files", IsDefaultCollection = true)]
        public FilesCollection Files
        {
            get
            {
                return (FilesCollection)base["files"];
            }

            set
            {
                base["files"] = value;
            }
        }
    }
}
