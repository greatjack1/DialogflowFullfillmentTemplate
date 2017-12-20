using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DialogflowFullfillmentTemplate.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Zmanim;
using Zmanim.TimeZone;
using Zmanim.Utilities;


namespace DialogflowFullfillmentTemplate.Controllers
{
    /// <summary>
    /// Testing controller. This controller is used to test new methods while not interfereing with the production controller
    /// </summary>
    [Route("api/[controller]")]
    public class TestingController : Controller
    {
        // POST api/testing
        [HttpPost]
        public JsonResult Post([FromBody]JsonRequest value)
      {
            ResponseJson response = new ResponseJson();
            response.Speech = value.Result.Parameters.zmanim_names;
            response.DisplayText = JsonConvert.SerializeObject(value);
            response.Source = "random";
            return Json(response);
        }
    }
}
