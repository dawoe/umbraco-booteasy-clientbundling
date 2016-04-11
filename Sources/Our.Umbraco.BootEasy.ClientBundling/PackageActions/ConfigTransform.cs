namespace Our.Umbraco.BootEasy.ClientBundling.PackageActions
{
    using System.Web;

    using Microsoft.Web.XmlTransform;

    using umbraco.cms.businesslogic.packager.standardPackageActions;
    using umbraco.interfaces;

    /// <summary>
    /// The config transform package action
    /// </summary>
    public class ConfigTransform : IPackageAction
    {
        public string Alias()
        {
            return "BootEasyClientBundling.ConfigTransform";
        }

        private bool Transform(string packageName, System.Xml.XmlNode xmlData, bool uninstall = false)
        {
            // The config file we want to modify
            var file = xmlData.Attributes.GetNamedItem("file").Value;

            string sourceDocFileName = VirtualPathUtility.ToAbsolute(file);

            // The xdt file used for tranformation 
            // var xdtfile = xmlData.Attributes.GetNamedItem("xdtfile").Value;
            var fileEnd = "install.xdt";
            if (uninstall)
            {
                fileEnd = string.Format("un{0}", fileEnd);
            }

            var xdtfile = string.Format("{0}.{1}", xmlData.Attributes.GetNamedItem("xdtfile").Value, fileEnd);
            string xdtFileName = VirtualPathUtility.ToAbsolute(xdtfile);

            // The translation at-hand
            using (var xmlDoc = new XmlTransformableDocument())
            {
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load(HttpContext.Current.Server.MapPath(sourceDocFileName));

                using (var xmlTrans = new XmlTransformation(HttpContext.Current.Server.MapPath(xdtFileName)))
                {
                    if (xmlTrans.Apply(xmlDoc))
                    {
                        // If we made it here, sourceDoc now has transDoc's changes
                        // applied. So, we're going to save the final result off to
                        // destDoc.
                        xmlDoc.Save(HttpContext.Current.Server.MapPath(sourceDocFileName));
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Executes the package action
        /// </summary>
        /// <param name="packageName">Package name</param>
        /// <param name="xmlData">Xml data</param>
        /// <returns></returns>
        public bool Execute(string packageName, System.Xml.XmlNode xmlData)
        {
            return this.Transform(packageName, xmlData);
        }

        /// <summary>
        /// The sample xml.
        /// </summary>
        /// <returns>
        /// The <see cref="XmlNode"/>.
        /// </returns>
        public System.Xml.XmlNode SampleXml()
        {
            string str = "<Action runat=\"install\" undo=\"true\" alias=\"BootEasyClientBundling.ConfigTransform\" file=\"~/web.config\" xdtfile=\"~/app_plugins/demo/web.config\">" +
                     "</Action>";
            return helper.parseStringToXmlNode(str);
        }

        /// <summary>
        /// Runs at uninstall
        /// </summary>
        /// <param name="packageName">
        /// The package name.
        /// </param>
        /// <param name="xmlData">
        /// The xml data.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Undo(string packageName, System.Xml.XmlNode xmlData)
        {
            return this.Transform(packageName, xmlData, true);
        }
    }
}