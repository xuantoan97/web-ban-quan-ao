using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CongNgeWeb.Entities;
using CongNgeWeb.Entities.ViewModel;
using CongNgeWeb.Dao;
using CongNgeWeb.Models;
namespace CongNgeWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int PageNum = 1, int PageSize = 16)
        {
            SanPhamDao dao = new SanPhamDao();
           
            GioHangHoa gio = (GioHangHoa)Session["cart"];
            if (gio !=null)
            {
                ViewBag.gia = gio.getTongTien();
            }
                return View("List", dao.ListSPPage(PageNum, PageSize));
            
           
        }
        public ActionResult detailSP(string MASP)
        {
            SanPhamDao dao = new SanPhamDao();
            BINHLUANDao dao1 = new BINHLUANDao();
            SanPham sp = dao.detail(MASP);
            IQueryable<BINHLUAN> bl = dao1.ListBL(MASP);
            var slbl = dao1.SLBL(MASP);
            ViewBag.SLBL = slbl;
            CMTofSP cmt = new CMTofSP()
            {
                  SanPham=sp,
                  listBL=bl
             };
            return View(cmt);
        }
 
        public ActionResult AddBL(string MASP, string COMMENT)
        {
            if (Session["UserName"] != null)
            
            {
                string email = Convert.ToString(Session["UserName"]);
                var ngay = DateTime.Now.Date;
                BINHLUANDao dao = new BINHLUANDao();
                BINHLUAN bl = new BINHLUAN();
                bl.MASP = MASP;
                bl.NGAYCM = ngay;
                bl.EMAIL = email;
                bl.COMMENT = COMMENT;
                if (ModelState.IsValid)
                {

                    dao.AddBL(bl);
                }
            }
            return Redirect("detailSP?MASP="+MASP+"");
        }

        
       
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
