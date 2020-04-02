using lolpetprojectCSAPI.Interfaces;

namespace lolpetprojectCSAPI.Services
{
    public class ApiKeyProvider : IApiKeyProvider
    {
        private const string ApiKey = "RGAPI-0fb9e852-a1cf-40bd-9dc4-9dc5482369ab";

        public string GetApiKey()
        {
            return ApiKey;
        }
    }
}