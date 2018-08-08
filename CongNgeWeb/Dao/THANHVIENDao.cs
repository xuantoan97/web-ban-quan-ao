using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CongNgeWeb.Entities;
using PagedList;
namespace CongNgeWeb.Dao
{

    public class THANHVIENDao
    {
        MyClassDBContext db;
        public THANHVIENDao()
        {
            db = new MyClassDBContext();
        }
        public  IQueryable<THANHVIEN>  listtv()
        {
            var res = (from s in db.THANHVIENs orderby s.NGAYDK descending select s);
            return res;
        }
        public int DeleteTV(int ID)
        {
            THANHVIEN tv = db.THANHVIENs.Find(ID);
            if (tv != null)
            {
                db.THANHVIENs.Remove(tv);
                return db.SaveChanges();
            }
            else return -1;
        }
        public THANHVIEN DetailTV(int ID)
        {
            var res = db.THANHVIENs.Find(ID);
            return res;
        }
        public IEnumerable<THANHVIEN> ListTVPage(int Pagenum, int PageSize)
        {

            return db.THANHVIENs.OrderByDescending(a => a.NGAYDK).ToPagedList(Pagenum, PageSize);
        }

    }
}
