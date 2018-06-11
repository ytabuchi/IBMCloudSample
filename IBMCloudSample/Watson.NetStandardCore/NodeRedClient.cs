using CloudServices.Core;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Watson.NetStandardCore
{
    public class NodeRedClient : ICloudService
    {
        public async Task<string> GetResponseAsync(string input)
        {
            var _nodeRedUrl = Secrets.NodeRedUrl;

            using (var client = new HttpClient())
            {
                client.BaseAddress = _nodeRedUrl;

                try
                {
                    var response = await client.GetAsync($"/conversation?speech={input}");
                    response.EnsureSuccessStatusCode();

                    var resText = await response.Content.ReadAsStringAsync();
                    return resText;
                }
                catch (Exception ex)
                {
                    return $"some error\n{ex.Message}";
                }
            }
        }
    }
}
