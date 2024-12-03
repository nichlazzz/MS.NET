using System.Data.SqlTypes;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Validators;

namespace Restoraunt.Restoraunt.BL.UnitTests
{
    [TestFixture]
    public class TestBase
    {
        // The validators to be used in your tests
        private AdminValidator _adminValidator;
        private DishValidator _dishValidator;
        private MenuValidator _menuValidator;
        private OrderValidator _orderValidator;
        private UserValidator _userValidator;

        [SetUp]
        public void Setup()
        {
            // Initialize validators before each test
            _adminValidator = new AdminValidator();
            _dishValidator = new DishValidator();
            _menuValidator = new MenuValidator();
            _orderValidator = new OrderValidator();
            _userValidator = new UserValidator();
        }

        [TearDown]
        public void TearDown()
        {
            // Reset any state after each test
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // Initial setup before all tests (e.g., database connections, if needed)
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Cleanup after all tests are completed
        }

        [Test]
        [TestCase("admin@example.com", true)]
        [TestCase("invalidemail", false)]
        [TestCase(null, false)]
        public void AdminValidator_ShouldValidateEmail(string email, bool isValid)
        {
            // Arrange
            var admin = new Admin { Email = email };

            // Act
            var result = _adminValidator.TestValidate(admin);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Email);
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        [Test]
        [TestCase("Valid Name", true)]
        [TestCase("", false)]
        [TestCase(null, false)]
        public void AdminValidator_ShouldValidateName(string name, bool isValid)
        {
            // Arrange
            var admin = new Admin { Name = name };

            // Act
            var result = _adminValidator.TestValidate(admin);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Test]
        public void DishValidator_ShouldValidateCostGreaterThanZero()
        {
            // Arrange
            var dish = new Dish { Cost = new SqlMoney(-1) };

            // Act
            var result = _dishValidator.TestValidate(dish);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Cost);
        }

        [Test]
        public void DishValidator_ShouldValidateCostNotNull()
        {
            // Arrange
            var dish = new Dish { Cost = SqlMoney.Null };

            // Act
            var result = _dishValidator.TestValidate(dish);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Cost);
        }

        [Test]
        public void MenuValidator_ShouldValidateDishIdGreaterThanZero()
        {
            // Arrange
            var menu = new Menu { IdDish = 0 };

            // Act
            var result = _menuValidator.TestValidate(menu);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.IdDish);
        }

        [Test]
        public void MenuValidator_ShouldValidateAdminIdGreaterThanZero()
        {
            // Arrange
            var menu = new Menu { IdAdmin = 0 };

            // Act
            var result = _menuValidator.TestValidate(menu);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.IdAdmin);
        }

        [Test]
        public void OrderValidator_ShouldValidateDateCreateNotInFuture()
        {
            // Arrange
            var order = new Order { DateCreate = DateTime.UtcNow.AddMinutes(1) };

            // Act
            var result = _orderValidator.TestValidate(order);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.DateCreate);
        }

        [Test]
        public void UserValidator_ShouldValidateModificationTimeNotInFuture()
        {
            // Arrange
            var user = new User { ModificationTime = DateTime.UtcNow.AddMinutes(1) };

            // Act
            var result = _userValidator.TestValidate(user);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.ModificationTime);
        }

        [Test]
        public void UserValidator_ShouldValidateCreationTimeNotInFuture()
        {
            // Arrange
            var user = new User { CreationTime = DateTime.UtcNow.AddMinutes(1) };

            // Act
            var result = _userValidator.TestValidate(user);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CreationTime);
        }

        [Test]
        public void UserValidator_ShouldValidateOrdersNotNull()
        {
            // Arrange
            var user = new User { Orders = null };

            // Act
            var result = _userValidator.TestValidate(user);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Orders);
        }

        [Test]
        public void UserValidator_ShouldValidateFavoriteDishesNotNull()
        {
            // Arrange
            var user = new User { FavoriteDishes = null };

            // Act
            var result = _userValidator.TestValidate(user);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.FavoriteDishes);
        }
        
    }
}