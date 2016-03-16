﻿namespace Our.Umbraco.BootEasy.ClientBundling
{
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
            var config = ClientBundlingConfig.Current;
        }
    }
}
