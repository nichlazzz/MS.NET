using Duende.IdentityServer.Models;
using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.DataAccess;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Restoraunt.Restoraunt.BL.Auth;

public class AuthProvider : IAuthProvider
    {
        private readonly SignInManager<Admin> _signInManager;
        private readonly UserManager<Admin> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _identityServerUri;
        private readonly string _clientId;
        private readonly string _clientSecret;

        public AuthProvider(
            SignInManager<Admin> signInManager,
            UserManager<Admin> userManager,
            IHttpClientFactory httpClientFactory,
            string identityServerUri,
            string clientId,
            string clientSecret)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _identityServerUri = identityServerUri;
            _httpClientFactory = httpClientFactory;
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        public async Task<TokensResponse> AuthorizeUser(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                throw new Exception(); // UserNotFoundException, BusinessLogicException(Code.UserNotFound);
            }

            var verificationPasswordResult = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!verificationPasswordResult.Succeeded)
            {
                throw new Exception(); // AuthorizationException, BusinessLogicException(Code.PasswordOrLoginIsIncorrect);
            }

            var client = _httpClientFactory.CreateClient();
            var discoveryDoc = await client.GetDiscoveryDocumentAsync(_identityServerUri);
            if (discoveryDoc.IsError)
            {
                throw new Exception();
            }

            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = discoveryDoc.TokenEndpoint,
                GrantType = GrantType.ResourceOwnerPassword,
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                UserName = user.Name,
                Password = password,
                Scope = "api offline_access"
            });

            if (tokenResponse.IsError)
            {
                throw new Exception();
            }

            return new TokensResponse()
            {
                AccessToken = tokenResponse.AccessToken,
                RefreshToken = tokenResponse.RefreshToken
            };
        }

        public async Task RegisterUser(string email, string password)
        {
            Admin admin = new Admin()
            {
                Email = email, 
                Name = email
            };

            var createUserResult = await _userManager.CreateAsync(admin, password);
        }
    }
