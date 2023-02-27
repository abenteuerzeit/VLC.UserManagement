using UserManager.Domain.Users;

namespace UserManager.Utility;

/// <summary>
///     The account handler.
/// </summary>
public static class AccountHandler
{
    /// <summary>
    ///     Registers the <see cref="IResult" />.
    /// </summary>
    /// <param name="db">The db.</param>
    /// <param name="email">The email.</param>
    /// <returns><![CDATA[Task<IResult>]]></returns>
    internal static async Task<IResult> Register(UserDb db, string email)
    {
        var user = new User(new Email(email));
        db.Users.Add(user);
        await db.SaveChangesAsync();
        return TypedResults.Created($"/users/{user.Id}", user);
    }
}