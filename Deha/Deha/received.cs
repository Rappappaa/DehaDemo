namespace Deha
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("received")]
    public partial class received
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public received()
        {
            orders = new HashSet<order>();
        }

        public int id { get; set; }

        public DateTime purchase_date { get; set; }

        public DateTime received_date { get; set; }

        public int ref_customer { get; set; }

        public bool status { get; set; }

        public bool? active { get; set; }

        [StringLength(250)]
        public string note { get; set; }

        public int? ref_vehicle { get; set; }

        public int? ref_company { get; set; }

        [StringLength(250)]
        public string ranking { get; set; }

        public int ref_user { get; set; }

        public DateTime? ref_date { get; set; }

        public DateTime? mod_date { get; set; }

        public virtual company company { get; set; }

        public virtual customer customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }

        public virtual user user { get; set; }

        public virtual vehicle vehicle { get; set; }
    }
}
