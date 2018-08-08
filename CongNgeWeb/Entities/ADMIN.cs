namespace CongNgeWeb.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADMIN")]
    public partial class ADMIN
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }


        [Column(Order = 1)]
        [StringLength(30)]
        public string USERNAME { get; set; }


        [Column(Order = 2)]
        [StringLength(30)]
        public string PASSWORD { get; set; }


        [Column(Order = 3)]
        [StringLength(50)]
        public string NAME { get; set; }
    }
}
