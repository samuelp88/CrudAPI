using CrudAPI.Models;
using CrudAPI.Repositories.Abstract;

namespace CrudAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _context;
        public UserRepository()
        {
            if (_context == null) _context = MockUsers();
        }

        public User Create(User entity)
        {
            if (Exists(entity.Username))
                return null;

            _context.Add(entity);
            return entity;
        }

        public bool Exists(string username)
        {
            return _context.Any(x => x.Username == username);
        }

        public List<User> Get()
        {
            return _context.ToList();
        }

        public User? Get(string username, string password)
        {
            return _context.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password);
        }

        private static List<User> MockUsers()
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "batman", Password = "batman", Role = "manager" });
            users.Add(new User { Id = 2, Username = "robin", Password = "robin", Role = "employee" });
            return users;
        }
    }
}
