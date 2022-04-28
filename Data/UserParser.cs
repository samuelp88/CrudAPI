using CrudAPI.Data.VO;
using CrudAPI.Models;

namespace CrudAPI.Data
{
    public class UserParser : IParser<User, UserVO>
    {
        public UserVO Parse(User p)
        {
            return new UserVO
            {
                Id = p.Id,
                Username = p.Username,
                Password = p.Password,
                Gender = p.Gender.ToString(),
                Role = p.Role,
            };
        }

        public List<UserVO> Parse(List<User> p)
        {
            List<UserVO> list = new();
            foreach (var item in p)
            {
                list.Add(Parse(item));
            }
            return list;
        }

        public User Parse(UserVO r)
        {
            if (Enum.TryParse(NormalizeString(r.Gender), out Gender rGender))
                return new User
                {
                    Id = r.Id,
                    Username = r.Username,
                    Password = r.Password,
                    Gender = rGender,
                    Role = r.Role
                };

            throw new ArgumentException();
        }

        public List<User> Parse(List<UserVO> r)
        {
            List<User> list = new();
            foreach (var item in r)
            {
                list.Add(Parse(item));
            }
            return list;
        }

        private static string NormalizeString(string input)
        {
            var lowerCase = input.ToLower();
            return lowerCase[0].ToString().ToUpper() + lowerCase.Substring(1);
        }
    }
}
