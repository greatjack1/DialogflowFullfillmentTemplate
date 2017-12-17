using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DialogflowFullfillmentTemplate.Models;
using DialogflowFullfillmentTemplate.ResponseModel;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using Zmanim.TimeZone;
using Zmanim.Utilities;
using Zmanim;
using DialogflowFullfillmentTemplate.ExtensionMethods;
namespace DialogflowFullfillmentTemplate.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
     [HttpGet]
        public String Get(){
           return Request.Headers["x-forwarded-for"].ToString();
        }
        // POST api/values
        [HttpPost]
        public async Task<JsonResult> Post([FromBody]string value)
        {
         //Create request
            WebRequest request = WebRequest.Create("http://freegeoip.net/json/" + Request.Headers["x-forwarded-for"].ToString());
            request.Method = "GET";
            //Get the response
            WebResponse wr = await request.GetResponseAsync();
            Stream receiveStream = wr.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream);
            string content = reader.ReadToEnd();
            JObject obj = JObject.Parse(content);

            double lat = (Double)obj["latitude"];
            double lon = (Double)obj["longitude"];
            String timeZone = (String)obj["time_zone"];
            //generate the zmanim
            ITimeZone zmanimTimeZone = new WindowsTimeZone(timeZone);
            GeoLocation location = new GeoLocation("Random", lat, lon,
            0, zmanimTimeZone);
            ComplexZmanimCalendar czc = new ComplexZmanimCalendar(location);
            String Speech = "Alos is at " + czc.GetAlosHashachar().formatDate()+". Sunrise is at " + czc.GetSunrise().formatDate()
              + ". Sof Zeman Krias Shema is at " + czc.GetSofZmanShmaMGA().formatDate() + " According to the Magen Avraham, and at "
                + czc.GetSofZmanShmaGRA().formatDate() + " according to the Gra." + " Sof zeman Teffilah is at "
                                                 + czc.GetSofZmanTfilaGRA().formatDate() + " According to the gra and at "
                                                 + czc.GetSofZmanShmaMGA().formatDate() + " according to the Magen Avraham. "
                                                 + "Chatzos is at " + czc.GetChatzos().formatDate() + ". Mincha Gedolah is at " + czc.GetMinchaGedola().formatDate()
                                                 + ". Mincha Ketana is at " + czc.GetMinchaKetana().formatDate() + ". Shkia is at " + czc.GetSunset().formatDate()
                                                 + ". Tzais Hakochavim is at " + czc.GetTzais().formatDate();

            String display = 
         "Alos-" + czc.GetAlosHashachar().formatDate() + "\nSunrise-" + czc.GetSunrise().formatDate()
              + "\nSof Zeman Krias Shema MGA-" + czc.GetSofZmanShmaMGA().formatDate() + "\n Sof Zman Krias Shema Gra-"
                + czc.GetSofZmanShmaGRA().formatDate() + "\nSof zeman Teffilah Gra-"
                                                 + czc.GetSofZmanTfilaGRA().formatDate() + "\n Sof Zman Tefilah Mga-"
                                                 + czc.GetSofZmanShmaMGA().formatDate()
                                                 + "\nChatzos-" + czc.GetChatzos().formatDate() + "\nMincha Gedolah-" + czc.GetMinchaGedola().formatDate()
                                                 + "\nMincha Ketana-" + czc.GetMinchaKetana().formatDate() + "\nShkia-" + czc.GetSunset().formatDate()
                                                 + "\nTzais Hakochavim-" + czc.GetTzais().formatDate();

            JsonResponse response = new JsonResponse();
            response.DisplayText = Speech;
            response.Source = "Zmanim.net";
            response.Speech = Speech;
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
