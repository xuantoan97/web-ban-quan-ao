using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CongNgeWeb.Entities;
namespace CongNgeWeb.Entities.ViewModel
{
    public class CMTofSP
    {
        public SanPham SanPham { get; set;}
        public IQueryable<BINHLUAN> listBL { get; set;}
    

    
    }
}