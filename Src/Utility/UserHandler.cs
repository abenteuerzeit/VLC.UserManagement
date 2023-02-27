using Microsoft.EntityFrameworkCore;
using UserManager.Domain.Users;

namespace UserManager.Utility;

/// <summary>
///     The user handler.
/// </summary>
public static class UserHandler
{
    /// <summary>
    ///     Gets the all users.
    /// </summary>
    /// <param name="db">The db.</param>
    /// <returns><![CDATA[Task<IResult>]]></returns>
    internal static async Task<IResult> GetAllUsers(UserDb db)
    {
        return TypedResults.Ok(await db.Users.ToListAsync());
    }

    /// <summary>
    ///     Gets the user by id.
    /// </summary>
    /// <param name="db">The db.</param>
    /// <param name="id">The id.</param>
    /// <returns><![CDATA[Task<IResult>]]></returns>
    internal static async Task<IResult> GetUserById(UserDb db, string id)
    {
        var user = await db.Users.FindAsync(id);
        if (user == null)
            return TypedResults.NotFound();

        return TypedResults.Ok(user);
    }

    /// <summary>
    ///     Creates the user.
    /// </summary>
    /// <param name="db">The db.</param>
    /// <param name="user">The user.</param>
    /// <returns><![CDATA[Task<IResult>]]></returns>
    internal static async Task<IResult> CreateUser(UserDb db, User user)
    {
        db.Users.Add(user);
        await db.SaveChangesAsync();
        return TypedResults.Created($"/users/{user.Id}", user);
    }

    /// <summary>
    ///     Updates the user.
    /// </summary>
    /// <param name="db">The db.</param>
    /// <param name="id">The id.</param>
    /// <param name="user">The user.</param>
    /// <returns><![CDATA[Task<IResult>]]></returns>
    internal static async Task<IResult> UpdateUser(UserDb db, string id, User user)
    {
        if (id != user.Id)
            return TypedResults.BadRequest();

        db.Entry(user).State = EntityState.Modified;
        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    /// <summary>
    ///     Deletes the user.
    /// </summary>
    /// <param name="db">The db.</param>
    /// <param name="id">The id.</param>
    /// <returns><![CDATA[Task<IResult>]]></returns>
    internal static async Task<IResult> DeleteUser(UserDb db, string id)
    {
        var user = await db.Users.FindAsync(id);
        if (user == null)
            return TypedResults.NotFound();

        db.Users.Remove(user);
        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    /// <summary>
    ///     Generates the users by quantity.
    /// </summary>
    /// <param name="db">The db.</param>
    /// <param name="quantity">The quantity.</param>
    /// <returns><![CDATA[Task<IResult>]]></returns>
    internal static async Task<IResult> GenerateUsersByQuantity(UserDb db, int quantity)
    {
        List<User> users = new();
        for (var i = 0; i < quantity; i++)
        {
            User user = new(new Email($"user_{i}@userMakerRoute.com"));

            users.Add(user);
            db.Users.Add(user);
        }

        await db.SaveChangesAsync();

        return TypedResults.Created($"/users/make/{quantity}", users);
    }
}