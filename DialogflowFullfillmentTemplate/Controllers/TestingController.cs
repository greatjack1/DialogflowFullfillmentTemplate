using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DialogflowFullfillmentTemplate.ExtensionMethods;
using DialogflowFullfillmentTemplate.ResponseModel;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<JsonResult> Post([FromBody]string value)
        {
            return Json(value);
        }
    }
}
