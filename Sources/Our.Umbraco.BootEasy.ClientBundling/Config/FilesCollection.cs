namespace Our.Umbraco.BootEasy.ClientBundling.Config
{
    using System;
    using System.Configuration;

    /// <summary>
    /// The files collection config element.
    /// </summary>
    public class FilesCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// The tag name.
        /// </summary>
        internal const string TagName = "file";

        /// <summary>
        /// Gets the type of the <see cref="T:System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <returns>The <see cref="T:System.Configuration.ConfigurationElementCollectionType"/> of this collection.</returns>
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }

        /// <summary>
        /// Gets the element name.
        /// </summary>
        protected override string ElementName
        {
            get
            {
                return TagName;
            }
        }

        /// <summary>
        /// The this.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="BundleElement"/>.
        /// </returns>
        public new FileElement this[string key]
        {
            get
            {
                return (FileElement)this.BaseGet(key);
            }
        }
        
        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Configuration.ConfigurationElementCollection"/> object is read only.
        /// </summary>
        /// <returns>
        /// true if the <see cref="T:System.Configuration.ConfigurationElementCollection"/> object is read only; otherwise, false.
        /// </returns>
        public override bool IsReadOnly()
        {
            return false;
        }

        /// <summary>
        /// Indicates whether the specified <see cref="T:System.Configuration.ConfigurationElement"/> exists in the <see cref="T:System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="elementName">The name of the element to verify.</param>
        /// <returns>
        /// true if the element exists in the collection; otherwise, false. The default is false.
        /// </returns>
        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals(TagName, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// When overridden in a derived class, creates a new <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new FileElement();
        }

        /// <summary>
        /// Gets the element key for a specified configuration element when overridden in a derived class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Object"/> that acts as the key for the specified <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        /// <param name="element">The <see cref="T:System.Configuration.ConfigurationElement"/> to return the key for. </param>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FileElement)element).Path;
        }
    }
}
