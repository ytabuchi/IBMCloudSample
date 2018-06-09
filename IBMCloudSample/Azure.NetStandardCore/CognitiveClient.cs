using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CloudServices.Core;
using Newtonsoft.Json;

namespace Azure.NetStandardCore
{
    public class CognitiveClient : ICloudService
    {
        public async Task<string> GetResponseAsync(string input)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(
                    JsonConvert.SerializeObject(new { text = input }),
                    Encoding.UTF8,
                    "application/json");
                var response = await client.PostAsync(Secrets.Endpoint, content);
                if (!response.IsSuccessStatusCode)
                {
                    return "エラーが発生しました。";
                }

                var result = JsonConvert.DeserializeObject<CognitiveResult>(await response.Content.ReadAsStringAsync());
                if (!string.IsNullOrEmpty(result.Message))
                {
                    return result.Message;
                }

                var sentimentAverage = (int)(result.Sentiments.Any() ?
                                             result.Sentiments.Average() * 100 :
                                             0);
                return $@"{result.TwitterName}さんは{sentimentAverage}%ポジティブです☺

直近 {result.Sentiments.Length} 件のツイートのキーワードは 
{string.Join(", ", result.Keyphreases)}
です。";
            }
        }
    }
}
