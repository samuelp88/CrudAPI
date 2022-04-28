using CrudAPI.Models;

namespace CrudAPI.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        bool Exists(string username);
    }
}
