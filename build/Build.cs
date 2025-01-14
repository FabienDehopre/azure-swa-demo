using Nuke.Common;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Coverlet;
using Nuke.Common.Tools.Docker;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities;
using TextCopy;
using static AzTasks;
using static Nuke.Common.Tools.Docker.DockerTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
// ReSharper disable UnusedMember.Local

[GitHubActions(
    "continuous",
    GitHubActionsImage.UbuntuLatest,
    On = new[] { GitHubActionsTrigger.Push },
    InvokedTargets = new[] { nameof(Deploy) },
    ImportSecrets = new[] { nameof(ApiToken) })]
[CheckBuildProjectConfigurations]
partial class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() => Execute<Build>();

    [GitRepository] readonly GitRepository Repository;

    [PathExecutable] readonly Tool Az;

    [Parameter] readonly string Name;
    [Parameter] readonly string Location;
    [Parameter] readonly string ResourceGroup;

    AbsolutePath TemplateFile => BuildProjectDirectory / "create-swa.json";

    // nuke create --name azure-swa-demo --resource-group DEMOS
    Target Create => _ => _
        .Requires(() => Name)
        .Executes(() =>
        {
            AzDeploymentGroupCreate(_ => _
                .SetResourceGroup(ResourceGroup)
                .SetTemplateFile(TemplateFile)
                .AddParameter("name", Name)
                .AddParameter("location", Location));

            SaveParameter(() => Name);
        });

    [Parameter] readonly string User;
    [Parameter] readonly AzAuthenticationProvider Provider;
    [Parameter] readonly string[] Roles;
    [Parameter] readonly int InvitationExpiration = 1;

    // nuke invite --user matkoch --roles admin
    Target Invite => _ => _
        .Requires(() => User)
        .Requires(() => Provider)
        .Requires(() => Roles)
        .Executes(() =>
        {
            var invitationLink = AzStaticWebAppUsersInvite(_ => _
                .SetName(Name)
                .SetAuthenticationProvider(Provider)
                .SetRoles(Roles)
                .SetUserDetails(User)
                .SetDomain(GetDomain())
                .SetInvitationExpirationInHours(InvitationExpiration)).Result;

            ClipboardService.SetText(invitationLink);
        });

    Target Test => _ => _
        .Executes(() =>
        {
            DotNetTest(_ => _
                .ResetVerbosity()
                .SetResultsDirectory(RootDirectory / "output" / "test-results")
                .CombineWith(Solution.GetProjects("*.Tests"), (_, v) => _
                    .SetProjectFile(v)
                    .AddLoggers($"trx;LogFileName={v.Name}.trx")));
        });

    [Solution(GenerateProjects = true)] readonly Solution Solution;
    [Parameter] [Secret] readonly string ApiToken;

    // nuke deploy
    Target Deploy => _ => _
        .Requires(() => ApiToken != null || IsLocalBuild)
        .DependsOn(Test)
        .Executes(() =>
        {
            DockerRun(_ => _
                .SetImage("mcr.microsoft.com/appsvc/staticappsclient:stable")
                .SetWorkdir("/deploy")
                .AddVolume($"{RootDirectory}:/deploy")
                .SetPlatform("linux/amd64")
                .AddArgs((StaticSitesClientSettings _) => _
                    .SetDeploymentAction("upload")
                    .SetApiToken(ApiToken ?? GetApiToken())
                    .SetApiLocation(RootDirectory.GetUnixRelativePathTo(Solution.SwaApi.Directory))
                    .SetAppLocation(RootDirectory.GetUnixRelativePathTo(Solution.SwaApp.Directory))
                    .SetOutputLocation("wwwroot")));
        });

    string GetApiToken()
    {
        var result = Az($"staticwebapp secrets list --name {Name}", logOutput: false).StdOutputToJson();
        return result.GetPropertyValue("properties").GetPropertyStringValue("apiKey");
    }

    string GetDomain()
    {
        var result = Az($"staticwebapp show --name {Name}", logOutput: false).StdOutputToJson();
        return result.GetPropertyStringValue("defaultHostname");
    }
}
