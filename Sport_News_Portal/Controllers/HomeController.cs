using PasswordSecurity;
using Sport_News_Portal.Models;
using System;
using System.Collections.Generic;
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
            ViewBag.RSS = RssReader.GetRssFeed("https://bongda24h.vn/RSS/279.rss");
            return View();
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
        //Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string pass)
        {
            ThanhVien tv = db.ThanhViens.SingleOrDefault(x => x.Email.Equals(email));
            if (tv != null)
            {
                bool result = PasswordStorage.VerifyPassword(pass, tv.Password);
                if (result)
                {
                    Session.Add("ThanhVien", tv);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    @ViewBag.error = "Mật khẩu không hợp lệ";

                    return View("Login");
                }
            }
            else
            {
                @ViewBag.error = "Tài khoản không hợp lệ";

                return View("Login");
            }
        }
        //Log out
        public ActionResult Logout()
        {
            Session.Remove("ThanhVien");
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
            int username = tv.id;
            bl.NgayDangBL = DateTime.Now;
            bl.id_TV = db.ThanhViens.Single(x => x.id.Equals(tv.id)).id;
            bl.id_CTV = 1;
            db.BinhLuans.Add(bl);
            db.SaveChanges();
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