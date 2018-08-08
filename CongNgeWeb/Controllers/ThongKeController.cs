using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CongNgeWeb.Models;
using CongNgeWeb.Dao;
using CongNgeWeb.Entities;
namespace CongNgeWeb.Controllers
{
    public class ThongKeController : Controller
    {
        //
        // GET: /ThongKe/

        public ActionResult Index()
        {
            ThongKeDao dao = new ThongKeDao();
            dao.Tao();
            DataTable dr = new DataTable();
            dr = dao.returnTable();
            return View(dr.Rows);
        }

    }
}
