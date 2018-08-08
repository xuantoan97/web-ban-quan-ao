using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CongNgeWeb.Entities;
namespace CongNgeWeb.Entities.ViewModel
{
    public class DHofTV
    {
        public THANHVIEN THANHVIEN { get; set; }
        public IQueryable<DONHANG> ListDH { get; set;}
    }
}