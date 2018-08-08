using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CongNgeWeb.Entities
{
    public class ThongKe
    {
        public DateTime Ngay { get; set; }

        public decimal TongTienTrongNgay { get; set; }

        public int TongSLSanPham { get; set;}

        public int SLDH { get; set; }
    }
}
