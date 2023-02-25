namespace VLC.UserManagement.ValueObjects
{
    public class Email
    {
        public string Value { get; }

        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty or null");

            // TODO add additional email validation logic here
            Value = email;
        }

        public override string ToString()
        {
            return Value;
        }
    }

    public class Password
    {
        public string Value { get; }

        public Password(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty or null");

            // TODO add additional password validation logic here
            Value = password;
        }

        public override string ToString()
        {
            return Value;
        }
    }

    public class Role
    {
        public string Value { get; }

        public Role(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("Role cannot be empty or null");

            // TODO add additional role validation logic here
            Value = role;
        }

        public override string ToString()
        {
            return Value;
        }
    }

}
