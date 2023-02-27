using UserManager.Utility;

namespace UserManager.Infrastructure;

/// <summary>
///     The account endpoints.
/// </summary>
public static class AccountEndpoints
{
    /// <summary>
    ///     The account group.
    /// </summary>
    private const string AccountGroup = "account";

    /// <summary>
    ///     The register route.
    /// </summary>
    private const string RegisterRoute = "/register/{email}";

    /// <summary>
    ///     Maps the account endpoints.
    /// </summary>
    /// <param name="app">The app.</param>
    public static void MapAccountEndpoints(this WebApplication app)
    {
        var accountRouter = app.MapGroup(AccountGroup);
        accountRouter.MapPost(RegisterRoute, AccountHandler.Register).WithOpenApi();
    }
}