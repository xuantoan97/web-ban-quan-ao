namespace CongNgeWeb.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        [Required(ErrorMessage = "Hãy nhập mã sản phẩm :")]
        public string MASP { get; set; }

       
        [Column(Order = 1)]
        [StringLength(100)]
        [Required(ErrorMessage = "Hãy nhập tên sản phẩm:")]
        public string TENSP { get; set; }

        
        [Column(Order = 2)]
        [Required(ErrorMessage = "Hãy nhập giá sản phẩm")]
        public decimal GIASP { get; set; }

       
        [Column(Order = 3)]
        [StringLength(100)]
        [Required(ErrorMessage = "Hãy nhập  link ảnh:")]
        public string LINK_ANH { get; set; }

        [Column(Order = 4)]
        [StringLength(10)]
        [Required(ErrorMessage = "Hãy nhập mã danh mục")]
        public string MADM { get; set; }

        [Column(Order = 5)]
        public DateTime TDT { get; set; }

        [Column(Order = 6)]
        public int SLDH { get; set; }

    
    }
}
