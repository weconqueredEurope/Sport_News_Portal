namespace ServicesWebDB.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongTacVien")]
    public partial class CongTacVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CongTacVien()
        {
            BinhLuans = new HashSet<BinhLuan>();
            TinTucs = new HashSet<TinTuc>();
        }

        public int id { get; set; }

        [StringLength(150)]
        public string Username { get; set; }

        public string Password { get; set; }

        public int? Roles_id { get; set; }

        [StringLength(150)]
        public string Ho { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        public virtual PhanQuyen PhanQuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TinTuc> TinTucs { get; set; }
    }
}
