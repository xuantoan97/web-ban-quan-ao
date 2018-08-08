using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CongNgeWeb.Entities;
using PagedList;
namespace CongNgeWeb.Dao
{
    public class DONHANGDao
    {
        MyClassDBContext db;
        public DONHANGDao()
        {
            db = new MyClassDBContext();
        }
        public void add1(DONHANG dh)
        {
            db.DONHANGs.Add(dh);
            db.SaveChanges();
        }
        public IEnumerable<DONHANG> ListDHPage(int Pagenum, int PageSize)
        {

            return db.DONHANGs.OrderByDescending(a => a.TDTDH).ToPagedList(Pagenum, PageSize);
        }
        public void editDH(DONHANG dh)
        {
            DONHANG DH = db.DONHANGs.Find(dh.ID);
            if (DH != null)
            {
                DH.ID = dh.ID;
                DH.IDTHANHVIEN = dh.IDTHANHVIEN;
                DH.SDTKH = dh.SDTKH;
                DH.TDTDH = dh.TDTDH;
                DH.TENKH = dh.TENKH;
                DH.TONGTIEN = dh.TONGTIEN;
                DH.TRANGTHAI = dh.TRANGTHAI;
                DH.DCKH = dh.DCKH;
                db.SaveChanges();
            }
        }
        public DONHANG getDH(long ID)
        {
            return db.DONHANGs.FirstOrDefault(x => x.ID == ID);
        }
        public IEnumerable<DONHANG> ListDHofUser(string email)
        {
            THANHVIEN tv = db.THANHVIENs.FirstOrDefault(x => x.EMAIL == email);
            return db.DONHANGs.Where(x => x.IDTHANHVIEN == tv.ID).ToList();
        }
        public decimal TTTN(DateTime ngay)
        {
            var res = (from s in db.DONHANGs
                       where s.TDTDH == ngay
                       select s.TONGTIEN).Sum();
            return res;
        }
        public int  TDH(DateTime ngay)
        {
            var res = (from s in db.DONHANGs
                       where s.TDTDH == ngay
                       select s.ID).Count();
            return res;
        }
        public IQueryable<DONHANG> ListDH(int ID)
        {
            var res = (from s in db.DONHANGs where s.IDTHANHVIEN == ID orderby s.TDTDH descending select s);
            return res;
        }
        public void deleteDH(long ID)
        {
            DONHANG dh = db.DONHANGs.Find(ID);
            db.DONHANGs.Remove(dh);
            db.SaveChanges();
        }
    }
}