using DesafioApi.Models;

namespace DesafioApi.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
