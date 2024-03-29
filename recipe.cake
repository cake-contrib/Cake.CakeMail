#load nuget:?package=Cake.Recipe&version=3.1.1

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./Source",
                            title: "Cake.CakeMail",
                            masterBranchName: "main",
                            repositoryOwner: "cake-contrib",
                            repositoryName: "Cake.CakeMail",
                            shouldRunDotNetCorePack: true,
                            shouldRunInspectCode: false,
                            shouldRunCodecov: false,
                            shouldPostToGitter: false,
                            appVeyorAccountName: "cakecontrib",
                            shouldCalculateVersion: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();
