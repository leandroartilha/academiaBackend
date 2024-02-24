using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddUser(UserDTO user)
        {
            var userEntity = _mapper.Map<User>(user); 
            _repository.AddUser(userEntity);
        }

        public UserDTO? GetUserByUsername(string username)
        {
            
            var userEntity = _repository.GetUserByName(username);
            return _mapper.Map<UserDTO>(userEntity);
        }
    }
}
