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

namespace Watson.NetStandardCore
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
                var messegeResponse = await Task.Run(() => _assistant.Message(_workspaceId, messageRequest));
                var res = JsonConvert.DeserializeObject<Models.WatsonAssistantModel>(messegeResponse.ResponseJson);

                return res.Output.Text[0];
            }
            catch (Exception)
            {
                return "some error";
            }
        }
    }
}
