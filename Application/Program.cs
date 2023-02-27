using Microsoft.EntityFrameworkCore;
using UserManager.Domain.Users;
using UserManager.Infrastructure;
using UserManager.Utility;

namespace UserManager;

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
