// Generated from https://raw.githubusercontent.com/matkoch/SwaDemo2/master/build/Ext/Az.json

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

/// <summary>
///   <p>For more details, visit the <a href="">official website</a>.</p>
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class AzTasks
{
    /// <summary>
    ///   Path to the Az executable.
    /// </summary>
    public static string AzPath =>
        ToolPathResolver.TryGetEnvironmentExecutable("AZ_EXE") ??
        ToolPathResolver.GetPathExecutable("az");
    public static Action<OutputType, string> AzLogger { get; set; } = ProcessTasks.DefaultLogger;
    /// <summary>
    ///   <p>For more details, visit the <a href="">official website</a>.</p>
    /// </summary>
    public static IReadOnlyCollection<Output> Az(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, bool? logTimestamp = null, string logFile = null, Func<string, string> outputFilter = null)
    {
        using var process = ProcessTasks.StartProcess(AzPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, AzLogger, outputFilter);
        process.AssertZeroExitCode();
        return process.Output;
    }
    /// <summary>
    ///   <p>For more details, visit the <a href="">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--authentication-provider</c> via <see cref="AzStaticWebAppUsersInviteSettings.AuthenticationProvider"/></li>
    ///     <li><c>--domain</c> via <see cref="AzStaticWebAppUsersInviteSettings.Domain"/></li>
    ///     <li><c>--invitation-expiration-in-hours</c> via <see cref="AzStaticWebAppUsersInviteSettings.InvitationExpirationInHours"/></li>
    ///     <li><c>--name</c> via <see cref="AzStaticWebAppUsersInviteSettings.Name"/></li>
    ///     <li><c>--roles</c> via <see cref="AzStaticWebAppUsersInviteSettings.Roles"/></li>
    ///     <li><c>--user-details</c> via <see cref="AzStaticWebAppUsersInviteSettings.UserDetails"/></li>
    ///   </ul>
    /// </remarks>
    public static (string Result, IReadOnlyCollection<Output> Output) AzStaticWebAppUsersInvite(AzStaticWebAppUsersInviteSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new AzStaticWebAppUsersInviteSettings();
        PreProcess(ref toolSettings);
        using var process = ProcessTasks.StartProcess(toolSettings);
        process.AssertZeroExitCode();
        return (GetResult(process, toolSettings), process.Output);
    }
    /// <summary>
    ///   <p>For more details, visit the <a href="">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--authentication-provider</c> via <see cref="AzStaticWebAppUsersInviteSettings.AuthenticationProvider"/></li>
    ///     <li><c>--domain</c> via <see cref="AzStaticWebAppUsersInviteSettings.Domain"/></li>
    ///     <li><c>--invitation-expiration-in-hours</c> via <see cref="AzStaticWebAppUsersInviteSettings.InvitationExpirationInHours"/></li>
    ///     <li><c>--name</c> via <see cref="AzStaticWebAppUsersInviteSettings.Name"/></li>
    ///     <li><c>--roles</c> via <see cref="AzStaticWebAppUsersInviteSettings.Roles"/></li>
    ///     <li><c>--user-details</c> via <see cref="AzStaticWebAppUsersInviteSettings.UserDetails"/></li>
    ///   </ul>
    /// </remarks>
    public static (string Result, IReadOnlyCollection<Output> Output) AzStaticWebAppUsersInvite(Configure<AzStaticWebAppUsersInviteSettings> configurator)
    {
        return AzStaticWebAppUsersInvite(configurator(new AzStaticWebAppUsersInviteSettings()));
    }
    /// <summary>
    ///   <p>For more details, visit the <a href="">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--authentication-provider</c> via <see cref="AzStaticWebAppUsersInviteSettings.AuthenticationProvider"/></li>
    ///     <li><c>--domain</c> via <see cref="AzStaticWebAppUsersInviteSettings.Domain"/></li>
    ///     <li><c>--invitation-expiration-in-hours</c> via <see cref="AzStaticWebAppUsersInviteSettings.InvitationExpirationInHours"/></li>
    ///     <li><c>--name</c> via <see cref="AzStaticWebAppUsersInviteSettings.Name"/></li>
    ///     <li><c>--roles</c> via <see cref="AzStaticWebAppUsersInviteSettings.Roles"/></li>
    ///     <li><c>--user-details</c> via <see cref="AzStaticWebAppUsersInviteSettings.UserDetails"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(AzStaticWebAppUsersInviteSettings Settings, string Result, IReadOnlyCollection<Output> Output)> AzStaticWebAppUsersInvite(CombinatorialConfigure<AzStaticWebAppUsersInviteSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(AzStaticWebAppUsersInvite, AzLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>For more details, visit the <a href="">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--parameters</c> via <see cref="AzDeploymentGroupCreateSettings.Parameters"/></li>
    ///     <li><c>--resource-group</c> via <see cref="AzDeploymentGroupCreateSettings.ResourceGroup"/></li>
    ///     <li><c>--template-file</c> via <see cref="AzDeploymentGroupCreateSettings.TemplateFile"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> AzDeploymentGroupCreate(AzDeploymentGroupCreateSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new AzDeploymentGroupCreateSettings();
        PreProcess(ref toolSettings);
        using var process = ProcessTasks.StartProcess(toolSettings);
        process.AssertZeroExitCode();
        return process.Output;
    }
    /// <summary>
    ///   <p>For more details, visit the <a href="">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--parameters</c> via <see cref="AzDeploymentGroupCreateSettings.Parameters"/></li>
    ///     <li><c>--resource-group</c> via <see cref="AzDeploymentGroupCreateSettings.ResourceGroup"/></li>
    ///     <li><c>--template-file</c> via <see cref="AzDeploymentGroupCreateSettings.TemplateFile"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> AzDeploymentGroupCreate(Configure<AzDeploymentGroupCreateSettings> configurator)
    {
        return AzDeploymentGroupCreate(configurator(new AzDeploymentGroupCreateSettings()));
    }
    /// <summary>
    ///   <p>For more details, visit the <a href="">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--parameters</c> via <see cref="AzDeploymentGroupCreateSettings.Parameters"/></li>
    ///     <li><c>--resource-group</c> via <see cref="AzDeploymentGroupCreateSettings.ResourceGroup"/></li>
    ///     <li><c>--template-file</c> via <see cref="AzDeploymentGroupCreateSettings.TemplateFile"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(AzDeploymentGroupCreateSettings Settings, IReadOnlyCollection<Output> Output)> AzDeploymentGroupCreate(CombinatorialConfigure<AzDeploymentGroupCreateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(AzDeploymentGroupCreate, AzLogger, degreeOfParallelism, completeOnFailure);
    }
}
#region AzStaticWebAppUsersInviteSettings
/// <summary>
///   Used within <see cref="AzTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class AzStaticWebAppUsersInviteSettings : ToolSettings
{
    /// <summary>
    ///   Path to the Az executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? AzTasks.AzPath;
    public override Action<OutputType, string> ProcessCustomLogger => AzTasks.AzLogger;
    public virtual string Name { get; internal set; }
    public virtual AzAuthenticationProvider AuthenticationProvider { get; internal set; }
    public virtual IReadOnlyList<string> Roles => RolesInternal.AsReadOnly();
    internal List<string> RolesInternal { get; set; } = new List<string>();
    public virtual string UserDetails { get; internal set; }
    public virtual string Domain { get; internal set; }
    public virtual int? InvitationExpirationInHours { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("staticwebapp users invite")
          .Add("--name {value}", Name)
          .Add("--authentication-provider {value}", AuthenticationProvider)
          .Add("--roles {value}", Roles, separator: ',')
          .Add("--user-details {value}", UserDetails)
          .Add("--domain {value}", Domain)
          .Add("--invitation-expiration-in-hours {value}", InvitationExpirationInHours);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region AzDeploymentGroupCreateSettings
/// <summary>
///   Used within <see cref="AzTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class AzDeploymentGroupCreateSettings : ToolSettings
{
    /// <summary>
    ///   Path to the Az executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? AzTasks.AzPath;
    public override Action<OutputType, string> ProcessCustomLogger => AzTasks.AzLogger;
    public virtual string ResourceGroup { get; internal set; }
    public virtual string TemplateFile { get; internal set; }
    public virtual IReadOnlyDictionary<string, string> Parameters => ParametersInternal.AsReadOnly();
    internal Dictionary<string, string> ParametersInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("deployment group create")
          .Add("--resource-group {value}", ResourceGroup)
          .Add("--template-file {value}", TemplateFile)
          .Add("--parameters {value}", Parameters, "{key}={value}", separator: ' ');
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region AzStaticWebAppUsersInviteSettingsExtensions
/// <summary>
///   Used within <see cref="AzTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class AzStaticWebAppUsersInviteSettingsExtensions
{
    #region Name
    /// <summary>
    ///   <p><em>Sets <see cref="AzStaticWebAppUsersInviteSettings.Name"/></em></p>
    /// </summary>
    [Pure]
    public static T SetName<T>(this T toolSettings, string name) where T : AzStaticWebAppUsersInviteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Name = name;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="AzStaticWebAppUsersInviteSettings.Name"/></em></p>
    /// </summary>
    [Pure]
    public static T ResetName<T>(this T toolSettings) where T : AzStaticWebAppUsersInviteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Name = null;
        return toolSettings;
    }
    #endregion
    #region AuthenticationProvider
    /// <summary>
    ///   <p><em>Sets <see cref="AzStaticWebAppUsersInviteSettings.AuthenticationProvider"/></em></p>
    /// </summary>
    [Pure]
    public static T SetAuthenticationProvider<T>(this T toolSettings, AzAuthenticationProvider authenticationProvider) where T : AzStaticWebAppUsersInviteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AuthenticationProvider = authenticationProvider;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="AzStaticWebAppUsersInviteSettings.AuthenticationProvider"/></em></p>
    /// </summary>
    [Pure]
    public static T ResetAuthenticationProvider<T>(this T toolSettings) where T : AzStaticWebAppUsersInviteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AuthenticationProvider = null;
        return toolSettings;
    }
    #endregion
    #region Roles
    /// <summary>
    ///   <p><em>Sets <see cref="AzStaticWebAppUsersInviteSettings.Roles"/> to a new list</em></p>
    /// </summary>
    [Pure]
    public static T SetRoles<T>(this T toolSettings, params string[] roles) where T : AzStaticWebAppUsersInviteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RolesInternal = roles.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="AzStaticWebAppUsersInviteSettings.Roles"/> to a new list</em></p>
    /// </summary>
    [Pure]
    public static T SetRoles<T>(this T toolSettings, IEnumerable<string> roles) where T : AzStaticWebAppUsersInviteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RolesInternal = roles.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="AzStaticWebAppUsersInviteSettings.Roles"/></em></p>
    /// </summary>
    [Pure]
    public static T AddRoles<T>(this T toolSettings, params string[] roles) where T : AzStaticWebAppUsersInviteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RolesInternal.AddRange(roles);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="AzStaticWebAppUsersInviteSettings.Roles"/></em></p>
    /// </summary>
    [Pure]
    public static T AddRoles<T>(this T toolSettings, IEnumerable<string> roles) where T : AzStaticWebAppUsersInviteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RolesInternal.AddRange(roles);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="AzStaticWebAppUsersInviteSettings.Roles"/></em></p>
    /// </summary>
    [Pure]
    public static T ClearRoles<T>(this T toolSettings) where T : AzStaticWebAppUsersInviteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RolesInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="AzStaticWebAppUsersInviteSettings.Roles"/></em></p>
    /// </summary>
    [Pure]
    public static T RemoveRoles<T>(this T toolSettings, params string[] roles) where T : AzStaticWebAppUsersInviteSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(roles);
        toolSettings.RolesInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="AzStaticWebAppUsersInviteSettings.Roles"/></em></p>
    /// </summary>
    [Pure]
    public static T RemoveRoles<T>(this T toolSettings, IEnumerable<string> roles) where T : AzStaticWebAppUsersInviteSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(roles);
        toolSettings.RolesInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region UserDetails
    /// <summary>
    ///   <p><em>Sets <see cref="AzStaticWebAppUsersInviteSettings.UserDetails"/></em></p>
    /// </summary>
    [Pure]
    public static T SetUserDetails<T>(this T toolSettings, string userDetails) where T : AzStaticWebAppUsersInviteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.UserDetails = userDetails;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="AzStaticWebAppUsersInviteSettings.UserDetails"/></em></p>
    /// </summary>
    [Pure]
    public static T ResetUserDetails<T>(this T toolSettings) where T : AzStaticWebAppUsersInviteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.UserDetails = null;
        return toolSettings;
    }
    #endregion
    #region Domain
    /// <summary>
    ///   <p><em>Sets <see cref="AzStaticWebAppUsersInviteSettings.Domain"/></em></p>
    /// </summary>
    [Pure]
    public static T SetDomain<T>(this T toolSettings, string domain) where T : AzStaticWebAppUsersInviteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Domain = domain;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="AzStaticWebAppUsersInviteSettings.Domain"/></em></p>
    /// </summary>
    [Pure]
    public static T ResetDomain<T>(this T toolSettings) where T : AzStaticWebAppUsersInviteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Domain = null;
        return toolSettings;
    }
    #endregion
    #region InvitationExpirationInHours
    /// <summary>
    ///   <p><em>Sets <see cref="AzStaticWebAppUsersInviteSettings.InvitationExpirationInHours"/></em></p>
    /// </summary>
    [Pure]
    public static T SetInvitationExpirationInHours<T>(this T toolSettings, int? invitationExpirationInHours) where T : AzStaticWebAppUsersInviteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.InvitationExpirationInHours = invitationExpirationInHours;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="AzStaticWebAppUsersInviteSettings.InvitationExpirationInHours"/></em></p>
    /// </summary>
    [Pure]
    public static T ResetInvitationExpirationInHours<T>(this T toolSettings) where T : AzStaticWebAppUsersInviteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.InvitationExpirationInHours = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region AzDeploymentGroupCreateSettingsExtensions
/// <summary>
///   Used within <see cref="AzTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class AzDeploymentGroupCreateSettingsExtensions
{
    #region ResourceGroup
    /// <summary>
    ///   <p><em>Sets <see cref="AzDeploymentGroupCreateSettings.ResourceGroup"/></em></p>
    /// </summary>
    [Pure]
    public static T SetResourceGroup<T>(this T toolSettings, string resourceGroup) where T : AzDeploymentGroupCreateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ResourceGroup = resourceGroup;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="AzDeploymentGroupCreateSettings.ResourceGroup"/></em></p>
    /// </summary>
    [Pure]
    public static T ResetResourceGroup<T>(this T toolSettings) where T : AzDeploymentGroupCreateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ResourceGroup = null;
        return toolSettings;
    }
    #endregion
    #region TemplateFile
    /// <summary>
    ///   <p><em>Sets <see cref="AzDeploymentGroupCreateSettings.TemplateFile"/></em></p>
    /// </summary>
    [Pure]
    public static T SetTemplateFile<T>(this T toolSettings, string templateFile) where T : AzDeploymentGroupCreateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TemplateFile = templateFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="AzDeploymentGroupCreateSettings.TemplateFile"/></em></p>
    /// </summary>
    [Pure]
    public static T ResetTemplateFile<T>(this T toolSettings) where T : AzDeploymentGroupCreateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TemplateFile = null;
        return toolSettings;
    }
    #endregion
    #region Parameters
    /// <summary>
    ///   <p><em>Sets <see cref="AzDeploymentGroupCreateSettings.Parameters"/> to a new dictionary</em></p>
    /// </summary>
    [Pure]
    public static T SetParameters<T>(this T toolSettings, IDictionary<string, string> parameters) where T : AzDeploymentGroupCreateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ParametersInternal = parameters.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="AzDeploymentGroupCreateSettings.Parameters"/></em></p>
    /// </summary>
    [Pure]
    public static T ClearParameters<T>(this T toolSettings) where T : AzDeploymentGroupCreateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ParametersInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds a new key-value-pair <see cref="AzDeploymentGroupCreateSettings.Parameters"/></em></p>
    /// </summary>
    [Pure]
    public static T AddParameter<T>(this T toolSettings, string parameterKey, string parameterValue) where T : AzDeploymentGroupCreateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ParametersInternal.Add(parameterKey, parameterValue);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes a key-value-pair from <see cref="AzDeploymentGroupCreateSettings.Parameters"/></em></p>
    /// </summary>
    [Pure]
    public static T RemoveParameter<T>(this T toolSettings, string parameterKey) where T : AzDeploymentGroupCreateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ParametersInternal.Remove(parameterKey);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets a key-value-pair in <see cref="AzDeploymentGroupCreateSettings.Parameters"/></em></p>
    /// </summary>
    [Pure]
    public static T SetParameter<T>(this T toolSettings, string parameterKey, string parameterValue) where T : AzDeploymentGroupCreateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ParametersInternal[parameterKey] = parameterValue;
        return toolSettings;
    }
    #endregion
}
#endregion
#region AzAuthenticationProvider
/// <summary>
///   Used within <see cref="AzTasks"/>.
/// </summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<AzAuthenticationProvider>))]
public partial class AzAuthenticationProvider : Enumeration
{
    public static AzAuthenticationProvider AAD = (AzAuthenticationProvider) "AAD";
    public static AzAuthenticationProvider Facebook = (AzAuthenticationProvider) "Facebook";
    public static AzAuthenticationProvider GitHub = (AzAuthenticationProvider) "GitHub";
    public static AzAuthenticationProvider Google = (AzAuthenticationProvider) "Google";
    public static AzAuthenticationProvider Twitter = (AzAuthenticationProvider) "Twitter";
    public static implicit operator AzAuthenticationProvider(string value)
    {
        return new AzAuthenticationProvider { Value = value };
    }
}
#endregion
