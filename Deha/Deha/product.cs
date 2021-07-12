namespace Deha
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        public int id { get; set; }

        [Required]
        [StringLength(250)]
        public string name { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        public int type { get; set; }

        public bool active { get; set; }

        public int ref_user { get; set; }

        public DateTime? ref_date { get; set; }
    }
}
