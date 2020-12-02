namespace ServicesWebDB.models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SportModel : DbContext
    {
        public SportModel()
            : base("name=SportModel")
        {
        }

        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<ChuyenMuc> ChuyenMucs { get; set; }
        public virtual DbSet<CongTacVien> CongTacViens { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<ThanhVien> ThanhViens { get; set; }
        public virtual DbSet<ThongKe> ThongKes { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChuyenMuc>()
                .HasMany(e => e.TinTucs)
                .WithOptional(e => e.ChuyenMuc)
                .HasForeignKey(e => e.idCM);

            modelBuilder.Entity<CongTacVien>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<CongTacVien>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<CongTacVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<CongTacVien>()
                .HasMany(e => e.BinhLuans)
                .WithOptional(e => e.CongTacVien)
                .HasForeignKey(e => e.id_CTV);

            modelBuilder.Entity<CongTacVien>()
                .HasMany(e => e.TinTucs)
                .WithOptional(e => e.CongTacVien)
                .HasForeignKey(e => e.id_User);

            modelBuilder.Entity<PhanQuyen>()
                .HasMany(e => e.CongTacViens)
                .WithOptional(e => e.PhanQuyen)
                .HasForeignKey(e => e.Roles_id);

            modelBuilder.Entity<ThanhVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ThanhVien>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<ThanhVien>()
                .HasMany(e => e.BinhLuans)
                .WithOptional(e => e.ThanhVien)
                .HasForeignKey(e => e.id_TV);

            modelBuilder.Entity<TinTuc>()
                .HasMany(e => e.BinhLuans)
                .WithOptional(e => e.TinTuc)
                .HasForeignKey(e => e.id_TT);
        }
    }
}
