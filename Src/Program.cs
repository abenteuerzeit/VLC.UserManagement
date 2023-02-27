using Microsoft.EntityFrameworkCore;
using UserManager.Domain.Users;
using UserManager.Infrastructure;
using UserManager.Utility;

namespace UserManager;

/// <summary>
/// Entry point for the user management module
/// </summary>
public static class Program
{
#pragma warning disable CS1591
    public static void Main(string[] args)
#pragma warning restore CS1591 
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<UserDb>(options => options.UseInMemoryDatabase("UserDb"));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.MapAccountEndpoints();
        app.MapUserEndpoints();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(Constants.SwaggerUrl, Constants.SwaggerEndpointName);
                options.RoutePrefix = string.Empty;
                options.DocumentTitle = Constants.SwaggerDocTitle;
            });
        }

        app.Run();
    }
}
