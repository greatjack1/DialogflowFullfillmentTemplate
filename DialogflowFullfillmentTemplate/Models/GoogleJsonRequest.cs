using System;
using Newtonsoft.Json;
using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace DialogflowFullfillmentTemplate.GoogleModels
{
    
        public partial class GoogleJsonRequest
        {
            [J("originalRequest")] public OriginalRequest OriginalRequest { get; set; }
            [J("id")] public string Id { get; set; }
            [J("timestamp")] public DateTime Timestamp { get; set; }
            [J("lang")] public string Lang { get; set; }
            [J("result")] public Result Result { get; set; }
            [J("status")] public Status Status { get; set; }
            [J("sessionId")] public string SessionId { get; set; }
        }

        public partial class Status
        {
            [J("code")] public long Code { get; set; }
            [J("errorType")] public string ErrorType { get; set; }
            [J("webhookTimedOut")] public bool WebhookTimedOut { get; set; }
        }

        public partial class Result
        {
            [J("source")] public string Source { get; set; }
            [J("resolvedQuery")] public string ResolvedQuery { get; set; }
            [J("speech")] public string Speech { get; set; }
            [J("action")] public string Action { get; set; }
            [J("actionIncomplete")] public bool ActionIncomplete { get; set; }
            [J("parameters")] public ResultParameters Parameters { get; set; }
            [J("contexts")] public Context[] Contexts { get; set; }
            [J("metadata")] public Metadata Metadata { get; set; }
            [J("fulfillment")] public Fulfillment Fulfillment { get; set; }
            [J("score")] public long Score { get; set; }
        }

        public partial class ResultParameters
        {
            [J("zmanim_names")] public string ZmanimNames { get; set; }
        }

        public partial class Metadata
        {
            [J("matchedParameters")] public MatchedParameter[] MatchedParameters { get; set; }
            [J("intentName")] public string IntentName { get; set; }
            [J("intentId")] public string IntentId { get; set; }
            [J("webhookUsed")] public string WebhookUsed { get; set; }
            [J("webhookForSlotFillingUsed")] public string WebhookForSlotFillingUsed { get; set; }
            [J("nluResponseTime")] public long NluResponseTime { get; set; }
        }

        public partial class MatchedParameter
        {
            [J("required")] public bool Required { get; set; }
            [J("dataType")] public string DataType { get; set; }
            [J("name")] public string Name { get; set; }
            [J("value")] public string Value { get; set; }
            [J("prompts")] public Prompt[] Prompts { get; set; }
            [J("isList")] public bool IsList { get; set; }
        }

        public partial class Prompt
        {
            [J("lang")] public string Lang { get; set; }
            [J("value")] public string Value { get; set; }
        }

        public partial class Fulfillment
        {
            [J("speech")] public string Speech { get; set; }
            [J("messages")] public Message[] Messages { get; set; }
        }

        public partial class Message
        {
            [J("type")] public long Type { get; set; }
            [J("speech")] public string Speech { get; set; }
        }

        public partial class Context
        {
            [J("name")] public string Name { get; set; }
            [J("parameters")] public ContextParameters Parameters { get; set; }
            [J("lifespan")] public long Lifespan { get; set; }
        }

        public partial class ContextParameters
        {
            [J("zmanim_names")] public string ZmanimNames { get; set; }
            [J("zmanim_names.original")] public string ZmanimNamesOriginal { get; set; }
        }

        public partial class OriginalRequest
        {
            [J("source")] public string Source { get; set; }
            [J("version")] public string Version { get; set; }
            [J("data")] public Data Data { get; set; }
        }

        public partial class Data
        {
            [J("isInSandbox")] public bool IsInSandbox { get; set; }
            [J("surface")] public Urface Surface { get; set; }
            [J("inputs")] public Input[] Inputs { get; set; }
            [J("user")] public User User { get; set; }
            [J("conversation")] public Conversation Conversation { get; set; }
            [J("availableSurfaces")] public Urface[] AvailableSurfaces { get; set; }
        }

        public partial class User
        {
            [J("lastSeen")] public DateTime LastSeen { get; set; }
            [J("locale")] public string Locale { get; set; }
            [J("userId")] public string UserId { get; set; }
        }

        public partial class Input
        {
            [J("rawInputs")] public RawInput[] RawInputs { get; set; }
            [J("arguments")] public Argument[] Arguments { get; set; }
            [J("intent")] public string Intent { get; set; }
        }

        public partial class RawInput
        {
            [J("query")] public string Query { get; set; }
            [J("inputType")] public string InputType { get; set; }
        }

        public partial class Argument
        {
            [J("rawText")] public string RawText { get; set; }
            [J("textValue")] public string TextValue { get; set; }
            [J("name")] public string Name { get; set; }
        }

        public partial class Conversation
        {
            [J("conversationId")] public string ConversationId { get; set; }
            [J("type")] public string Type { get; set; }
            [J("conversationToken")] public string ConversationToken { get; set; }
        }

        public partial class Urface
        {
            [J("capabilities")] public Capability[] Capabilities { get; set; }
        }

        public partial class Capability
        {
            [J("name")] public string Name { get; set; }
        }

}
