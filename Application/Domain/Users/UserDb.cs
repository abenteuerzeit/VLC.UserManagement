using Microsoft.EntityFrameworkCore;

namespace UserManager.Domain.Users;

/// <summary>
///     The user db.
/// </summary>
internal class UserDb : DbContext
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserDb" /> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public UserDb(DbContextOptions<UserDb> options) : base(options)
    {
    }

    /// <summary>
    ///     Gets the users.
    /// </summary>
    internal DbSet<User> Users => Set<User>();
}