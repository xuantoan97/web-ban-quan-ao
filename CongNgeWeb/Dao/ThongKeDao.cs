using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CongNgeWeb.Entities;
using PagedList;
namespace CongNgeWeb.Dao
{
    public class ThongKeDao
    {
        MyClassDBContext db;
        public ThongKeDao()
        {
            db =new MyClassDBContext();
        }
        public List<ThongKe> ListTK = new List<ThongKe>();
        public void Tao()
        {
           DONHANGDao dao = new DONHANGDao();
           CHITIETDONHANGDao dao1 = new CHITIETDONHANGDao();
            List<DONHANG> listDH = db.DONHANGs.ToList();
            foreach (DONHANG i in listDH)
            {
                var res = ListTK.Count(x => x.Ngay == i.TDTDH);
                if (res == 0)
                {
                    ThongKe tk = new ThongKe();
                    tk.Ngay = i.TDTDH;
                    tk.TongTienTrongNgay = dao.TTTN(i.TDTDH);
                    tk.TongSLSanPham = dao1.TSLSP(i.TDTDH);
                    tk.SLDH = dao.TDH(i.TDTDH);
                    ListTK.Add(tk);
                }
            }
        }
        public DataTable returnTable()
        {

            DataTable tbl = new DataTable();
            tbl.Columns.Add("Ngày");
            tbl.Columns.Add("Tổng Số Đơn Hàng");
            tbl.Columns.Add("Tổng Số Lượng Sản Phẩm");
            tbl.Columns.Add("Tổng Doanh Thu");
          

            foreach (ThongKe i in ListTK)
            {
                DataRow dr = tbl.NewRow();
                dr["Ngày"] = i.Ngay;
                dr["Tổng Số Đơn Hàng"] = i.SLDH;
                dr["Tổng Số Lượng Sản Phẩm"] = i.TongSLSanPham;
                dr["Tổng Doanh Thu"] = i.TongTienTrongNgay;
                tbl.Rows.Add(dr);
            }
            return tbl; ;
        }
       
    }
}
