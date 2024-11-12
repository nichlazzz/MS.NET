using System.Data.SqlTypes;
using AutoMapper;
using Restoraunt.Restoraunt.BL.Mapper;
using Moq;
using NUnit.Framework;
using Restoraunt.DataAccess.Migrations.Restoraunt.BL.FavoriteDishes;
using Restoraunt.DataAccess.Migrations.Restoraunt.BL.FavoriteDishes.Entities;
using Restoraunt.Restoraunt.BL.FavoriteDishes;
using Restoraunt.Restoraunt.BL.FavoriteDishes.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace FitnessClub.BL.UnitTests.FavoriteDishes;

 [TestFixture]
    public class FavoriteDishProviderTests
    {
        private Mock<IRepository<FavoriteDish>> _favoriteDishRepository;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            // Arrange: Set up mocks and mapper
            _favoriteDishRepository = new Mock<IRepository<FavoriteDish>>();
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<FavoriteDishBLProfile>()).CreateMapper();
        }

        [Test]
        public void GetFavoriteDishes_ShouldReturnAllFavoriteDishes()
        {
            // Arrange: Mock repository to return a list of favorite dishes
            var expectedFavoriteDishes = new List<FavoriteDish>
            {
                new FavoriteDish { Id = 1, Descroption = "Favorite Dish 1" },
                new FavoriteDish { Id = 2, Descroption = "Favorite Dish 2" },
            };
            _favoriteDishRepository.Setup(x => x.GetAll());

            // Act: Call GetFavoriteDishes() on the FavoriteDishProvider
            var favoriteDishProvider = new FavoriteDishProvider(_favoriteDishRepository.Object, _mapper);
            var result = favoriteDishProvider.GetFavoriteDishes();

            // Assert: Verify the results
            Assert.Equals(expectedFavoriteDishes.Count, result.Count());
        }

        [Test]
        public void GetFavoriteDishInfo_ShouldReturnCorrectFavoriteDish()
        {
            // Arrange: Mock repository to return a specific favorite dish
            var expectedFavoriteDish = new FavoriteDish { Id = 1, Descroption = "Favorite Dish 1" };
            _favoriteDishRepository.Setup(x => x.GetById(1)).Returns(expectedFavoriteDish);

            // Act: Call GetFavoriteDishInfo()
            var favoriteDishProvider = new FavoriteDishProvider(_favoriteDishRepository.Object, _mapper);
            var result = favoriteDishProvider.GetFavoriteDishInfo(1);

            // Assert: Verify the results
            Assert.Equals(expectedFavoriteDish.Id, result.Id);
            Assert.Equals(expectedFavoriteDish.Descroption, result.Description); // Assuming the property name is Description in the model
        }

        [Test]
        public void GetFavoriteDishes_WithFilter_ShouldReturnFilteredFavoriteDishes()
        {
            // Arrange: Mock repository to return a list of favorite dishes
            var expectedFavoriteDishes = new List<FavoriteDish>
            {
                new FavoriteDish { Id = 1, Descroption = "Favorite Dish 1", IdUser = 1 },
                new FavoriteDish { Id = 2, Descroption = "Favorite Dish 2", IdUser = 2 },
            };
            _favoriteDishRepository.Setup(x => x.GetAll());

            // Act: Call GetFavoriteDishes() with a filter
            var filter = new FavoriteDishModelFilter { IdUser = 1 };
            var favoriteDishProvider = new FavoriteDishProvider(_favoriteDishRepository.Object, _mapper);
            var result = favoriteDishProvider.GetFavoriteDishes(filter);

            // Assert: Verify that only the filtered favorite dish is returned
            Assert.Equals(1, result.Count());
            Assert.Equals(expectedFavoriteDishes[0].IdUser, result.First().IdUser);}

        [Test]
        public void GetFavoriteDishInfo_ShouldThrowException_WhenFavoriteDishNotFound()
        {
            // Arrange: Mock repository to return null for a specific favorite dish
            _favoriteDishRepository.Setup(x => x.GetById(999)).Returns((FavoriteDish)null);

            // Act: Call GetFavoriteDishInfo() and expect an exception
            var favoriteDishProvider = new FavoriteDishProvider(_favoriteDishRepository.Object, _mapper);
            Assert.Throws<ArgumentException>(() => favoriteDishProvider.GetFavoriteDishInfo(999));
        }

        [Test]
        public void CreateFavoriteDish_ShouldCreateNewFavoriteDish()
        {
            // Arrange: Create a new favorite dish model
            var newFavoriteDishModel = new CreateFavoriteDishModel 
            { 
                ExternalId = Guid.NewGuid(), 
                Cost = 10.50m, 
                Category = "Main Course", 
                Description = "Delicious Dish", 
                IdUser = 1 
            };
            var expectedFavoriteDish = new FavoriteDish
            {
                Id = 1, 
                ExternalId = newFavoriteDishModel.ExternalId,
                Cost = new SqlMoney(newFavoriteDishModel.Cost),
                Category = newFavoriteDishModel.Category,
                Descroption = newFavoriteDishModel.Description,
                IdUser = newFavoriteDishModel.IdUser
            };
            _favoriteDishRepository.Setup(x => x.Save(It.IsAny<FavoriteDish>())).Callback<FavoriteDish>(dish => dish.Id = 1);

            // Act: Create the favorite dish
            var favoriteDishProvider = new FavoriteDishProvider(_favoriteDishRepository.Object, _mapper);
            var result = favoriteDishProvider.GetFavoriteDishInfo;

            // Assert: Verify that the favorite dish was saved and mapped correctly
            _favoriteDishRepository.Verify(x => x.Save(It.IsAny<FavoriteDish>()), Times.Once);
            Assert.Equals(expectedFavoriteDish.ExternalId, result);
        }

        [Test]
        public void UpdateFavoriteDish_ShouldUpdateExistingFavoriteDish()
        {
            // Arrange: Set up mock data and repository behavior
            var existingFavoriteDish = new FavoriteDish 
            { 
                Id = 1, 
                ExternalId = Guid.NewGuid(), 
                Cost = 10.50m, 
                Category = "Main Course", 
                Descroption = "Old Description", 
                IdUser = 1
            };
            var updateFavoriteDishModel = new UpdateFavoriteDishModel 
            { 
                Description = "Updated Description", 
                IdUser = 1 
            };

            _favoriteDishRepository.Setup(x => x.GetById(1)).Returns(existingFavoriteDish); // Mock GetById
            _favoriteDishRepository.Setup(x => x.Save(It.IsAny<FavoriteDish>())); // Mock Save

            // Act: Call UpdateFavoriteDish method
            var favoriteDishManager = new FavoriteDishManager(_favoriteDishRepository.Object, _mapper);
            var result = favoriteDishManager.UpdateFavoriteDish(1, updateFavoriteDishModel);

            // Assert: Verify that the favorite dish was updated and saved
            _favoriteDishRepository.Verify(x => x.Save(It.IsAny<FavoriteDish>()), Times.Once);
            Assert.Equals(updateFavoriteDishModel.IdUser, result.ExternalId);
            Assert.Equals(updateFavoriteDishModel.Cost, result.Cost);
            Assert.Equals(updateFavoriteDishModel.Category, result.Category);
            Assert.Equals(updateFavoriteDishModel.Description, result.Description);
            Assert.Equals(updateFavoriteDishModel.IdUser, result.IdUser);
        }

        [Test]
        public void UpdateFavoriteDish_ShouldThrowException_WhenFavoriteDishNotFound()
        {
            // Arrange: Set up mock data and repository behavior
            _favoriteDishRepository.Setup(x => x.GetById(999)).Returns((FavoriteDish)null); // Mock GetById to return null

            // Act: Call UpdateFavoriteDish method and expect an exception
            var favoriteDishManager = new FavoriteDishManager(_favoriteDishRepository.Object, _mapper);
            Assert.Throws<ArgumentException>(() => favoriteDishManager.UpdateFavoriteDish(999, new UpdateFavoriteDishModel()));
        }

        [Test]
        public void DeleteFavoriteDish_ShouldDeleteExistingFavoriteDish()
        {
            // Arrange: Set up mock data and repository behavior
            var existingFavoriteDish = new FavoriteDish { Id = 1, Descroption = "Favorite Dish 1" };
            _favoriteDishRepository.Setup(x => x.GetById(1)).Returns(existingFavoriteDish); // Mock GetById
            _favoriteDishRepository.Setup(x => x.Delete(It.IsAny<FavoriteDish>())); // Mock Delete

            // Act: Call DeleteFavoriteDish method
            var favoriteDishManager = new FavoriteDishManager(_favoriteDishRepository.Object, _mapper);
            favoriteDishManager.DeleteFavoriteDish(1);

            // Assert: Verify that Delete was called on the repository
            _favoriteDishRepository.Verify(x => x.Delete(It.IsAny<FavoriteDish>()), Times.Once);
        }

        [Test]
        public void DeleteFavoriteDish_ShouldThrowException_WhenFavoriteDishNotFound()
        {
            // Arrange: Set up mock data and repository behavior
            _favoriteDishRepository.Setup(x => x.GetById(999)).Returns((FavoriteDish)null); // Mock GetById to return null

            // Act: Call DeleteFavoriteDish method and expect an exception
            var favoriteDishManager = new FavoriteDishManager(_favoriteDishRepository.Object, _mapper);
            Assert.Throws<ArgumentException>(() => favoriteDishManager.DeleteFavoriteDish(999));
        }
    }