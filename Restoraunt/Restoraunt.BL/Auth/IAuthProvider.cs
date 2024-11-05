using Restoraunt.Restoraunt.BL.Auth.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;
public interface IAuthProvider
{
    Task<TokensResponse> AuthorizeUser(string email, string password);
    Task RegisterUser(string email, string password); 
}

