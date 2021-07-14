using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.IO.Abstractions;
using Cmf.Common.Cli.Attributes;
using Cmf.Common.Cli.Constants;
using Cmf.Common.Cli.Factories;
using Cmf.Common.Cli.Interfaces;
using Cmf.Common.Cli.Utilities;

namespace Cmf.Common.Cli.Commands.restore
{
    /// <summary>
    /// Restore package dependencies (declared cmfpackage.json) from repository packages
    /// </summary>
    [CmfCommand("restore")]
    public class RestoreCommand : BaseCommand
    {
        /// <summary>
        /// Configure the Restore command options and arguments 
        /// </summary>
        /// <param name="cmd"></param>
        public override void Configure(Command cmd)
        {
            cmd.AddOption(new Option<string>(
                aliases: new string[] { "-r", "--repo" },
                description: "Repository where dependencies are located (url or folder)"));
            
            var packageRoot = FileSystemUtilities.GetPackageRoot(this.fileSystem);
            var arg = new Argument<IDirectoryInfo>(
                name: "packagePath",
                description: "Package path");
            cmd.AddArgument(arg);

            if (packageRoot != null)
            {
                var packagePath = this.fileSystem.Path.GetRelativePath(this.fileSystem.Directory.GetCurrentDirectory(), packageRoot.FullName);
                arg.SetDefaultValue(this.fileSystem.DirectoryInfo.FromDirectoryName(packagePath));
            }
            cmd.Handler = CommandHandler.Create<IDirectoryInfo, string>(Execute);
        }

        /// <summary>
        /// Execute the restore command
        /// </summary>
        /// <param name="packagePath">The path of the current package folder</param>
        /// <param name="repo">The package repository URI/path</param>
        public void Execute(IDirectoryInfo packagePath, string repo)
        {
            IFileInfo cmfpackageFile = this.fileSystem.FileInfo.FromFileName($"{packagePath}/{CliConstants.CmfPackageFileName}");

            IPackageTypeHandler packageTypeHandler = PackageTypeFactory.GetPackageTypeHandler(cmfpackageFile, setDefaultValues: false);
            Log.Debug($"Using repo at {repo}");
            Uri repoUri = repo != null ? new Uri(repo) : null;
            
            packageTypeHandler.RestoreDependencies(repoUri);
        }
    }
}