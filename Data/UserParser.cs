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

            return null;
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

        public bool TryParse(User p, out UserVO r)
        {
            try
            {
                r = Parse(p);
                return true;
            }
            catch (Exception e) when (e is ArgumentException)
            {
                r = null;
                return false;
            }
        }

        public bool TryParse(List<User> p, out List<UserVO> r)
        {
            try
            {
                r = Parse(p);
                return true;
            }
            catch (Exception e) when (e is ArgumentException)
            {
                r = null;
                return false;
            }
        }

        public bool TryParse(UserVO r, out User p)
        {
            try
            {
                p = Parse(r);
                return true;
            }
            catch (Exception e) when (e is ArgumentException)
            {
                p = null;
                return false;
            }
        }

        public bool TryParse(List<UserVO> r, out List<User> p)
        {
            try
            {
                p = Parse(r);
                return true;
            }
            catch (Exception e) when (e is ArgumentException)
            {
                p = null;
                return false;
            }
        }
    }
}
