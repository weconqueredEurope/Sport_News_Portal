namespace ServicesWebDB.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        public int id { get; set; }

        public int? id_TT { get; set; }

        public string NoiDungBinhLuan { get; set; }

        public DateTime? NgayDangBL { get; set; }

        public int? id_CTV { get; set; }

        public int? id_TV { get; set; }

        public virtual CongTacVien CongTacVien { get; set; }

        public virtual TinTuc TinTuc { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }
    }
}
