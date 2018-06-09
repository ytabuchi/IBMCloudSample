using System;
using Newtonsoft.Json;
namespace Azure.NetStandardCore
{
    public class CognitiveResult
    {
        [JsonProperty("twitterName")]
        public string TwitterName { get; set; }
        [JsonProperty("keyphreases")]
        public string[] Keyphreases { get; set; }
        [JsonProperty("sentiments")]
        public double[] Sentiments { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
