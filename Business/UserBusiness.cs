using CrudAPI.Business.Abstract;
using CrudAPI.Data;
using CrudAPI.Data.Output;
using CrudAPI.Data.VO;
using CrudAPI.Models;
using CrudAPI.Repositories;
using CrudAPI.Repositories.Abstract;
using CrudAPI.Services.Abstract;

namespace CrudAPI.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;
        private readonly IParser<User, UserVO> _userParser;

        public UserBusiness(ITokenService tokenService, IParser<User, UserVO> parser)
        {
            _repository = new UserRepository();
            _tokenService = tokenService;
            _userParser = parser;
        }

        public async Task<LoginOutput?> Login(string username, string password)
        {
            if (username == null || password == null) return null;
            var user = _repository.Get(username, password);
            if (user == null)
                return null;

            var token = _tokenService.GenerateToken(user);
            return new LoginOutput(user.Username, user.Gender, user.Role, token);
        }

        public async Task<UserVO> Register(UserVO userVO)
        {
            var user = _userParser.Parse(userVO);
            try
            {
                user = _repository.Create(user);
                return _userParser.Parse(user);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
