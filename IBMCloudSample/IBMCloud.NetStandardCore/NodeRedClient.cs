using CloudServices.Core;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IBMCloud.NetStandardCore
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
                    // Node-REDはGETのエンドポイントなので普通にHttpClientでアクセスします
                    var response = await client.GetAsync($"/conversation?speech={input}");
                    response.EnsureSuccessStatusCode();

                    // 今回はStringを返すようにNode-REDを作ったので、`Content.ReadAsStringAsync`で返信のStringを取得できます。
                    var resText = await response.Content.ReadAsStringAsync();
                    return resText;
                }
                catch (Exception ex)
                {
                    return $"エラーが発生しました。\n{ex.Message}";
                }
            }
        }
    }
}
