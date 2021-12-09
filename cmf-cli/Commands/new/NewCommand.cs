using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO.Abstractions;
using Cmf.Common.Cli.Attributes;
using Cmf.Common.Cli.Enums;
using Cmf.Common.Cli.Objects;
using Cmf.Common.Cli.Utilities;
using Namotion.Reflection;

namespace Cmf.Common.Cli.Commands
{
    /// <summary>
    /// "new" command group
    /// </summary>
    [CmfCommand("new")]
    public class NewCommand : TemplateCommand
    {
        private Command _cmd;
        /// <summary>
        /// Configure command
        /// </summary>
        /// <param name="cmd"></param>
        public override void Configure(Command cmd)
        {
            this._cmd = cmd;
            cmd.AddOption(new Option<bool>(
                aliases: new[] { "--reset" },
                description: "Reset template engine. Use this if after an upgrade the templates are not working correctly."
            ));
            cmd.AddOption(new Option<ScaffoldingTarget>(
                aliases: new[] { "--target" },
                parseArgument: result =>
                {
                    ScaffoldingTarget? res = null;
                    if (result.Tokens.Count == 1)
                    {
                        switch (result.Tokens[0].Value?.ToLowerInvariant())
                        {
                            case "df":
                            case "deploymentframework":
                                res = ScaffoldingTarget.DeploymentFramework;
                                break;
                            case "doc":
                            case "devopscenter":
                                res = ScaffoldingTarget.DevOpsCenter;
                                break;
                        }
                    }

                    if (res == null)
                    {
                        try
                        {
                            var projectConfig = FileSystemUtilities.ReadProjectConfig(this.fileSystem);

                            if (projectConfig.RootElement.HasProperty("DefaultScaffoldingTarget") &&
                                ScaffoldingTarget.TryParse(
                                    projectConfig.RootElement.GetProperty("DefaultScaffoldingTarget")
                                        .GetString(), true, out ScaffoldingTarget target))
                            {
                                res = target;
                            }
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                    return res ?? ScaffoldingTarget.DevOpsCenter;

                },
                isDefault: true,
                description: "Scaffolding target: DevOps Center (DOC/DevOpsCenter) or Deployment Framework (DF/DeploymentFramework). If not provided, will fallback to the mode used for the init command. If not available, will default to DevOps Center."
            ));
            cmd.Handler = CommandHandler.Create<bool, ScaffoldingTarget>(Execute);
        }

        /// <summary>
        /// Execute command
        /// </summary>
        /// <param name="reset"></param>
        public void Execute(bool reset, ScaffoldingTarget target)
        {
            // TODO: this is not invoked when running e.g. cmf new business
            ExecutionContext.Instance.ScaffoldingTarget = target;
            if (reset)
            {
                RunCommand(new []{ "--debug:reinit" });
            }
            else
            {
                this._cmd.Invoke(new [] { "-h" });
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public NewCommand() : base("new")
        {
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="fileSystem"></param>
        public NewCommand(IFileSystem fileSystem) : base("new", fileSystem)
        {
        }
    }
}