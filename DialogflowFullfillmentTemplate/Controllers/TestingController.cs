﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DialogflowFullfillmentTemplate.Models;
using Microsoft.AspNetCore.Mvc;

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

