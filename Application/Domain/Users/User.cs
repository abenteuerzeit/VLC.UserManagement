using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using UserManager.Domain.Users;

namespace UserManager.Domain.Entities
{
    public interface IUser
    {
    }

    internal class User : IdentityUser, IUser
    {
        internal new Email Email { get; }
        internal Password Password { get; private set; }

        [JsonConstructor]
        internal User(Email email, Password password)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = new Password(this, password.Value);
        }
        internal User(Email email)
        {
            Email = email;
            Password = new Password(this, "password");
        }

        internal User()
        {
            Email = new Email("not set");
            Password = new Password(this, "password");
        }


        protected void ChangeEmail(Email newEmail)
        {
            throw new NotImplementedException();
        }

        internal void ChangePassword(string providedPassword)
        {
            if (providedPassword == null)
                throw new ArgumentNullException(nameof(providedPassword));

            Password = new(this, providedPassword);
        }
    }
}