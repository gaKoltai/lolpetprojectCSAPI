using lolpetprojectCSAPI.Interfaces;

namespace lolpetprojectCSAPI.Services
{
    public class ApiRouter : IApiRouter
    {
        public string GetRegionLink(string region)
        {
            return region switch
            {
                "EUW" => "euw1",
                "EUNE" => "eun1",
                "NA" => "na1",
                "KR" => "kr",
                "OCE" => "oc1",
                "BR" => "br1",
                "TR" => "tr1",
                "RU" => "ru",
                "JP" => "jp1",
                _ => "euw1"
            };
        }
    }
}