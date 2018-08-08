using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CongNgeWeb.Dao;
using CongNgeWeb.Entities;
using CongNgeWeb.Entities.ViewModel;
namespace CongNgeWeb.Controllers
{
    public class ADminController : Controller
    {
        //
        // GET: /ADmin/
        
       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult tv(int PageNum = 1, int PageSize = 16)
        {
            THANHVIENDao dao = new THANHVIENDao();
            return View(dao.ListTVPage(PageNum, PageSize));
        }
        public ActionResult sp(int PageNum = 1, int PageSize = 10)
        {
            SanPhamDao dao = new SanPhamDao();
            return View(dao.ListSPPage(PageNum, PageSize));
        }
        public ActionResult dh(int PageNum = 1, int PageSize = 16)
        {
            DONHANGDao dao = new DONHANGDao();
            return View(dao.ListDHPage(PageNum,PageSize));
        }
       /* public ActionResult sp()
        {
            SanPhamDao dao = new SanPhamDao();
            IQueryable<SanPham> ojb = dao.Listsp();
            return View(ojb);
        }
        public ActionResult tv()
        {
           THANHVIENDao dao = new THANHVIENDao();
            IQueryable<THANHVIEN> ojb = dao.listtv();
            return View(ojb);
        }*/
        public ActionResult add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult add(string MASP,string TENSP,decimal GIASP,string LINK_ANH,string MADM)
         {
            
             var e = DateTime.Now.Date;
        SanPham sp = new SanPham();
        sp.MASP = MASP;
        sp.TENSP = TENSP;
        sp.GIASP = GIASP;
        sp.LINK_ANH = LINK_ANH;
        sp.MADM = MADM;
        sp.TDT = e;
        if (ModelState.IsValid)
        {
            SanPhamDao dao = new SanPhamDao();
            dao.add(sp);
            return RedirectToAction("sp");
        }
        else
        {
            return View();
        }
        }
    
        public ActionResult delete(string MASP)
        {
            SanPhamDao dao = new SanPhamDao();
            dao.delete(MASP);
            return Redirect("~/ADmin/sp");
        }
        public ActionResult edit(string MASP)
        {
            SanPhamDao dao = new SanPhamDao();
            SanPham sp = new SanPham();
            sp = dao.getMASP(MASP);
            return View(sp);
        }
        [HttpPost]
        public ActionResult edit(string MASP, string TENSP, decimal GIASP, string LINK_ANH, string MADM, DateTime TDT)
        {
            SanPhamDao dao = new SanPhamDao();
            SanPham sp = new SanPham();
            sp = dao.getMASP(MASP);
            sp.TENSP = TENSP;
            sp.GIASP = GIASP;
            sp.LINK_ANH = LINK_ANH;
            sp.MADM = MADM;
            sp.TDT = TDT;
            if (ModelState.IsValid)
            {
                
                dao.edit(sp);
                return RedirectToAction("sp");
            }
            else
            {
                return View(sp);
            }
        }
        public ActionResult detail(string MASP)
        {
            SanPhamDao dao = new SanPhamDao();
            SanPham sp = dao.detail(MASP);
            return View(sp);
        }
        public ActionResult DeleteTV(int ID)
        {
            THANHVIENDao dao = new THANHVIENDao();
            dao.DeleteTV(ID);
            return RedirectToAction("tv");
        }
        public ActionResult DetailTV(int ID)
        {
            THANHVIENDao dao = new THANHVIENDao();
            DONHANGDao dao1 = new DONHANGDao();
            THANHVIEN tv = dao.DetailTV(ID);
            IQueryable<DONHANG> listDH = dao1.ListDH(ID);
            DHofTV d = new DHofTV()
            {
                THANHVIEN = tv,
                ListDH = listDH
            };
            return View(d);
        }
        public ActionResult editDH(long  ID)
        {

            return View();
        }
        [HttpPost]
        public ActionResult editDH(long ID,string TRANGTHAI)
        {
            DONHANGDao dao = new DONHANGDao();
            DONHANG dh = new DONHANG();
            dh = dao.getDH(ID);
            dh.TRANGTHAI = TRANGTHAI;
            if (ModelState.IsValid)
            {

                dao.editDH(dh);
                return RedirectToAction("dh");
            }
            else
            {
                return View();
            }
        }
        public ActionResult detailDH(long ID)
        {
            CHITIETDONHANGDao dao = new CHITIETDONHANGDao();
            IEnumerable<HangHoaBan> listCTDH = dao.listCTDH(ID);
            ViewBag.IDDONHANG = ID;
            return View(listCTDH);
        }
        public ActionResult deleteDH(long ID)
        {
            DONHANGDao dao = new DONHANGDao();
            CHITIETDONHANGDao dao1 = new CHITIETDONHANGDao();
            dao1.deleteCTDH(ID);
            dao.deleteDH(ID);
            return RedirectToAction("dh");
        }
    }
}
