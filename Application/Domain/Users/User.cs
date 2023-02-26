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

        [JsonConstructor]
        internal User(Email email, Password password)
        {
            Email = email.Value ?? throw new ArgumentNullException(nameof(email));
            _ = new Password(this, password.Value);
        }
        internal User(Email email)
        {
            Email = email.Value;
            _ = new Password(this, "password");
        }

        internal User()
        {
            Email = new Email("not set").ToString();
            _ = new Password(this, "password");
        }


        protected bool ChangeEmail(Email newEmail)
        {
            Email = newEmail.Value;
            return Email == newEmail.Value;
        }

        internal bool ChangePassword(string providedPassword)
        {
            if (providedPassword == null)
                throw new ArgumentNullException(nameof(providedPassword));
            Password newPassword = new(this, providedPassword);
            return newPassword.Value == providedPassword && newPassword.HashedPassword == PasswordHash;
        }
    }
}