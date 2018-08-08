using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CongNgeWeb.Entities;
using PagedList;
namespace CongNgeWeb.Dao
{
    public class CHITIETDONHANGDao
    {
        MyClassDBContext db;
        public CHITIETDONHANGDao()
        {
            db = new MyClassDBContext();
        }
        public List<HangHoaBan> listHangHoa = new List<HangHoaBan>();
        public void add(List<HangHoaBan> list,long ID)
        {
            foreach (HangHoaBan hh in list)
            {
                if (hh != null)
                {
                    CHITIETDONHANG ctdh = new CHITIETDONHANG();
                    ctdh.IDDONHANG = ID;
                    ctdh.MASP = hh.id;
                    ctdh.SOLUONG = hh.sl;
                    db.CHITIETDONHANGs.Add(ctdh);
                    db.SaveChanges();
                }
            }
            
        }
        public IEnumerable<HangHoaBan> listCTDH(long ID)
        {
            
            List<CHITIETDONHANG> list = db.CHITIETDONHANGs.Where(x => x.IDDONHANG == ID).ToList();
            foreach (CHITIETDONHANG ctdh in list)
            {
                HangHoaBan hhb = new HangHoaBan(ctdh.MASP,ctdh.SOLUONG);
                SanPham sp = db.SanPhams.Find(ctdh.MASP);
                hhb.name = sp.TENSP;
                hhb.link_anh = sp.LINK_ANH;
                hhb.price = sp.GIASP;
                listHangHoa.Add(hhb);
            }
            return listHangHoa;
        }
        public int TSLSP(DateTime ngay)
        {
            var res = (from s in db.CHITIETDONHANGs
                       join d in db.DONHANGs
                       on s.IDDONHANG equals d.ID
                       where d.TDTDH == ngay
                       select s.SOLUONG).Sum();
            return res;
        }
        public void deleteCTDH(long ID)
        {
            List<CHITIETDONHANG> listCTDH = db.CHITIETDONHANGs.Where(x => x.IDDONHANG == ID).ToList();
            foreach (CHITIETDONHANG cthh in listCTDH)
            {
                db.CHITIETDONHANGs.Remove(cthh);
                db.SaveChanges();
            }
        }
    }
}