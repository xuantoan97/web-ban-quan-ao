using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CongNgeWeb.Entities;
namespace CongNgeWeb.Dao
{
    
    public class UserDao
    {
        MyClassDBContext db;
        public UserDao()
        {
            db = new MyClassDBContext();
        }
        public int Login(string email, string password)
        {
            var res = db.THANHVIENs.Count(x => x.EMAIL == email && x.PASSWORD == password);
            var res2 = db.ADMINs.Count(x => x.USERNAME == email && x.PASSWORD == password);
            if (res > 0)
                return 1;
            else if(res2 > 0)
                return 2;
            else
                return 0;
        }
        public void add(THANHVIEN tv)
        {
            db.THANHVIENs.Add(tv);
            db.SaveChanges();
        }
        public THANHVIEN detailuser(string email)
        {
            return db.THANHVIENs.FirstOrDefault(x => x.EMAIL==email);
        }
        public void edituser(THANHVIEN tv)
        {
            THANHVIEN tv1 = db.THANHVIENs.Find(tv.ID);
            if (tv1 != null)
            {
                tv1.TENTV = tv.TENTV;
                tv1.DIACHI = tv.DIACHI;
                tv1.EMAIL = tv.EMAIL;
                tv1.SDT = tv.SDT;
                tv1.NG = tv.NG;
                tv1.GT = tv.GT;
                db.SaveChanges();
                return;
            }
        }
        public THANHVIEN getKH(string email)
        {
            THANHVIEN tv = db.THANHVIENs.Where(x => x.EMAIL == email).FirstOrDefault();
            return tv;
        }

    }
}
