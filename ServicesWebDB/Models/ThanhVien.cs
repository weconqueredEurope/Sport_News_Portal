namespace ServicesWebDB.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThanhVien")]
    public partial class ThanhVien 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThanhVien()
        {
            BinhLuans = new HashSet<BinhLuan>();
        }

        public int id { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Password { get; set; }

        public string Ho { get; set; }

        public string Ten { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }
    }
}
