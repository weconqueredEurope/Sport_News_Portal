namespace Sport_News_Portal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongKe")]
    public partial class ThongKe
    {
        public int id { get; set; }

        public DateTime? Times { get; set; }

        public long? NumVisit { get; set; }
    }
}
