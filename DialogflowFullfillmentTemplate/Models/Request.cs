using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialogflowFullfillmentTemplate.Models {

    public class JsonRequest
    {
        public string Lang { get; set; }
        public Status Status { get; set; }
        public DateTime Timestamp { get; set; }
        public string SessionId { get; set; }
        public Result Result { get; set; }
        public string Id { get; set; }
        public OriginalRequest OriginalRequest { get; set; }
    }

    public class Status
    {
        public string ErrorType { get; set; }
        public long Code { get; set; }
    }

    public class Result
    {
        public Parameters Parameters { get; set; }
        public object[] Contexts { get; set; }
        public string ResolvedQuery { get; set; }
        public string Source { get; set; }
        public long Score { get; set; }
        public string Speech { get; set; }
        public Fulfillment Fulfillment { get; set; }
        public bool ActionIncomplete { get; set; }
        public string Action { get; set; }
        public Metadata Metadata { get; set; }
    }

    public class Parameters
    {
        public string zmanim_names { get; set; }
    }

    public class Metadata
    {
        public string IntentId { get; set; }
        public string WebhookForSlotFillingUsed { get; set; }
        public string IntentName { get; set; }
        public string WebhookUsed { get; set; }
    }

    public class Fulfillment
    {
        public Message[] Messages { get; set; }
        public string Speech { get; set; }
    }

    public class Message
    {
        public string Speech { get; set; }
        public long Type { get; set; }
    }

    public class OriginalRequest
    {
        public string Source { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public Input[] Inputs { get; set; }
        public User User { get; set; }
        public Conversation Conversation { get; set; }
    }

    public class User
    {
        public string UserId { get; set; }
    }

    public class Input
    {
        public RawInput[] Raw_Inputs { get; set; }
        public string Intent { get; set; }
        public Argument[] Arguments { get; set; }
    }

    public class RawInput
    {
        public string Query { get; set; }
        public long InputType { get; set; }
    }

    public class Argument
    {
        public string Text_Value { get; set; }
        public string Raw_Text { get; set; }
        public string Name { get; set; }
    }

    public class Conversation
    {
        public string Conversation_Id { get; set; }
        public long Type { get; set; }
        public string Conversation_Token { get; set; }
    }
}
