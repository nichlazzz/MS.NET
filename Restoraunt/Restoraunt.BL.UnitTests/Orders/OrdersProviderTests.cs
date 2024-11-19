using AutoMapper;
using Restoraunt.Restoraunt.BL.Mapper;
using Moq;
using NUnit.Framework;
using Restoraunt.DataAccess.Migrations.Restoraunt.BL.Orders.Entities;
using Restoraunt.Restoraunt.BL.Orders;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.BL.UnitTests;

   [TestFixture]
    public class OrderProviderTests
    {
        private Mock<IRepository<Order>> _orderRepository;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            // Arrange: Set up mocks and mapper
            _orderRepository = new Mock<IRepository<Order>>();
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<OrderBLProfile>()).CreateMapper();
        }

        [Test]
        public void GetOrders_ShouldReturnAllOrders()
        {
            // Arrange: Mock repository to return a list of orders
            var expectedOrders = new List<Order>
            {
                new Order { Id = 1, Heading = "Order 1" },
                new Order { Id = 2, Heading = "Order 2" },
            };
            _orderRepository.Setup(x => x.GetAll());

            // Act: Call GetOrders() on the OrderProvider
            var orderProvider = new OrderProvider(_orderRepository.Object, _mapper);
            var result = orderProvider.GetOrders();

            // Assert: Verify the results
            Assert.Equals(expectedOrders.Count, result.Count());
        }

        [Test]
        public void GetOrderInfo_ShouldReturnCorrectOrder()
        {
            // Arrange: Mock repository to return a specific order
            var expectedOrder = new Order { Id = 1, Heading = "Order 1" };
            _orderRepository.Setup(x => x.GetById(1)).Returns(expectedOrder);

            // Act: Call GetOrderInfo()
            var orderProvider = new OrderProvider(_orderRepository.Object, _mapper);
            var result = orderProvider.GetOrderInfo(1);

            // Assert: Verify the results
            Assert.Equals(expectedOrder.Id, result.Id);
            Assert.Equals(expectedOrder.Heading, result.Heading);
        }

        [Test]
        public void GetOrders_WithFilter_ShouldReturnFilteredOrders()
        {
            // Arrange: Mock repository to return a list of orders
            var expectedOrders = new List<Order>
            {
                new Order { Id = 1, Heading = "Order 1", IdDish = 1 },
                new Order { Id = 2, Heading = "Order 2", IdDish = 2 },
            };
            _orderRepository.Setup(x => x.GetAll());

            // Act: Call GetOrders() with a filter
            var filter = new OrderModelFilter { IdDish = 1 };
            var orderProvider = new OrderProvider(_orderRepository.Object, _mapper);
            var result = orderProvider.GetOrders(filter);

            // Assert: Verify that only the filtered order is returned
            Assert.Equals(1, result.Count());
            Assert.Equals(expectedOrders[0].IdDish, result.First().IdDish);
        }

        [Test]
        public void GetOrderInfo_ShouldThrowException_WhenOrderNotFound()
        {
            // Arrange: Mock repository to return null for a specific order
            _orderRepository.Setup(x => x.GetById(999)).Returns((Order)null);

            // Act: Call GetOrderInfo() and expect an exception
            var orderProvider = new OrderProvider(_orderRepository.Object, _mapper);
            Assert.Throws<ArgumentException>(() => orderProvider.GetOrderInfo(999));
        }

        [Test]
        public void CreateOrder_ShouldCreateNewOrder()
        {
            // Arrange: Create a new order model
            var newOrderModel = new CreateOrderModel { Heading = "New Order", IdDish = 1, IdUser = 1 };
            var expectedOrder = new Order { Id = 1, Heading = "New Order", IdDish = 1, IdUser = 1 }; // Assuming ID is generated
            _orderRepository.Setup(x => x.Save(It.IsAny<Order>())).Callback<Order>(order => order.Id = 1);

            // Act: Create the order
            var orderProvider = new OrderProvider(_orderRepository.Object, _mapper);
            var result = orderProvider.GetOrderInfo;

            // Assert: Verify that the order was saved and mapped correctly
            _orderRepository.Verify(x => x.Save(It.IsAny<Order>()), Times.Once);
            Assert.Equals(expectedOrder.Heading, result);
        }

        [Test]
        public void UpdateOrder_ShouldUpdateExistingOrder()
        {
            // Arrange: Set up mock data and repository behavior
            var existingOrder = new Order { Id = 1, Heading = "Old Order" };
            var updateOrderModel = new UpdateOrderModel { Heading = "Updated Order" };

            _orderRepository.Setup(x => x.GetById(1)).Returns(existingOrder); // Mock GetById
            _orderRepository.Setup(x => x.Save(It.IsAny<Order>())); // Mock Save

            // Act: Call UpdateOrder method
            var orderManager = new OrderManager(_orderRepository.Object, _mapper);
            var result = orderManager.UpdateOrder(1, updateOrderModel);

            // Assert: Verify that the order was updated and saved
            _orderRepository.Verify(x => x.Save(It.IsAny<Order>()), Times.Once);
            Assert.Equals(updateOrderModel.Heading, result.Heading);
        }

        [Test]
        public void UpdateOrder_ShouldThrowException_WhenOrderNotFound()
        {
            // Arrange: Set up mock data and repository behavior
            _orderRepository.Setup(x => x.GetById(999)).Returns((Order)null); // Mock GetById to return null

            // Act: Call UpdateOrder method and expect an exception
            var orderManager = new OrderManager(_orderRepository.Object, _mapper);
            Assert.Throws<ArgumentException>(() => orderManager.UpdateOrder(999, new UpdateOrderModel()));
        }

        [Test]
        public void DeleteOrder_ShouldDeleteExistingOrder()
        {
            // Arrange: Set up mock data and repository behavior
            var existingOrder = new Order { Id = 1, Heading = "Order 1" };
            _orderRepository.Setup(x => x.GetById(1)).Returns(existingOrder); // Mock GetById
            _orderRepository.Setup(x => x.Delete(It.IsAny<Order>())); // Mock Delete

            // Act: Call DeleteOrder method
            var orderManager = new OrderManager(_orderRepository.Object, _mapper);
            orderManager.DeleteOrder(1);

            // Assert: Verify that Delete was called on the repository
            _orderRepository.Verify(x => x.Delete(It.IsAny<Order>()), Times.Once);
        }

        [Test]
        public void DeleteOrder_ShouldThrowException_WhenOrderNotFound()
        {
            // Arrange: Set up mock data and repository behavior
            _orderRepository.Setup(x => x.GetById(999)).Returns((Order)null); // Mock GetById to return null

            // Act: Call DeleteOrder method and expect an exception
            var orderManager = new OrderManager(_orderRepository.Object, _mapper);
            Assert.Throws<ArgumentException>(() => orderManager.DeleteOrder(999));
        }
    }