using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CrudAPI.Data.VO
{
    public class UserVO
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Gender { get; set; }

        [JsonIgnore]
        public string Role { get; set; }
    }
}
