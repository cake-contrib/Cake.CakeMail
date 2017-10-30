#load nuget:https://www.myget.org/F/cake-contrib/api/v2?package=Cake.Recipe&prerelease

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./Source",
                            title: "Cake.CakeMail",
                            repositoryOwner: "cake-contrib",
                            repositoryName: "Cake.CakeMail",
                            shouldRunDotNetCorePack: true,
                            appVeyorAccountName: "cakecontrib");

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
                            dupFinderExcludePattern: new string[] {
                                BuildParameters.RootDirectoryPath + "/Source/Cake.CakeMail.Tests/**/*.cs",
                                BuildParameters.RootDirectoryPath + "/Source/Cake.CakeMail/**/*.AssemblyInfo.cs"
                            },
                            testCoverageFilter: "+[Cake.CakeMail]*",
                            testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
                            testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");

Build.RunDotNetCore();
