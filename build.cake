#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
/// argsddfff
var target = Argument("target", "default");

Task("b1")
    .Does(() =>
{
    MSBuild("./customerAPI.sln", new MSBuildSettings{
        Verbosity = Verbosity.Minimal
    });
});

Task("b2")
    .Does(() =>
{
    MSBuild("./AElf.Console.sln", new MSBuildSettings{
        Verbosity = Verbosity.Minimal
    });
});

Task("b3")
    .Does(() =>
{
    MSBuild("./AElf.Management.sln", new MSBuildSettings{
        Verbosity = Verbosity.Minimal
    });
});


Task("default")
    .IsDependentOn("b1")
      .Does(() =>
{
      Information("Hello World!");
});


RunTarget(target);
