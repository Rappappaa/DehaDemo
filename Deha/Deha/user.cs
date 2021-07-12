namespace Deha
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            invoices = new HashSet<invoice>();
            receiveds = new HashSet<received>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        public string fullname { get; set; }

        public int? ref_vehicle { get; set; }

        public bool admin { get; set; }

        public bool auth_direct_sale { get; set; }

        public bool auth_order { get; set; }

        public bool auth_customer_change { get; set; }

        public bool auth_expense_add { get; set; }

        public bool auth_report { get; set; }

        public bool auth_product { get; set; }

        public bool auth_vehicle { get; set; }

        public bool auth_area { get; set; }

        public bool auth_settings { get; set; }

        public bool auth_company { get; set; }

        public bool auth_collective_sms { get; set; }

        public bool auth_sms_user { get; set; }

        public bool auth_all_vehicle { get; set; }

        public bool active { get; set; }

        public DateTime? ref_date { get; set; }

        public int? ref_printnormal { get; set; }

        public int? ref_printtag { get; set; }

        public bool? auth_offline_mode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<invoice> invoices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<received> receiveds { get; set; }
    }
}
