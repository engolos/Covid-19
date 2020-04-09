using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Covid_19.Models;
using RestSharp;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System;

namespace Covid_19.Controllers
{
    public class CountryController : Controller
    {
        private AppDbContext _context;
        public CountryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string name)
        {
            if (name == null)
                return BadRequest();
            try
            {
                string url = "https://covid-19-coronavirus-statistics.p.rapidapi.com/v1/stats?country=" + name;
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("x-rapidapi-host", "covid-19-coronavirus-statistics.p.rapidapi.com");
                request.AddHeader("x-rapidapi-key", "{key}");
                IRestResponse response = client.Execute(request);

                var totalObject = JObject.Parse(response.Content);
                string result = totalObject["data"]["covid19Stats"].ToString();
                List<Country> CountryResult = JsonConvert.DeserializeObject<List<Country>>(result);
                return View(CountryResult);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
    }
}