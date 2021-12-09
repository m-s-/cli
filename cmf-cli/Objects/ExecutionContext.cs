using System;
using Cmf.Common.Cli.Utilities;
using System.IO.Abstractions;
using System.Text.Json;
using Cmf.Common.Cli.Enums;

namespace Cmf.Common.Cli.Objects
{
    /// <summary>
    /// The current execution context
    /// </summary>
    public class ExecutionContext
    {
        private static ExecutionContext instance;
        private IFileSystem fileSystem;

        /// <summary>
        /// The current ExecutionContext object
        /// </summary>
        public static ExecutionContext Instance => instance;

        /// <summary>
        /// The current FileSystem object
        /// </summary>
        public IFileSystem FileSystem => fileSystem;

        /// <summary>
        /// The current execution RepositoriesConfig object
        /// </summary>
        public RepositoriesConfig RepositoriesConfig { get; set; }

        /// <summary>
        /// What installation target are we scaffolding for
        /// </summary>
        public ScaffoldingTarget ScaffoldingTarget { get; set; }

        private ExecutionContext(IFileSystem fileSystem)
        {
            // private constructor, can only obtain instance via the Instance property
            this.fileSystem = fileSystem;
            this.RepositoriesConfig = FileSystemUtilities.ReadRepositoriesConfig(fileSystem);
        }

        /// <summary>
        /// Initialize the current ExecutionContext instance
        /// </summary>
        public static ExecutionContext Initialize(IFileSystem fileSystem) => instance = new ExecutionContext(fileSystem);
    }
}
