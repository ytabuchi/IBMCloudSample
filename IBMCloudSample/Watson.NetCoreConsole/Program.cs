using IBM.WatsonDeveloperCloud.Assistant.v1;
using IBM.WatsonDeveloperCloud.Assistant.v1.Model;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Watson.NetCoreConsole
{
    class Program
    {
        static readonly string _username = Secrets.UserName;
        static readonly string _password = Secrets.Password;
        static readonly string _workspaceId = Secrets.WorkspaceId;
        static readonly string _versionDate = Secrets.VersionDate;


        static void Main(string[] args)
        {
            // Assistant Serviceのインスタンス作成
            var _assistant = new AssistantService();
            // Credentialをセット
            _assistant.SetCredential(_username, _password);
            // VersionDateをセット
            _assistant.VersionDate = _versionDate;

            // MessageRequestを作成
            var messageRequest0 = new MessageRequest()
            {
                Input = new InputData()
                {
                    Text = "こんにちは",
                }
            };

            // Assistantのインスタンスにメッセージを送信
            var result0 = _assistant.Message(_workspaceId, messageRequest0);
            var res0 = JsonConvert.DeserializeObject<AssistantResponseJson>(result0.ResponseJson);
            System.Console.WriteLine(res0.Outputs.Texts[0]);

            //  reference the message context to continue a conversation
            var messageRequest1 = new MessageRequest()
            {
                Input = new InputData()
                {
                    Text = "またね",
                }
            };

            //  Send another message including message context.
            var result1 = _assistant.Message(_workspaceId, messageRequest1);
            var res1 = JsonConvert.DeserializeObject<AssistantResponseJson>(result1.ResponseJson);
            System.Console.WriteLine(res1.Outputs.Texts[0]);

            #region Net Standard Core
            //var client = new Watson.NetStandardCore.WatsonAssistantClient();
            //var res1 = client.GetResponse("こんにちは");
            //var res2 = client.GetResponse("またね");

            //Console.WriteLine(res1);
            //Console.WriteLine(res2);
            #endregion

            Console.ReadKey();
        }
    }

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
