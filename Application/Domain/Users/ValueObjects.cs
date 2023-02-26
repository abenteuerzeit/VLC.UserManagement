using Microsoft.AspNetCore.Identity;
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

    internal class Password
    {
        internal string Value { get; }

        internal Password(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty or null");

            // TODO add additional password validation logic here
            Value = password;
        }
    }

    internal class Role
    {
        internal string Value { get; }

        internal Role(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("Role cannot be empty or null");

            // TODO add additional role validation logic here
            Value = role;
        }
    }

}
