using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Context;

namespace Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public User? GetUserByName(string userName)
        {
            var user = _context.User.Where(u => u.Username == userName).FirstOrDefault();
            return user;
        }
    }
}
