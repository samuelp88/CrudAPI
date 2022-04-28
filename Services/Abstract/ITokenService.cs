using CrudAPI.Models;

namespace CrudAPI.Services.Abstract
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
