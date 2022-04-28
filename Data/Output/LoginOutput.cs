using CrudAPI.Models;

namespace CrudAPI.Data.Output
{
    public class LoginOutput
    {
        public string Username { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

        public LoginOutput(string username, Gender gender, string role, string token)
        {
            Username = username;
            Gender = gender.ToString();
            Role = role;
            Token = token;
        }
    }
}
