using lolpetprojectCSAPI.Interfaces;

namespace lolpetprojectCSAPI.Services
{
    public class ApiKeyProvider : IApiKeyProvider
    {
        private const string ApiKey = "";
        public string GetApiKey()
        {
            return ApiKey;
        }
    }
}