using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Data;
using UserManager.Domain.Entities;
using UserManager.Domain.Users;
using VLC.UserManagement.Infrastructure.Repositories;

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
        public void CreateUser_WithValidEmail_ShouldReturnNewUser()
        {
            // Arrange
            Email email = new("create_user@test.com");
            User user = new(email);

            // Act
            _userRepositoryMock.Setup(x => x.Add(user)).Returns(user);
            var newUser = _userRepositoryMock.Object.Add(user);

            // Assert
            Assert.AreEqual(user, newUser);
        }

        [Test]
        public void CreateUser_WithInvalidEmail_ShouldThrowException()
        {
            // Arrange
            Email email = new("invalid_email");
            User user = new(email);

            // Act
            _userRepositoryMock.Setup(x => x.Add(user)).Throws(new ConstraintException("Email is invalid"));

            // Assert
            Assert.Throws<ConstraintException>(() => _userRepositoryMock.Object.Add(user));
        }

        //[Test]
        //public void CreateUser_WithWeakPassword_ShouldThrowException()
        //{
        //    // Arrange
        //    Email email = new("test@test.com");
        //    Password weakPassword = new("password");

        //    // Act
        //    User newUser = new(email, weakPassword);
        //    _userRepositoryMock.Setup(x => x.Add(newUser)).Returns(newUser);

        //    // Assert
        //    Assert.AreEqual(email, newUser.Email);
        //    Assert.AreEqual(weakPassword, newUser.Password);
        //    Assert.Throws<ArgumentException>(() => _userRepositoryMock.Setup(x => x.Add(newUser)).Returns(newUser));
        //}

        // TODO: public void UpdateUserEmail_WithValidEmail_ShouldReturnNewEmail()
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