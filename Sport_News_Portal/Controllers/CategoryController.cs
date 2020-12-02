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
        SportsModel db = new SportsModel();
        // GET: Category
        public ActionResult TTVN()
        {
            var model = db.TinTucs.ToList().Where(x => x.idCM == 1);
            ViewBag.RSS = RssReader.GetRssFeed("https://bongda24h.vn/RSS/168.rss");
            return View(model);
        }
        public ActionResult C1()
        {
            var model = db.TinTucs.ToList().Where(x => x.idCM == 2);
            ViewBag.RSS = RssReader.GetRssFeed("https://bongda24h.vn/RSS/488.rss");
            return View(model);
        }
        public ActionResult BDAnh()
        {
            var model = db.TinTucs.ToList().Where(x => x.idCM == 3);
            ViewBag.RSS = RssReader.GetRssFeed("https://bongda24h.vn/RSS/172.rss");
            return View(model);
        }
        public ActionResult BDDuc()
        {
            var model = db.TinTucs.ToList().Where(x => x.idCM == 4);
            ViewBag.RSS = RssReader.GetRssFeed("https://bongda24h.vn/RSS/193.rss");
            return View(model);
        }
        public ActionResult BDTBN()
        {
            var model = db.TinTucs.ToList().Where(x => x.idCM == 5);
            ViewBag.RSS = RssReader.GetRssFeed("https://bongda24h.vn/RSS/180.rss");
            return View(model);
        }
        public ActionResult BDItalia()
        {
            var model = db.TinTucs.ToList().Where(x => x.idCM == 6);
            ViewBag.RSS = RssReader.GetRssFeed("https://bongda24h.vn/RSS/176.rss");
            return View(model);
        }
        public ActionResult Tennis()
        {
            var model = db.TinTucs.ToList().Where(x => x.idCM == 7);
            ViewBag.RSS = RssReader.GetRssFeed2("https://thethao247.vn/quan-vot-tennis-c4.rss");
            return View(model);
        }
        public ActionResult DuaXe()
        {
            var model = db.TinTucs.ToList().Where(x => x.idCM == 8);
            ViewBag.RSS = RssReader.GetRssFeed2("https://thethao247.vn/dua-xe-c96.rss");
            return View(model);
        }
        public ActionResult CauLong()
        {
            var model = db.TinTucs.ToList().Where(x => x.idCM == 9);
            ViewBag.RSS = RssReader.GetRssFeed2("https://thethao247.vn/cau-long-c44.rss");
            return View(model);
        }
    }
}