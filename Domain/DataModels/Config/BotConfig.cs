using Newtonsoft.Json;

namespace Domain.DataModels.Config
{
    public class BotConfig
    {
        [JsonProperty("token")]
        public string Token { get; set; } = "";

        [JsonProperty("prefixes")]
        public List<string> Prefixes { get; set; } = new List<string>();
    }
}
