namespace Deha
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("haliposmain")]
    public partial class haliposmain
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string businesscode { get; set; }

        [Required]
        [StringLength(250)]
        public string url { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }

        [Required]
        [StringLength(50)]
        public string business_phone { get; set; }

        [Required]
        [StringLength(50)]
        public string business_mail { get; set; }

        [Required]
        [StringLength(50)]
        public string business_owner { get; set; }

        public string description { get; set; }

        public bool? active { get; set; }

        [StringLength(150)]
        public string dbname { get; set; }
    }
}
