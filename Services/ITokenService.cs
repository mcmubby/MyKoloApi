using MyKoloApi.Models;

namespace MyKoloApi.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}