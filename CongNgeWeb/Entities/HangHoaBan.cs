using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CongNgeWeb.Entities
{
    public class HangHoaBan
    {
        
        public HangHoaBan(string id, int sl)
        {
             this.id = id;
             this.sl = sl;
        }

       

        

        public int sl
        {
            get;
            set;
        }
        public string id
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public decimal price
        {
            get;
            set;
        }
        public string link_anh { set; get; }
    }
}