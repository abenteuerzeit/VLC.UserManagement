using NUnit.Framework;
using Moq;
using VLC.UserManagement.Entities;
using VLC.UserManagement.ValueObjects;

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
    }
}
