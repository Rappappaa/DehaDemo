namespace Deha
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("company")]
    public partial class company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public company()
        {
            receiveds = new HashSet<received>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [StringLength(250)]
        public string description { get; set; }

        public int? ref_sms_users { get; set; }

        public int? ref_upon_receipt { get; set; }

        public int? ref_new_order_sms { get; set; }

        public int? ref_when_delivered { get; set; }

        public int? send_upon_receipt { get; set; }

        public int? send_new_order_sms { get; set; }

        public int? send_when_delivered { get; set; }

        [Required]
        [StringLength(50)]
        public string color { get; set; }

        public bool active { get; set; }

        public int ref_user { get; set; }

        public DateTime ref_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<received> receiveds { get; set; }
    }
}
