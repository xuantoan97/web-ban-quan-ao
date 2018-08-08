namespace CongNgeWeb.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THANHVIEN")]
    public partial class THANHVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THANHVIEN()
        {
            DONHANGs = new HashSet<DONHANG>();
        }
         [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] 
        
        public int ID { get; set; }

        [Required(ErrorMessage="Hãy nhập họ tên:")]
        [StringLength(50)]
        public string TENTV { get; set; }


         [Required(ErrorMessage = "Hãy nhập email:")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string EMAIL { get; set; }

         [Required(ErrorMessage = "Hãy nhập địa chỉ:")]
        [StringLength(100)]
        public string DIACHI { get; set; }

         [Required(ErrorMessage = "Hãy nhập mật khẩu:")]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string PASSWORD { get; set; }

         [Required(ErrorMessage = "Hãy nhập ngày sinh:")]
        public DateTime NG { get; set; }

         [Required(ErrorMessage = "Hãy nhập giới tính")]
        [StringLength(3)]
        public string GT { get; set; }

        public DateTime NGAYDK { get; set; }

        [DataType(DataType.PhoneNumber)]
          [Required(ErrorMessage = "Hãy nhập số điện thoại")]
        public int SDT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
    }
}
