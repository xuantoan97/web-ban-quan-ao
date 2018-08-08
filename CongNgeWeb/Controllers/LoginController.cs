using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CongNgeWeb.Dao;
using CongNgeWeb.Entities;
using CongNgeWeb.Models;
namespace CongNgeWeb.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult LoginAction(Account acc)
        {
            UserDao dao = new UserDao();
            int check = dao.Login(acc.EMAIL, acc.PASSWORD);
            if (check == 1)
            {
                Session["UserName"] = acc.EMAIL;
                return RedirectToAction("Index", "Home");
            }
            else if (check == 2)
            {
                Session["UserName"] = acc.EMAIL;
                return RedirectToAction("Index", "ADmin");
            }
            else
                return View("Login");
        }
        public ActionResult done()
        {
            return View();
        }
        public ActionResult logout()
         {
             Session["UserName"] = null;
             return Redirect("~/Home/Index"); 
         }
        public ActionResult detailuser(string email)
        {
            UserDao dao = new UserDao();
            THANHVIEN tv = dao.detailuser(email);
            return View(tv);
        }
        public ActionResult detailDHofUser(string email)
        {
            DONHANGDao dao = new DONHANGDao();
            IEnumerable<DONHANG> list = dao.ListDHofUser(email);
            return View(list);
        }
       
        public ActionResult add()
        {
            var test = DateTime.Now;
            ViewBag.test = test;
            return View();
        }
        [HttpPost]
        public ActionResult add(string TENTV,string EMAIL,string DIACHI,string PASSWORD,DateTime NG,string GT,int SDT)
    {
            var e =DateTime.Now.Date;
            UserDao dao = new UserDao();
        THANHVIEN tv = new THANHVIEN();
        tv = dao.getKH(EMAIL);
        if (tv == null)
        {
            tv.TENTV = TENTV;
            tv.EMAIL = EMAIL;
            tv.DIACHI = DIACHI;
            tv.PASSWORD = PASSWORD;
            tv.NG = NG;
            tv.GT = GT;
            tv.NGAYDK = e;
            tv.SDT = SDT;
            if (ModelState.IsValid)
            {

                dao.add(tv);
                return RedirectToAction("done");
            }
            else return View();
        }
        else
        {
            return View();
        }
    }
        public ActionResult edituser(int ID)
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult edituser(int ID,string TENTV, string EMAIL, string DIACHI, DateTime NG, string GT, int SDT)
        {
         
            THANHVIEN tv = new THANHVIEN();
            tv.ID = ID;
            tv.TENTV = TENTV;
            tv.EMAIL = EMAIL;
            tv.DIACHI = DIACHI;
            tv.NG = NG;
            tv.GT = GT;
            tv.SDT = SDT;
            if (ModelState.IsValid)
            {
                UserDao dao = new UserDao();
                dao.edituser(tv);
                return Redirect("~/Home/Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult detailCTDHofUser(long ID)
        {
            CHITIETDONHANGDao dao = new CHITIETDONHANGDao();
            IEnumerable<HangHoaBan> listCTDH = dao.listCTDH(ID);
            ViewBag.IDDONHANG = ID;
            return View(listCTDH);
        }
  }    
}
