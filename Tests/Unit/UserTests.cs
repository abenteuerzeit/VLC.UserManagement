using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using UserManager.Domain.Users;

namespace Tests.Unit;

/// <summary>
///     The user db tests.
/// </summary>
[TestFixture]
public class UserDbTests
{
    /// <summary>
    ///     Users the should not be null.
    /// </summary>
    [Test]
    public void Users_ShouldNotBeNull()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<UserDb>()
            .UseInMemoryDatabase("UsersDatabase")
            .Options;

        // Act
        using var context = new UserDb(options);

        // Assert
        Assert.IsNotNull(context.Users);
    }


    /// <summary>
    ///     Constructors the with email and valid password should create user with hashed password.
    /// </summary>
    [Test]
    public void Constructor_WithEmailAndValidPassword_ShouldCreateUserWithHashedPassword()
    {
        // Arrange
        var email = new Email("test@example.com");
        var password = new Password(new User(), "password");

        // Act
        var user = new User(email, password);

        // Assert
        user.Email.Should().Be(email.Value);
        user.PasswordHash.Should().NotBeNullOrEmpty();
    }


    /// <summary>
    ///     Constructors the with email only should create user with default password.
    /// </summary>
    [Test]
    public void Constructor_WithEmailOnly_ShouldCreateUserWithDefaultPassword()
    {
        // Arrange
        var email = new Email("test@example.com");

        // Act
        var user = new User(email);

        // Assert
        user.Email.Should().Be(email.Value);
        user.PasswordHash.Should().NotBeNullOrEmpty();
    }

    /// <summary>
    ///     Constructors the with no arguments should create user with default email and password.
    /// </summary>
    [Test]
    public void Constructor_WithNoArguments_ShouldCreateUserWithDefaultEmailAndPassword()
    {
        // Arrange

        // Act
        var user = new User();

        // Assert
        user.Email.Should().Be("not set");
        user.PasswordHash.Should().NotBeNullOrEmpty();
    }

    /// <summary>
    ///     Users the db should have db set of users.
    /// </summary>
    [Test]
    public void UserDb_ShouldHaveDbSetOfUsers()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<UserDb>()
            .UseInMemoryDatabase("UserDb")
            .Options;

        // Act
        using var context = new UserDb(options);
        // Assert
        context.Users.Should().NotBeNull();
    }

    /// <summary>
    ///     User the should be initialized with email and password.
    /// </summary>
    [Test]
    public void User_ShouldBeInitializedWithEmailAndPassword()
    {
        // Arrange
        var email = new Email("test@example.com");
        var password = new Password(new User(), "password123");

        // Act
        var user = new User(email, password);

        // Assert
        user.Email.Should().Be(email.Value);
        user.PasswordHash.Should().NotBeNullOrEmpty();
    }

    /// <summary>
    ///     User the should be initialized with email only.
    /// </summary>
    [Test]
    public void User_ShouldBeInitializedWithEmailOnly()
    {
        // Arrange
        var email = new Email("test@example.com");

        // Act
        var user = new User(email);

        // Assert
        user.Email.Should().Be(email.Value);
        user.PasswordHash.Should().NotBeNullOrEmpty();
    }

    /// <summary>
    ///     User the should be initialized with default values.
    /// </summary>
    [Test]
    public void User_ShouldBeInitializedWithDefaultValues()
    {
        // Arrange

        // Act
        var user = new User();

        // Assert
        user.Email.Should().NotBeNull();
        user.PasswordHash.Should().NotBeNullOrEmpty();
    }

    /// <summary>
    ///     Email the should throw argument null exception if value is null.
    /// </summary>
    [Test]
    public void Email_ShouldThrowArgumentNullExceptionIfValueIsNull()
    {
        // Arrange, Act, Assert
        Assert.Throws<ArgumentNullException>(() => new Email(null));
    }

    /// <summary>
    ///     Password the should throw argument null exception if value is null.
    /// </summary>
    [Test]
    public void Password_ShouldThrowArgumentNullExceptionIfValueIsNull()
    {
        // Arrange
        var user = new User();

        // Act, Assert
        Assert.Throws<ArgumentNullException>(() => new Password(user, null));
    }

    /// <summary>
    ///     Passwords the hash password should return hashed password.
    /// </summary>
    [Test]
    public void Password_HashPassword_ShouldReturnHashedPassword()
    {
        // Arrange
        var user = new User();
        const string? password = "password123";
        var passwordHasher = new Password(user, password);

        // Act
        var hashedPassword = passwordHasher.HashPassword(user, password);

        // Assert
        hashedPassword.Should().NotBeNullOrEmpty();
    }
}