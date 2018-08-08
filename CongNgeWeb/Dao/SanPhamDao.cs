using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CongNgeWeb.Entities;
using PagedList;
namespace CongNgeWeb.Dao
{
    public class SanPhamDao
    {
        MyClassDBContext db;
        public SanPhamDao()
        {
            db = new MyClassDBContext();
        }
        public IQueryable<SanPham> SanPhams
        {
            get { return db.SanPhams; }
        }
        public IQueryable<SanPham> Listsp()
        {
            var res = (from s in db.SanPhams
                       orderby s.TDT descending
                       select s
                       );
            return res;
        }
        public void add(SanPham sp)
        {
            SanPham test = db.SanPhams.Find(sp.MASP);
            if (test == null)
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
            }
            
        }
        public int delete(string MASP)
        {
            SanPham sp = db.SanPhams.Find(MASP);
            if (sp != null)
            {
                db.SanPhams.Remove(sp);
                return db.SaveChanges();
            }
            else return -1;
           
        }
        public void edit(SanPham sp)
        {
            SanPham sp1 = db.SanPhams.Find(sp.MASP);
            if (sp1 != null)
            {
                sp1.TENSP = sp.TENSP;
                sp1.GIASP = sp.GIASP;
                sp1.LINK_ANH = sp.LINK_ANH;
                sp1.MADM = sp.MADM;
                sp1.TDT = sp.TDT;
                db.SaveChanges();
            }
        }
        public SanPham detail(string MASP)
        {
            var res = db.SanPhams.Find(MASP);
            return res;
        }
        public SanPham getMASP(string MASP)
        {
            return db.SanPhams.FirstOrDefault(x => x.MASP == MASP);
        }
        public IEnumerable<SanPham> ListSPPage(int Pagenum, int PageSize)
        {

            return db.SanPhams.OrderByDescending(a => a.TDT).ToPagedList(Pagenum, PageSize);
        }
    }
}