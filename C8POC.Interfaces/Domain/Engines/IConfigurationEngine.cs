﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConfigurationEngine.cs" company="AlFranco">
//   Albert Rodriguez Franco 2013
// </copyright>
// <summary>
//   Defines the IConfigurationEngine type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace C8POC.Interfaces.Domain.Engines
{
    using C8POC.Interfaces.Infrastructure.Services;

    /// <summary>
    /// The Configuration Engine interface.
    /// </summary>
    public interface IConfigurationEngine : IMediatedEngine
    {
        /// <summary>
        /// Gets or sets the configuration service.
        /// </summary>
        IConfigurationService ConfigurationService { get; set; }

        /// <summary>
        /// The get configuration key of type.
        /// </summary>
        /// <param name="configurationKey">
        /// The configuration key.
        /// </param>
        /// <typeparam name="T">
        /// Type of parameter
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T GetConfigurationKeyOfType<T>(string configurationKey);
    }
}