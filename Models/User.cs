using CrudAPI.Models.Abstract;

namespace CrudAPI.Models
{
    public enum Gender
    {
        Masculine,
        Feminine
    }
    public class User : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Gender Gender { get; set; }
        public string Role { get; set; }
    }
}
