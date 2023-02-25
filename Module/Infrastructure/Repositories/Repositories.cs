using VLC.UserManagement.Entities;

namespace VLC.UserManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Add(User user)
        {
            // Add user to database or any other persistence mechanism here
            return user;
        }

        public void Update(User newUser)
        {
            throw new NotImplementedException();
        }
    }
}
