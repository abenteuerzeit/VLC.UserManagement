using Moq;
using NUnit.Framework;

namespace VLC.UserManagement.Tests.Unit
{
    [TestFixture]
    public class UserManagerTests
    {
        [Test]
        public void CreateUser_ValidEmailAndPassword_ReturnsNewUser()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var userManager = new UserManager(mockUserRepository.Object);
            var email = new Email("john.doe@example.com");
            var password = new Password("P@ssword123");

            // Act
            var user = userManager.CreateUser(email, password);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(email, user.Email);
            Assert.IsTrue(user.Password.IsValid(password));
        }
    }
}
