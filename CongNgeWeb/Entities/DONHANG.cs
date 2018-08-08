namespace CongNgeWeb.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONHANG")]
    public partial class DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONHANG()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
       
        public decimal TONGTIEN { get; set; }

        public int IDTHANHVIEN { get; set; }

        [StringLength(50)]
        public string TENKH { get; set; }

        public int SDTKH { get; set; }

        [StringLength(100)]
        public string DCKH { get; set; }

        public DateTime TDTDH { get; set;}

         [StringLength(15)]
        public string TRANGTHAI { get; set; }

         public virtual THANHVIEN THANHVIEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        
    }
}
