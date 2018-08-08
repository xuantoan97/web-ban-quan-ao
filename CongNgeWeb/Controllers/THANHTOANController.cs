using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CongNgeWeb.Entities;
using CongNgeWeb.Dao;
namespace CongNgeWeb.Controllers
{
    public class THANHTOANController : Controller
    {
        //
        // GET: /THANHTOAN/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add1(string email)
        {
            var e = DateTime.Now.Date;
            UserDao dao1 = new UserDao();
            THANHVIEN tv = dao1.detailuser(email);

            GioHangHoa gio = (GioHangHoa)Session["cart"];
            List<HangHoaBan> list = gio.listHangHoa.ToList();
            decimal tongtien = gio.getTongTien();
           
            DONHANG dh = new DONHANG();
            DONHANGDao dao = new DONHANGDao();

            CHITIETDONHANG ctdh = new CHITIETDONHANG();
            CHITIETDONHANGDao dao2 = new CHITIETDONHANGDao();

            if (tongtien > 0)
            {
                if (tv != null)
                {
                    dh.IDTHANHVIEN = tv.ID;
                    dh.TENKH = tv.TENTV;
                    dh.SDTKH = tv.SDT;
                    dh.DCKH = tv.DIACHI;
                    dh.TRANGTHAI = "Chưa Giao Hàng";
                    dh.TDTDH = e;
                    dh.TONGTIEN = tongtien;
                    dao.add1(dh);
                    dao2.add(list, dh.ID);
                    gio.deleteall(list);
                    Session["cart"] = gio;
                    return View("done");
                }
            }
            return Redirect("~/Shopping/Index");
    
        }
        public ActionResult Add2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add2(string TENKH, int SDTKH, string DCKH)
        {
            var e = DateTime.Now.Date;
           

            GioHangHoa gio = (GioHangHoa)Session["cart"];
            List<HangHoaBan> list = gio.listHangHoa.ToList();
            decimal tongtien = gio.getTongTien();

            DONHANG dh = new DONHANG();
            DONHANGDao dao = new DONHANGDao();

            CHITIETDONHANG ctdh = new CHITIETDONHANG();
            CHITIETDONHANGDao dao2 = new CHITIETDONHANGDao();
            if (tongtien > 0)
            {
                if (ModelState.IsValid)
                {
                    dh.TENKH = TENKH;
                    dh.SDTKH = SDTKH;
                    dh.DCKH = DCKH;
                    dh.TDTDH = e;
                    dh.TRANGTHAI = "Chưa Giao Hàng";
                    dh.TONGTIEN = tongtien;
                    dao.add1(dh);
                    dao2.add(list, dh.ID);
                    gio.deleteall(list);
                    Session["cart"] = gio;
                    return View("done");
                }
                else
                    return View("Add2");
            }
            else return Redirect("~/Shopping/Index");
        }
    }


}
