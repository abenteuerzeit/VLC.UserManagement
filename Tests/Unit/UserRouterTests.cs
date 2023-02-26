//using Moq;
//using NUnit.Framework;
//using UserManager.Domain.Entities;
//using UserManager.Domain.Users;

//namespace VLC.UserManagement.Tests
//{
//    [TestFixture]
//    public class UserRouterTests
//    {
//        [Test]
//        public async void GetAllUsers_ReturnsOKOfUsersResult()
//        {
//            // Arrange
//            var db = CreateDbContext();

//            // Act
//            var result = await UserApi.GetAllUsers(db);

//            // Assert

//            Assert.IsType<Ok<User[]>>(result);

//        }

//        private object CreateDbContext()
//        {
//            throw new NotImplementedException();
//        }
//    }

//}


