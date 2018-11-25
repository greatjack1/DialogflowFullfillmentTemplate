using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace DialogflowFullfillmentTemplate.Models2
{

    public partial class JsonRequestV2
    {
        [J("responseId")] public string ResponseId { get; set; }
        [J("queryResult")] public QueryResult QueryResult { get; set; }
        [J("session")] public string Session { get; set; }
        [J("originalDetectIntentRequest")] public JObject OriginalDetectIntentRequest { get; set; }

    }

    public partial class QueryResult
    {
        [J("queryText")] public string QueryText { get; set; }
        [J("parameters")] public YeslyParameters Parameters { get; set; }
        [J("allRequiredParamsPresent")] public bool AllRequiredParamsPresent { get; set; }
        [J("fulfillmentText")] public string FulfillmentText { get; set; }
        [J("fulfillmentMessages")] public JObject[] FulfillmentMessages { get; set; }
        [J("outputContexts", NullValueHandling = NullValueHandling.Ignore)] public Context[] OutputContexts { get; set; }
        [J("intent")] public Intent Intent { get; set; }
        [J("intentDetectionConfidence")] public float IntentDetectionConfidence { get; set; }
        [J("diagnosticInfo", NullValueHandling = NullValueHandling.Ignore)] public JObject DiagnosticInfo { get; set; }
        [J("languageCode")] public string LanguageCode { get; set; }
    }

    public partial class Intent
    {
        [J("name")] public string Name { get; set; }
        [J("displayName")] public string DisplayName { get; set; }
    }

    public partial class Context
    {
        [J("name")] public string Name { get; set; }
        [J("lifespanCount")] public int LifespanCount { get; set; }
        [J("parameters")] public JObject Parameters { get; set; }
    }

    public partial class YeslyParameters
    {
        [J("room")] public string Room { get; set; }
        [J("device")] public string Device { get; set; }
    }
}
