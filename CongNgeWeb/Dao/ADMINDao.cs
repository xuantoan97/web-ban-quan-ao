using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CongNgeWeb.Entities;
namespace CongNgeWeb.Dao
{

    public class ADMINDao
    {
        MyClassDBContext db;
        public ADMINDao()
        {
            db = new MyClassDBContext();
        }
        public bool Login(string username, string password)
        {
            var res = db.ADMINs.Count(x => x.USERNAME == username && x.PASSWORD == password);
            if (res > 0)
                return true;
            else
                return false;
        }

    }
}