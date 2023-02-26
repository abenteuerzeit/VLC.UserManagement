using UserManager.Domain.Entities;

namespace VLC.UserManagement.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        public IUser Add(IUser user);
        public void Update(IUser newUser);
    }
    public class UserRepository : IUserRepository
    {
        public IUser Add(IUser user)
        {
            // Add user to database or any other persistence mechanism here
            return user;
        }

        public void Update(IUser newUser)
        {
            throw new NotImplementedException();
        }
    }
}
