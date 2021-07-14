﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;

namespace Cmf.Common.Cli.Interfaces
{
    /// <summary>
    ///
    /// </summary>
    public interface IPackageTypeHandler
    {
        /// <summary>
        /// Gets or sets the default content to ignore.
        /// </summary>
        /// <value>
        /// The default content to ignore.
        /// </value>
        public List<string> DefaultContentToIgnore { get; }

        /// <summary>
        /// Bumps the specified version.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="buildNr">The version for build Nr.</param>
        /// <param name="bumpInformation">The bump information.</param>
        public abstract void Bump(string version, string buildNr, Dictionary<string, object> bumpInformation = null);

        /// <summary>
        /// Builds this instance.
        /// </summary>
        public void Build();

        /// <summary>
        /// Packs the specified package output dir.
        /// </summary>
        /// <param name="packageOutputDir">The package output dir.</param>
        /// <param name="outputDir">The output dir.</param>
        public void Pack(IDirectoryInfo packageOutputDir, IDirectoryInfo outputDir);
        
        /// <summary>
        /// Restore package dependencies (declared cmfpackage.json) from repository packages
        /// </summary>
        public void RestoreDependencies(Uri repository);
    }
}