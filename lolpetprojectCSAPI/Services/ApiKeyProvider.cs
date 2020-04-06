using lolpetprojectCSAPI.Interfaces;

namespace lolpetprojectCSAPI.Services
{
    public class ApiKeyProvider : IApiKeyProvider
    {
        private const string ApiKey = "RGAPI-b29d6c1b-f0ad-48a6-ab3a-ce6653af9aaf";
        public string GetApiKey()
        {
            return ApiKey;
        }
    }
}