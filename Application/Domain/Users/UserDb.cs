using Microsoft.EntityFrameworkCore;
using UserManager.Domain.Entities;

namespace UserManager.Domain.Users
{
    internal class UserDb : DbContext
    {
        public UserDb(DbContextOptions<UserDb> options) : base(options)
        {
        }

        internal DbSet<User> Users => Set<User>();

        //internal DbSet<Email> Emails => Set<Email>();

        //internal DbSet<Password> Passwords => Set<Password>();

    }
}
