namespace CongNgeWeb.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETDONHANG")]
    public partial class CHITIETDONHANG
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public long IDDONHANG { get; set; }

        [StringLength(10)]
        public string MASP { get; set; }

        public int SOLUONG { get; set; }

        public virtual DONHANG DONHANG { get; set; }
    }
}
