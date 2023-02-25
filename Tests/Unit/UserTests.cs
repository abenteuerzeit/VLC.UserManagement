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
            var email = new Email("test@test.com");
            var password = new Password("TestPassword1");

            // Act
            var newUser = new User(email, password);
            _userRepositoryMock.Setup(x => x.Add(newUser)).Returns(newUser);

            // Assert
            Assert.AreEqual(email, newUser.Email);
            Assert.AreEqual(password, newUser.Password);
        }
    }
}
