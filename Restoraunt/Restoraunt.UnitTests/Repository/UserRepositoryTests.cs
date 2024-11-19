

using Restoraunt.Restoraunt.UnitTests.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Internal;
using NUnit.Framework;
using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.UnitTests.Repository;

[TestFixture]
[Category("Integration")]
public class UserRepositoryTests : RepositoryTestsBaseClass
{
    [Test]
    public void GetAllUsersTest()
    {
        // Prepare
        using var context = DbContextFactory.CreateDbContext();
        var userModel = new UserModel()
        {
            Id = new Guid("1"),  // or Guid.NewGuid() if that's your logic
            ExternalId = Guid.NewGuid(),
            Name = "Test User 1",
            CreationTime = DateTime.UtcNow,
            ModificationTime = DateTime.UtcNow
        };
        context.Users.Add(userModel);
        context.SaveChanges();

        // Execute
        var repository = new Repository<User>(DbContextFactory);
        var actualUsers = repository.GetAll();

        // Assert
        actualUsers.Should().BeEquivalentTo(new[] { userModel }, options => options.Excluding(x => x.Orders).Excluding(x => x.FavoriteDishes));
    }

    [Test]
    public void GetAllUsersWithFilterTest()
    {
        // Prepare
        using var context = DbContextFactory.CreateDbContext();
        var userModel1 = new UserModel()
        {
            Id = new Guid("1"),
            ExternalId = Guid.NewGuid(),
            Name = "Test User 1",
            CreationTime = DateTime.UtcNow,
            ModificationTime = DateTime.UtcNow
        };
        var userModel2 = new UserModel()
        {
            Id = new Guid("2"),
            ExternalId = Guid.NewGuid(),
            Name = "Test User 2",
            CreationTime = DateTime.UtcNow,
            ModificationTime = DateTime.UtcNow
        };
        context.Users.AddRange(userModel1, userModel2);
        context.SaveChanges();

        var repository = new Repository<User>(DbContextFactory);
        var actualUsers = repository.GetAll();

        // Assert
        actualUsers.Should().BeEquivalentTo(new[] { userModel1 }, options => options.Excluding(x => x.Orders).Excluding(x => x.FavoriteDishes));
    }

    [Test]
    public void SaveNewUserTest()
    {
        // Prepare
        using var context = DbContextFactory.CreateDbContext();
        var userModel = new UserModel()
        {
            Id = new Guid("1"),  // or Guid.NewGuid() if you prefer
            ExternalId = Guid.NewGuid(),
            Name = "Test User 1",
            CreationTime = DateTime.UtcNow,
            ModificationTime = DateTime.UtcNow
        };

        var repository = new Repository<User>(DbContextFactory);

        // Execute
        repository.Save(new User());

        // Assert
        var actualUser = context.Users.SingleOrDefault();
        actualUser.Should().BeEquivalentTo(userModel, options => options.Excluding(x => x.Orders).Excluding(x => x.FavoriteDishes)
            .Excluding(x => x.Id)
            .Excluding(x => x.ModificationTime)
            .Excluding(x => x.CreationTime)
            .Excluding(x => x.ExternalId));
        actualUser.ModificationTime.Should().NotBe(default);
        actualUser.CreationTime.Should().NotBe(default);
        actualUser.ExternalId.Should().NotBe(Guid.Empty);
    }

    [Test]
    public void UpdateUserTest()
    {
        // Prepare
        using var context = DbContextFactory.CreateDbContext();
        var userModel = new UserModel()
        {
            Id = new Guid("1"),
            ExternalId = Guid.NewGuid(),
            Name = "Test User 1",
            CreationTime = DateTime.UtcNow,
            ModificationTime = DateTime.UtcNow
        };
        context.Users.Add(userModel);
        context.SaveChanges();

        // Execute
        userModel.Name = "Updated User Name";
        var repository = new Repository<User>(DbContextFactory);
        repository.Save(new User());

        // Assert
        var actualUser = context.Users.SingleOrDefault();
        actualUser.Name.Should().Be("Updated User Name");
    }

    [Test]
    public void DeleteUserTest()
    {
        // Prepare
        using var context = DbContextFactory.CreateDbContext();
        var userModel = new UserModel()
        {
            Id = new Guid("1"),
            ExternalId = Guid.NewGuid(),
            Name = "Test User 1",
            CreationTime = DateTime.UtcNow,
            ModificationTime = DateTime.UtcNow
        };
        context.Users.Add(userModel);
        context.SaveChanges();

        // Execute
        var repository = new Repository<User>(DbContextFactory);
        repository.Delete(new User());

        // Assert
        context.Users.Count().Should().Be(0);
    }

    [Test]
    public void GetByIdTest_PositiveCase()
    {
        // Prepare
        using var context = DbContextFactory.CreateDbContext();
        var userModel1 = new UserModel()
        {
            Id = new Guid("1"),
            ExternalId = Guid.NewGuid(),
            Name = "Test User 1",
            CreationTime = DateTime.UtcNow,
            ModificationTime = DateTime.UtcNow
        };
        var userModel2 = new UserModel()
        {
            Id = new Guid("2"),
            ExternalId = Guid.NewGuid(),
            Name = "Test User 2",
            CreationTime = DateTime.UtcNow,
            ModificationTime = DateTime.UtcNow
        };
        context.Users.AddRange(userModel1, userModel2);
        context.SaveChanges();

        // Execute
        var repository = new Repository<User>(DbContextFactory);
        var actualUser = repository.GetById(userModel1.Id);

        // Assert
        actualUser.Should().BeEquivalentTo(userModel1, options => options.Excluding(x => x.Orders).Excluding(x => x.FavoriteDishes));
    }

    [Test]
    public void GetByIdTest_NotFound()
    {
        // Execute
        var repository = new Repository<User>(DbContextFactory);
        var actualUser = repository.GetById(999); // Assuming this ID doesn't exist.

        // Assert
        actualUser.Should().BeNull();
    }

    [SetUp]
    public void SetUp()
    {
        CleanUp();
    }

    [TearDown]
    public void TearDown()
    {
        CleanUp();
    }

    public void CleanUp()
    {
        using (var context = DbContextFactory.CreateDbContext())
        {
            context.Users.RemoveRange(context.Users);
            context.SaveChanges();
        }
    }
}

