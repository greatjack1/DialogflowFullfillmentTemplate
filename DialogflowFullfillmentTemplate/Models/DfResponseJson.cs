using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DialogflowFullfillmentTemplate.ResponseModel
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
   
        public partial class JsonResponse
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

        public partial class Data
        {
        }

        public partial class JsonResponse
        {
            public static JsonResponse FromJson(string json) => JsonConvert.DeserializeObject<JsonResponse>(json, Converter.Settings);
        }

        public static class Serialize
        {
            public static string ToJson(this JsonResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
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

    

  
   

