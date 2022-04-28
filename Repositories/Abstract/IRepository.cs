using CrudAPI.Models.Abstract;

namespace CrudAPI.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        List<T> Get();
        T? Get(string username, string password);

        T Create(T entity);
    }
}
