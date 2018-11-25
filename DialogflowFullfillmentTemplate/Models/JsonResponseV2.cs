using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace DialogflowFullfillmentTemplate.Models2
{
    public class JsonResponseV2
    {
        [J("fulfillmentText")] public string FulfillmentText { get; set; }
        [J("fulfillmentMessages")] public JObject[] FulfillmentMessages { get; set; }
        [J("source")] public string Source { get; set; }
        [J("payload")] public JObject Payload { get; set; }
        [J("outputContexts")] public Context[] OutputContexts { get; set; }
        [J("followupEventInput")] public JObject FollowupEventInput { get; set; }
    }
}

    

  
   

