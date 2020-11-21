using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sport_News_Portal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(ReadRSSFeedMVC.Models.RssReader.GetRssFeed("https://bongda24h.vn/RSS/279.rss"));
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

    }
}