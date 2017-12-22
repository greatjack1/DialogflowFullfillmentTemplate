using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DialogflowFullfillmentTemplate.ExtensionMethods;
using DialogflowFullfillmentTemplate.GoogleModels;
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
        public async Task<JsonResult> Post([FromBody]GoogleJsonRequest value)
        {

            //Create request
            try
            {
                HttpContext.Request.Body.Position = 0;
                StreamReader read = new StreamReader(HttpContext.Request.Body,true);
                //log the inconming request body just to be able to view them on heroku
                Console.WriteLine( await read.ReadToEndAsync());
                WebRequest request = WebRequest.Create("http://freegeoip.net/json/" + Request.Headers["x-forwarded-for"].ToString());
                request.Method = "GET";
                //Get the response
                WebResponse wr = await request.GetResponseAsync();
                Stream receiveStream = wr.GetResponseStream();
                StreamReader reader = new StreamReader(receiveStream);
                string content = reader.ReadToEnd();
                JObject obj = JObject.Parse(content);
                String city = (String)obj["city"];
                double lat = (Double)obj["latitude"];
                double lon = (Double)obj["longitude"];
                String timeZone = (String)obj["time_zone"];
                //generate the zmanim
                ITimeZone zmanimTimeZone = new WindowsTimeZone(timeZone);
                GeoLocation location = new GeoLocation("Random", lat, lon,
                0, zmanimTimeZone);
                ComplexZmanimCalendar czc = new ComplexZmanimCalendar(location);
                //if zmanim_names is null then return the full zmanim, otherwise return that specific zman
                if (value is null ||value.Result is null || value.Result.Parameters is null || value.Result.Parameters.ZmanimNames is null)
                {
                    String Speech = "Here are your jewish times for " + city + ". Dawn is at " + czc.GetAlosHashachar().formatDate() + ". Sunrise is at " + czc.GetSunrise().formatDate()
                      + ". The Latest Shema is at " + czc.GetSofZmanShmaMGA().formatDate() + " According to the magein avraham, and at "
                        + czc.GetSofZmanShmaGRA().formatDate() + " according to the grah." + " The latest time for morning prayers is at "
                                                         + czc.GetSofZmanTfilaGRA().formatDate() + " According to the grah and at "
                                                         + czc.GetSofZmanShmaMGA().formatDate() + " according to the magein avraham. "
                                                         + "Midday is at " + czc.GetChatzos().formatDate() + ". The earliest time for afternoon services is at " + czc.GetMinchaGedola().formatDate()
                                                         + " Sunset is at" + czc.GetSunset().formatDate()
                                                         + ". Nightfall is at " + czc.GetTzais().formatDate();

                    String display =
                 "Jewish times for " + city + "\nDawn-" + czc.GetAlosHashachar().formatDate() + "\nSunrise-" + czc.GetSunrise().formatDate()
                      + "\n Latest Shema MGA-" + czc.GetSofZmanShmaMGA().formatDate() + "\n Latest Shema Gra-"
                        + czc.GetSofZmanShmaGRA().formatDate() + "\nLatest morning prayers Gra-"
                                                         + czc.GetSofZmanTfilaGRA().formatDate() + "\nLatest morning prayers Mga-"
                                                         + czc.GetSofZmanShmaMGA().formatDate()
                                                         + "\nMidday-" + czc.GetChatzos().formatDate() + "\nEarliest afternoon prayers-" + czc.GetMinchaGedola().formatDate()
                                                         + "\nSunset-" + czc.GetSunset().formatDate()
                                                         + "\nNightfall-" + czc.GetTzais().formatDate();

                    ResponseJson response = new ResponseJson();
                    response.DisplayText = display;
                    response.Source = "Zmanim.net";
                    response.Speech = Speech;
                    Console.WriteLine("Processed post method");
                    return Json(response);
                }
                else
                {
                    String speech = "";
                    String display = "";
                    switch (value.Result.Parameters.ZmanimNames)
                    {
                        case "shkia":
                            speech = "Sunset is at " + czc.GetSunset().formatDate();
                            display = speech;
                            break;
                        case "sofeshema":
                            speech = "Latest shema is at " + czc.GetSofZmanShmaGRA().formatDate() + " according to the grah, and at " + czc.GetSofZmanShmaMGA().formatDate() + " according to the magein avraham.";
                            display = "Latest Shema Gra: " + czc.GetSofZmanShmaGRA().formatDate() + ". Latest Shema Magein Avraham: " + czc.GetSofZmanShmaMGA().formatDate();
                            break;
                        case "sofeteffilah":
                            speech = "The latest time for morning prayers is at " + czc.GetSofZmanTfilaGRA().formatDate() + " according to the grah, and at " + czc.GetSofZmanTfilaMGA().formatDate() + " according to the magein avraham.";
                            display = "Latest morning prayers Gra: " + czc.GetSofZmanTfilaGRA().formatDate() + ". Latest morning prayers Magein Avraham: " + czc.GetSofZmanTfilaMGA().formatDate();
                            break;
                        case "chatzos":
                            speech = "Midday is at " + czc.GetChatzos().formatDate();
                            display = speech;
                            break;
                        case "minchagedolah":
                            speech = "The earliest time for afternoon prayer is at " + czc.GetMinchaGedola().formatDate();
                            display = speech;
                            break;
                        case "minchaketana":
                            speech = "Mincha Ketana is at " + czc.GetMinchaKetana().formatDate();
                            display = speech;
                            break;
                        case "neitz":
                            speech = "Sunrise is at " + czc.GetSunrise().formatDate();
                            display = speech;
                            break;
                        case "alos":
                            speech = "Dawn is at " + czc.GetAlosHashachar().formatDate();
                            display = speech;
                            break;
                        case "tzaishakochavim":
                            speech = "Nightfall is at " + czc.GetTzais().formatDate();
                            display = speech;
                            break;
                        default:
                            speech = "The zman you requested could not be calculated";
                            display = speech;
                            break;

                    }
                    ResponseJson response = new ResponseJson();
                    response.DisplayText = display + " in " + city;
                    response.Source = "Zmanim.net";
                    response.Speech = speech + " in " + city;
                    Console.WriteLine("Processed post method");
                    return Json(response);
                }
            }
            catch (Exception ex)
            {
                //write the error message to console
                Console.WriteLine(ex.ToString());
                ResponseJson Errresponse = new ResponseJson();
                Errresponse.DisplayText = "There was a error getting jewish times for your location, please try again later";
                Errresponse.Source = "Zmanimaog.herokuapp.com";
                Errresponse.Speech = "There was a error getting jewish times for your location, please try again later";
                return Json(Errresponse);
            }
        }

    }
}

