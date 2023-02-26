using Moq;
using NUnit.Framework;
using UserManager.Domain.Entities;
using UserManager.Domain.Users;
using Microsoft.AspNetCore.Mvc.Testing;
using VLC.UserManagement.Infrastructure.Repositories;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace VLC.UserManagement.Tests
{
    [TestFixture]
    public class UserRouterTests
    {
        [Test]
        public async Task SwaggerApi_ReturnsOk()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();
            var responseCode = HttpStatusCode.OK;

            // Act
            var response = await client.GetAsync("/swagger/v1/swagger.json");

            // Assert
            Assert.AreEqual(responseCode, response.StatusCode);
        }

        [Test]
        public async Task GetAllUsers_ReturnsOk()
        {
            // Arrange
            var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();
            var responseCode = HttpStatusCode.OK;

            // Act
            var response = await client.GetAsync("/users");

            // Assert
            Assert.AreEqual(responseCode, response.StatusCode);
        }


    }
}


