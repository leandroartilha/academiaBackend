using Application.DTOs;

namespace Application.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(UserDTO user);
    }
}
