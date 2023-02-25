using NUnit.Framework;
using Moq;
using VLC.UserManagement.Entities;
using VLC.UserManagement.ValueObjects;
using Microsoft.AspNetCore.Http.HttpResults;
using NUnit.Framework.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;
using System.Net;
using System.Security.Principal;

namespace VLC.UserManagement.Tests
{
    [TestFixture]
    public class UserTests
    {
        private Mock<IUserRepository> _userRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
        }

        [Test]
        public void CreateUser_WithValidEmailAndPassword_ShouldReturnNewUser()
        {
            // Arrange
            Email email = new("test@test.com");
            Password password = new("TestPassword1");

            // Act
            User newUser = new(email, password);
            _userRepositoryMock.Setup(x => x.Add(newUser)).Returns(newUser);

            // Assert
            Assert.AreEqual(email, newUser.Email);
            Assert.AreEqual(password, newUser.Password);
        }

        [Test]
        public void CreateUser_WithInvalidEmail_ShouldThrowException()
        {
            // Arrange
            Email invalidEmail = new("testtest.com");
            Password password = new("TestPassword1");

            // Act
            User newUser = new(invalidEmail, password);

            // Assert
            Assert.Throws<ArgumentException>(() => _userRepositoryMock.Setup(x => x.Add(newUser)).Returns(newUser));
        }

        [Test]
        public void CreateUser_WithWeakPassword_ShouldThrowException()
        {
            // Arrange
            Email email = new("test@test.com");
            Password weakPassword = new("password");

            // Act
            User newUser = new(email, weakPassword);
            _userRepositoryMock.Setup(x => x.Add(newUser)).Returns(newUser);

            // Assert
            Assert.AreEqual(email, newUser.Email);
            Assert.AreEqual(weakPassword, newUser.Password);
        }

        //TODO: public void UpdateUserEmail_WithValidEmail_ShouldReturnNewEmail()
        // TODO:Test that a user cannot update their email address to an invalid email address.
        // TODO:Test that a user can update their password.
        // TODO:Test that a user cannot update their password to a weak password.
        // TODO:Test that a user can change their name in their profile.
        // TODO:Test that an admin can create a new user account and assign a role.
        // TODO:Test that an admin can update a user's role to grant or revoke permissions.
        // TODO:Test that an admin can view a list of all users and their roles.
        // TODO:Test that an admin can deactivate a user's account to prevent them from accessing the app.
        // TODO:Test that an admin can reactivate a previously deactivated user account.
        // TODO:Test that a user can upload a profile picture to display on their profile.
        // TODO:Test that an admin can reset a user's password if they forget it.
        // TODO:Test that a user can reset their password using the email address associated with their account.
        // TODO:Test that a user can delete their account and all associated data
    }
}

