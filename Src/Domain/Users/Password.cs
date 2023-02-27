using Microsoft.AspNetCore.Identity;

namespace UserManager.Domain.Users;

/// <summary>
///     The password.
/// </summary>
internal class Password : IPasswordHasher<User>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Password"/> class.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <param name="newPassword">The new password.</param>
    public Password(User user, string newPassword)
    {
        if (string.IsNullOrWhiteSpace(newPassword)) throw new ArgumentNullException(nameof(newPassword));
        Salt = BCrypt.Net.BCrypt.GenerateSalt();
        Value = newPassword;
        HashedPassword = HashPassword(user, newPassword);
        user.PasswordHash = HashedPassword;
    }

    /// <summary>
    ///     Gets the salt.
    /// </summary>
    private string Salt { get; }

    /// <summary>
    ///     Gets the hashed password.
    /// </summary>
    internal string HashedPassword { get; }

    public string Value { get; internal set; }

    /// <summary>
    ///     Hashes the password.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <param name="password">The password.</param>
    /// <returns>A string.</returns>
    public string HashPassword(User user, string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, Salt);
    }

    /// <summary>
    ///     Verifies the hashed password.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <param name="hashedPassword">The hashed password.</param>
    /// <param name="providedPassword">The provided password.</param>
    /// <returns>A PasswordVerificationResult.</returns>
    public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword)
            ? PasswordVerificationResult.Success
            : PasswordVerificationResult.Failed;
    }
}