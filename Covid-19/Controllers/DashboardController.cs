using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Covid_19.Models;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;

namespace Covid_19.Controllers
{
    public class DashboardController : Controller
    {
        private AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            DashboardModel dbm = new DashboardModel();
            List<ChartTotal> CT = new List<ChartTotal>();
            var client = new RestClient("https://covid19-data.p.rapidapi.com/all");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "covid19-data.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "{key}");
            IRestResponse response = client.Execute(request);
            string result = response.Content;
            List<map> CountryResult = JsonConvert.DeserializeObject<List<map>>(result);
            dbm.mapData = CountryResult;
            dbm.chartTotal = CT;

            List<DateTime> Dates = _context.ConfirmTable.Select(q=>q.Date).Distinct().ToList();
            Dates.Sort();

            ChartTotal World = GenerelInfo();
            World.Dates = Dates;
            CT.Add(World);

            ChartTotal TurkeyChart = CountryInfo("Turkey");
            TurkeyChart.Dates = Dates;
            CT.Add(TurkeyChart);

            ChartTotal ItalyChart = CountryInfo("Italy");
            ItalyChart.Dates = Dates;
            CT.Add(ItalyChart);

            ChartTotal USAChart = CountryInfo("US");
            USAChart.Dates = Dates;
            CT.Add(USAChart);

            List<string> Info = new List<string>();

            float WorldConfirmed = World.Confirmed.Last();
            float WorldRecovered = World.Recovered.Last();
            float WorldDeaths = World.Deaths.Last();

            Info.Add(String.Format(CultureInfo.InvariantCulture,"{0:#,#}", WorldConfirmed));
            Info.Add(String.Format(CultureInfo.InvariantCulture, "{0:#,#}", WorldRecovered));
            Info.Add(String.Format(CultureInfo.InvariantCulture, "{0:#,#}", WorldDeaths));

            float CountryRate = dbm.mapData.Count() * 100 / 206;
            float RecoveredRate = WorldRecovered * 100 / WorldConfirmed;
            float DeathRate = WorldDeaths * 100 / WorldConfirmed;

            ViewBag.TotalCountry = dbm.mapData.Count();
            Info.Add(CountryRate.ToString("0.#"));
            Info.Add(RecoveredRate.ToString("0.#"));
            Info.Add(DeathRate.ToString("0.#"));

            dbm.info = Info;

            return View(dbm);
        }
        public ChartTotal CountryInfo(string countryname)
        {
            ChartTotal Chart = new ChartTotal();

            Chart.Confirmed = (from n in _context.ConfirmTable
                               where n.Country == countryname
                               group n by n.Date into g
                               select g.Sum(q => q.TotalCase)).ToList();
            Chart.Deaths = (from n in _context.DeathTable
                            where n.Country == countryname
                            group n by n.Date into g
                            select g.Sum(q => q.Death)).ToList();
            Chart.Recovered = (from n in _context.RecoveredTable
                               where n.Country == countryname
                               group n by n.Date into g
                               select g.Sum(q => q.Recovered)).ToList();
            return Chart;
        }
        public ChartTotal GenerelInfo()
        {
            ChartTotal Chart = new ChartTotal();

            Chart.Confirmed = (from n in _context.ConfirmTable
                               group n by n.Date into g
                               select g.Sum(q => q.TotalCase)).ToList();
            Chart.Confirmed.Sort();
            Chart.Deaths = (from n in _context.DeathTable
                            group n by n.Date into g
                            select g.Sum(q => q.Death)).ToList();
            Chart.Deaths.Sort();
            Chart.Recovered = (from n in _context.RecoveredTable
                               group n by n.Date into g
                               select g.Sum(q => q.Recovered)).ToList();
            Chart.Recovered.Sort();
            return Chart;
        }
    }
}