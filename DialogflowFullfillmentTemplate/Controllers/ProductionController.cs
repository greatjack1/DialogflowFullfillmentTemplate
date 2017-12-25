using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using DialogflowFullfillmentTemplate.Models;

namespace DialogflowFullfillmentTemplate.Controllers
{
    [Route("dialogflow/[controller]")]
    public class ProductionController : Controller
    {
        // POST dialogflow/production
        /// <summary>
        /// This method receives the post request from dialog flow and binds the json to the value object.
        /// You then use the JsonResponse class to build a reponse to return for dialog flow.
        /// </summary>
        /// <returns>The Json of the JsonResponse object for dialog to use</returns>
        /// <param name="value">Value.</param>
        [HttpPost]
        public JsonResult Post([FromBody]JsonRequest value)
        {
            JsonResponse response = new JsonResponse();
            response.Speech = "Here is some sample speech returned from the fullfillment service";
            response.DisplayText = "Here is some sample display text returned from the fullfillment service";
            response.Source = "sample fullfillment api";
            return Json(response);
        }
      
    }
}
