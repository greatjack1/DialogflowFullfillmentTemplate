using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DialogflowFullfillmentTemplate.Models;
using DialogflowFullfillmentTemplate.ResponseModel;

namespace DialogflowFullfillmentTemplate.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
     

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]string value)
        {
            JsonResponse response = new JsonResponse();
            response.DisplayText = "Sunset tonight is at 2:48pm";
            response.Source = "Zmanim.net";
            response.Speech = "Sunset tonight is at 3:56 pm";
            Console.WriteLine("Got a request from postman");
            return Json(response);
        }
       
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
