using Microsoft.EntityFrameworkCore;
using UserManager.Domain.Entities;
using UserManager.Domain.Users;

namespace VLC.UserManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<UserDb>(options => options.UseInMemoryDatabase("UserDb"));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();


            var app = builder.Build();
            var userRouter = app.MapGroup("/users");

            app.MapGet("/", () => "Viva La Carte User Management Module. Go to route localhost:port/users/make/{quantity} to create users");

            userRouter.MapGet("/", GetAllUsers);
            userRouter.MapGet("/{id}", GetUserById);
            userRouter.MapPost("/", CreateUser);
            userRouter.MapPut("/{id}", UpdateUser);
            userRouter.MapDelete("/{id}", DeleteUser);
            userRouter.MapGet("/make/{quantity}", async (UserDb db, int quantity) =>
            {
                var users = new List<User>();
                for (int i = 0; i < quantity; i++)
                {
                    User user = new(new Email($"user{i}@user-factory.com"), new Password($"P@$5wOrd&{new Random(i)}"));
                    users.Add(user);
                    db.Users.Add(user);
                    await db.SaveChangesAsync();
                }
                return TypedResults.Created($"/users/make/{quantity}", users);
            });



            app.Run();

            static async Task<IResult> GetAllUsers(UserDb db)
            {
                return TypedResults.Ok(await db.Users.ToListAsync());
            }

            static async Task<IResult> GetUserById(UserDb db, string id)
            {
                var user = await db.Users.FindAsync(id);
                if (user == null)
                {
                    return TypedResults.NotFound();
                }

                return TypedResults.Ok(user);
            }

            static async Task<IResult> CreateUser(UserDb db, User user)
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/users/{user.Id}", user);
            }

            static async Task<IResult> UpdateUser(UserDb db, string id, User user)
            {
                if (id != user.Id)
                {
                    return TypedResults.BadRequest();
                }

                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return TypedResults.NoContent();
            }

            static async Task<IResult> DeleteUser(UserDb db, string id)
            {
                var user = await db.Users.FindAsync(id);
                if (user == null)
                {
                    return TypedResults.NotFound();
                }

                db.Users.Remove(user);
                await db.SaveChangesAsync();
                return TypedResults.NoContent();
            }
        }
    }
}