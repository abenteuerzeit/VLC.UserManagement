using UserManager.Utility;

namespace UserManager.Infrastructure;

/// <summary>
///     The user endpoints.
/// </summary>
public static class UserEndpoints
{
    /// <summary>
    ///     The user group.
    /// </summary>
    private const string UserGroup = "users";

    /// <summary>
    ///     The account group.
    /// </summary>
    private const string AccountGroup = "account";

    /// <summary>
    ///     The register route.
    /// </summary>
    private const string RegisterRoute = "/register/{email}";

    /// <summary>
    ///     The make route.
    /// </summary>
    private const string MakeRoute = "/make/{quantity}";

    /// <summary>
    ///     The get all route.
    /// </summary>
    private const string GetAllRoute = "/";

    /// <summary>
    ///     The get by id route.
    /// </summary>
    private const string GetByIdRoute = "/{id}";

    /// <summary>
    ///     The create route.
    /// </summary>
    private const string CreateRoute = "/";

    /// <summary>
    ///     The update route.
    /// </summary>
    private const string UpdateRoute = "/{id}";

    /// <summary>
    ///     The delete route.
    /// </summary>
    private const string DeleteRoute = "/{id}";

    /// <summary>
    ///     Maps the user endpoints.
    /// </summary>
    /// <param name="app">The app.</param>
    public static void MapUserEndpoints(this WebApplication app)
    {
        var userRouter = app.MapGroup(UserGroup);
        userRouter.MapGet(MakeRoute, UserHandler.GenerateUsersByQuantity).WithOpenApi();
        userRouter.MapGet(GetAllRoute, UserHandler.GetAllUsers).WithOpenApi();
        userRouter.MapGet(GetByIdRoute, UserHandler.GetUserById).WithOpenApi();
        userRouter.MapPost(CreateRoute, UserHandler.CreateUser).WithOpenApi();
        userRouter.MapPut(UpdateRoute, UserHandler.UpdateUser).WithOpenApi();
        userRouter.MapDelete(DeleteRoute, UserHandler.DeleteUser).WithOpenApi();
    }
}