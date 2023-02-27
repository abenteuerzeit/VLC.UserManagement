using UserManager.Domain.Users;

namespace UserManager.Infrastructure.Repositories;

/// <summary>
///     The user repository.
/// </summary>
public class UserRepository : IUserRepository
{
    /// <summary>
    ///     Add the <see cref="IUser" />.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <returns>An IUser.</returns>
    public IUser Add(IUser user)
    {

        // #TODO Add user to database or any other persistence mechanism here
        return user;
    }

    /// <summary>
    /// </summary>
    /// <param name="newUser">The new user.</param>
    /// <exception cref="NotImplementedException"></exception>
    public void Update(IUser newUser)
    {
        // # TODO Update user in database or any other persistence mechanism here
        throw new NotImplementedException();
    }
}