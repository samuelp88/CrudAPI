using CrudAPI.Settings.Abstract;

namespace CrudAPI.Settings
{
    public class Settings : ISettings
    {
        public readonly string Secret = "fedaf7d8863b48e197b9287d492b708e";

        public string GetSecret()
        {
            return Secret;
        }
    }
}
