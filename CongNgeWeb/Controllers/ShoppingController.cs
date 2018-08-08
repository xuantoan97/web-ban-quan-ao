using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CongNgeWeb.Entities;
using CongNgeWeb.Models;
namespace CongNgeWeb.Controllers
{
    public class ShoppingController : Controller
    {
        //
        // GET: /Shopping/
        MyClassDBContext db;
        public ShoppingController()
        {
            db = new MyClassDBContext();
        }
        public ActionResult Index()
        {
            GioHangHoa gio = (GioHangHoa)Session["cart"];
            if (gio == null)
            {
                return View("null");
            }
          
                DataTable dt = new DataTable();
                dt = gio.returnTable();
                ViewBag.tongtien = gio.getTongTien();
                ViewBag.count = gio.getSL();
                return View(dt.Rows);
           
        }
        
         public ActionResult Add(string MASP)
        {
            SanPham sp = db.SanPhams.Find(MASP);
            GioHangHoa gio = (GioHangHoa)Session["cart"];
            if (gio == null)
            {
                gio = new GioHangHoa();
   
            }
            HangHoaBan hangHoa = new HangHoaBan(MASP, 1);
            hangHoa.name = sp.TENSP;
            hangHoa.price = sp.GIASP;
            hangHoa.link_anh = sp.LINK_ANH;
            gio.addHangHoa(hangHoa);
            Session["cart"] = gio;
            return Redirect("~/Shopping/Index");
        }
        
         public ActionResult delete(string id)
        {
             GioHangHoa gio =  (GioHangHoa)Session["cart"];
             gio.delete(id);
             Session["cart"] = gio;
             return Redirect("~/Shopping/Index");
         }
         public ActionResult SuaSoLuong(string id, int slm)
         {
             GioHangHoa gio = (GioHangHoa)Session["cart"];
             gio.SuaSoLuong(id, slm);
             Session["cart"] = gio;
             return Redirect("~/Shopping/Index");
         }
        
    }
}
