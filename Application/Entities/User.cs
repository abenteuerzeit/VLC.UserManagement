using System.Data;
using VLC.UserManagement.ValueObjects;

namespace VLC.UserManagement.Entities
{
    public interface IUserRepository
    {
        User Add(User user);
        void Update(User newUser);
    }
    public class User
    {
        public Email Email { get; }
        public Password Password { get; }
        public Role Role { get; }

        public User(Email email, Password password)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Role = new Role("user");
        }
        public User(Email email, Password password, Role role)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Role = role ?? throw new ArgumentNullException(nameof(role));
        }

        public void ChangeEmail(Email newEmail)
        {
            throw new NotImplementedException();
        }
    }
}
