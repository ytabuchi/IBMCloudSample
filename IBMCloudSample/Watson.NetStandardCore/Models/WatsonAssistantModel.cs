using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Watson.NetStandardCore.Models
{
    public partial class WatsonAssistantModel
    {
        [JsonProperty("intents")]
        public Intent[] Intents { get; set; }

        [JsonProperty("entities")]
        public object[] Entities { get; set; }

        [JsonProperty("input")]
        public Input Input { get; set; }

        [JsonProperty("output")]
        public Output Output { get; set; }

        [JsonProperty("context")]
        public Context Context { get; set; }
    }

    public partial class Context
    {
        [JsonProperty("conversation_id")]
        public string ConversationId { get; set; }

        [JsonProperty("system")]
        public SystemClass System { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public partial class SystemClass
    {
        [JsonProperty("dialog_stack")]
        public DialogStack[] DialogStack { get; set; }

        [JsonProperty("dialog_turn_counter")]
        public long DialogTurnCounter { get; set; }

        [JsonProperty("dialog_request_counter")]
        public long DialogRequestCounter { get; set; }

        [JsonProperty("_node_output_map")]
        public NodeOutputMap NodeOutputMap { get; set; }

        [JsonProperty("branch_exited")]
        public bool BranchExited { get; set; }

        [JsonProperty("branch_exited_reason")]
        public string BranchExitedReason { get; set; }
    }

    public partial class DialogStack
    {
        [JsonProperty("dialog_node")]
        public string DialogNode { get; set; }
    }

    public partial class NodeOutputMap
    {
        [JsonProperty("node_1_1528199282186")]
        public long[] Node1_1528199282186 { get; set; }
    }

    public partial class Input
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public partial class Intent
    {
        [JsonProperty("intent")]
        public string IntentIntent { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }

    public partial class Output
    {
        [JsonProperty("text")]
        public string[] Text { get; set; }

        [JsonProperty("nodes_visited")]
        public string[] NodesVisited { get; set; }

        [JsonProperty("log_messages")]
        public object[] LogMessages { get; set; }
    }

    public partial class WatsonAssistantModel
    {
        public static WatsonAssistantModel FromJson(string json) => JsonConvert.DeserializeObject<WatsonAssistantModel>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this WatsonAssistantModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
