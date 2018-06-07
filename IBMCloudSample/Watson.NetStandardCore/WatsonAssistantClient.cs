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
    public class WatsonAssistantClient
    {
        static readonly string _username = Secrets.UserName;
        static readonly string _password = Secrets.Password;
        static readonly string _workspaceId = Secrets.WorkspaceId;
        static readonly string _versionDate = Secrets.VersionDate;

        AssistantService _assistant = new AssistantService(_username, _password, _versionDate);

        public WatsonAssistantClient()
        {
            
        }

        public string GetResponse(string input)
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
                var messegeResponse = _assistant.Message(_workspaceId, messageRequest);
                var res = JsonConvert.DeserializeObject<AssistantResponseJson>(messegeResponse.ResponseJson);

                return res.Outputs.Texts[0];
            }
            catch (Exception)
            {
                return "some error";
            }
        }
    }

    // Watson からの
    class AssistantResponseJson
    {
        public class Intent
        {
            public string intent { get; set; }
            public int confidence { get; set; }
        }

        public class Input
        {
            [JsonProperty(PropertyName = "text")]
            public string Text { get; set; }
        }

        public class Output
        {
            [JsonProperty(PropertyName = "text")]
            public List<string> Texts { get; set; }
            [JsonProperty(PropertyName = "nodes_visited")]
            public List<string> VisitedNodes { get; set; }
            [JsonProperty(PropertyName = "log_messages")]
            public List<object> LogMessages { get; set; }
        }

        public class DialogStack
        {
            public string dialog_node { get; set; }
        }

        public class NodeOutputMap
        {
            public List<int> node_1_1524556849654 { get; set; }
        }

        public class System
        {
            public List<DialogStack> dialog_stack { get; set; }
            public int dialog_turn_counter { get; set; }
            public int dialog_request_counter { get; set; }
            public NodeOutputMap _node_output_map { get; set; }
            public bool branch_exited { get; set; }
            public string branch_exited_reason { get; set; }
        }

        public class Context
        {
            public string conversation_id { get; set; }
            public System system { get; set; }
        }

        public List<Intent> intents { get; set; }
        public List<object> entities { get; set; }
        [JsonProperty(PropertyName = "input")]
        public Input Inputs { get; set; }
        [JsonProperty(PropertyName = "output")]
        public Output Outputs { get; set; }
        public Context context { get; set; }
        public bool alternate_intents { get; set; }
    }
}
