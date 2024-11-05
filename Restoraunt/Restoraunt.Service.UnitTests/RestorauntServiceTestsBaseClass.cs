using System.Data.SqlTypes;
using System.Net.Http.Headers;
using FitnessClub.Service.UnitTests;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.UnitTests;
using Restoraunt.Restoraunt.Service.UnitTests.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Moq;
using NUnit.Framework;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.UnitTests.Helpers;

namespace Restoraunt.Restoraunt.Service.UnitTests;

public class RestorauntServiceTestsBaseClass
{
    public RestorauntServiceTestsBaseClass(WebApplicationFactory<Program> factory)
    {
        _factory = factory;

        var settings = TestSettingsHelper.GetSettings();

        _testServer = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.Replace(ServiceDescriptor.Scoped(_ =>
                {
                    var httpClientFactoryMock = new Mock<IHttpClientFactory>();
                    httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>()))
                        .Returns(TestHttpClient);
                    return httpClientFactoryMock.Object;
                }));
                services.PostConfigureAll<JwtBearerOptions>(options =>
                {
                    options.ConfigurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                        $"{settings.IdentityServerUri}/.well-known/openid-configuration",
                        new OpenIdConnectConfigurationRetriever(),
                        new HttpDocumentRetriever(TestHttpClient)
                        {
                            RequireHttps = false,
                            SendAdditionalHeaderData = true
                        });
                });
            });
        });           TestHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "token");
        }

        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            // Create test data in your database using the test server
            using var scope = GetService<IServiceScopeFactory>().CreateScope();

            // Create an Admin
            var adminRepository = scope.ServiceProvider.GetRequiredService<IRepository<Admin>>();
            var admin = adminRepository.Save(new Admin
            {
                Name = "TestAdmin",
                Email = "test@admin.com"
            });
            TestAdminId = int.Parse(admin.ExternalId.ToString());

            // Create a Dish
            var dishRepository = scope.ServiceProvider.GetRequiredService<IRepository<Dish>>();
            var dish = dishRepository.Save(new Dish
            {
                Cost = new SqlMoney(10.00m),
                Category = "Test Category"
            });
            TestDishId = dish.Id;

            // Create a Menu
            var menuRepository = scope.ServiceProvider.GetRequiredService<IRepository<Menu>>();
            var menu = menuRepository.Save(new Menu
            {
                IdAdmin = TestAdminId,
                IdDish = TestDishId
            });
            TestMenuId = menu.Id;

            // Create a User
            var userRepository = scope.ServiceProvider.GetRequiredService<IRepository<User>>();
            var user = userRepository.Save(new User
            {
                Name = "TestUser"
            });
            TestUserId = user.Id;

            // Create an Order
            var orderRepository = scope.ServiceProvider.GetRequiredService<IRepository<Order>>();
            var order = orderRepository.Save(new Order
            {
                Heading = "Test Order",
                DateCreate = DateTime.UtcNow,
                Details = "Test order details",
                IdDish = TestDishId,
                IdUser = int.Parse(TestUserId.ToString())
            });
            TestOrderId = order.Id;
        }

        public T? GetService<T>()
        {
            return _testServer.Services.GetRequiredService<T>();
        }

        public HttpClient TestHttpClient => _testServer.CreateClient();

        private readonly WebApplicationFactory<Program> _factory;
        private readonly WebApplicationFactory<Program> _testServer;

        protected int TestAdminId;
        protected int TestDishId;
        protected int TestMenuId;
        protected int TestUserId;
        protected int TestOrderId;
    }