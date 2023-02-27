namespace UserManager.Domain.Users;

/// <summary>
///     The email.
/// </summary>
internal class Email
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Email" /> class.
    /// </summary>
    /// <param name="email">The email.</param>
    public Email(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentNullException(nameof(email));

        // TODO add additional email validation logic here
        Value = email;
    }

    /// <summary>
    ///     Gets the value.
    /// </summary>
    internal string Value { get; }
}