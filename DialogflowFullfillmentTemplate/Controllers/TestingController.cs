using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DialogflowFullfillmentTemplate.Models;
using DialogflowFullfillmentTemplate.Models2;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DialogflowFullfillmentTemplate.Controllers
{
    /// <summary>
    /// Testing controller. This controller is used to test new methods while not interfereing with the production controller
    /// </summary>
    [Route("dialogflow/[controller]")]
    public class TestingController : Controller
    {
        // POST dialogflow/testing
        /// <summary>
        /// This method receives the post request from dialog flow and binds the json to the value object.
        /// You then use the JsonResponse class to build a reponse to return for dialog flow.
        /// </summary>
        /// <returns>The Json of the JsonResponse object for dialog to use</returns>
        /// <param name="value">Value.</param>
        [HttpPost]
        public JsonResult Post([FromBody]JsonRequestV2 value)
        {
            JsonResponseV2 response = new JsonResponseV2();
            response.FulfillmentText = "Hi, here is a response from the server";
            response.Source = "sample fullfillment api";
            return Json(response);
        }
    }
}

