using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UserManager.Domain.Entities;
using UserManager.Domain.Users;
using Microsoft.AspNetCore.OpenApi;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;

namespace VLC.UserManagement
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<UserDb>(options => options.UseInMemoryDatabase("UserDb"));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();
            var userRouter = app.MapGroup("users");

            userRouter.MapGet("/make/{quantity}", GenerateUsersByQuantity).WithOpenApi();
            userRouter.MapGet("/", GetAllUsers).WithOpenApi();
            userRouter.MapGet("/{id}", GetUserById).WithOpenApi();
            userRouter.MapPost("/", CreateUser).WithOpenApi();
            userRouter.MapPut("/{id}", UpdateUser).WithOpenApi();
            userRouter.MapDelete("/{id}", DeleteUser).WithOpenApi();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                    options.DocumentTitle = "Viva La Carte - User Api";
                });
            }

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

            static async Task<IResult> GenerateUsersByQuantity(UserDb db, int quantity)
            {
                List<User> users = new();
                for (int i = 0; i < quantity; i++)
                {
                    User user = new(new Email($"user_{i}@userMakerRoute.com"));

                    users.Add(user);
                    db.Users.Add(user);
                }
                await db.SaveChangesAsync();

                return TypedResults.Created($"/users/make/{quantity}", users);
            }
        }
    }
}