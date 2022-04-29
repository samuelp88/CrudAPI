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
        private readonly IInputValidator _inputValidator;

        public UserBusiness(ITokenService tokenService, IParser<User, UserVO> parser, IInputValidator inputValidator)
        {
            _repository = new UserRepository();
            _tokenService = tokenService;
            _userParser = parser;
            _inputValidator = inputValidator;
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
            if (user == null)
            {
                _inputValidator.Failed("Invalid value for field 'Gender'");
                return null;
            }
        
            user = _repository.Create(user);
            if (user == null)
            {
                _inputValidator.Failed($"Username '{userVO.Username}' already exists");
                return null;
            }
            return _userParser.Parse(user);
        }
    }
}
