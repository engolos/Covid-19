using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Covid_19.Models;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace Covid_19.Controllers
{
    public class DataController : Controller
    {
        private AppDbContext _context;
        public DataController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<string> userList = _context.TweetDataTable.Select(q => q.username).Distinct().ToList();
            List<WordCloud> wordClouds = new List<WordCloud>();
            foreach (var user in userList)
            {
                WordCloud cloud = new WordCloud();
                cloud.user = user;
                cloud.text = "";
                List<string> texts = _context.TweetDataTable.Where(q => q.username == user).Select(q => q.tweet).ToList();
                foreach (var item in texts)
                {
                    string text = item.Replace(" veya","").Replace(" bu", "").Replace(" ve", "").Replace(" için","").Replace(" ile", "").Replace(" de", "").Replace(" da", "");
                    cloud.text += text;
                }
                wordClouds.Add(cloud);
            }
            ViewBag.DListCloud = new SelectList(wordClouds, "text", "user");
            return View();
        }
    }
}