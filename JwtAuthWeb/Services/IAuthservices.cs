using JwtAuthWeb.Entities;
using JwtAuthWeb.Model;

namespace JwtAuthWeb.Services
{
    public interface IAuthservices
    {
        Task <User?> DeActivateUser(UserDecativationDto request);
        Task<TokenResponceDto?> LoginAsync(Userdto request);

        //Task<TokenResponceDto?> RefreshTokenAsync(TokenResponceDto request);
        Task<TokenResponceDto?> RefreshTokenAsync(RefreshRequestToken request);
        Task<User?> RegisterAsync(Userdto request);
    }
}