using Sport_News_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sport_News_Portal.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult TTVN()
        {
            ViewBag.RSS = RssReader.GetRssFeed("https://bongda24h.vn/RSS/168.rss");
            return View();
        }
        public ActionResult C1()
        {
            ViewBag.RSS = RssReader.GetRssFeed("https://bongda24h.vn/RSS/488.rss");
            return View();
        }
        public ActionResult BDAnh()
        {
            ViewBag.RSS = RssReader.GetRssFeed("https://bongda24h.vn/RSS/172.rss");
            return View();
        }
        public ActionResult BDDuc()
        {
            ViewBag.RSS = RssReader.GetRssFeed("https://bongda24h.vn/RSS/193.rss");
            return View();
        }
        public ActionResult BDTBN()
        {
            ViewBag.RSS = RssReader.GetRssFeed("https://bongda24h.vn/RSS/180.rss");
            return View();
        }
        public ActionResult BDItalia()
        {
            ViewBag.RSS = RssReader.GetRssFeed("https://bongda24h.vn/RSS/176.rss");
            return View();
        }
        public ActionResult Tennis()
        {
            ViewBag.RSS = RssReader.GetRssFeed2("https://thethao247.vn/quan-vot-tennis-c4.rss");
            return View();
        }
        public ActionResult DuaXe()
        {
            ViewBag.RSS = RssReader.GetRssFeed2("https://thethao247.vn/dua-xe-c96.rss");
            return View();
        }
        public ActionResult CauLong()
        {
            ViewBag.RSS = RssReader.GetRssFeed2("https://thethao247.vn/cau-long-c44.rss");
            return View();
        }
    }
}