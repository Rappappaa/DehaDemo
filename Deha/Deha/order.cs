namespace Deha
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order()
        {
            orders_detail = new HashSet<orders_detail>();
        }

        public int id { get; set; }

        public int? ref_received { get; set; }

        [Column(TypeName = "money")]
        public decimal total { get; set; }

        public int discount { get; set; }

        [Column(TypeName = "money")]
        public decimal amount { get; set; }

        public bool status { get; set; }

        public bool active { get; set; }

        public int type { get; set; }

        public bool? calculatedUsed { get; set; }

        public int? ranking { get; set; }

        public int ref_user { get; set; }

        public DateTime? ref_date { get; set; }

        public DateTime? mod_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orders_detail> orders_detail { get; set; }

        public virtual received received { get; set; }
    }
}
