namespace CrudAPI.Services.Abstract
{
    public interface IInputValidator
    {
        List<string> Errors { get; }
        bool Sucess { get; set; }
        void Failed(string message);
    }
}
