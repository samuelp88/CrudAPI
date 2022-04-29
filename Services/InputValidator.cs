using CrudAPI.Services.Abstract;

namespace CrudAPI.Services
{
    public class InputValidator : IInputValidator
    {
        protected readonly List<string> _errors = new List<string>();
        public List<string> Errors => _errors;
        public bool Sucess { get; set; }
        

        public void Failed(string reason)
        {
            _errors.Add(reason);
            Sucess = false;
        }
    }
}
