using CrudAPI.Data.Abstract;

namespace CrudAPI.Data.VO
{
    public class Username : ValueObject<string>
    {
        public Username(string value) : base(value) { }
    }
}
