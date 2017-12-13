using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialogflowFullfillmentTemplate.Models
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class Welcome
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("result")]
        public Result Result { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("originalRequest")]
        public OriginalRequest OriginalRequest { get; set; }
    }

    public partial class Status
    {
        [JsonProperty("errorType")]
        public string ErrorType { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("parameters")]
        public Parameters Parameters { get; set; }

        [JsonProperty("contexts")]
        public object[] Contexts { get; set; }

        [JsonProperty("resolvedQuery")]
        public string ResolvedQuery { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("speech")]
        public string Speech { get; set; }

        [JsonProperty("fulfillment")]
        public Fulfillment Fulfillment { get; set; }

        [JsonProperty("actionIncomplete")]
        public bool ActionIncomplete { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
    }

    public partial class Parameters
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Metadata
    {
        [JsonProperty("intentId")]
        public string IntentId { get; set; }

        [JsonProperty("webhookForSlotFillingUsed")]
        public string WebhookForSlotFillingUsed { get; set; }

        [JsonProperty("intentName")]
        public string IntentName { get; set; }

        [JsonProperty("webhookUsed")]
        public string WebhookUsed { get; set; }
    }

    public partial class Fulfillment
    {
        [JsonProperty("messages")]
        public Message[] Messages { get; set; }

        [JsonProperty("speech")]
        public string Speech { get; set; }
    }

    public partial class Message
    {
        [JsonProperty("speech")]
        public string Speech { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }
    }

    public partial class OriginalRequest
    {
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("inputs")]
        public Input[] Inputs { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("conversation")]
        public Conversation Conversation { get; set; }
    }

    public partial class User
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }

    public partial class Input
    {
        [JsonProperty("raw_inputs")]
        public RawInput[] RawInputs { get; set; }

        [JsonProperty("intent")]
        public string Intent { get; set; }

        [JsonProperty("arguments")]
        public Argument[] Arguments { get; set; }
    }

    public partial class RawInput
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("input_type")]
        public long InputType { get; set; }
    }

    public partial class Argument
    {
        [JsonProperty("text_value")]
        public string TextValue { get; set; }

        [JsonProperty("raw_text")]
        public string RawText { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Conversation
    {
        [JsonProperty("conversation_id")]
        public string ConversationId { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("conversation_token")]
        public string ConversationToken { get; set; }
    }

    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
