namespace Deha
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class orders_detail
    {
        public int id { get; set; }

        public int ref_orders { get; set; }

        public double m2 { get; set; }

        public int product_number { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        public virtual order order { get; set; }
    }
}
