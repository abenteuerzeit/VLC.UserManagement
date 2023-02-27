using UserManager.Domain.Users;

namespace UserManager.Infrastructure.Repositories;

// #TODO Implement repository pattern for user persistence and retrieval.
public interface IUserRepository
{
    public IUser Add(IUser user);
    public void Update(IUser newUser);
}