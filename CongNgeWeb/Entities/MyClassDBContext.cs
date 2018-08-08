namespace CongNgeWeb.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyClassDBContext : DbContext
    {
        public MyClassDBContext()
            : base("name=MyClassDBContext")
        {
        }
        
        public virtual DbSet<CHITIETDONHANG> CHITIETDONHANGs { get; set; }
        public virtual DbSet<DONHANG> DONHANGs { get; set; }

        public virtual DbSet<THANHVIEN> THANHVIENs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<BINHLUAN> BINHLUANs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.MASP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.TENKH)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .HasMany(e => e.CHITIETDONHANGs)
                .WithRequired(e => e.DONHANG)
                .HasForeignKey(e => e.IDDONHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THANHVIEN>()
                .Property(e => e.TENTV)
                .IsUnicode(false);

            modelBuilder.Entity<THANHVIEN>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<THANHVIEN>()
                .Property(e => e.DIACHI)
                .IsUnicode(false);

            modelBuilder.Entity<THANHVIEN>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<THANHVIEN>()
                .HasMany(e => e.DONHANGs)
                .WithOptional(e => e.THANHVIEN)
                .HasForeignKey(e => e.IDTHANHVIEN);
            modelBuilder.Entity<DONHANG>().Property(p => p.IDTHANHVIEN).IsOptional();
            modelBuilder.Entity<SanPham>()
                .Property(e => e.MASP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.GIASP)
                .HasPrecision(15, 2);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.LINK_ANH)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MADM)
                .IsFixedLength()
                .IsUnicode(false);
          
        }
    }
}
