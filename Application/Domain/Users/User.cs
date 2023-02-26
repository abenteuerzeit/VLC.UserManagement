using Microsoft.AspNetCore.Identity;
using System.Data;
using UserManager.Domain.Users;

namespace UserManager.Domain.Entities
{
    public interface IUser
    {
    }

    internal class User : IdentityUser, IUser
    {
        internal new Email Email { get; }
        internal Password Password { get; }
        internal Role Role { get; }

        internal User(Email email, Password password)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Role = new Role("user");
        }
        internal User(Email email, Password password, Role role)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Role = role ?? throw new ArgumentNullException(nameof(role));
        }
        internal User()
        {
            Email = new Email("not set");
            Password = new Password("not set");
            Role = new Role("not set");
        }


        protected void ChangeEmail(Email newEmail)
        {
            throw new NotImplementedException();
        }
        protected string HashPassword(string password)
        {
            return new PasswordHasher<User>().HashPassword(this, password);
        }

    }
}