using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CongNgeWeb.Entities;
namespace CongNgeWeb.Dao
{
    public class BINHLUANDao
    {
        MyClassDBContext db;
        public  BINHLUANDao()
        {
            db = new MyClassDBContext();
        }
        public IQueryable<BINHLUAN> ListBL(string MASP)
        {
          
          var   res = (from s in db.BINHLUANs where s.MASP == MASP orderby s.NGAYCM descending select s);
            return res;
        }
        public int SLBL(string MASP)
        {
            var res = (from s in db.BINHLUANs where s.MASP == MASP select s).Count();
            return res;
        }
        public void AddBL(BINHLUAN bl)
        {
            db.BINHLUANs.Add(bl);
            db.SaveChanges();
        }
    }
}