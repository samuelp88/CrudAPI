using CrudAPI.Data.Output;
using CrudAPI.Data.VO;

namespace CrudAPI.Business.Abstract
{
    public interface IUserBusiness
    {
        Task<LoginOutput?> Login (string username, string password);
        Task<UserVO> Register(UserVO user);
    }
}
