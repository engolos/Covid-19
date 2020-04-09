using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Covid_19.Models;
using RestSharp;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Covid_19.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "apikey {key}");
            request.AddHeader("content-type", "application/json");

            var tclient = new RestClient("https://api.collectapi.com/corona/totalData");
            IRestResponse tresponse = tclient.Execute(request);

            var client = new RestClient("https://api.collectapi.com/corona/countriesData");
            IRestResponse response = client.Execute(request);

            var totalObject = JObject.Parse(tresponse.Content);
            JToken totalresult = totalObject["result"];

            string totalDeaths = totalresult["totalDeaths"].ToString();
            string totalCases = totalresult["totalCases"].ToString();
            string totalRecovered = totalresult["totalRecovered"].ToString();

            ViewBag.totalDeaths = totalDeaths;
            ViewBag.totalCases = totalCases;
            ViewBag.totalRecovered = totalRecovered;

            var countrysObject = JObject.Parse(response.Content);
            string countrysresult = countrysObject["result"].ToString();
            List<CoronaGeneral> GeneralResult = JsonConvert.DeserializeObject<List<CoronaGeneral>>(countrysresult);
            List<CoronaGeneral> WorldGeneralResult = GeneralResult.Take(8).ToList();
            WorldGeneralResult[6].country = "Antartika";
            GeneralResult.RemoveRange(0, 8);
            WorldGeneralResult = WorldGeneralResult.Concat(GeneralResult).ToList();
            return View(WorldGeneralResult);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
