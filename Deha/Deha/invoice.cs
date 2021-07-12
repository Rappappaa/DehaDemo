namespace Deha
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("invoice")]
    public partial class invoice
    {
        public int id { get; set; }

        public int? ref_customer { get; set; }

        public int? ref_orders { get; set; }

        [Column(TypeName = "money")]
        public decimal total { get; set; }

        [Column(TypeName = "money")]
        public decimal? collect { get; set; }

        public int? type { get; set; }

        public int? payment_type { get; set; }

        [StringLength(500)]
        public string note { get; set; }

        public int? ref_user { get; set; }

        public DateTime? ref_date { get; set; }

        public virtual customer customer { get; set; }

        public virtual user user { get; set; }
    }
}
