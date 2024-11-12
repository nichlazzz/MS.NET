
using AutoMapper;
using Restoraunt.Restoraunt.BL.Mapper;
using Moq;
using NUnit.Framework;
using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.BL.Trainers.Entities;
using Restoraunt.Restoraunt.DataAccess;

[TestFixture]
    public class AdminsProviderTests
    {
        private Mock<IRepository<Admin>> _adminsRepository;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            // Arrange: Set up mocks and mapper
            _adminsRepository = new Mock<IRepository<Admin>>();
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<AdminBLProfile>()).CreateMapper();
        }

        [Test]
        public void GetAdmins_ShouldReturnAllAdmins()
        {
            // Arrange: Mock repository to return a list of admins
            var expectedAdmins = new List<Admin>
            {
                new Admin { Id = 1, Email = "admin1@example.com" },
                new Admin { Id = 2, Email = "admin2@example.com" },
            };
            _adminsRepository.Setup(x => x.GetAll());

            // Act: Call GetAdmins() on the AdminsProvider
            var adminsProvider = new AdminsProvider(_adminsRepository.Object, _mapper);
            var result = adminsProvider.GetAdmins();

            // Assert: Verify the result
            Assert.Equals(expectedAdmins.Count, result.Count());
        }

        [Test]
        public void GetAdminInfo_ShouldReturnCorrectAdmin()
        {
            // Arrange: Mock repository to return a specific admin
            var expectedAdmin = new Admin { Id = 1, Email = "admin1@example.com" };
            _adminsRepository.Setup(x => x.GetById(1)).Returns(expectedAdmin);

            // Act: Call GetAdminInfo()
            var adminsProvider = new AdminsProvider(_adminsRepository.Object, _mapper);
            var result = adminsProvider.GetAdminInfo(1);

            // Assert: Verify the results
            Assert.Equals(expectedAdmin.Id, result.Id);
            Assert.Equals(expectedAdmin.Email, result.Email);
        }

        [Test]
        public void GetAdmins_WithFilter_ShouldReturnFilteredAdmins()
        {
            // Arrange: Mock repository to return a list of admins
            var expectedAdmins = new List<Admin>
            {               new Admin { Id = 1, Email = "admin1@example.com" },
                new Admin { Id = 2, Email = "admin2@example.com" },
            };
            _adminsRepository.Setup(x => x.GetAll());

            // Act: Call GetAdmins() with a filter
            var filter = new AdminModelFilter { Email = "admin1@example.com" };
            var adminsProvider = new AdminsProvider(_adminsRepository.Object, _mapper);
            var result = adminsProvider.GetAdmins(filter);

            // Assert: Verify that only the filtered admin is returned
            Assert.Equals(1, result.Count());
            Assert.Equals(expectedAdmins[0].Email, result.First().Email);
        }

        [Test]
        public void GetAdminInfo_ShouldThrowException_WhenAdminNotFound()
        {
            // Arrange: Mock repository to return null for a specific admin
            _adminsRepository.Setup(x => x.GetById(999)).Returns((Admin)null);

            // Act: Call GetAdminInfo() and expect an exception
            var adminsProvider = new AdminsProvider(_adminsRepository.Object, _mapper);
            Assert.Throws<ArgumentException>(() => adminsProvider.GetAdminInfo(999));
        }

        [Test]
        public void CreateAdmin_ShouldCreateNewAdmin()
        {
            // Arrange: Create a new admin model
            var newAdminModel = new CreateAdminModel { Email = "newadmin@example.com", Password = "password" };
            var expectedAdmin = new Admin { Id = 1, Email = "newadmin@example.com" }; // Assuming ID is generated
            _adminsRepository.Setup(x => x.Save(It.IsAny<Admin>())).Callback<Admin>(admin => admin.Id = 1);

            // Act: Create the admin
            var adminsProvider = new AdminsProvider(_adminsRepository.Object, _mapper);
            var result = adminsProvider.GetAdmins();

            // Assert: Verify that the admin was saved and mapped correctly
            _adminsRepository.Verify(x => x.Save(It.IsAny<Admin>()), Times.Once);
            Assert.Equals(expectedAdmin.Email, result);
        }

        [Test]
        public void UpdateAdmin_ShouldUpdateExistingAdmin()
        {
            // Arrange: Set up mock data and repository behavior
            var existingAdmin = new Admin { Id = 1, Email = "oldadmin@example.com" };
            var updateAdminModel = new UpdateAdminModel { Email = "updatedadmin@example.com" };

            _adminsRepository.Setup(x => x.GetById(1)).Returns(existingAdmin); // Mock GetById
            _adminsRepository.Setup(x => x.Save(It.IsAny<Admin>())); // Mock Save

            // Act: Call UpdateAdmin method
            var adminsManager = new AdminsManager(_adminsRepository.Object, _mapper);
            var result = adminsManager.UpdateAdmin(1, updateAdminModel);

            // Assert: Verify that the admin was updated and saved
            _adminsRepository.Verify(x => x.Save(It.IsAny<Admin>()), Times.Once);
            Assert.Equals(updateAdminModel.Email, result.Email);
        }

        [Test]
        public void UpdateAdmin_ShouldThrowException_WhenAdminNotFound()
        {
            // Arrange: Set up mock data and repository behavior
            _adminsRepository.Setup(x => x.GetById(999)).Returns((Admin)null); // Mock GetById to return null

            // Act: Call UpdateAdmin method and expect an exception
            var adminsManager = new AdminsManager(_adminsRepository.Object, _mapper);
            UpdateAdminModel adminModel = new UpdateAdminModel();
            Assert.Throws<ArgumentException>(() => adminsManager.UpdateAdmin(999, adminModel));
        }

        [Test]
        public void DeleteAdmin_ShouldDeleteExistingAdmin()
        {
            // Arrange: Set up mock data and repository behavior
            var existingAdmin= new Admin { Id = 1, Email = "admin1@example.com" };
            _adminsRepository.Setup(x => x.GetById(1)).Returns(existingAdmin); // Mock GetById
            _adminsRepository.Setup(x => x.Delete(It.IsAny<Admin>())); // Mock Delete

            // Act: Call DeleteAdmin method
            var adminsManager = new AdminsManager(_adminsRepository.Object, _mapper);
            adminsManager.DeleteAdmin(1);

            // Assert: Verify that Delete was called on the repository
            _adminsRepository.Verify(x => x.Delete(It.IsAny<Admin>()), Times.Once);
        }

        [Test]
        public void DeleteAdmin_ShouldThrowException_WhenAdminNotFound()
        {
            // Arrange: Set up mock data and repository behavior
            _adminsRepository.Setup(x => x.GetById(999)).Returns((Admin)null); // Mock GetById to return null

            // Act: Call DeleteAdmin method and expect an exception
            var adminsManager = new AdminsManager(_adminsRepository.Object, _mapper);
            Assert.Throws<ArgumentException>(() => adminsManager.DeleteAdmin(999));
        }
    }

