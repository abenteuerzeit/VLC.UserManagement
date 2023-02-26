using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using UserManager.Domain.Entities;

namespace UserManager.Domain.Users
{
    internal class Email
    {
        internal string Value { get; }

        internal Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty or null");

            // TODO add additional email validation logic here
            Value = email;
        }
    }
    internal class Password : IPasswordHasher<User>
    {
        internal string Salt { get; private set; }
        internal string HashedPassword { get; private set; }
        internal string Value { get; private set; }

        internal Password(User user, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                throw new ArgumentException("Password cannot be empty or null");
            }
            Salt = BCrypt.Net.BCrypt.GenerateSalt();
            HashedPassword = HashPassword(user, newPassword);
            user.PasswordHash = HashedPassword;
        }

        public string HashPassword(User user, string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, Salt);
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword) ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }
}

