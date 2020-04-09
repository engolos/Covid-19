using Covid_19.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System;
using Newtonsoft.Json;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace Covid_19.Controllers
{
    public class TweetsController : Controller
    {
        private AppDbContext _context;
        public TweetsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<string> userList = _context.TweetDataTable.Select(q => q.username).Distinct().ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in userList)
            {
                items.Add(new SelectListItem { Text = item, Value = item });
            }
            ViewBag.DUserList = items;
            return View();
        }
        [HttpPost]
        public IActionResult GetUserTweets(string user)
        {

            List<TweetDataTable> UserTweets = _context.TweetDataTable.Where(q => q.username == user).OrderByDescending(q => q.date).ToList();

            JArray vals = new JArray();
            if (UserTweets != null)
            {
                foreach (var item in UserTweets)
                {
                    JObject myobject = JObject.FromObject(new
                    {
                        Tweet = item.tweet,
                        Favorites = item.favorites,
                        Retweets = item.retweets,
                        Link = item.link,
                        Date = item.date.ToString("dd.MM.yyyy")
                    });
                    vals.Add(myobject);
                }
            }

            var jsondata = new
            {
                result = UserTweets
            };
            return Json(jsondata);
        }
    }
}