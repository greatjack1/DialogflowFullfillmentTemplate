
using Newtonsoft.Json;
namespace DialogflowFullfillmentTemplate.Models
{

   /// <summary>
   /// Response json. This is a poco for the json response that dialog flow expects
   /// </summary>
        public class JsonResponse
        {
        /// <summary>
        /// Gets or sets the speech that dialog flow will read to the user
        /// </summary>
        /// <value>The speech.</value>
            [JsonProperty("speech")]
            public string Speech { get; set; }
        /// <summary>
        /// Gets or sets the display text that dialog flow will show to the user
        /// </summary>
        /// <value>The display text.</value>
            [JsonProperty("displayText")]
            public string DisplayText { get; set; }
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
            [JsonProperty("data")]
            public Data Data { get; set; }
        /// <summary>
        /// Gets or sets the context out that dialog flow will use
        /// </summary>
        /// <value>The context out.</value>
            [JsonProperty("contextOut")]
            public object[] ContextOut { get; set; }
        /// <summary>
        /// Gets or sets the source of the response
        /// </summary>
        /// <value>The source.</value>
            [JsonProperty("source")]
            public string Source { get; set; }
        }

    }

    

  
   

