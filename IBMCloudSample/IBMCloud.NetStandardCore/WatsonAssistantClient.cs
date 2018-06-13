using CloudServices.Core;
using IBM.WatsonDeveloperCloud.Assistant.v1;
using IBM.WatsonDeveloperCloud.Assistant.v1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IBMCloud.NetStandardCore
{
    public class WatsonAssistantClient : ICloudService
    {
        //Watson Client(AssistantService)のインスタンス化に必要な情報
        static readonly string _username = Secrets.UserName;
        static readonly string _password = Secrets.Password;
        static readonly string _workspaceId = Secrets.WorkspaceId;
        static readonly string _versionDate = Secrets.VersionDate;

        AssistantService _assistant = new AssistantService(_username, _password, _versionDate);

        public WatsonAssistantClient()
        {
            
        }

        // Watson SDKを使用してレスポンスを取得
        public async Task<string> GetResponseAsync(string input)
        {
            // MessageRequestを作成
            var messageRequest = new MessageRequest()
            {
                Input = new InputData()
                {
                    Text = input,
                }
            };

            // Assistantのインスタンスにメッセージを送信
            try
            {
                // Assistant SDKは同期メソッドしかないのでTask化
                var messegeResponse = await Task.Run(() => _assistant.Message(_workspaceId, messageRequest));
                // 返信のJSONは`MessageResponse.ResponseJson`で取得できるので、オブジェクト化する
                var res = JsonConvert.DeserializeObject<WatsonAssistantModel>(messegeResponse.ResponseJson);

                return res.Output.Text[0];
            }
            catch (Exception ex)
            {
                return $"エラーが発生しました。\n{ex.Message}";
            }
        }
    }
}
