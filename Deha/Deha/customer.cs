namespace Deha
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer()
        {
            invoices = new HashSet<invoice>();
            receiveds = new HashSet<received>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(10)]
        public string countryCode { get; set; }

        [Required]
        [StringLength(50)]
        public string gsm { get; set; }

        public int ref_areas { get; set; }

        [Required]
        [StringLength(250)]
        public string adress { get; set; }

        [StringLength(50)]
        public string coordinat { get; set; }

        [Column(TypeName = "money")]
        public decimal? balance { get; set; }

        public bool active { get; set; }

        public int? ref_user { get; set; }

        public DateTime? ref_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<invoice> invoices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<received> receiveds { get; set; }
    }
}
