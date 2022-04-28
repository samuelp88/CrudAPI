using CrudAPI.Data.Abstract;

namespace CrudAPI.Data.VO
{
    public class Password : ValueObject<string>
    {
        public Password(string value) : base(value) { }
    }
}
