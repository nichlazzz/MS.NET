using System.Net;
using FitnessClub.Service.UnitTests;
using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.DataAccess;
using FluentAssertions;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using Restoraunt.Restoraunt.Service.UnitTests;


namespace Restoraunt.Restoraunt.Service.Tests
{
    public class LoginUserTests : RestorauntServiceTestsBaseClass
    {
        [Test]
        public async Task SuccessFullResult()
        {
            // prepare: create new user (login, password) => execute (try to login) => assert (Success : access token, refresh token)
            //prepare
            var user = new User
            {
                Name = "test@test",
            };
            var password = "Password1@";

            using var scope = GetService<IServiceScopeFactory>().CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var result = await userManager.CreateAsync(user, password);

            //execute
            var query = $"?email={user.Name}&password={password}";
            var requestUri =
                RestorauntApiEndpoints.AuthorizeUserEndpoint + query; // /auth/login?login=test@test&password=password
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var client = TestHttpClient;
            var response = await client.SendAsync(request);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseContentJson = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<TokensResponse>(responseContentJson);

            content.Should().NotBeNull();
            content.AccessToken.Should().NotBeNull();
            content.RefreshToken.Should().NotBeNull();

            //check that access token is valid
            // ... (Your code for checking token validity)
        }

        [Test]
        public async Task BadRequestUserNotFoundResultTest()
        {
            // prepare: (imagine_login, imagine_password) => execute (try to login) => assert (BadRequest user not found)
            //prepare
            var login = "not_existing@mail.ru";
            using var scope = GetService<IServiceScopeFactory>().CreateScope();
            var userRepository = scope.ServiceProvider.GetRequiredService<IRepository<User>>();
            var user = userRepository.GetAll().FirstOrDefault(x => x.Name.ToLower() == login.ToLower());
            if (user != null)
            {
                userRepository.Delete(user);
            }

            var password = "password";
            //100% confidence
            //execute
            var query = $"?email={login}&password={password}";
            var requestUri =
                RestorauntApiEndpoints.AuthorizeUserEndpoint + query; // /auth/login?login=test@test&password=password
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var response = await TestHttpClient.SendAsync(request);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task PasswordIsIncorrectResultTest()
        {
            // prepare: create new user (login, password) => execute (try to login with wrong password) => assert (BadRequest password is incorrect)

            //prepare
            var user = new User
            {
                Name = "test@test",
            };
            var password = "password";

            using var scope = GetService<IServiceScopeFactory>().CreateScope();
            var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
            await userManager.CreateAsync(user, password);

            var incorrect_password = "kvhdbkvhbk";

            //execute
            var query = $"?email={user.Name}&password={incorrect_password}";
            var requestUri =
                RestorauntApiEndpoints.AuthorizeUserEndpoint + query;
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var response = await TestHttpClient.SendAsync(request);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

    }
}
