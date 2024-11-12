using System.Data.SqlTypes;
using AutoMapper;
using Restoraunt.Restoraunt.BL.Mapper;
using Moq;
using NUnit.Framework;
using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.BL.Dishes;
using Restoraunt.Restoraunt.DataAccess;
using UpdateDishModel = Restoraunt.Restoraunt.BL.Dishes.Entities.UpdateDishModel;

namespace Restoraunt.Restoraunt.BL.UnitTests.Dishes;

[TestFixture]
public class DishProviderTests
{
    private Mock<IRepository<Dish>> _dishRepository;
    private IMapper _mapper;

    [SetUp]
    public void SetUp()
    {
        // Arrange: Set up mocks and mapper
        _dishRepository = new Mock<IRepository<Dish>>();
        _mapper = new MapperConfiguration(cfg => cfg.AddProfile<DishBLProfile>()).CreateMapper();
    }

    [Test]
    public void GetDishes_ShouldReturnAllDishes()
    {
        // Arrange: Mock repository to return a list of dishes
        var expectedDishes = new List<Dish>
        {
            new Dish { Id = 1, ExternalId = Guid.NewGuid(), Cost = new SqlMoney(10.50m), Category = "Main Course" },
            new Dish { Id = 2, ExternalId = Guid.NewGuid(), Cost = new SqlMoney(12.00m), Category = "Dessert" },
        };
        _dishRepository.Setup(x => x.GetAll());

        // Act: Call GetDishes() on the DishProvider
        var dishProvider = new DishProvider(_dishRepository.Object, _mapper);
        var result = dishProvider.GetDishes();

        // Assert: Verify the results
        Assert.Equals(expectedDishes.Count, result.Count());
    }

        [Test]
        public void UpdateDish_ShouldThrowException_WhenDishNotFound()
        {
            // Arrange: Set up mock data and repository behavior
            _dishRepository.Setup(x => x.GetById(999)).Returns((Dish)null); // Mock GetById to return null

            // Act: Call UpdateDish method and expect an exception
            var dishManager = new DishManager(_dishRepository.Object, _mapper);
            Assert.Throws<ArgumentException>(() => dishManager.UpdateDish(999, new UpdateDishModel()));
        }

        [Test]
        public void DeleteDish_ShouldDeleteExistingDish()
        {
            // Arrange: Set up mock data and repository behavior
            var existingDish = new Dish { Id = 1, ExternalId = Guid.NewGuid(), Cost = new SqlMoney(10.50m), Category = "Main Course" };
            _dishRepository.Setup(x => x.GetById(1)).Returns(existingDish); // Mock GetById
            _dishRepository.Setup(x => x.Delete(It.IsAny<Dish>())); // Mock Delete

            // Act: Call DeleteDish method
            var dishManager = new DishManager(_dishRepository.Object, _mapper);
            dishManager.DeleteDish(1);

            // Assert: Verify that Delete was called on the repository
            _dishRepository.Verify(x => x.Delete(It.IsAny<Dish>()), Times.Once);
        }

        [Test]
        public void DeleteDish_ShouldThrowException_WhenDishNotFound()
        {
            // Arrange: Set up mock data and repository behavior
            _dishRepository.Setup(x => x.GetById(999)).Returns((Dish)null); // Mock GetById to return null

            // Act: Call DeleteDish method and expect an exception
            var dishManager = new DishManager(_dishRepository.Object, _mapper);
            Assert.Throws<ArgumentException>(() => dishManager.DeleteDish(999));
        }
    }
