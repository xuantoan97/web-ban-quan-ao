using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
namespace CongNgeWeb.Entities
{
    public class GioHangHoa
    {
        public List<HangHoaBan> listHangHoa = new List<HangHoaBan>();
        public GioHangHoa()
        {
            //
            // TODO: Add constructor logic here
            //
        }
     
        public void addHangHoa(HangHoaBan tmp)
        {
            bool co = false;
            foreach (HangHoaBan i in listHangHoa)
                if (i.id == tmp.id) //Already exists
                {
                    i.sl += tmp.sl;
                    co = true;
                    break;
                }
            if (!co)
                listHangHoa.Add(tmp);
        }

        public void updateHangHoa(HangHoaBan tmp)
        {
            foreach (HangHoaBan i in listHangHoa)
                if (i.id == tmp.id)
                {
                    i.sl = tmp.sl;
                    if (tmp.sl == 0)
                        listHangHoa.Remove(tmp);
                    return;
                }
        }
        
        public void delete(string id)
        {
            foreach(HangHoaBan hh in listHangHoa)
                if(hh.id==id)
                {
                listHangHoa.Remove(hh);
                return;
                }
        }
        public void deleteall(List<HangHoaBan> list)
        {
            foreach (HangHoaBan hh in list)
            {
                listHangHoa.Remove(hh);
            }
        }
            public void SuaSoLuong(string id,int slm)
            {
                foreach (HangHoaBan hh in listHangHoa)
                    if (hh.id == id)
                    {
                        hh.sl = slm;
                        return;
                    }
            }
        

        public int getSL()
        {
            int sll = 0;
            foreach (HangHoaBan i in listHangHoa)
                sll += i.sl;
            return sll;

        }
       public decimal getTongTien()
        {
            decimal tong = 0;
            foreach (HangHoaBan i in listHangHoa)
                tong += i.sl * i.price;
            return tong;
        }

        public DataTable returnTable()
        {

            DataTable tbl = new DataTable();
            tbl.Columns.Add("ID");
            tbl.Columns.Add("Hình Ảnh");
            tbl.Columns.Add("Tên");
            tbl.Columns.Add("Giá");
            tbl.Columns.Add("Số Lượng");
            tbl.Columns.Add("Thành Tiền");

            foreach (HangHoaBan i in listHangHoa)
            {
                DataRow dr = tbl.NewRow();
                dr["Hình Ảnh"] = i.link_anh;
                dr["ID"] = i.id;
                dr["Tên"] = i.name;
                dr["Giá"] = i.price;
                dr["Số Lượng"] = i.sl;
                dr["Thành Tiền"] = (i.sl) *(i.price);
                tbl.Rows.Add(dr);
            }
            return tbl;
        }
    }
}