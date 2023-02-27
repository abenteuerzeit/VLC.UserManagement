using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace UserManager.Domain.Users;

/// <summary>
///     The user interface.
/// </summary>
public interface IUser
{
}

/// <summary>
///     The user.
/// </summary>
internal class User : IdentityUser, IUser
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="User" /> class.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <param name="password">The password.</param>
    [JsonConstructor]
    public User(Email email, Password password)
    {
        Email = email.Value;
        _ = new Password(this, password.Value);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="User" /> class.
    /// </summary>
    /// <param name="email">The email.</param>
    public User(Email email)
    {
        Email = email.Value;
        _ = new Password(this, "password");
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="User" /> class.
    /// </summary>
    public User()
    {
        Email = "not set";
        _ = new Password(this, "password");
    }
}