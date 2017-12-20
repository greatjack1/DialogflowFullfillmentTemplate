using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DialogflowFullfillmentTemplate.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
   
        public class ResponseJson
        {
            [JsonProperty("speech")]
            public string Speech { get; set; }

            [JsonProperty("displayText")]
            public string DisplayText { get; set; }

            [JsonProperty("data")]
            public Data Data { get; set; }

            [JsonProperty("contextOut")]
            public object[] ContextOut { get; set; }

            [JsonProperty("source")]
            public string Source { get; set; }
        }

    }

    

  
   

