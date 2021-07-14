#### [cmf](index.md 'index')
## Cmf.Common.Cli.Commands.restore Namespace
### Classes
<a name='Cmf_Common_Cli_Commands_restore_RestoreCommand'></a>
## RestoreCommand Class
Restore package dependencies (declared cmfpackage.json) from repository packages  
```csharp
public class RestoreCommand : Cmf.Common.Cli.Commands.BaseCommand
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BaseCommand](Cmf_Common_Cli_Commands.md#Cmf_Common_Cli_Commands_BaseCommand 'Cmf.Common.Cli.Commands.BaseCommand') &#129106; RestoreCommand  
### Methods
<a name='Cmf_Common_Cli_Commands_restore_RestoreCommand_Configure(System_CommandLine_Command)'></a>
## RestoreCommand.Configure(Command) Method
Configure the Restore command options and arguments   
```csharp
public override void Configure(System.CommandLine.Command cmd);
```
#### Parameters
<a name='Cmf_Common_Cli_Commands_restore_RestoreCommand_Configure(System_CommandLine_Command)_cmd'></a>
`cmd` [System.CommandLine.Command](https://docs.microsoft.com/en-us/dotnet/api/System.CommandLine.Command 'System.CommandLine.Command')  
  
  
<a name='Cmf_Common_Cli_Commands_restore_RestoreCommand_Execute(System_IO_Abstractions_IDirectoryInfo_string)'></a>
## RestoreCommand.Execute(IDirectoryInfo, string) Method
Execute the restore command  
```csharp
public void Execute(System.IO.Abstractions.IDirectoryInfo packagePath, string repo);
```
#### Parameters
<a name='Cmf_Common_Cli_Commands_restore_RestoreCommand_Execute(System_IO_Abstractions_IDirectoryInfo_string)_packagePath'></a>
`packagePath` [System.IO.Abstractions.IDirectoryInfo](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Abstractions.IDirectoryInfo 'System.IO.Abstractions.IDirectoryInfo')  
The path of the current package folder
  
<a name='Cmf_Common_Cli_Commands_restore_RestoreCommand_Execute(System_IO_Abstractions_IDirectoryInfo_string)_repo'></a>
`repo` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The package repository URI/path
  
  
  
