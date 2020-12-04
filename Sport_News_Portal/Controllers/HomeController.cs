using PasswordSecurity;
using Sport_News_Portal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sport_News_Portal.Controllers
{
    public class HomeController : Controller
    {
        private SportsModel db = new SportsModel();
        public ActionResult Index()
        {
            var model = db.TinTucs.ToList();
            ViewBag.RSS = RssReader.GetRssFeed("https://bongda24h.vn/RSS/279.rss");
            return View(model);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var Tintuc = db.TinTucs.Find(id);
            ViewBag.TinTuc = Tintuc;
            var bl = new BinhLuan()
            {
                id_TT = Tintuc.id
            };
            return View("Details", bl);
        }
        //Search
        [HttpGet]
        public ActionResult Index(string search)
        {
            ViewBag.RSS = RssReader.GetRssFeed("https://bongda24h.vn/RSS/279.rss");
            DBServices.DBServicesSoapClient client = new DBServices.DBServicesSoapClient();
            int s = client.Search(search);
            if (s == 1) 
            {
                var result = ConvertToOBJ.Convert2(client.GetTT(search));
                return View("SearchResult", result);
            }
            else
            {
                return View(db.TinTucs.ToList());
            }
        }
        public ActionResult SearchResult()
        {
            return View();
        }
        //Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string pass)
        {
            DBServices.DBServicesSoapClient client = new DBServices.DBServicesSoapClient();
            int result = client.CheckLogin(email, pass);
            if (result == 1)
            {
                ThanhVien tv = ConvertToOBJ.Convert1(client.GetAccount(email));
                Session.Add("ThanhVien", tv);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (result == 2)
                {
                    CongTacVien ctv = ConvertToOBJ.Convert3(client.GetAccountCTV(email));
                    Session.Add("CTV", ctv);
                    return RedirectToAction("Index", "Home");
                }
                if (result == 0)
                {
                    @ViewBag.error = "Mật khẩu không hợp lệ";

                    return View("Login");
                }
                else
                {
                    @ViewBag.error = "Tài khoản không hợp lệ";

                    return View("Login");
                }
            }
            
        }
        //Log out
        public ActionResult Logout()
        {
            Session.Remove("ThanhVien");
            Session.Remove("CTV");
            return RedirectToAction("Index", "Home");
        }
        //Register
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "id,Email,Password,Ho,Ten,NgayDK")] ThanhVien thanhVien)
        {
            if (ModelState.IsValid)
            {
                thanhVien.Password = PasswordStorage.CreateHash(thanhVien.Password);
                db.ThanhViens.Add(thanhVien);
                thanhVien.NgayDK = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thanhVien);
        }
        [HttpPost]
        public ActionResult BinhLuans(BinhLuan bl)
        {
            ThanhVien tv = (ThanhVien)Session["ThanhVien"];
            CongTacVien ctv = (CongTacVien)Session["CTV"];
            if (tv != null) 
            {
                int idTV = tv.id;
                bl.NgayDangBL = DateTime.Now;
                bl.id_TV = idTV;
                db.BinhLuans.Add(bl);
                db.SaveChanges();
                return RedirectToAction("Details", "Home", new { @id = bl.id_TT });
            }
            if (ctv != null)
            {
                int idCTV = ctv.id;
                bl.NgayDangBL = DateTime.Now;
                bl.id_CTV = idCTV;
                db.BinhLuans.Add(bl);
                db.SaveChanges();
                return RedirectToAction("Details", "Home", new { @id = bl.id_TT });
            }
            return RedirectToAction("Details", "Home", new { @id = bl.id_TT });


        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}