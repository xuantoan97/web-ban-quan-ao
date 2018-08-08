
    namespace CongNgeWeb.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
        [Table("BINHLUAN")]
    public partial class BINHLUAN 
    {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key]
        public long ID { get; set; }
        
            [StringLength(10)]
        public string MASP { get; set; }
            
        public DateTime NGAYCM { get; set; }

            [StringLength(500)]
            [Required(ErrorMessage="Hãy nhập bình luận!")]
        public string COMMENT
        {
            get;
            set;
        }

            [StringLength(50)]
            public string EMAIL { get; set; }


    }
}
