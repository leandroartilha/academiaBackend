using Application.DTOs;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public void AddUser(UserDTO user);
        public UserDTO? GetUserByUsername(string username);
    }
}
