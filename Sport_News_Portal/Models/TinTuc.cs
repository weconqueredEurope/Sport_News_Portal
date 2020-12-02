namespace Sport_News_Portal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TinTuc()
        {
            BinhLuans = new HashSet<BinhLuan>();
        }

        public int id { get; set; }

        public int? idCM { get; set; }

        public int? id_User { get; set; }

        public string TieuDe { get; set; }

        public string MoTa { get; set; }

        public string NoiDung { get; set; }

        [StringLength(50)]
        public string TacGia { get; set; }

        public string Thumbnails { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDang { get; set; }

        public int? Numread { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        public virtual ChuyenMuc ChuyenMuc { get; set; }

        public virtual CongTacVien CongTacVien { get; set; }
    }
}
